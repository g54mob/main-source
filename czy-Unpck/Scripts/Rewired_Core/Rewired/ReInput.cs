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
			private static ConfigHelper ilVQEiENSgAnwgRreWwIUWTqyneQ;

			private float COfpvBFgHNSUBfmMEeRbhbHJzwEE = 0.7f;

			private float nIUyhXXccVQEeYFxvBObISIAFWdb = 100f;

			internal static ConfigHelper Instance => ilVQEiENSgAnwgRreWwIUWTqyneQ ?? (ilVQEiENSgAnwgRreWwIUWTqyneQ = new ConfigHelper());

			public bool useXInput
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					if (UnityTools.platform == Platform.Windows && NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.XInput)
					{
						return true;
					}
					if (UnityTools.platform == Platform.WindowsUWP)
					{
						return (NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP).useGamepadAPI;
					}
					return NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.useXInput;
				}
				set
				{
					if (!CheckInitialized())
					{
						goto IL_000a;
					}
					goto IL_00a6;
					IL_000a:
					int num = 1413725554;
					goto IL_000f;
					IL_000f:
					while (true)
					{
						switch (num ^ 0x5443BD76)
						{
						case 3:
							break;
						default:
							return;
						case 4:
							return;
						case 5:
							oaHYsVKqotUxmLMRdTojIYzEOnG.ResetAll();
							num = 1413725559;
							continue;
						case 11:
							return;
						case 10:
							if (UnityTools.platform == Platform.Windows && NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.XInput)
							{
								windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.RawInput;
								Logger.Log("The primary input source has been changed to Raw Input.");
								return;
							}
							goto IL_00da;
						case 6:
							goto IL_00a6;
						case 2:
							goto IL_00da;
						case 8:
							goto IL_00fb;
						case 7:
							return;
						case 0:
							goto IL_012e;
						case 9:
							goto IL_0154;
						case 1:
							return;
						}
						break;
						IL_0154:
						NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.useXInput = value;
						int num2;
						if (value)
						{
							num = 1413725556;
							num2 = num;
						}
						else
						{
							num = 1413725564;
							num2 = num;
						}
						continue;
						IL_00da:
						int num3;
						if (!(oaHYsVKqotUxmLMRdTojIYzEOnG != null))
						{
							num = 1413725559;
							num3 = num;
						}
						else
						{
							num = 1413725555;
							num3 = num;
						}
					}
					goto IL_000a;
					IL_00fb:
					ConfigVars.PlatformVars_WindowsUWP platformVars_WindowsUWP = default(ConfigVars.PlatformVars_WindowsUWP);
					platformVars_WindowsUWP.useGamepadAPI = value;
					if (oaHYsVKqotUxmLMRdTojIYzEOnG != null)
					{
						oaHYsVKqotUxmLMRdTojIYzEOnG.ResetAll();
						num = 1413725553;
						goto IL_000f;
					}
					return;
					IL_00a6:
					if (UnityTools.platform == Platform.WindowsUWP)
					{
						platformVars_WindowsUWP = NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP;
						if (platformVars_WindowsUWP.useGamepadAPI == value)
						{
							return;
						}
						goto IL_00fb;
					}
					goto IL_012e;
					IL_012e:
					int num4;
					if (NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.useXInput != value)
					{
						num = 1413725567;
						num4 = num;
					}
					else
					{
						num = 1413725565;
						num4 = num;
					}
					goto IL_000f;
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
					return NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.updateLoop;
				}
				set
				{
					if (!CheckInitialized())
					{
						goto IL_0007;
					}
					goto IL_004a;
					IL_0007:
					int num = 61698213;
					goto IL_000c;
					IL_000c:
					switch (num ^ 0x3AD70A6)
					{
					case 5:
						break;
					default:
						return;
					case 3:
						return;
					case 4:
						goto IL_0039;
					case 2:
						goto IL_004a;
					case 1:
						goto IL_0064;
					case 0:
						return;
					}
					goto IL_0007;
					IL_004a:
					if (value == NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.updateLoop)
					{
						return;
					}
					goto IL_0039;
					IL_0039:
					if ((value & UpdateLoopSetting.Update) == 0)
					{
						value |= UpdateLoopSetting.Update;
						num = 61698215;
						goto IL_000c;
					}
					goto IL_0064;
					IL_0064:
					NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.updateLoop = value;
					if (oaHYsVKqotUxmLMRdTojIYzEOnG != null)
					{
						oaHYsVKqotUxmLMRdTojIYzEOnG.ResetAll();
						num = 61698214;
						goto IL_000c;
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
					return NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.windowsStandalonePrimaryInputSource;
				}
				set
				{
					if (!CheckInitialized())
					{
						goto IL_000a;
					}
					goto IL_00c0;
					IL_000a:
					int num = 1612092794;
					goto IL_000f;
					IL_000f:
					while (true)
					{
						switch (num ^ 0x60169578)
						{
						case 7:
							break;
						default:
							return;
						case 2:
							return;
						case 4:
							goto IL_0047;
						case 1:
							if (oaHYsVKqotUxmLMRdTojIYzEOnG != null)
							{
								oaHYsVKqotUxmLMRdTojIYzEOnG.ResetAll();
								num = 1612092792;
								continue;
							}
							return;
						case 5:
							goto IL_008e;
						case 6:
							NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.useXInput = true;
							num = 1612092793;
							continue;
						case 3:
							goto IL_00c0;
						case 0:
							return;
						}
						break;
						IL_008e:
						int num2;
						if (value != WindowsStandalonePrimaryInputSource.XInput)
						{
							num = 1612092793;
							num2 = num;
						}
						else
						{
							num = 1612092798;
							num2 = num;
						}
					}
					goto IL_000a;
					IL_00c0:
					if (NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.windowsStandalonePrimaryInputSource == value)
					{
						return;
					}
					goto IL_0047;
					IL_0047:
					NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.windowsStandalonePrimaryInputSource = value;
					int num3;
					if (UnityTools.platform == Platform.Windows)
					{
						num = 1612092797;
						num3 = num;
					}
					else
					{
						num = 1612092793;
						num3 = num;
					}
					goto IL_000f;
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
					return NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.osx_primaryInputSource;
				}
				set
				{
					if (!CheckInitialized())
					{
						return;
					}
					while (NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.osx_primaryInputSource != value)
					{
						while (true)
						{
							IL_0048:
							NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.osx_primaryInputSource = value;
							int num = 1458371816;
							while (true)
							{
								switch (num ^ 0x56ECFCEC)
								{
								case 3:
									num = 1458371822;
									continue;
								default:
									return;
								case 2:
									break;
								case 1:
									goto IL_0048;
								case 4:
									if (oaHYsVKqotUxmLMRdTojIYzEOnG != null)
									{
										oaHYsVKqotUxmLMRdTojIYzEOnG.ResetAll();
										num = 1458371820;
										continue;
									}
									return;
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

			public LinuxStandalonePrimaryInputSource linuxStandalonePrimaryInputSource
			{
				get
				{
					if (!CheckInitialized())
					{
						return LinuxStandalonePrimaryInputSource.Native;
					}
					return NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.linux_primaryInputSource;
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
						if (NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.linux_primaryInputSource != value)
						{
							num = 309782197;
							num2 = num;
						}
						else
						{
							num = 309782198;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ 0x1276E6B7)
							{
							case 0:
								num = 309782196;
								continue;
							default:
								return;
							case 4:
								if (oaHYsVKqotUxmLMRdTojIYzEOnG != null)
								{
									oaHYsVKqotUxmLMRdTojIYzEOnG.ResetAll();
									num = 309782194;
									continue;
								}
								return;
							case 2:
								NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.linux_primaryInputSource = value;
								num = 309782195;
								continue;
							case 1:
								return;
							case 3:
								break;
							case 5:
								return;
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
					return NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.windowsUWP_primaryInputSource;
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
						if (NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.windowsUWP_primaryInputSource != value)
						{
							num = 627293967;
							num2 = num;
						}
						else
						{
							num = 627293962;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ 0x2563BF0B)
							{
							case 0:
								num = 627293960;
								continue;
							default:
								return;
							case 3:
								break;
							case 1:
								return;
							case 4:
								NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.windowsUWP_primaryInputSource = value;
								if (oaHYsVKqotUxmLMRdTojIYzEOnG != null)
								{
									oaHYsVKqotUxmLMRdTojIYzEOnG.ResetAll();
									num = 627293961;
									continue;
								}
								return;
							case 2:
								return;
							}
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
					ConfigVars.PlatformVars_WindowsUWP platformVars_WindowsUWP = NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP;
					return platformVars_WindowsUWP.useHIDAPI;
				}
				set
				{
					if (!CheckInitialized())
					{
						goto IL_0007;
					}
					goto IL_0039;
					IL_0007:
					int num = 322718108;
					goto IL_000c;
					IL_000c:
					ConfigVars.PlatformVars_WindowsUWP platformVars_WindowsUWP = default(ConfigVars.PlatformVars_WindowsUWP);
					while (true)
					{
						switch (num ^ 0x133C4999)
						{
						case 2:
							break;
						default:
							return;
						case 5:
							return;
						case 0:
							goto IL_0039;
						case 3:
							if (platformVars_WindowsUWP.useHIDAPI == value)
							{
								return;
							}
							goto case 4;
						case 4:
							platformVars_WindowsUWP.useHIDAPI = value;
							if (oaHYsVKqotUxmLMRdTojIYzEOnG != null)
							{
								oaHYsVKqotUxmLMRdTojIYzEOnG.ResetAll();
								num = 322718104;
								continue;
							}
							return;
						case 1:
							return;
						}
						break;
					}
					goto IL_0007;
					IL_0039:
					platformVars_WindowsUWP = NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP;
					num = 322718106;
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
					return NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.xboxOne_primaryInputSource;
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
						if (NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.xboxOne_primaryInputSource == value)
						{
							num = 6872776;
							num2 = num;
						}
						else
						{
							num = 6872779;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ 0x68DEC9)
							{
							case 4:
								num = 6872778;
								continue;
							default:
								return;
							case 3:
								break;
							case 0:
								oaHYsVKqotUxmLMRdTojIYzEOnG.ResetAll();
								num = 6872780;
								continue;
							case 1:
								return;
							case 2:
							{
								NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.xboxOne_primaryInputSource = value;
								int num3;
								if (!(oaHYsVKqotUxmLMRdTojIYzEOnG != null))
								{
									num = 6872780;
									num3 = num;
								}
								else
								{
									num = 6872777;
									num3 = num;
								}
								continue;
							}
							case 5:
								return;
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
					return NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.ps4_primaryInputSource;
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
						if (NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.ps4_primaryInputSource != value)
						{
							num = 1809036956;
							num2 = num;
						}
						else
						{
							num = 1809036954;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ 0x6BD3B69F)
							{
							case 4:
								num = 1809036957;
								continue;
							default:
								return;
							case 2:
								break;
							case 3:
							{
								NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.ps4_primaryInputSource = value;
								int num3;
								if (oaHYsVKqotUxmLMRdTojIYzEOnG != null)
								{
									num = 1809036959;
									num3 = num;
								}
								else
								{
									num = 1809036958;
									num3 = num;
								}
								continue;
							}
							case 0:
								oaHYsVKqotUxmLMRdTojIYzEOnG.ResetAll();
								num = 1809036958;
								continue;
							case 5:
								return;
							case 1:
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
					return NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.webGL_primaryInputSource;
				}
				set
				{
					if (!CheckInitialized())
					{
						return;
					}
					while (NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.webGL_primaryInputSource != value)
					{
						while (true)
						{
							NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.webGL_primaryInputSource = value;
							int num = 71564425;
							while (true)
							{
								switch (num ^ 0x443FC89)
								{
								case 3:
									num = 71564429;
									continue;
								default:
									return;
								case 0:
									break;
								case 2:
									goto end_IL_000d;
								case 1:
									oaHYsVKqotUxmLMRdTojIYzEOnG.ResetAll();
									num = 71564428;
									continue;
								case 4:
									goto end_IL_0050;
								case 5:
									return;
								}
								int num2;
								if (oaHYsVKqotUxmLMRdTojIYzEOnG != null)
								{
									num = 71564424;
									num2 = num;
								}
								else
								{
									num = 71564428;
									num2 = num;
								}
								continue;
								end_IL_000d:
								break;
							}
							continue;
							end_IL_0050:
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
					return NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.alwaysUseUnityInput;
				}
				set
				{
					if (!CheckInitialized())
					{
						goto IL_0007;
					}
					goto IL_0039;
					IL_0007:
					int num = -1683065893;
					goto IL_000c;
					IL_000c:
					while (true)
					{
						switch (num ^ -1683065890)
						{
						case 4:
							break;
						default:
							return;
						case 5:
							return;
						case 0:
							goto IL_0039;
						case 3:
							return;
						case 2:
							NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.alwaysUseUnityInput = value;
							if (oaHYsVKqotUxmLMRdTojIYzEOnG != null)
							{
								oaHYsVKqotUxmLMRdTojIYzEOnG.ResetAll();
								num = -1683065889;
								continue;
							}
							return;
						case 1:
							return;
						}
						break;
					}
					goto IL_0007;
					IL_0039:
					int num2;
					if (NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.alwaysUseUnityInput != value)
					{
						num = -1683065892;
						num2 = num;
					}
					else
					{
						num = -1683065891;
						num2 = num;
					}
					goto IL_000c;
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
					return NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.GetPlatformVar_useNativeMouse();
				}
				set
				{
					if (!CheckInitialized())
					{
						return;
					}
					while (NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.SetPlatformVar_useNativeMouse(value))
					{
						while (true)
						{
							IL_0044:
							if (!(oaHYsVKqotUxmLMRdTojIYzEOnG != null))
							{
								return;
							}
							oaHYsVKqotUxmLMRdTojIYzEOnG.ResetAll();
							int num = 763430557;
							while (true)
							{
								switch (num ^ 0x2D81069E)
								{
								case 2:
									num = 763430559;
									continue;
								default:
									return;
								case 1:
									break;
								case 0:
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

			public bool nativeKeyboardSupport
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					return NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.GetPlatformVar_useNativeKeyboard();
				}
				set
				{
					if (!CheckInitialized())
					{
						goto IL_0007;
					}
					goto IL_0068;
					IL_0007:
					int num = -311831130;
					goto IL_000c;
					IL_000c:
					while (true)
					{
						switch (num ^ -311831134)
						{
						case 5:
							break;
						default:
							return;
						case 4:
							return;
						case 3:
							goto IL_0039;
						case 1:
							oaHYsVKqotUxmLMRdTojIYzEOnG.ResetAll();
							num = -311831136;
							continue;
						case 0:
							goto IL_0068;
						case 2:
							return;
						}
						break;
					}
					goto IL_0007;
					IL_0068:
					if (!NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.SetPlatformVar_useNativeKeyboard(value))
					{
						return;
					}
					goto IL_0039;
					IL_0039:
					int num2;
					if (!(oaHYsVKqotUxmLMRdTojIYzEOnG != null))
					{
						num = -311831136;
						num2 = num;
					}
					else
					{
						num = -311831133;
						num2 = num;
					}
					goto IL_000c;
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
					return NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.GetPlatformVar_useEnhancedDeviceSupport();
				}
				set
				{
					if (!CheckInitialized())
					{
						return;
					}
					while (NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.SetPlatformVar_useEnhancedDeviceSupport(value))
					{
						while (true)
						{
							IL_0044:
							if (!(oaHYsVKqotUxmLMRdTojIYzEOnG != null))
							{
								return;
							}
							oaHYsVKqotUxmLMRdTojIYzEOnG.ResetAll();
							int num = 219002135;
							while (true)
							{
								switch (num ^ 0xD0DB517)
								{
								case 2:
									num = 219002134;
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

			public int joystickRefreshRate
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0;
					}
					return NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.GetPlatformVar_joystickRefreshRate();
				}
				set
				{
					if (!CheckInitialized())
					{
						goto IL_0007;
					}
					goto IL_0031;
					IL_0007:
					int num = 2000994696;
					goto IL_000c;
					IL_000c:
					switch (num ^ 0x7744C18B)
					{
					case 2:
						break;
					case 3:
						return;
					case 0:
						goto IL_0031;
					default:
						goto IL_0050;
					}
					goto IL_0007;
					IL_0031:
					value = MathTools.Clamp(value, 0, 2000);
					if (value == 0)
					{
						value = 240;
						num = 2000994698;
						goto IL_000c;
					}
					goto IL_0050;
					IL_0050:
					NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.SetPlatformVar_joystickRefreshRate(value);
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
					return NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.GetPlatformVar_ignoreInputWhenAppNotInFocus();
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
						if (!NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.SetPlatformVar_ignoreInputWhenAppNotInFocus(value))
						{
							num = -679648530;
							num2 = num;
						}
						else
						{
							num = -679648531;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ -679648529)
							{
							case 0:
								goto IL_0008;
							case 3:
								break;
							case 1:
								return;
							default:
								VwhkrGIDxEPPOgFLGvlHoIRGioH();
								return;
							}
							break;
							IL_0008:
							num = -679648532;
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
					return NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.android_supportUnknownGamepads;
				}
				set
				{
					if (!CheckInitialized())
					{
						return;
					}
					while (NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.android_supportUnknownGamepads != value)
					{
						while (true)
						{
							IL_0044:
							NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.android_supportUnknownGamepads = value;
							if (!(oaHYsVKqotUxmLMRdTojIYzEOnG != null))
							{
								return;
							}
							oaHYsVKqotUxmLMRdTojIYzEOnG.ResetAll();
							int num = -1851971362;
							while (true)
							{
								switch (num ^ -1851971362)
								{
								case 2:
									num = -1851971361;
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

			public DeadZone2DType defaultJoystickAxis2DDeadZoneType
			{
				get
				{
					if (!CheckInitialized())
					{
						return DeadZone2DType.Radial;
					}
					return NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.defaultJoystickAxis2DDeadZoneType;
				}
				set
				{
					if (!CheckInitialized())
					{
						goto IL_0007;
					}
					goto IL_004c;
					IL_0007:
					int num = -216185302;
					goto IL_000c;
					IL_000c:
					switch (num ^ -216185301)
					{
					case 4:
						break;
					default:
						return;
					case 1:
						return;
					case 2:
						goto IL_0035;
					case 3:
						goto IL_004c;
					case 0:
						return;
					}
					goto IL_0007;
					IL_004c:
					if (NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.defaultJoystickAxis2DDeadZoneType == value)
					{
						return;
					}
					goto IL_0035;
					IL_0035:
					NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.defaultJoystickAxis2DDeadZoneType = value;
					num = -216185301;
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
					return NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.defaultJoystickAxis2DSensitivityType;
				}
				set
				{
					if (!CheckInitialized())
					{
						return;
					}
					while (NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.defaultJoystickAxis2DSensitivityType != value)
					{
						while (true)
						{
							IL_0044:
							NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.defaultJoystickAxis2DSensitivityType = value;
							int num = -299197201;
							while (true)
							{
								switch (num ^ -299197201)
								{
								case 2:
									num = -299197202;
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

			public AxisSensitivityType defaultAxisSensitivityType
			{
				get
				{
					if (!CheckInitialized())
					{
						return AxisSensitivityType.Multiplier;
					}
					return NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.defaultAxisSensitivityType;
				}
				set
				{
					if (!CheckInitialized())
					{
						while (true)
						{
							switch (0x2915206C ^ 0x2915206D)
							{
							case 0:
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
					if (NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.defaultAxisSensitivityType == value)
					{
						return;
					}
					goto IL_004b;
					IL_004b:
					NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.defaultAxisSensitivityType = value;
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
					return NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.force4WayHats;
				}
				set
				{
					if (!CheckInitialized())
					{
						return;
					}
					while (NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.force4WayHats != value)
					{
						while (true)
						{
							IL_0044:
							NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.force4WayHats = value;
							int num = -1986822255;
							while (true)
							{
								switch (num ^ -1986822255)
								{
								case 3:
									num = -1986822253;
									continue;
								default:
									return;
								case 2:
									break;
								case 1:
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

			public float defaultAbsoluteAxisPollingDeadZone
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0.7f;
					}
					return COfpvBFgHNSUBfmMEeRbhbHJzwEE;
				}
				set
				{
					if (!CheckInitialized())
					{
						return;
					}
					while (true)
					{
						IL_0062:
						int num;
						if (value < 0f)
						{
							value = 0f;
							num = -286342835;
							goto IL_000d;
						}
						goto IL_003a;
						IL_000d:
						while (true)
						{
							switch (num ^ -286342833)
							{
							case 0:
								num = -286342838;
								continue;
							default:
								return;
							case 1:
								return;
							case 2:
								break;
							case 4:
								COfpvBFgHNSUBfmMEeRbhbHJzwEE = value;
								num = -286342836;
								continue;
							case 5:
								goto IL_0062;
							case 3:
								return;
							}
							break;
						}
						goto IL_003a;
						IL_003a:
						int num2;
						if (COfpvBFgHNSUBfmMEeRbhbHJzwEE == value)
						{
							num = -286342834;
							num2 = num;
						}
						else
						{
							num = -286342837;
							num2 = num;
						}
						goto IL_000d;
					}
				}
			}

			public float defaultRelativeAxisPollingDeadZone
			{
				get
				{
					if (!CheckInitialized())
					{
						return 100f;
					}
					return nIUyhXXccVQEeYFxvBObISIAFWdb;
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
						if (value >= 0f)
						{
							num = -285363096;
							num2 = num;
						}
						else
						{
							num = -285363091;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ -285363092)
							{
							case 3:
								num = -285363090;
								continue;
							case 2:
								break;
							case 4:
							{
								int num3;
								if (nIUyhXXccVQEeYFxvBObISIAFWdb != value)
								{
									num = -285363092;
									num3 = num;
								}
								else
								{
									num = -285363095;
									num3 = num;
								}
								continue;
							}
							case 5:
								return;
							case 1:
								value = 0f;
								num = -285363096;
								continue;
							default:
								nIUyhXXccVQEeYFxvBObISIAFWdb = value;
								return;
							}
							break;
						}
					}
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
					return NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.activateActionButtonsOnNegativeValue;
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
						if (NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.activateActionButtonsOnNegativeValue == value)
						{
							num = 1768211108;
							num2 = num;
						}
						else
						{
							num = 1768211109;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ 0x6964C2A6)
							{
							case 0:
								goto IL_0008;
							case 1:
								break;
							case 2:
								return;
							default:
								NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.activateActionButtonsOnNegativeValue = value;
								return;
							}
							break;
							IL_0008:
							num = 1768211111;
						}
					}
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
					return NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.throttleCalibrationMode;
				}
				set
				{
					if (!CheckInitialized())
					{
						return;
					}
					while (NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.throttleCalibrationMode != value)
					{
						while (true)
						{
							IL_0044:
							NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.throttleCalibrationMode = value;
							int num = -262198209;
							while (true)
							{
								switch (num ^ -262198211)
								{
								case 0:
									num = -262198210;
									continue;
								case 3:
									break;
								case 1:
									goto IL_0044;
								default:
									akUdmKMbrqFLXkjqdKLUZOPTArx.IDEywWFxxQnkLUsYVchGCtQvPNH(value);
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
					return NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.deferControllerConnectedEventsOnStart;
				}
				set
				{
					if (!CheckInitialized())
					{
						while (true)
						{
							switch (0x391D3B48 ^ 0x391D3B4A)
							{
							case 3:
								break;
							case 2:
								return;
							case 1:
								goto end_IL_0007;
							default:
								goto IL_004b;
							}
							continue;
							end_IL_0007:
							break;
						}
					}
					if (NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.deferControllerConnectedEventsOnStart == value)
					{
						return;
					}
					goto IL_004b;
					IL_004b:
					NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.deferControllerConnectedEventsOnStart = value;
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
					return NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.autoAssignJoysticks;
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
						if (NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.autoAssignJoysticks == value)
						{
							num = 1119551822;
							num2 = num;
						}
						else
						{
							num = 1119551823;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ 0x42BB014F)
							{
							case 4:
								num = 1119551821;
								continue;
							default:
								return;
							case 2:
								break;
							case 0:
								NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.autoAssignJoysticks = value;
								num = 1119551820;
								continue;
							case 1:
								return;
							case 3:
								return;
							}
							break;
						}
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
					return NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.maxJoysticksPerPlayer;
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
						if (value < 1)
						{
							value = 1;
							num = 288573219;
							goto IL_000d;
						}
						goto IL_003c;
						IL_000d:
						while (true)
						{
							switch (num ^ 0x11334720)
							{
							case 0:
								num = 288573220;
								continue;
							case 4:
								break;
							case 3:
								goto IL_003c;
							case 2:
								return;
							default:
								NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.maxJoysticksPerPlayer = value;
								return;
							}
							break;
						}
						continue;
						IL_003c:
						int num2;
						if (NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.maxJoysticksPerPlayer == value)
						{
							num = 288573218;
							num2 = num;
						}
						else
						{
							num = 288573217;
							num2 = num;
						}
						goto IL_000d;
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
					return NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.distributeJoysticksEvenly;
				}
				set
				{
					if (!CheckInitialized())
					{
						return;
					}
					while (NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.distributeJoysticksEvenly != value)
					{
						while (true)
						{
							IL_0044:
							NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.distributeJoysticksEvenly = value;
							int num = 2019650332;
							while (true)
							{
								switch (num ^ 0x78616B1D)
								{
								case 0:
									num = 2019650335;
									continue;
								default:
									return;
								case 2:
									break;
								case 3:
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

			public bool assignJoysticksToPlayingPlayersOnly
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					return NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.assignJoysticksToPlayingPlayersOnly;
				}
				set
				{
					if (!CheckInitialized())
					{
						goto IL_0007;
					}
					goto IL_0035;
					IL_0007:
					int num = -26728241;
					goto IL_000c;
					IL_000c:
					switch (num ^ -26728245)
					{
					case 0:
						break;
					case 3:
						return;
					case 1:
						goto IL_0035;
					case 4:
						return;
					default:
						NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.assignJoysticksToPlayingPlayersOnly = value;
						return;
					}
					goto IL_0007;
					IL_0035:
					int num2;
					if (NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.assignJoysticksToPlayingPlayersOnly != value)
					{
						num = -26728247;
						num2 = num;
					}
					else
					{
						num = -26728248;
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
					return NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.reassignJoystickToPreviousOwnerOnReconnect;
				}
				set
				{
					if (!CheckInitialized())
					{
						while (true)
						{
							switch (-1270106886 ^ -1270106885)
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
					if (NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.reassignJoystickToPreviousOwnerOnReconnect == value)
					{
						return;
					}
					goto IL_004b;
					IL_004b:
					NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.reassignJoystickToPreviousOwnerOnReconnect = value;
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
					return NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.logLevel;
				}
				set
				{
					if (CheckInitialized() && NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.logLevel != value)
					{
						NrWVrlwEDRnzNfQhnCmEXbpqELr.ConfigVars.logLevel = value;
					}
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
			[Browsable(false)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public sealed class PollingHelper : CodeHelper
			{
				private sealed class EkmAegIggPEEQJMdwdkcPHabWve : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo ubyTdixGSFKGaFQFZdQnpwgWIvJ;

					private int isaqVUvqwfWYqOUtovbpbCbxgPc;

					private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

					public PollingHelper syCPfFbHYMDOvEPjTnPLBqiOhsPv;

					public ControllerPollingInfo mDhbisqEMxhXyZvleBTRJGxdMfdo;

					public ControllerPollingInfo HffJVTqXsVJjkiaHADwIhgdkkekE;

					public ControllerPollingInfo EniFwuNGOgpZgqaxZGcCKVlnSgGP;

					public ControllerPollingInfo wsJkBfOvArPvsfskGFEMrMLmHWC;

					public IEnumerator<ControllerPollingInfo> tJydjLXrKKKqvligudjpaPnCICwf;

					public IEnumerator<ControllerPollingInfo> eRIwvurkaHCnfTqAfvOQeKjpynw;

					public IEnumerator<ControllerPollingInfo> MHLoWANIaRuGihhQhrXAhwACQvY;

					public IEnumerator<ControllerPollingInfo> xNPNbsEBEEKRVFDJSFFQAsCakyAi;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT)
						{
							goto IL_0012;
						}
						goto IL_0063;
						IL_0012:
						int num = -1400882398;
						goto IL_0017;
						IL_0017:
						EkmAegIggPEEQJMdwdkcPHabWve ekmAegIggPEEQJMdwdkcPHabWve = default(EkmAegIggPEEQJMdwdkcPHabWve);
						while (true)
						{
							switch (num ^ -1400882394)
							{
							case 2:
								break;
							case 4:
								goto IL_0038;
							case 3:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
								ekmAegIggPEEQJMdwdkcPHabWve = this;
								num = -1400882393;
								continue;
							case 0:
								goto IL_0063;
							default:
								return ekmAegIggPEEQJMdwdkcPHabWve;
							}
							break;
							IL_0038:
							int num2;
							if (isaqVUvqwfWYqOUtovbpbCbxgPc != -2)
							{
								num = -1400882394;
								num2 = num;
							}
							else
							{
								num = -1400882395;
								num2 = num;
							}
						}
						goto IL_0012;
						IL_0063:
						ekmAegIggPEEQJMdwdkcPHabWve = new EkmAegIggPEEQJMdwdkcPHabWve(0);
						ekmAegIggPEEQJMdwdkcPHabWve.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
						num = -1400882393;
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
							int num = isaqVUvqwfWYqOUtovbpbCbxgPc;
							while (true)
							{
								IL_0007:
								int num2 = -1318409874;
								while (true)
								{
									switch (num2 ^ -1318409873)
									{
									case 9:
										break;
									case 0:
										isaqVUvqwfWYqOUtovbpbCbxgPc = 7;
										num2 = -1318409867;
										continue;
									case 19:
										isaqVUvqwfWYqOUtovbpbCbxgPc = 8;
										result = true;
										num2 = -1318409859;
										continue;
									case 5:
										isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
										num2 = -1318409865;
										continue;
									case 24:
										if (!tJydjLXrKKKqvligudjpaPnCICwf.MoveNext())
										{
											ztVkUpBgodPTduzEVBsJlVZFILk();
											eRIwvurkaHCnfTqAfvOQeKjpynw = syCPfFbHYMDOvEPjTnPLBqiOhsPv.gDkkTbkjunDzYgomHuBtVHKKyugd().GetEnumerator();
											isaqVUvqwfWYqOUtovbpbCbxgPc = 3;
											num2 = -1318409877;
											continue;
										}
										goto case 11;
									case 23:
										goto IL_00fb;
									case 11:
										mDhbisqEMxhXyZvleBTRJGxdMfdo = tJydjLXrKKKqvligudjpaPnCICwf.Current;
										num2 = -1318409858;
										continue;
									case 2:
										goto IL_0147;
									case 15:
										goto IL_0158;
									case 18:
										goto end_IL_000c;
									case 16:
										wsJkBfOvArPvsfskGFEMrMLmHWC = xNPNbsEBEEKRVFDJSFFQAsCakyAi.Current;
										num2 = -1318409880;
										continue;
									case 4:
										num2 = -1318409886;
										continue;
									case 14:
										goto IL_019d;
									case 8:
										MHLoWANIaRuGihhQhrXAhwACQvY = syCPfFbHYMDOvEPjTnPLBqiOhsPv.LWvBSAgTxRsMyBxOdRmnheGbXFz().GetEnumerator();
										isaqVUvqwfWYqOUtovbpbCbxgPc = 5;
										num2 = -1318409863;
										continue;
									case 3:
										num2 = -1318409867;
										continue;
									case 20:
										ubyTdixGSFKGaFQFZdQnpwgWIvJ = HffJVTqXsVJjkiaHADwIhgdkkekE;
										isaqVUvqwfWYqOUtovbpbCbxgPc = 4;
										result = true;
										goto end_IL_000c;
									case 21:
										ubyTdixGSFKGaFQFZdQnpwgWIvJ = EniFwuNGOgpZgqaxZGcCKVlnSgGP;
										isaqVUvqwfWYqOUtovbpbCbxgPc = 6;
										result = true;
										goto end_IL_000c;
									case 27:
										HffJVTqXsVJjkiaHADwIhgdkkekE = eRIwvurkaHCnfTqAfvOQeKjpynw.Current;
										num2 = -1318409861;
										continue;
									case 13:
									{
										int num3;
										if (eRIwvurkaHCnfTqAfvOQeKjpynw.MoveNext())
										{
											num2 = -1318409868;
											num3 = num2;
										}
										else
										{
											num2 = -1318409883;
											num3 = num2;
										}
										continue;
									}
									case 10:
										CmBveOWpAOSArIawWXXZcvbgRkq();
										num2 = -1318409881;
										continue;
									case 7:
										ubyTdixGSFKGaFQFZdQnpwgWIvJ = wsJkBfOvArPvsfskGFEMrMLmHWC;
										num2 = -1318409860;
										continue;
									case 12:
										xNPNbsEBEEKRVFDJSFFQAsCakyAi = syCPfFbHYMDOvEPjTnPLBqiOhsPv.zcUFwEBZayAeHYOLARPISCyDMtL().GetEnumerator();
										isaqVUvqwfWYqOUtovbpbCbxgPc = 7;
										num2 = -1318409876;
										continue;
									case 1:
										switch (num)
										{
										case 8:
											break;
										case 0:
											goto IL_00fb;
										case 2:
											goto IL_0147;
										case 6:
											goto IL_0158;
										case 4:
											goto IL_019d;
										default:
											goto IL_02da;
										case 1:
										case 3:
										case 5:
										case 7:
											goto IL_035d;
										}
										goto case 0;
									case 22:
										if (!MHLoWANIaRuGihhQhrXAhwACQvY.MoveNext())
										{
											WPxYEjryHeVJRpsEUkPoHPVldGj();
											num2 = -1318409885;
											continue;
										}
										goto case 6;
									case 17:
										ubyTdixGSFKGaFQFZdQnpwgWIvJ = mDhbisqEMxhXyZvleBTRJGxdMfdo;
										isaqVUvqwfWYqOUtovbpbCbxgPc = 2;
										result = true;
										goto end_IL_000c;
									case 26:
										if (!xNPNbsEBEEKRVFDJSFFQAsCakyAi.MoveNext())
										{
											coCmVEthVHbCGeNXyScowWpYfhbm();
											num2 = -1318409866;
											continue;
										}
										goto case 16;
									case 6:
										EniFwuNGOgpZgqaxZGcCKVlnSgGP = MHLoWANIaRuGihhQhrXAhwACQvY.Current;
										num2 = -1318409862;
										continue;
									default:
										goto IL_035d;
										IL_02da:
										num2 = -1318409866;
										continue;
										IL_019d:
										isaqVUvqwfWYqOUtovbpbCbxgPc = 3;
										num2 = -1318409886;
										continue;
										IL_0158:
										isaqVUvqwfWYqOUtovbpbCbxgPc = 5;
										num2 = -1318409863;
										continue;
										IL_0147:
										isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
										num2 = -1318409865;
										continue;
										IL_00fb:
										isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
										if (CheckInitialized())
										{
											tJydjLXrKKKqvligudjpaPnCICwf = syCPfFbHYMDOvEPjTnPLBqiOhsPv.EryhAdvSAsRpSPxTBrqLynabLEN().GetEnumerator();
											num2 = -1318409878;
											continue;
										}
										goto IL_035d;
										IL_035d:
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
						switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
						{
						case 1:
						case 2:
							try
							{
							}
							finally
							{
								ztVkUpBgodPTduzEVBsJlVZFILk();
							}
							break;
						}
						switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
						{
						case 3:
						case 4:
							try
							{
							}
							finally
							{
								CmBveOWpAOSArIawWXXZcvbgRkq();
							}
							break;
						}
						int num = isaqVUvqwfWYqOUtovbpbCbxgPc;
						while (true)
						{
							int num2 = -768384702;
							while (true)
							{
								switch (num2 ^ -768384701)
								{
								case 2:
									break;
								case 1:
									switch (num)
									{
									default:
										goto IL_0079;
									case 5:
									case 6:
										break;
									}
									try
									{
									}
									finally
									{
										WPxYEjryHeVJRpsEUkPoHPVldGj();
									}
									goto default;
								default:
									switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
									{
									case 7:
									case 8:
										try
										{
											break;
										}
										finally
										{
											coCmVEthVHbCGeNXyScowWpYfhbm();
										}
									}
									return;
								}
								break;
								IL_0079:
								num2 = -768384701;
							}
						}
					}

					[DebuggerHidden]
					public EkmAegIggPEEQJMdwdkcPHabWve(int _003C_003E1__state)
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
						TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
					}

					private void ztVkUpBgodPTduzEVBsJlVZFILk()
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						if (tJydjLXrKKKqvligudjpaPnCICwf == null)
						{
							return;
						}
						while (true)
						{
							int num = 635203427;
							while (true)
							{
								switch (num ^ 0x25DC6F61)
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
								tJydjLXrKKKqvligudjpaPnCICwf.Dispose();
								num = 635203424;
							}
						}
					}

					private void CmBveOWpAOSArIawWXXZcvbgRkq()
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						if (eRIwvurkaHCnfTqAfvOQeKjpynw == null)
						{
							return;
						}
						while (true)
						{
							int num = -425581080;
							while (true)
							{
								switch (num ^ -425581079)
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
								eRIwvurkaHCnfTqAfvOQeKjpynw.Dispose();
								num = -425581079;
							}
						}
					}

					private void WPxYEjryHeVJRpsEUkPoHPVldGj()
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						while (true)
						{
							int num = -1968890037;
							while (true)
							{
								switch (num ^ -1968890039)
								{
								case 0:
									break;
								default:
									return;
								case 2:
									if (MHLoWANIaRuGihhQhrXAhwACQvY != null)
									{
										goto IL_002d;
									}
									return;
								case 1:
									return;
								}
								break;
								IL_002d:
								MHLoWANIaRuGihhQhrXAhwACQvY.Dispose();
								num = -1968890040;
							}
						}
					}

					private void coCmVEthVHbCGeNXyScowWpYfhbm()
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						if (xNPNbsEBEEKRVFDJSFFQAsCakyAi != null)
						{
							xNPNbsEBEEKRVFDJSFFQAsCakyAi.Dispose();
						}
					}
				}

				private sealed class cYVdUakcrcewVPgGfqRxOuqISWG : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo ubyTdixGSFKGaFQFZdQnpwgWIvJ;

					private int isaqVUvqwfWYqOUtovbpbCbxgPc;

					private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

					public PollingHelper syCPfFbHYMDOvEPjTnPLBqiOhsPv;

					public ControllerPollingInfo kOAXiCtGWSfFRqZEmBYRaAbHLzB;

					public ControllerPollingInfo ntZGvpHYZcnVCKifHVUzASjZPYM;

					public ControllerPollingInfo SIeFmPgejNDvVZZNVvpykOZgDWeY;

					public ControllerPollingInfo iauMdLAhwizMtLxWQgsrbIQHamuF;

					public IEnumerator<ControllerPollingInfo> gHjztOAXCeTQEWQJgUMGHnEeeZN;

					public IEnumerator<ControllerPollingInfo> RpElJscdriGmqfsWHGIiCRjIfQxf;

					public IEnumerator<ControllerPollingInfo> kPBplPFOZeNLdcSUMFKoDgXNYfJC;

					public IEnumerator<ControllerPollingInfo> DoxcpwZceMmVYUngdqmgirnPuxn;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
						{
							goto IL_001c;
						}
						goto IL_004e;
						IL_004e:
						cYVdUakcrcewVPgGfqRxOuqISWG cYVdUakcrcewVPgGfqRxOuqISWG2 = new cYVdUakcrcewVPgGfqRxOuqISWG(0);
						cYVdUakcrcewVPgGfqRxOuqISWG2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
						int num = -1606104521;
						goto IL_0021;
						IL_001c:
						num = -1606104523;
						goto IL_0021;
						IL_0021:
						while (true)
						{
							switch (num ^ -1606104524)
							{
							case 2:
								break;
							case 1:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
								cYVdUakcrcewVPgGfqRxOuqISWG2 = this;
								num = -1606104521;
								continue;
							case 0:
								goto IL_004e;
							default:
								return cYVdUakcrcewVPgGfqRxOuqISWG2;
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
							switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
							{
							default:
								num = 750285575;
								goto IL_0036;
							case 4:
								goto IL_0166;
							case 8:
								goto IL_019e;
							case 0:
								goto IL_0248;
							case 2:
								goto IL_0349;
							case 6:
								goto IL_037b;
							case 1:
							case 3:
							case 5:
							case 7:
								break;
								IL_0036:
								while (true)
								{
									switch (num ^ 0x2CB8730E)
									{
									case 31:
										break;
									case 4:
										goto IL_00c6;
									case 17:
										ntZGvpHYZcnVCKifHVUzASjZPYM = RpElJscdriGmqfsWHGIiCRjIfQxf.Current;
										num = 750285595;
										continue;
									case 26:
										result = true;
										goto end_IL_0000;
									case 28:
										isaqVUvqwfWYqOUtovbpbCbxgPc = 2;
										num = 750285588;
										continue;
									case 15:
										isaqVUvqwfWYqOUtovbpbCbxgPc = 6;
										result = true;
										num = 750285584;
										continue;
									case 30:
										goto end_IL_0000;
									case 2:
										isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
										num = 750285591;
										continue;
									case 11:
										goto end_IL_0000;
									case 22:
										goto IL_0166;
									case 29:
										kOAXiCtGWSfFRqZEmBYRaAbHLzB = gHjztOAXCeTQEWQJgUMGHnEeeZN.Current;
										ubyTdixGSFKGaFQFZdQnpwgWIvJ = kOAXiCtGWSfFRqZEmBYRaAbHLzB;
										num = 750285586;
										continue;
									case 3:
										goto IL_019e;
									case 25:
										goto IL_01af;
									case 23:
										rhqXTZzPzrsUskGnkhqHqnKpUQY();
										num = 750285583;
										continue;
									case 10:
										num = 750285598;
										continue;
									case 8:
										iauMdLAhwizMtLxWQgsrbIQHamuF = DoxcpwZceMmVYUngdqmgirnPuxn.Current;
										num = 750285570;
										continue;
									case 27:
										loPlDgJAOZwEDXNuJFtAjIJLkPro();
										RpElJscdriGmqfsWHGIiCRjIfQxf = syCPfFbHYMDOvEPjTnPLBqiOhsPv.YFihCQKfLwUlPaHilGyRDWbGGEhs().GetEnumerator();
										isaqVUvqwfWYqOUtovbpbCbxgPc = 3;
										num = 750285577;
										continue;
									case 21:
										ubyTdixGSFKGaFQFZdQnpwgWIvJ = ntZGvpHYZcnVCKifHVUzASjZPYM;
										num = 750285590;
										continue;
									case 13:
										goto IL_0248;
									case 5:
										SIeFmPgejNDvVZZNVvpykOZgDWeY = kPBplPFOZeNLdcSUMFKoDgXNYfJC.Current;
										ubyTdixGSFKGaFQFZdQnpwgWIvJ = SIeFmPgejNDvVZZNVvpykOZgDWeY;
										num = 750285569;
										continue;
									case 14:
										result = true;
										goto end_IL_0000;
									case 6:
										sXUlnaDSdJrHTBxrNXkxJShSmuD();
										kPBplPFOZeNLdcSUMFKoDgXNYfJC = syCPfFbHYMDOvEPjTnPLBqiOhsPv.VkxyXiOCCUrUaenxypQwkZnutHW().GetEnumerator();
										isaqVUvqwfWYqOUtovbpbCbxgPc = 5;
										num = 750285578;
										continue;
									case 24:
										isaqVUvqwfWYqOUtovbpbCbxgPc = 4;
										num = 750285568;
										continue;
									case 9:
										num = 750285596;
										continue;
									case 7:
										num = 750285594;
										continue;
									case 12:
										ubyTdixGSFKGaFQFZdQnpwgWIvJ = iauMdLAhwizMtLxWQgsrbIQHamuF;
										isaqVUvqwfWYqOUtovbpbCbxgPc = 8;
										result = true;
										num = 750285573;
										continue;
									case 1:
										DoxcpwZceMmVYUngdqmgirnPuxn = syCPfFbHYMDOvEPjTnPLBqiOhsPv.BYftyvqdMQrIiCsPpQZLfkroaki().GetEnumerator();
										isaqVUvqwfWYqOUtovbpbCbxgPc = 7;
										num = 750285572;
										continue;
									case 0:
										goto IL_0349;
									case 20:
										goto IL_035a;
									case 19:
										goto IL_037b;
									case 16:
										if (!DoxcpwZceMmVYUngdqmgirnPuxn.MoveNext())
										{
											NvXEBroHBLABzQxsfAibHMwLOwF();
											num = 750285596;
											continue;
										}
										goto case 8;
									default:
										goto end_IL_0008;
									}
									break;
									IL_035a:
									int num2;
									if (!RpElJscdriGmqfsWHGIiCRjIfQxf.MoveNext())
									{
										num = 750285576;
										num2 = num;
									}
									else
									{
										num = 750285599;
										num2 = num;
									}
									continue;
									IL_01af:
									int num3;
									if (gHjztOAXCeTQEWQJgUMGHnEeeZN.MoveNext())
									{
										num = 750285587;
										num3 = num;
									}
									else
									{
										num = 750285589;
										num3 = num;
									}
									continue;
									IL_00c6:
									int num4;
									if (!kPBplPFOZeNLdcSUMFKoDgXNYfJC.MoveNext())
									{
										num = 750285593;
										num4 = num;
									}
									else
									{
										num = 750285579;
										num4 = num;
									}
								}
								goto default;
								IL_037b:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 5;
								num = 750285578;
								goto IL_0036;
								IL_0349:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								num = 750285591;
								goto IL_0036;
								IL_0248:
								isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
								if (!CheckInitialized())
								{
									break;
								}
								gHjztOAXCeTQEWQJgUMGHnEeeZN = syCPfFbHYMDOvEPjTnPLBqiOhsPv.jFXsMOuBYvqPuajGjCPfHtTJlPD().GetEnumerator();
								num = 750285580;
								goto IL_0036;
								IL_0166:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 3;
								num = 750285594;
								goto IL_0036;
								IL_019e:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 7;
								num = 750285598;
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
						switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
						{
						case 1:
						case 2:
							try
							{
							}
							finally
							{
								loPlDgJAOZwEDXNuJFtAjIJLkPro();
							}
							break;
						}
						switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
						{
						case 3:
						case 4:
							try
							{
							}
							finally
							{
								sXUlnaDSdJrHTBxrNXkxJShSmuD();
							}
							break;
						}
						switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
						{
						case 5:
						case 6:
							try
							{
							}
							finally
							{
								rhqXTZzPzrsUskGnkhqHqnKpUQY();
							}
							break;
						}
						switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
						{
						case 7:
						case 8:
							try
							{
								break;
							}
							finally
							{
								NvXEBroHBLABzQxsfAibHMwLOwF();
							}
						}
					}

					[DebuggerHidden]
					public cYVdUakcrcewVPgGfqRxOuqISWG(int _003C_003E1__state)
					{
						while (true)
						{
							int num = 1314958560;
							while (true)
							{
								switch (num ^ 0x4E60ACE2)
								{
								case 0:
									break;
								case 2:
									goto IL_0024;
								default:
									TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
									return;
								}
								break;
								IL_0024:
								isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
								num = 1314958563;
							}
						}
					}

					private void loPlDgJAOZwEDXNuJFtAjIJLkPro()
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						if (gHjztOAXCeTQEWQJgUMGHnEeeZN != null)
						{
							gHjztOAXCeTQEWQJgUMGHnEeeZN.Dispose();
						}
					}

					private void sXUlnaDSdJrHTBxrNXkxJShSmuD()
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						if (RpElJscdriGmqfsWHGIiCRjIfQxf == null)
						{
							return;
						}
						while (true)
						{
							int num = -1314029356;
							while (true)
							{
								switch (num ^ -1314029355)
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
								RpElJscdriGmqfsWHGIiCRjIfQxf.Dispose();
								num = -1314029355;
							}
						}
					}

					private void rhqXTZzPzrsUskGnkhqHqnKpUQY()
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						while (true)
						{
							int num = -1732006300;
							while (true)
							{
								switch (num ^ -1732006299)
								{
								case 2:
									break;
								default:
									return;
								case 1:
									if (kPBplPFOZeNLdcSUMFKoDgXNYfJC != null)
									{
										goto IL_002d;
									}
									return;
								case 0:
									return;
								}
								break;
								IL_002d:
								kPBplPFOZeNLdcSUMFKoDgXNYfJC.Dispose();
								num = -1732006299;
							}
						}
					}

					private void NvXEBroHBLABzQxsfAibHMwLOwF()
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						if (DoxcpwZceMmVYUngdqmgirnPuxn != null)
						{
							DoxcpwZceMmVYUngdqmgirnPuxn.Dispose();
						}
					}
				}

				private sealed class lpVlJfSZpGYbWfeISnUqxCtPXov : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo ubyTdixGSFKGaFQFZdQnpwgWIvJ;

					private int isaqVUvqwfWYqOUtovbpbCbxgPc;

					private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

					public PollingHelper syCPfFbHYMDOvEPjTnPLBqiOhsPv;

					public ControllerPollingInfo QFECXHBfgWroullVeQwKOmaPapv;

					public ControllerPollingInfo vmDpYWQnFzWnXXTeJePEmfNxcn;

					public ControllerPollingInfo XwIeTvOSTsEANjzNetZuaYfKJcQw;

					public ControllerPollingInfo KZpbcBkPjkIeyqoxyethRTboHCJ;

					public IEnumerator<ControllerPollingInfo> TxLsrUTvgMaxuUreAANuKCxieGo;

					public IEnumerator<ControllerPollingInfo> mBHLRsEkGWGvIQDMBYFfLJsFFYg;

					public IEnumerator<ControllerPollingInfo> KWFFsHNAzjEpkoYERloZkfJcxZS;

					public IEnumerator<ControllerPollingInfo> TycbpOighRlGccQwhRcrgNXQvxxN;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT)
						{
							goto IL_0012;
						}
						goto IL_0085;
						IL_0012:
						int num = 584861013;
						goto IL_0017;
						IL_0017:
						lpVlJfSZpGYbWfeISnUqxCtPXov lpVlJfSZpGYbWfeISnUqxCtPXov2 = default(lpVlJfSZpGYbWfeISnUqxCtPXov);
						while (true)
						{
							switch (num ^ 0x22DC4550)
							{
							case 0:
								break;
							case 3:
								num = 584861014;
								continue;
							case 2:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
								lpVlJfSZpGYbWfeISnUqxCtPXov2 = this;
								num = 584861011;
								continue;
							case 5:
								goto IL_0057;
							case 1:
								lpVlJfSZpGYbWfeISnUqxCtPXov2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
								num = 584861014;
								continue;
							case 4:
								goto IL_0085;
							default:
								return lpVlJfSZpGYbWfeISnUqxCtPXov2;
							}
							break;
							IL_0057:
							int num2;
							if (isaqVUvqwfWYqOUtovbpbCbxgPc != -2)
							{
								num = 584861012;
								num2 = num;
							}
							else
							{
								num = 584861010;
								num2 = num;
							}
						}
						goto IL_0012;
						IL_0085:
						lpVlJfSZpGYbWfeISnUqxCtPXov2 = new lpVlJfSZpGYbWfeISnUqxCtPXov(0);
						num = 584861009;
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
							switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
							{
							case 0:
								isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
								num = 2007284361;
								goto IL_003b;
							case 4:
								goto IL_01ac;
							case 6:
								goto IL_0271;
							case 2:
								goto IL_02a4;
							case 8:
								goto IL_035e;
								IL_003b:
								while (true)
								{
									switch (num ^ 0x77A4BA80)
									{
									case 10:
										num = 2007284366;
										continue;
									case 14:
										break;
									case 19:
										TxLsrUTvgMaxuUreAANuKCxieGo = syCPfFbHYMDOvEPjTnPLBqiOhsPv.BDXqaKgkdRXnsQDcZJDMqkzqcVE().GetEnumerator();
										num = 2007284367;
										continue;
									case 26:
										goto end_IL_0000;
									case 13:
										mBHLRsEkGWGvIQDMBYFfLJsFFYg = syCPfFbHYMDOvEPjTnPLBqiOhsPv.gDkkTbkjunDzYgomHuBtVHKKyugd().GetEnumerator();
										isaqVUvqwfWYqOUtovbpbCbxgPc = 3;
										num = 2007284379;
										continue;
									case 23:
										KZpbcBkPjkIeyqoxyethRTboHCJ = TycbpOighRlGccQwhRcrgNXQvxxN.Current;
										ubyTdixGSFKGaFQFZdQnpwgWIvJ = KZpbcBkPjkIeyqoxyethRTboHCJ;
										isaqVUvqwfWYqOUtovbpbCbxgPc = 8;
										result = true;
										num = 2007284354;
										continue;
									case 3:
										num = 2007284374;
										continue;
									case 0:
										num = 2007284377;
										continue;
									case 5:
										YIvgpFFRALCmSTTrcyNXkRaNlvr();
										KWFFsHNAzjEpkoYERloZkfJcxZS = syCPfFbHYMDOvEPjTnPLBqiOhsPv.miHjzAcBEPKficFvHaAFHcLthBCU().GetEnumerator();
										num = 2007284372;
										continue;
									case 4:
										if (!TxLsrUTvgMaxuUreAANuKCxieGo.MoveNext())
										{
											TfMQOyZIeLsdIrdvDjHoegLwBxF();
											num = 2007284365;
											continue;
										}
										goto case 16;
									case 11:
										goto IL_01ac;
									case 1:
										goto IL_01bd;
									case 8:
										vmDpYWQnFzWnXXTeJePEmfNxcn = mBHLRsEkGWGvIQDMBYFfLJsFFYg.Current;
										ubyTdixGSFKGaFQFZdQnpwgWIvJ = vmDpYWQnFzWnXXTeJePEmfNxcn;
										isaqVUvqwfWYqOUtovbpbCbxgPc = 4;
										result = true;
										num = 2007284358;
										continue;
									case 25:
										if (!TycbpOighRlGccQwhRcrgNXQvxxN.MoveNext())
										{
											hQJrIACBhfElZeDOnJoMpwKmBti();
											num = 2007284376;
											continue;
										}
										goto case 23;
									case 27:
										num = 2007284353;
										continue;
									case 2:
										goto end_IL_0000;
									case 6:
										goto end_IL_0000;
									case 9:
										goto IL_0256;
									case 12:
										goto IL_0271;
									case 20:
										isaqVUvqwfWYqOUtovbpbCbxgPc = 5;
										num = 2007284355;
										continue;
									case 15:
										isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
										num = 2007284356;
										continue;
									case 18:
										goto IL_02a4;
									case 7:
										result = true;
										goto end_IL_0000;
									case 21:
										XwIeTvOSTsEANjzNetZuaYfKJcQw = KWFFsHNAzjEpkoYERloZkfJcxZS.Current;
										ubyTdixGSFKGaFQFZdQnpwgWIvJ = XwIeTvOSTsEANjzNetZuaYfKJcQw;
										isaqVUvqwfWYqOUtovbpbCbxgPc = 6;
										num = 2007284359;
										continue;
									case 16:
										QFECXHBfgWroullVeQwKOmaPapv = TxLsrUTvgMaxuUreAANuKCxieGo.Current;
										ubyTdixGSFKGaFQFZdQnpwgWIvJ = QFECXHBfgWroullVeQwKOmaPapv;
										isaqVUvqwfWYqOUtovbpbCbxgPc = 2;
										result = true;
										num = 2007284378;
										continue;
									case 22:
										if (!KWFFsHNAzjEpkoYERloZkfJcxZS.MoveNext())
										{
											KOBPhOgBBVgkKkIGZKwmEciEoIQM();
											TycbpOighRlGccQwhRcrgNXQvxxN = syCPfFbHYMDOvEPjTnPLBqiOhsPv.SVFjlkKxnzCeeHyjQdOjKFkasqY().GetEnumerator();
											isaqVUvqwfWYqOUtovbpbCbxgPc = 7;
											num = 2007284352;
											continue;
										}
										goto case 21;
									case 17:
										goto IL_035e;
									default:
										goto end_IL_0008;
									}
									break;
									IL_0256:
									int num2;
									if (!CheckInitialized())
									{
										num = 2007284376;
										num2 = num;
									}
									else
									{
										num = 2007284371;
										num2 = num;
									}
									continue;
									IL_01bd:
									int num3;
									if (mBHLRsEkGWGvIQDMBYFfLJsFFYg.MoveNext())
									{
										num = 2007284360;
										num3 = num;
									}
									else
									{
										num = 2007284357;
										num3 = num;
									}
								}
								goto case 0;
								IL_035e:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 7;
								num = 2007284377;
								goto IL_003b;
								IL_02a4:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								num = 2007284356;
								goto IL_003b;
								IL_0271:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 5;
								num = 2007284374;
								goto IL_003b;
								IL_01ac:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 3;
								num = 2007284353;
								goto IL_003b;
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
						switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
						{
						case 1:
						case 2:
							try
							{
							}
							finally
							{
								TfMQOyZIeLsdIrdvDjHoegLwBxF();
							}
							break;
						}
						switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
						{
						case 3:
						case 4:
							try
							{
							}
							finally
							{
								YIvgpFFRALCmSTTrcyNXkRaNlvr();
							}
							break;
						}
						switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
						{
						case 5:
						case 6:
							try
							{
							}
							finally
							{
								KOBPhOgBBVgkKkIGZKwmEciEoIQM();
							}
							break;
						}
						switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
						{
						case 7:
						case 8:
							try
							{
								break;
							}
							finally
							{
								hQJrIACBhfElZeDOnJoMpwKmBti();
							}
						}
					}

					[DebuggerHidden]
					public lpVlJfSZpGYbWfeISnUqxCtPXov(int _003C_003E1__state)
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
						TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
					}

					private void TfMQOyZIeLsdIrdvDjHoegLwBxF()
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						if (TxLsrUTvgMaxuUreAANuKCxieGo != null)
						{
							TxLsrUTvgMaxuUreAANuKCxieGo.Dispose();
						}
					}

					private void YIvgpFFRALCmSTTrcyNXkRaNlvr()
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						if (mBHLRsEkGWGvIQDMBYFfLJsFFYg != null)
						{
							mBHLRsEkGWGvIQDMBYFfLJsFFYg.Dispose();
						}
					}

					private void KOBPhOgBBVgkKkIGZKwmEciEoIQM()
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						while (true)
						{
							int num = 253951661;
							while (true)
							{
								switch (num ^ 0xF22FEAC)
								{
								case 2:
									break;
								default:
									return;
								case 1:
								{
									int num2;
									if (KWFFsHNAzjEpkoYERloZkfJcxZS != null)
									{
										num = 253951663;
										num2 = num;
									}
									else
									{
										num = 253951660;
										num2 = num;
									}
									continue;
								}
								case 3:
									KWFFsHNAzjEpkoYERloZkfJcxZS.Dispose();
									num = 253951660;
									continue;
								case 0:
									return;
								}
								break;
							}
						}
					}

					private void hQJrIACBhfElZeDOnJoMpwKmBti()
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						if (TycbpOighRlGccQwhRcrgNXQvxxN != null)
						{
							TycbpOighRlGccQwhRcrgNXQvxxN.Dispose();
						}
					}
				}

				private sealed class yezJyfgTPrRTMSTqTuVkXnpNjILA : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo ubyTdixGSFKGaFQFZdQnpwgWIvJ;

					private int isaqVUvqwfWYqOUtovbpbCbxgPc;

					private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

					public PollingHelper syCPfFbHYMDOvEPjTnPLBqiOhsPv;

					public ControllerPollingInfo wJemqSZqjghjJbBwRfTvGGuifHPE;

					public ControllerPollingInfo jiiaAWdVPdkDpKxXdZmcWJdliiqa;

					public ControllerPollingInfo QyngTVcJxVLDXNhJpowzvkMWFLju;

					public ControllerPollingInfo ndlLqTahjHALrlFzVzvVaBRsEjoF;

					public IEnumerator<ControllerPollingInfo> uAFMzQddMYbVQJIayLozYkHUUkz;

					public IEnumerator<ControllerPollingInfo> eFWywWKayFlBWalGSSkpcoaVCMwG;

					public IEnumerator<ControllerPollingInfo> WzlhDFVQwSoiysKKBNkMlmYvgwN;

					public IEnumerator<ControllerPollingInfo> IceGtMgGetPJIIweeswSeWZOxwjO;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT)
						{
							goto IL_0012;
						}
						goto IL_005d;
						IL_0012:
						int num = -526657442;
						goto IL_0017;
						IL_0017:
						yezJyfgTPrRTMSTqTuVkXnpNjILA yezJyfgTPrRTMSTqTuVkXnpNjILA2 = default(yezJyfgTPrRTMSTqTuVkXnpNjILA);
						while (true)
						{
							switch (num ^ -526657445)
							{
							case 0:
								break;
							case 5:
								if (isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
								{
									isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
									yezJyfgTPrRTMSTqTuVkXnpNjILA2 = this;
									num = -526657446;
									continue;
								}
								goto IL_005d;
							case 1:
								num = -526657448;
								continue;
							case 4:
								goto IL_005d;
							case 2:
								yezJyfgTPrRTMSTqTuVkXnpNjILA2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
								num = -526657448;
								continue;
							default:
								return yezJyfgTPrRTMSTqTuVkXnpNjILA2;
							}
							break;
						}
						goto IL_0012;
						IL_005d:
						yezJyfgTPrRTMSTqTuVkXnpNjILA2 = new yezJyfgTPrRTMSTqTuVkXnpNjILA(0);
						num = -526657447;
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
							switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
							{
							case 0:
								isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
								if (!CheckInitialized())
								{
									break;
								}
								uAFMzQddMYbVQJIayLozYkHUUkz = syCPfFbHYMDOvEPjTnPLBqiOhsPv.yfDsFsjsoHAnEBROnABWDkWqawLb().GetEnumerator();
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								num = 649381494;
								goto IL_003b;
							case 6:
								goto IL_011f;
							case 4:
								goto IL_0157;
							case 8:
								goto IL_01e8;
							case 2:
								goto IL_02d9;
								IL_011f:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 5;
								num = 649381499;
								goto IL_003b;
								IL_003b:
								while (true)
								{
									switch (num ^ 0x26B4C67E)
									{
									case 7:
										num = 649381487;
										continue;
									case 17:
										break;
									case 10:
										jiiaAWdVPdkDpKxXdZmcWJdliiqa = eFWywWKayFlBWalGSSkpcoaVCMwG.Current;
										ubyTdixGSFKGaFQFZdQnpwgWIvJ = jiiaAWdVPdkDpKxXdZmcWJdliiqa;
										isaqVUvqwfWYqOUtovbpbCbxgPc = 4;
										num = 649381483;
										continue;
									case 2:
										num = 649381501;
										continue;
									case 21:
										result = true;
										num = 649381484;
										continue;
									case 13:
										goto IL_011f;
									case 16:
										QyngTVcJxVLDXNhJpowzvkMWFLju = WzlhDFVQwSoiysKKBNkMlmYvgwN.Current;
										ubyTdixGSFKGaFQFZdQnpwgWIvJ = QyngTVcJxVLDXNhJpowzvkMWFLju;
										num = 649381488;
										continue;
									case 0:
										goto IL_0157;
									case 14:
										isaqVUvqwfWYqOUtovbpbCbxgPc = 6;
										result = true;
										goto end_IL_0000;
									case 5:
										if (!WzlhDFVQwSoiysKKBNkMlmYvgwN.MoveNext())
										{
											mHrSvXNVperOxvJbayQHhbMbiCCK();
											IceGtMgGetPJIIweeswSeWZOxwjO = syCPfFbHYMDOvEPjTnPLBqiOhsPv.yANCwRtKvhWoObLgMNqrbnsSYcX().GetEnumerator();
											isaqVUvqwfWYqOUtovbpbCbxgPc = 7;
											num = 649381500;
											continue;
										}
										goto case 16;
									case 9:
										wJemqSZqjghjJbBwRfTvGGuifHPE = uAFMzQddMYbVQJIayLozYkHUUkz.Current;
										ubyTdixGSFKGaFQFZdQnpwgWIvJ = wJemqSZqjghjJbBwRfTvGGuifHPE;
										isaqVUvqwfWYqOUtovbpbCbxgPc = 2;
										num = 649381490;
										continue;
									case 6:
										goto IL_01e8;
									case 15:
										ndlLqTahjHALrlFzVzvVaBRsEjoF = IceGtMgGetPJIIweeswSeWZOxwjO.Current;
										num = 649381503;
										continue;
									case 12:
										result = true;
										goto end_IL_0000;
									case 8:
										if (!uAFMzQddMYbVQJIayLozYkHUUkz.MoveNext())
										{
											HEOeFelOjEcadbNphxakdHoHGak();
											eFWywWKayFlBWalGSSkpcoaVCMwG = syCPfFbHYMDOvEPjTnPLBqiOhsPv.YFihCQKfLwUlPaHilGyRDWbGGEhs().GetEnumerator();
											isaqVUvqwfWYqOUtovbpbCbxgPc = 3;
											num = 649381498;
											continue;
										}
										goto case 9;
									case 4:
										if (!eFWywWKayFlBWalGSSkpcoaVCMwG.MoveNext())
										{
											HpYLBXjvkdnPzyeKrgcXUgkPjQMf();
											WzlhDFVQwSoiysKKBNkMlmYvgwN = syCPfFbHYMDOvEPjTnPLBqiOhsPv.UiOxmgBhnVCFFDwxMrlvZtxFpLb().GetEnumerator();
											isaqVUvqwfWYqOUtovbpbCbxgPc = 5;
											num = 649381499;
											continue;
										}
										goto case 10;
									case 1:
										ubyTdixGSFKGaFQFZdQnpwgWIvJ = ndlLqTahjHALrlFzVzvVaBRsEjoF;
										isaqVUvqwfWYqOUtovbpbCbxgPc = 8;
										result = true;
										goto end_IL_0000;
									case 20:
										VWXpEzaviiroRAaphyXwPUmCRqK();
										num = 649381485;
										continue;
									case 18:
										goto end_IL_0000;
									case 11:
										goto IL_02d9;
									case 3:
										goto IL_02ea;
									default:
										goto end_IL_0008;
									}
									break;
									IL_02ea:
									int num2;
									if (IceGtMgGetPJIIweeswSeWZOxwjO.MoveNext())
									{
										num = 649381489;
										num2 = num;
									}
									else
									{
										num = 649381482;
										num2 = num;
									}
								}
								goto case 0;
								IL_02d9:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								num = 649381494;
								goto IL_003b;
								IL_01e8:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 7;
								num = 649381501;
								goto IL_003b;
								IL_0157:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 3;
								num = 649381498;
								goto IL_003b;
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
						switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
						{
						case 1:
						case 2:
							try
							{
							}
							finally
							{
								HEOeFelOjEcadbNphxakdHoHGak();
							}
							break;
						}
						switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
						{
						case 3:
						case 4:
							try
							{
							}
							finally
							{
								HpYLBXjvkdnPzyeKrgcXUgkPjQMf();
							}
							break;
						}
						switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
						{
						case 5:
						case 6:
							try
							{
							}
							finally
							{
								mHrSvXNVperOxvJbayQHhbMbiCCK();
							}
							break;
						}
						switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
						{
						case 7:
						case 8:
							try
							{
								break;
							}
							finally
							{
								VWXpEzaviiroRAaphyXwPUmCRqK();
							}
						}
					}

					[DebuggerHidden]
					public yezJyfgTPrRTMSTqTuVkXnpNjILA(int _003C_003E1__state)
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
						TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
					}

					private void HEOeFelOjEcadbNphxakdHoHGak()
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						while (true)
						{
							int num = -788188852;
							while (true)
							{
								switch (num ^ -788188849)
								{
								case 0:
									break;
								default:
									return;
								case 3:
								{
									int num2;
									if (uAFMzQddMYbVQJIayLozYkHUUkz != null)
									{
										num = -788188851;
										num2 = num;
									}
									else
									{
										num = -788188850;
										num2 = num;
									}
									continue;
								}
								case 2:
									uAFMzQddMYbVQJIayLozYkHUUkz.Dispose();
									num = -788188850;
									continue;
								case 1:
									return;
								}
								break;
							}
						}
					}

					private void HpYLBXjvkdnPzyeKrgcXUgkPjQMf()
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						if (eFWywWKayFlBWalGSSkpcoaVCMwG != null)
						{
							eFWywWKayFlBWalGSSkpcoaVCMwG.Dispose();
						}
					}

					private void mHrSvXNVperOxvJbayQHhbMbiCCK()
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						while (true)
						{
							int num = 1974357966;
							while (true)
							{
								switch (num ^ 0x75AE4FCC)
								{
								case 0:
									break;
								default:
									return;
								case 2:
								{
									int num2;
									if (WzlhDFVQwSoiysKKBNkMlmYvgwN != null)
									{
										num = 1974357965;
										num2 = num;
									}
									else
									{
										num = 1974357967;
										num2 = num;
									}
									continue;
								}
								case 1:
									WzlhDFVQwSoiysKKBNkMlmYvgwN.Dispose();
									num = 1974357967;
									continue;
								case 3:
									return;
								}
								break;
							}
						}
					}

					private void VWXpEzaviiroRAaphyXwPUmCRqK()
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						if (IceGtMgGetPJIIweeswSeWZOxwjO != null)
						{
							IceGtMgGetPJIIweeswSeWZOxwjO.Dispose();
						}
					}
				}

				private sealed class NQNGCMlghAaBBZoEfGomQfLTEuO : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo ubyTdixGSFKGaFQFZdQnpwgWIvJ;

					private int isaqVUvqwfWYqOUtovbpbCbxgPc;

					private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

					public PollingHelper syCPfFbHYMDOvEPjTnPLBqiOhsPv;

					public ControllerPollingInfo eAEdMqhfEzIOanjXSLmInIeuwGOd;

					public ControllerPollingInfo XEyBcTQLJpolWlpqJQiUzfcVHzbC;

					public ControllerPollingInfo GcDCdsJcLBzMLMrajrszPixZekO;

					public IEnumerator<ControllerPollingInfo> FpFSrkqldeAdbjTLJJJuDuEjpYlB;

					public IEnumerator<ControllerPollingInfo> BEKMBfWflZhAkgLSwDpnxUnSgbla;

					public IEnumerator<ControllerPollingInfo> MiqPGGngGxEzKjGFbJLjOYaBzxO;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						NQNGCMlghAaBBZoEfGomQfLTEuO nQNGCMlghAaBBZoEfGomQfLTEuO;
						if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
						{
							isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
							nQNGCMlghAaBBZoEfGomQfLTEuO = this;
						}
						else
						{
							while (true)
							{
								nQNGCMlghAaBBZoEfGomQfLTEuO = new NQNGCMlghAaBBZoEfGomQfLTEuO(0);
								int num = 731147996;
								while (true)
								{
									switch (num ^ 0x2B946EDE)
									{
									case 3:
										num = 731147999;
										continue;
									case 1:
										break;
									case 2:
										nQNGCMlghAaBBZoEfGomQfLTEuO.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
										num = 731147998;
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
						return nQNGCMlghAaBBZoEfGomQfLTEuO;
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
							switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
							{
							case 0:
								isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
								if (!CheckInitialized())
								{
									break;
								}
								FpFSrkqldeAdbjTLJJJuDuEjpYlB = syCPfFbHYMDOvEPjTnPLBqiOhsPv.QvjbdreJYHJzNNJNaAIIcVLhlbRh().GetEnumerator();
								num = -1565948785;
								goto IL_0033;
							case 2:
								goto IL_011a;
							case 4:
								goto IL_0157;
							case 6:
								goto IL_0237;
								IL_011a:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								num = -1565948771;
								goto IL_0033;
								IL_0033:
								while (true)
								{
									switch (num ^ -1565948787)
									{
									case 7:
										num = -1565948795;
										continue;
									case 9:
										eAEdMqhfEzIOanjXSLmInIeuwGOd = FpFSrkqldeAdbjTLJJJuDuEjpYlB.Current;
										num = -1565948769;
										continue;
									case 16:
										if (!FpFSrkqldeAdbjTLJJJuDuEjpYlB.MoveNext())
										{
											mdhpGlGTkmJkKNMDmaBKWSEOlBv();
											BEKMBfWflZhAkgLSwDpnxUnSgbla = syCPfFbHYMDOvEPjTnPLBqiOhsPv.YeTNaUxKHwpcBUcxqVFBXqJQpoA().GetEnumerator();
											isaqVUvqwfWYqOUtovbpbCbxgPc = 3;
											num = -1565948786;
											continue;
										}
										goto case 9;
									case 8:
										break;
									case 19:
										goto IL_011a;
									case 15:
										num = -1565948800;
										continue;
									case 0:
										num = -1565948771;
										continue;
									case 6:
										isaqVUvqwfWYqOUtovbpbCbxgPc = 4;
										result = true;
										goto end_IL_0000;
									case 14:
										goto IL_0157;
									case 18:
										ubyTdixGSFKGaFQFZdQnpwgWIvJ = eAEdMqhfEzIOanjXSLmInIeuwGOd;
										isaqVUvqwfWYqOUtovbpbCbxgPc = 2;
										result = true;
										num = -1565948772;
										continue;
									case 17:
										goto end_IL_0000;
									case 11:
										cVvUlcbSRnPvqnQISzPRqqltmdE();
										num = -1565948791;
										continue;
									case 1:
										XEyBcTQLJpolWlpqJQiUzfcVHzbC = BEKMBfWflZhAkgLSwDpnxUnSgbla.Current;
										num = -1565948792;
										continue;
									case 3:
										num = -1565948775;
										continue;
									case 2:
										isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
										num = -1565948787;
										continue;
									case 20:
										if (!BEKMBfWflZhAkgLSwDpnxUnSgbla.MoveNext())
										{
											uogzzfXrKNRANPyMjWEXbIQkaYK();
											MiqPGGngGxEzKjGFbJLjOYaBzxO = syCPfFbHYMDOvEPjTnPLBqiOhsPv.uIKiytJDnwrkAnLZdNXPAObcvAE().GetEnumerator();
											isaqVUvqwfWYqOUtovbpbCbxgPc = 5;
											num = -1565948798;
											continue;
										}
										goto case 1;
									case 13:
										goto IL_0216;
									case 12:
										goto IL_0237;
									case 5:
										ubyTdixGSFKGaFQFZdQnpwgWIvJ = XEyBcTQLJpolWlpqJQiUzfcVHzbC;
										num = -1565948789;
										continue;
									case 10:
										GcDCdsJcLBzMLMrajrszPixZekO = MiqPGGngGxEzKjGFbJLjOYaBzxO.Current;
										ubyTdixGSFKGaFQFZdQnpwgWIvJ = GcDCdsJcLBzMLMrajrszPixZekO;
										isaqVUvqwfWYqOUtovbpbCbxgPc = 6;
										result = true;
										goto end_IL_0000;
									default:
										goto end_IL_0008;
									}
									break;
									IL_0216:
									int num2;
									if (MiqPGGngGxEzKjGFbJLjOYaBzxO.MoveNext())
									{
										num = -1565948793;
										num2 = num;
									}
									else
									{
										num = -1565948794;
										num2 = num;
									}
								}
								goto case 0;
								IL_0237:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 5;
								num = -1565948800;
								goto IL_0033;
								IL_0157:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 3;
								num = -1565948775;
								goto IL_0033;
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
						switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
						{
						case 1:
						case 2:
							try
							{
							}
							finally
							{
								mdhpGlGTkmJkKNMDmaBKWSEOlBv();
							}
							break;
						}
						switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
						{
						case 3:
						case 4:
							try
							{
							}
							finally
							{
								uogzzfXrKNRANPyMjWEXbIQkaYK();
							}
							break;
						}
						switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
						{
						case 5:
						case 6:
							try
							{
								break;
							}
							finally
							{
								cVvUlcbSRnPvqnQISzPRqqltmdE();
							}
						}
					}

					[DebuggerHidden]
					public NQNGCMlghAaBBZoEfGomQfLTEuO(int _003C_003E1__state)
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
						TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
					}

					private void mdhpGlGTkmJkKNMDmaBKWSEOlBv()
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						if (FpFSrkqldeAdbjTLJJJuDuEjpYlB != null)
						{
							FpFSrkqldeAdbjTLJJJuDuEjpYlB.Dispose();
						}
					}

					private void uogzzfXrKNRANPyMjWEXbIQkaYK()
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						while (true)
						{
							int num = 1545020302;
							while (true)
							{
								switch (num ^ 0x5C17238F)
								{
								case 2:
									break;
								default:
									return;
								case 1:
								{
									int num2;
									if (BEKMBfWflZhAkgLSwDpnxUnSgbla == null)
									{
										num = 1545020300;
										num2 = num;
									}
									else
									{
										num = 1545020303;
										num2 = num;
									}
									continue;
								}
								case 0:
									BEKMBfWflZhAkgLSwDpnxUnSgbla.Dispose();
									num = 1545020300;
									continue;
								case 3:
									return;
								}
								break;
							}
						}
					}

					private void cVvUlcbSRnPvqnQISzPRqqltmdE()
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						if (MiqPGGngGxEzKjGFbJLjOYaBzxO == null)
						{
							return;
						}
						while (true)
						{
							int num = 1003673854;
							while (true)
							{
								switch (num ^ 0x3BD2D8FC)
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
								MiqPGGngGxEzKjGFbJLjOYaBzxO.Dispose();
								num = 1003673853;
							}
						}
					}
				}

				private sealed class dkIDgLCpKXZMGYQQLNKDkcjaJGh : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo ubyTdixGSFKGaFQFZdQnpwgWIvJ;

					private int isaqVUvqwfWYqOUtovbpbCbxgPc;

					private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

					public IList<Joystick> eYgZExFnWbFTHWNUSgpTcPOXCCQ;

					public int jTeUcnuCgJDBMGojCNMdufHRKBF;

					public ControllerPollingInfo YUkcAJhjclMjzyRxepRagAMeayIU;

					public PollingHelper syCPfFbHYMDOvEPjTnPLBqiOhsPv;

					public IEnumerator<ControllerPollingInfo> TUMPhGcpLfatkjwWxWDoPjcbrwFI;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT)
						{
							goto IL_0012;
						}
						goto IL_0050;
						IL_0012:
						int num = 1525493219;
						goto IL_0017;
						IL_0017:
						dkIDgLCpKXZMGYQQLNKDkcjaJGh dkIDgLCpKXZMGYQQLNKDkcjaJGh2 = default(dkIDgLCpKXZMGYQQLNKDkcjaJGh);
						while (true)
						{
							switch (num ^ 0x5AED2DE7)
							{
							case 2:
								break;
							case 4:
								if (isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
								{
									isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
									num = 1525493220;
									continue;
								}
								goto IL_0050;
							case 0:
								goto IL_0050;
							case 3:
								dkIDgLCpKXZMGYQQLNKDkcjaJGh2 = this;
								num = 1525493222;
								continue;
							default:
								return dkIDgLCpKXZMGYQQLNKDkcjaJGh2;
							}
							break;
						}
						goto IL_0012;
						IL_0050:
						dkIDgLCpKXZMGYQQLNKDkcjaJGh2 = new dkIDgLCpKXZMGYQQLNKDkcjaJGh(0);
						dkIDgLCpKXZMGYQQLNKDkcjaJGh2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
						num = 1525493222;
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
							int num = isaqVUvqwfWYqOUtovbpbCbxgPc;
							while (true)
							{
								IL_0007:
								int num2 = 1109548120;
								while (true)
								{
									switch (num2 ^ 0x42225C5C)
									{
									case 5:
										break;
									default:
										goto end_IL_000c;
									case 2:
										jTeUcnuCgJDBMGojCNMdufHRKBF++;
										num2 = 1109548125;
										continue;
									case 6:
										if (!TUMPhGcpLfatkjwWxWDoPjcbrwFI.MoveNext())
										{
											jJFAhUSCKSBiEIJVGHstzTzZCbl();
											num2 = 1109548126;
											continue;
										}
										goto case 7;
									case 4:
										switch (num)
										{
										case 0:
											goto IL_00fe;
										case 2:
											goto IL_011f;
										case 1:
											goto IL_0130;
										}
										num2 = 1109548119;
										continue;
									case 7:
										YUkcAJhjclMjzyRxepRagAMeayIU = TUMPhGcpLfatkjwWxWDoPjcbrwFI.Current;
										ubyTdixGSFKGaFQFZdQnpwgWIvJ = YUkcAJhjclMjzyRxepRagAMeayIU;
										isaqVUvqwfWYqOUtovbpbCbxgPc = 2;
										result = true;
										goto end_IL_000c;
									case 3:
										TUMPhGcpLfatkjwWxWDoPjcbrwFI = eYgZExFnWbFTHWNUSgpTcPOXCCQ[jTeUcnuCgJDBMGojCNMdufHRKBF].PollForAllElements().GetEnumerator();
										isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
										num2 = 1109548122;
										continue;
									case 8:
										goto IL_00fe;
									case 0:
										goto IL_011f;
									case 11:
										goto IL_0130;
									case 9:
										jTeUcnuCgJDBMGojCNMdufHRKBF = 0;
										num2 = 1109548125;
										continue;
									case 1:
									{
										int num3;
										if (jTeUcnuCgJDBMGojCNMdufHRKBF < eYgZExFnWbFTHWNUSgpTcPOXCCQ.Count)
										{
											num2 = 1109548127;
											num3 = num2;
										}
										else
										{
											num2 = 1109548119;
											num3 = num2;
										}
										continue;
									}
									case 10:
										goto end_IL_000c;
										IL_0130:
										result = false;
										num2 = 1109548118;
										continue;
										IL_011f:
										isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
										num2 = 1109548122;
										continue;
										IL_00fe:
										isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
										eYgZExFnWbFTHWNUSgpTcPOXCCQ = akUdmKMbrqFLXkjqdKLUZOPTArx.Joysticks_readOnly;
										num2 = 1109548117;
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
						switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								jJFAhUSCKSBiEIJVGHstzTzZCbl();
							}
						}
					}

					[DebuggerHidden]
					public dkIDgLCpKXZMGYQQLNKDkcjaJGh(int _003C_003E1__state)
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
						TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
					}

					private void jJFAhUSCKSBiEIJVGHstzTzZCbl()
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						if (TUMPhGcpLfatkjwWxWDoPjcbrwFI != null)
						{
							TUMPhGcpLfatkjwWxWDoPjcbrwFI.Dispose();
						}
					}
				}

				private sealed class pZOjNisemGjFNZVPXFnTVhYbwti : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo ubyTdixGSFKGaFQFZdQnpwgWIvJ;

					private int isaqVUvqwfWYqOUtovbpbCbxgPc;

					private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

					public IList<Joystick> lhrJxdbdZAgkBSLdQRSVtFvnIzb;

					public int FJjePFcgYXiIYSLSZTlxUHefuhO;

					public ControllerPollingInfo QEuhwbwFdmKRctitLtFfLhlxDEL;

					public PollingHelper syCPfFbHYMDOvEPjTnPLBqiOhsPv;

					public IEnumerator<ControllerPollingInfo> ZpERzzCKXeqSnQMfVHkKALnAnMh;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT)
						{
							goto IL_0012;
						}
						goto IL_0038;
						IL_0012:
						int num = -1369311985;
						goto IL_0017;
						IL_0017:
						pZOjNisemGjFNZVPXFnTVhYbwti pZOjNisemGjFNZVPXFnTVhYbwti2 = default(pZOjNisemGjFNZVPXFnTVhYbwti);
						while (true)
						{
							switch (num ^ -1369311986)
							{
							case 4:
								break;
							case 0:
								goto IL_0038;
							case 3:
								pZOjNisemGjFNZVPXFnTVhYbwti2 = this;
								num = -1369311988;
								continue;
							case 1:
								if (isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
								{
									isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
									num = -1369311987;
									continue;
								}
								goto IL_0038;
							default:
								return pZOjNisemGjFNZVPXFnTVhYbwti2;
							}
							break;
						}
						goto IL_0012;
						IL_0038:
						pZOjNisemGjFNZVPXFnTVhYbwti2 = new pZOjNisemGjFNZVPXFnTVhYbwti(0);
						pZOjNisemGjFNZVPXFnTVhYbwti2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
						num = -1369311988;
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
							switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
							{
							default:
								num = 2105084952;
								goto IL_001e;
							case 0:
								goto IL_0127;
							case 2:
								goto IL_014f;
							case 1:
								break;
								IL_001e:
								while (true)
								{
									switch (num ^ 0x7D790C1E)
									{
									case 9:
										break;
									case 8:
										goto IL_0056;
									case 2:
										ZpERzzCKXeqSnQMfVHkKALnAnMh = lhrJxdbdZAgkBSLdQRSVtFvnIzb[FJjePFcgYXiIYSLSZTlxUHefuhO].PollForAllElementsDown().GetEnumerator();
										isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
										num = 2105084950;
										continue;
									case 4:
										goto IL_00a6;
									case 1:
										QEuhwbwFdmKRctitLtFfLhlxDEL = ZpERzzCKXeqSnQMfVHkKALnAnMh.Current;
										ubyTdixGSFKGaFQFZdQnpwgWIvJ = QEuhwbwFdmKRctitLtFfLhlxDEL;
										isaqVUvqwfWYqOUtovbpbCbxgPc = 2;
										return true;
									case 7:
										dCmZMRRjmdVTzSQlfrziQpAzsCd();
										FJjePFcgYXiIYSLSZTlxUHefuhO++;
										num = 2105084954;
										continue;
									case 6:
										num = 2105084955;
										continue;
									case 0:
										goto IL_0127;
									case 3:
										goto IL_014f;
									default:
										goto end_IL_0008;
									}
									break;
									IL_00a6:
									int num2;
									if (FJjePFcgYXiIYSLSZTlxUHefuhO >= lhrJxdbdZAgkBSLdQRSVtFvnIzb.Count)
									{
										num = 2105084955;
										num2 = num;
									}
									else
									{
										num = 2105084956;
										num2 = num;
									}
									continue;
									IL_0056:
									int num3;
									if (ZpERzzCKXeqSnQMfVHkKALnAnMh.MoveNext())
									{
										num = 2105084959;
										num3 = num;
									}
									else
									{
										num = 2105084953;
										num3 = num;
									}
								}
								goto default;
								IL_014f:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								num = 2105084950;
								goto IL_001e;
								IL_0127:
								isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
								lhrJxdbdZAgkBSLdQRSVtFvnIzb = akUdmKMbrqFLXkjqdKLUZOPTArx.Joysticks_readOnly;
								FJjePFcgYXiIYSLSZTlxUHefuhO = 0;
								num = 2105084954;
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
						switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								dCmZMRRjmdVTzSQlfrziQpAzsCd();
							}
						}
					}

					[DebuggerHidden]
					public pZOjNisemGjFNZVPXFnTVhYbwti(int _003C_003E1__state)
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
						TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
					}

					private void dCmZMRRjmdVTzSQlfrziQpAzsCd()
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						while (true)
						{
							int num = -573790382;
							while (true)
							{
								switch (num ^ -573790383)
								{
								case 0:
									break;
								default:
									return;
								case 3:
								{
									int num2;
									if (ZpERzzCKXeqSnQMfVHkKALnAnMh != null)
									{
										num = -573790381;
										num2 = num;
									}
									else
									{
										num = -573790384;
										num2 = num;
									}
									continue;
								}
								case 2:
									ZpERzzCKXeqSnQMfVHkKALnAnMh.Dispose();
									num = -573790384;
									continue;
								case 1:
									return;
								}
								break;
							}
						}
					}
				}

				private sealed class xsWzHrRPSUThAKavRAGqFEaAFlih : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo ubyTdixGSFKGaFQFZdQnpwgWIvJ;

					private int isaqVUvqwfWYqOUtovbpbCbxgPc;

					private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

					public IList<Joystick> iqjlZGfggZFWpAMeKbbqweoRAorg;

					public int jjDhTodkwdaBlEooaLLSoAnAUKer;

					public ControllerPollingInfo nCscKddyAUrgUPeDLNfcXXcWVfUC;

					public PollingHelper syCPfFbHYMDOvEPjTnPLBqiOhsPv;

					public IEnumerator<ControllerPollingInfo> ORlrhsyfYjiWhizLVQVWcIwOSVO;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT)
						{
							goto IL_0012;
						}
						goto IL_004e;
						IL_0012:
						int num = -1664186755;
						goto IL_0017;
						IL_0017:
						xsWzHrRPSUThAKavRAGqFEaAFlih xsWzHrRPSUThAKavRAGqFEaAFlih2 = default(xsWzHrRPSUThAKavRAGqFEaAFlih);
						while (true)
						{
							switch (num ^ -1664186756)
							{
							case 3:
								break;
							case 1:
								if (isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
								{
									isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
									xsWzHrRPSUThAKavRAGqFEaAFlih2 = this;
									num = -1664186756;
									continue;
								}
								goto IL_004e;
							case 2:
								goto IL_004e;
							default:
								return xsWzHrRPSUThAKavRAGqFEaAFlih2;
							}
							break;
						}
						goto IL_0012;
						IL_004e:
						xsWzHrRPSUThAKavRAGqFEaAFlih2 = new xsWzHrRPSUThAKavRAGqFEaAFlih(0);
						xsWzHrRPSUThAKavRAGqFEaAFlih2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
						num = -1664186756;
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
							int num = isaqVUvqwfWYqOUtovbpbCbxgPc;
							while (true)
							{
								int num2 = -2036283370;
								while (true)
								{
									switch (num2 ^ -2036283369)
									{
									case 2:
										break;
									case 1:
										switch (num)
										{
										case 0:
											goto IL_0065;
										case 2:
											goto IL_0093;
										case 1:
											goto IL_0172;
										}
										num2 = -2036283362;
										continue;
									case 5:
										goto IL_0065;
									case 11:
										if (!ORlrhsyfYjiWhizLVQVWcIwOSVO.MoveNext())
										{
											gCudOhfFrSNsMwWaWfnaeiRwuIyg();
											num2 = -2036283375;
											continue;
										}
										goto case 3;
									case 0:
										goto IL_0093;
									case 8:
										ORlrhsyfYjiWhizLVQVWcIwOSVO = iqjlZGfggZFWpAMeKbbqweoRAorg[jjDhTodkwdaBlEooaLLSoAnAUKer].PollForAllButtons().GetEnumerator();
										num2 = -2036283363;
										continue;
									case 6:
										jjDhTodkwdaBlEooaLLSoAnAUKer++;
										num2 = -2036283376;
										continue;
									case 7:
									{
										int num3;
										if (jjDhTodkwdaBlEooaLLSoAnAUKer < iqjlZGfggZFWpAMeKbbqweoRAorg.Count)
										{
											num2 = -2036283361;
											num3 = num2;
										}
										else
										{
											num2 = -2036283362;
											num3 = num2;
										}
										continue;
									}
									case 3:
										nCscKddyAUrgUPeDLNfcXXcWVfUC = ORlrhsyfYjiWhizLVQVWcIwOSVO.Current;
										ubyTdixGSFKGaFQFZdQnpwgWIvJ = nCscKddyAUrgUPeDLNfcXXcWVfUC;
										isaqVUvqwfWYqOUtovbpbCbxgPc = 2;
										return true;
									case 10:
										isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
										num2 = -2036283364;
										continue;
									case 4:
										iqjlZGfggZFWpAMeKbbqweoRAorg = akUdmKMbrqFLXkjqdKLUZOPTArx.Joysticks_readOnly;
										jjDhTodkwdaBlEooaLLSoAnAUKer = 0;
										num2 = -2036283376;
										continue;
									default:
										goto IL_0172;
										IL_0172:
										return false;
										IL_0093:
										isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
										num2 = -2036283364;
										continue;
										IL_0065:
										isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
										num2 = -2036283373;
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
						switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								gCudOhfFrSNsMwWaWfnaeiRwuIyg();
							}
						}
					}

					[DebuggerHidden]
					public xsWzHrRPSUThAKavRAGqFEaAFlih(int _003C_003E1__state)
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
						TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
					}

					private void gCudOhfFrSNsMwWaWfnaeiRwuIyg()
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						if (ORlrhsyfYjiWhizLVQVWcIwOSVO != null)
						{
							ORlrhsyfYjiWhizLVQVWcIwOSVO.Dispose();
						}
					}
				}

				private sealed class mLlMreOaVeQADWdmmZyMbcAccsv : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo ubyTdixGSFKGaFQFZdQnpwgWIvJ;

					private int isaqVUvqwfWYqOUtovbpbCbxgPc;

					private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

					public IList<Joystick> vYfmbPaPFUwWHhBvnFtFdlyqxpA;

					public int GtYLnJmNXJqUKYyrGkGFvxgPmQU;

					public ControllerPollingInfo ltAhHWwAESkNBtWdEqqMgPkpvjg;

					public PollingHelper syCPfFbHYMDOvEPjTnPLBqiOhsPv;

					public IEnumerator<ControllerPollingInfo> NgmWFAmwJAzSdWidibLhmDnFWlI;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT)
						{
							goto IL_0012;
						}
						goto IL_0038;
						IL_0012:
						int num = 799665245;
						goto IL_0017;
						IL_0017:
						mLlMreOaVeQADWdmmZyMbcAccsv mLlMreOaVeQADWdmmZyMbcAccsv2 = default(mLlMreOaVeQADWdmmZyMbcAccsv);
						while (true)
						{
							switch (num ^ 0x2FA9EC5C)
							{
							case 3:
								break;
							case 0:
								goto IL_0038;
							case 2:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
								mLlMreOaVeQADWdmmZyMbcAccsv2 = this;
								num = 799665240;
								continue;
							case 1:
								goto IL_0062;
							default:
								return mLlMreOaVeQADWdmmZyMbcAccsv2;
							}
							break;
							IL_0062:
							int num2;
							if (isaqVUvqwfWYqOUtovbpbCbxgPc != -2)
							{
								num = 799665244;
								num2 = num;
							}
							else
							{
								num = 799665246;
								num2 = num;
							}
						}
						goto IL_0012;
						IL_0038:
						mLlMreOaVeQADWdmmZyMbcAccsv2 = new mLlMreOaVeQADWdmmZyMbcAccsv(0);
						mLlMreOaVeQADWdmmZyMbcAccsv2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
						num = 799665240;
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
							switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
							{
							default:
								num = -1018404172;
								goto IL_001e;
							case 0:
								goto IL_0076;
							case 2:
								goto IL_00a5;
							case 1:
								goto IL_0148;
								IL_001e:
								while (true)
								{
									switch (num ^ -1018404171)
									{
									case 4:
										break;
									default:
										goto end_IL_0008;
									case 3:
										ltAhHWwAESkNBtWdEqqMgPkpvjg = NgmWFAmwJAzSdWidibLhmDnFWlI.Current;
										num = -1018404162;
										continue;
									case 7:
										goto IL_0076;
									case 1:
										num = -1018404169;
										continue;
									case 5:
										goto IL_00a5;
									case 10:
										NgmWFAmwJAzSdWidibLhmDnFWlI = vYfmbPaPFUwWHhBvnFtFdlyqxpA[GtYLnJmNXJqUKYyrGkGFvxgPmQU].PollForAllButtonsDown().GetEnumerator();
										isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
										num = -1018404163;
										continue;
									case 0:
										goto IL_00e8;
									case 11:
										ubyTdixGSFKGaFQFZdQnpwgWIvJ = ltAhHWwAESkNBtWdEqqMgPkpvjg;
										isaqVUvqwfWYqOUtovbpbCbxgPc = 2;
										result = true;
										goto end_IL_0008;
									case 6:
										GtYLnJmNXJqUKYyrGkGFvxgPmQU++;
										num = -1018404171;
										continue;
									case 2:
										goto IL_0148;
									case 8:
										if (!NgmWFAmwJAzSdWidibLhmDnFWlI.MoveNext())
										{
											XoLpRuOfqrFVSTKQawyanYiycRJ();
											num = -1018404173;
											continue;
										}
										goto case 3;
									case 9:
										goto end_IL_0008;
									}
									break;
									IL_00e8:
									int num2;
									if (GtYLnJmNXJqUKYyrGkGFvxgPmQU < vYfmbPaPFUwWHhBvnFtFdlyqxpA.Count)
									{
										num = -1018404161;
										num2 = num;
									}
									else
									{
										num = -1018404169;
										num2 = num;
									}
								}
								goto default;
								IL_0148:
								result = false;
								num = -1018404164;
								goto IL_001e;
								IL_00a5:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								num = -1018404163;
								goto IL_001e;
								IL_0076:
								isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
								vYfmbPaPFUwWHhBvnFtFdlyqxpA = akUdmKMbrqFLXkjqdKLUZOPTArx.Joysticks_readOnly;
								GtYLnJmNXJqUKYyrGkGFvxgPmQU = 0;
								num = -1018404171;
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
						switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								XoLpRuOfqrFVSTKQawyanYiycRJ();
							}
						}
					}

					[DebuggerHidden]
					public mLlMreOaVeQADWdmmZyMbcAccsv(int _003C_003E1__state)
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
						TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
					}

					private void XoLpRuOfqrFVSTKQawyanYiycRJ()
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						if (NgmWFAmwJAzSdWidibLhmDnFWlI != null)
						{
							NgmWFAmwJAzSdWidibLhmDnFWlI.Dispose();
						}
					}
				}

				private sealed class OkxqYpsMDyntDaPWZdaQdXNvnDBw : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo ubyTdixGSFKGaFQFZdQnpwgWIvJ;

					private int isaqVUvqwfWYqOUtovbpbCbxgPc;

					private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

					public IList<Joystick> dIwJKlpiRTASvaviiLFTfGakHJEv;

					public int OCZkzcJysedFVmUktoQyzvUBaDi;

					public ControllerPollingInfo YBizYLEoZTnaUkJjJsBoFiqojvc;

					public PollingHelper syCPfFbHYMDOvEPjTnPLBqiOhsPv;

					public IEnumerator<ControllerPollingInfo> qMLKSndTBShtpXRjRyIFxNWktwG;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						OkxqYpsMDyntDaPWZdaQdXNvnDBw okxqYpsMDyntDaPWZdaQdXNvnDBw;
						if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
						{
							isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
							okxqYpsMDyntDaPWZdaQdXNvnDBw = this;
						}
						else
						{
							while (true)
							{
								okxqYpsMDyntDaPWZdaQdXNvnDBw = new OkxqYpsMDyntDaPWZdaQdXNvnDBw(0);
								okxqYpsMDyntDaPWZdaQdXNvnDBw.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
								int num = 571603610;
								while (true)
								{
									switch (num ^ 0x2211FA98)
									{
									case 0:
										num = 571603609;
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
						return okxqYpsMDyntDaPWZdaQdXNvnDBw;
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
							int num = isaqVUvqwfWYqOUtovbpbCbxgPc;
							while (true)
							{
								IL_0007:
								int num2 = 1265280893;
								while (true)
								{
									switch (num2 ^ 0x4B6AA775)
									{
									case 11:
										break;
									default:
										goto end_IL_000c;
									case 1:
										qMLKSndTBShtpXRjRyIFxNWktwG = dIwJKlpiRTASvaviiLFTfGakHJEv[OCZkzcJysedFVmUktoQyzvUBaDi].PollForAllAxes().GetEnumerator();
										num2 = 1265280889;
										continue;
									case 6:
									{
										int num4;
										if (OCZkzcJysedFVmUktoQyzvUBaDi >= dIwJKlpiRTASvaviiLFTfGakHJEv.Count)
										{
											num2 = 1265280891;
											num4 = num2;
										}
										else
										{
											num2 = 1265280884;
											num4 = num2;
										}
										continue;
									}
									case 14:
										result = false;
										num2 = 1265280887;
										continue;
									case 0:
									{
										int num3;
										if (!qMLKSndTBShtpXRjRyIFxNWktwG.MoveNext())
										{
											num2 = 1265280882;
											num3 = num2;
										}
										else
										{
											num2 = 1265280881;
											num3 = num2;
										}
										continue;
									}
									case 4:
										YBizYLEoZTnaUkJjJsBoFiqojvc = qMLKSndTBShtpXRjRyIFxNWktwG.Current;
										ubyTdixGSFKGaFQFZdQnpwgWIvJ = YBizYLEoZTnaUkJjJsBoFiqojvc;
										isaqVUvqwfWYqOUtovbpbCbxgPc = 2;
										result = true;
										num2 = 1265280888;
										continue;
									case 12:
										isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
										num2 = 1265280885;
										continue;
									case 10:
										OCZkzcJysedFVmUktoQyzvUBaDi = 0;
										num2 = 1265280883;
										continue;
									case 5:
										goto IL_0126;
									case 13:
										goto end_IL_000c;
									case 7:
										xYDXGfZnyRjOdYzNgikCZMCGnho();
										OCZkzcJysedFVmUktoQyzvUBaDi++;
										num2 = 1265280883;
										continue;
									case 3:
										dIwJKlpiRTASvaviiLFTfGakHJEv = akUdmKMbrqFLXkjqdKLUZOPTArx.Joysticks_readOnly;
										num2 = 1265280895;
										continue;
									case 9:
										goto IL_017b;
									case 8:
										switch (num)
										{
										case 1:
											break;
										case 0:
											goto IL_0126;
										case 2:
											goto IL_017b;
										default:
											goto IL_019e;
										}
										goto case 14;
									case 2:
										goto end_IL_000c;
										IL_019e:
										num2 = 1265280891;
										continue;
										IL_017b:
										isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
										num2 = 1265280885;
										continue;
										IL_0126:
										isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
										num2 = 1265280886;
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
						switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								xYDXGfZnyRjOdYzNgikCZMCGnho();
							}
						}
					}

					[DebuggerHidden]
					public OkxqYpsMDyntDaPWZdaQdXNvnDBw(int _003C_003E1__state)
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
						TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
					}

					private void xYDXGfZnyRjOdYzNgikCZMCGnho()
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						while (true)
						{
							int num = 230884625;
							while (true)
							{
								switch (num ^ 0xDC30510)
								{
								case 0:
									break;
								default:
									return;
								case 1:
									if (qMLKSndTBShtpXRjRyIFxNWktwG != null)
									{
										goto IL_002d;
									}
									return;
								case 2:
									return;
								}
								break;
								IL_002d:
								qMLKSndTBShtpXRjRyIFxNWktwG.Dispose();
								num = 230884626;
							}
						}
					}
				}

				private sealed class HdxjWNEcFfXADtkIPncfcPMkJaBo : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo ubyTdixGSFKGaFQFZdQnpwgWIvJ;

					private int isaqVUvqwfWYqOUtovbpbCbxgPc;

					private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

					public IList<CustomController> CftqRQWpgbxsJXNGKlwhiOfXWbO;

					public int wZGFioGlvMMQiKyqdUYKgcJokyRd;

					public ControllerPollingInfo tSdIfVNHbFGrlWbJDbElfqKEocpG;

					public PollingHelper syCPfFbHYMDOvEPjTnPLBqiOhsPv;

					public IEnumerator<ControllerPollingInfo> ZDFDmbcYrAwuirsfZtIgRmWNFFq;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						HdxjWNEcFfXADtkIPncfcPMkJaBo hdxjWNEcFfXADtkIPncfcPMkJaBo;
						if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
						{
							isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
							hdxjWNEcFfXADtkIPncfcPMkJaBo = this;
						}
						else
						{
							while (true)
							{
								hdxjWNEcFfXADtkIPncfcPMkJaBo = new HdxjWNEcFfXADtkIPncfcPMkJaBo(0);
								hdxjWNEcFfXADtkIPncfcPMkJaBo.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
								int num = -997510817;
								while (true)
								{
									switch (num ^ -997510819)
									{
									case 0:
										num = -997510820;
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
						return hdxjWNEcFfXADtkIPncfcPMkJaBo;
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
							switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
							{
							case 0:
								goto IL_00c9;
							case 2:
								goto IL_0101;
							default:
								goto IL_0112;
								IL_00c9:
								isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
								num = -1673887027;
								goto IL_0023;
								IL_0023:
								while (true)
								{
									switch (num ^ -1673887031)
									{
									case 6:
										num = -1673887038;
										continue;
									case 7:
										wZGFioGlvMMQiKyqdUYKgcJokyRd = 0;
										num = -1673887035;
										continue;
									case 0:
										isaqVUvqwfWYqOUtovbpbCbxgPc = 2;
										result = true;
										break;
									case 8:
										BSvpCnAfZebiwIpPUWRIlyRloLvk();
										wZGFioGlvMMQiKyqdUYKgcJokyRd++;
										num = -1673887035;
										continue;
									case 5:
										goto IL_00a8;
									case 11:
										goto IL_00c9;
									case 12:
										goto IL_00da;
									case 10:
										goto IL_0101;
									case 9:
										goto IL_0112;
									case 3:
										tSdIfVNHbFGrlWbJDbElfqKEocpG = ZDFDmbcYrAwuirsfZtIgRmWNFFq.Current;
										ubyTdixGSFKGaFQFZdQnpwgWIvJ = tSdIfVNHbFGrlWbJDbElfqKEocpG;
										num = -1673887031;
										continue;
									case 2:
										ZDFDmbcYrAwuirsfZtIgRmWNFFq = CftqRQWpgbxsJXNGKlwhiOfXWbO[wZGFioGlvMMQiKyqdUYKgcJokyRd].PollForAllElements().GetEnumerator();
										isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
										num = -1673887028;
										continue;
									case 4:
										CftqRQWpgbxsJXNGKlwhiOfXWbO = akUdmKMbrqFLXkjqdKLUZOPTArx.CustomControllers_readOnly;
										num = -1673887026;
										continue;
									case 1:
										break;
									}
									break;
									IL_00da:
									int num2;
									if (wZGFioGlvMMQiKyqdUYKgcJokyRd < CftqRQWpgbxsJXNGKlwhiOfXWbO.Count)
									{
										num = -1673887029;
										num2 = num;
									}
									else
									{
										num = -1673887040;
										num2 = num;
									}
									continue;
									IL_00a8:
									int num3;
									if (!ZDFDmbcYrAwuirsfZtIgRmWNFFq.MoveNext())
									{
										num = -1673887039;
										num3 = num;
									}
									else
									{
										num = -1673887030;
										num3 = num;
									}
								}
								break;
								IL_0112:
								result = false;
								num = -1673887032;
								goto IL_0023;
								IL_0101:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								num = -1673887028;
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
						switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								BSvpCnAfZebiwIpPUWRIlyRloLvk();
							}
						}
					}

					[DebuggerHidden]
					public HdxjWNEcFfXADtkIPncfcPMkJaBo(int _003C_003E1__state)
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
						TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
					}

					private void BSvpCnAfZebiwIpPUWRIlyRloLvk()
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						if (ZDFDmbcYrAwuirsfZtIgRmWNFFq == null)
						{
							return;
						}
						while (true)
						{
							int num = -235275176;
							while (true)
							{
								switch (num ^ -235275175)
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
								ZDFDmbcYrAwuirsfZtIgRmWNFFq.Dispose();
								num = -235275173;
							}
						}
					}
				}

				private sealed class GGuGsZnPFVFhJfjKEyitDpknMkv : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo ubyTdixGSFKGaFQFZdQnpwgWIvJ;

					private int isaqVUvqwfWYqOUtovbpbCbxgPc;

					private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

					public IList<CustomController> TXaWrCZqKPlafmdrIDPijQHDKeMj;

					public int FGkQuLFXPJqYVCnelsJGMpKFdRL;

					public ControllerPollingInfo jQHcqeCGVnbMMzLBSIhpRBXdlMNM;

					public PollingHelper syCPfFbHYMDOvEPjTnPLBqiOhsPv;

					public IEnumerator<ControllerPollingInfo> NNDCJdPaRCFhVOyPtwEKyxyMKfP;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						GGuGsZnPFVFhJfjKEyitDpknMkv gGuGsZnPFVFhJfjKEyitDpknMkv;
						if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
						{
							isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
							gGuGsZnPFVFhJfjKEyitDpknMkv = this;
							goto IL_0025;
						}
						goto IL_004e;
						IL_002a:
						int num;
						while (true)
						{
							switch (num ^ -101939235)
							{
							case 0:
								break;
							case 3:
								num = -101939236;
								continue;
							case 2:
								goto IL_004e;
							default:
								return gGuGsZnPFVFhJfjKEyitDpknMkv;
							}
							break;
						}
						goto IL_0025;
						IL_004e:
						gGuGsZnPFVFhJfjKEyitDpknMkv = new GGuGsZnPFVFhJfjKEyitDpknMkv(0);
						gGuGsZnPFVFhJfjKEyitDpknMkv.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
						num = -101939236;
						goto IL_002a;
						IL_0025:
						num = -101939234;
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
							switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
							{
							default:
								num = 411798237;
								goto IL_001e;
							case 1:
								goto IL_00e9;
							case 0:
								goto IL_00f5;
							case 2:
								goto IL_0197;
								IL_001e:
								while (true)
								{
									switch (num ^ 0x188B8AD3)
									{
									case 3:
										break;
									default:
										goto end_IL_0008;
									case 11:
										FGkQuLFXPJqYVCnelsJGMpKFdRL = 0;
										num = 411798235;
										continue;
									case 9:
										ubyTdixGSFKGaFQFZdQnpwgWIvJ = jQHcqeCGVnbMMzLBSIhpRBXdlMNM;
										isaqVUvqwfWYqOUtovbpbCbxgPc = 2;
										num = 411798239;
										continue;
									case 10:
										NNDCJdPaRCFhVOyPtwEKyxyMKfP = TXaWrCZqKPlafmdrIDPijQHDKeMj[FGkQuLFXPJqYVCnelsJGMpKFdRL].PollForAllElementsDown().GetEnumerator();
										num = 411798229;
										continue;
									case 5:
										jQHcqeCGVnbMMzLBSIhpRBXdlMNM = NNDCJdPaRCFhVOyPtwEKyxyMKfP.Current;
										num = 411798234;
										continue;
									case 6:
										isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
										num = 411798225;
										continue;
									case 1:
										goto IL_00e9;
									case 13:
										goto IL_00f5;
									case 12:
										result = true;
										goto end_IL_0008;
									case 2:
										goto IL_0127;
									case 8:
										goto IL_0148;
									case 0:
										VRTgqUIJDZJwrdmLmttPfsVjploF();
										FGkQuLFXPJqYVCnelsJGMpKFdRL++;
										num = 411798235;
										continue;
									case 14:
										num = 411798226;
										continue;
									case 4:
										goto IL_0197;
									case 7:
										goto end_IL_0008;
									}
									break;
									IL_0148:
									int num2;
									if (FGkQuLFXPJqYVCnelsJGMpKFdRL < TXaWrCZqKPlafmdrIDPijQHDKeMj.Count)
									{
										num = 411798233;
										num2 = num;
									}
									else
									{
										num = 411798226;
										num2 = num;
									}
									continue;
									IL_0127:
									int num3;
									if (!NNDCJdPaRCFhVOyPtwEKyxyMKfP.MoveNext())
									{
										num = 411798227;
										num3 = num;
									}
									else
									{
										num = 411798230;
										num3 = num;
									}
								}
								goto default;
								IL_0197:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								num = 411798225;
								goto IL_001e;
								IL_00f5:
								isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
								TXaWrCZqKPlafmdrIDPijQHDKeMj = akUdmKMbrqFLXkjqdKLUZOPTArx.CustomControllers_readOnly;
								num = 411798232;
								goto IL_001e;
								IL_00e9:
								result = false;
								num = 411798228;
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
						switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								VRTgqUIJDZJwrdmLmttPfsVjploF();
							}
						}
					}

					[DebuggerHidden]
					public GGuGsZnPFVFhJfjKEyitDpknMkv(int _003C_003E1__state)
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
						TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
					}

					private void VRTgqUIJDZJwrdmLmttPfsVjploF()
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						while (true)
						{
							int num = 503721055;
							while (true)
							{
								switch (num ^ 0x1E062C5E)
								{
								case 3:
									break;
								default:
									return;
								case 1:
								{
									int num2;
									if (NNDCJdPaRCFhVOyPtwEKyxyMKfP == null)
									{
										num = 503721052;
										num2 = num;
									}
									else
									{
										num = 503721054;
										num2 = num;
									}
									continue;
								}
								case 0:
									NNDCJdPaRCFhVOyPtwEKyxyMKfP.Dispose();
									num = 503721052;
									continue;
								case 2:
									return;
								}
								break;
							}
						}
					}
				}

				private sealed class lFROYnFPJrUPIcImIFMPabhyDgnK : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo ubyTdixGSFKGaFQFZdQnpwgWIvJ;

					private int isaqVUvqwfWYqOUtovbpbCbxgPc;

					private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

					public IList<CustomController> HlbyTRGSpYQLbpdUZQlDXAJqFes;

					public int nIXdDYkZPdZOCqbTmHiUiKFEYHP;

					public ControllerPollingInfo MazjgGxrkkUHrKySBIlkEakXQTf;

					public PollingHelper syCPfFbHYMDOvEPjTnPLBqiOhsPv;

					public IEnumerator<ControllerPollingInfo> XjuZOjLBTlfcHWkhQQNEZlDwmXC;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
						{
							goto IL_001c;
						}
						goto IL_0050;
						IL_0050:
						lFROYnFPJrUPIcImIFMPabhyDgnK lFROYnFPJrUPIcImIFMPabhyDgnK2 = new lFROYnFPJrUPIcImIFMPabhyDgnK(0);
						lFROYnFPJrUPIcImIFMPabhyDgnK2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
						int num = 1992158137;
						goto IL_0021;
						IL_001c:
						num = 1992158136;
						goto IL_0021;
						IL_0021:
						while (true)
						{
							switch (num ^ 0x76BDEBBB)
							{
							case 4:
								break;
							case 3:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
								num = 1992158139;
								continue;
							case 1:
								goto IL_0050;
							case 0:
								lFROYnFPJrUPIcImIFMPabhyDgnK2 = this;
								num = 1992158137;
								continue;
							default:
								return lFROYnFPJrUPIcImIFMPabhyDgnK2;
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
							int num = isaqVUvqwfWYqOUtovbpbCbxgPc;
							while (true)
							{
								int num2 = -646305508;
								while (true)
								{
									switch (num2 ^ -646305506)
									{
									case 3:
										break;
									case 4:
										isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
										num2 = -646305509;
										continue;
									case 10:
										isaqVUvqwfWYqOUtovbpbCbxgPc = 2;
										return true;
									case 7:
										MazjgGxrkkUHrKySBIlkEakXQTf = XjuZOjLBTlfcHWkhQQNEZlDwmXC.Current;
										ubyTdixGSFKGaFQFZdQnpwgWIvJ = MazjgGxrkkUHrKySBIlkEakXQTf;
										num2 = -646305516;
										continue;
									case 8:
									{
										int num4;
										if (nIXdDYkZPdZOCqbTmHiUiKFEYHP >= HlbyTRGSpYQLbpdUZQlDXAJqFes.Count)
										{
											num2 = -646305505;
											num4 = num2;
										}
										else
										{
											num2 = -646305506;
											num4 = num2;
										}
										continue;
									}
									case 9:
										goto IL_00b9;
									case 5:
									{
										int num3;
										if (!XjuZOjLBTlfcHWkhQQNEZlDwmXC.MoveNext())
										{
											num2 = -646305512;
											num3 = num2;
										}
										else
										{
											num2 = -646305511;
											num3 = num2;
										}
										continue;
									}
									case 0:
										XjuZOjLBTlfcHWkhQQNEZlDwmXC = HlbyTRGSpYQLbpdUZQlDXAJqFes[nIXdDYkZPdZOCqbTmHiUiKFEYHP].PollForAllButtons().GetEnumerator();
										isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
										num2 = -646305509;
										continue;
									case 2:
										switch (num)
										{
										case 2:
											break;
										case 0:
											goto IL_00b9;
										default:
											goto IL_0146;
										case 1:
											goto IL_016e;
										}
										goto case 4;
									case 6:
										olMfpCBgbRHuWiurAFWPFmJWjdbj();
										nIXdDYkZPdZOCqbTmHiUiKFEYHP++;
										num2 = -646305514;
										continue;
									default:
										goto IL_016e;
										IL_016e:
										return false;
										IL_0146:
										num2 = -646305505;
										continue;
										IL_00b9:
										isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
										HlbyTRGSpYQLbpdUZQlDXAJqFes = akUdmKMbrqFLXkjqdKLUZOPTArx.CustomControllers_readOnly;
										nIXdDYkZPdZOCqbTmHiUiKFEYHP = 0;
										num2 = -646305514;
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
						switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								olMfpCBgbRHuWiurAFWPFmJWjdbj();
							}
						}
					}

					[DebuggerHidden]
					public lFROYnFPJrUPIcImIFMPabhyDgnK(int _003C_003E1__state)
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
						TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
					}

					private void olMfpCBgbRHuWiurAFWPFmJWjdbj()
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						if (XjuZOjLBTlfcHWkhQQNEZlDwmXC != null)
						{
							XjuZOjLBTlfcHWkhQQNEZlDwmXC.Dispose();
						}
					}
				}

				private sealed class xIppThrUPlAeICTZPRDqXVIVcJP : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo ubyTdixGSFKGaFQFZdQnpwgWIvJ;

					private int isaqVUvqwfWYqOUtovbpbCbxgPc;

					private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

					public IList<CustomController> xRoVOUmNJQvsUhOehwiMMMhpuhX;

					public int qAfupoOZyxfKylwvBusGQdhiUnf;

					public ControllerPollingInfo UWVEiBHHbCJTcyajgmZkJCvucFqI;

					public PollingHelper syCPfFbHYMDOvEPjTnPLBqiOhsPv;

					public IEnumerator<ControllerPollingInfo> sFWQghnjOXwiWfwPIToaAbBfczBg;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT)
						{
							goto IL_0012;
						}
						goto IL_003c;
						IL_0012:
						int num = -1734398303;
						goto IL_0017;
						IL_0017:
						xIppThrUPlAeICTZPRDqXVIVcJP xIppThrUPlAeICTZPRDqXVIVcJP2 = default(xIppThrUPlAeICTZPRDqXVIVcJP);
						while (true)
						{
							switch (num ^ -1734398302)
							{
							case 2:
								break;
							case 5:
								goto IL_003c;
							case 1:
								xIppThrUPlAeICTZPRDqXVIVcJP2 = this;
								num = -1734398302;
								continue;
							case 4:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
								num = -1734398301;
								continue;
							case 3:
								goto IL_006d;
							default:
								return xIppThrUPlAeICTZPRDqXVIVcJP2;
							}
							break;
							IL_006d:
							int num2;
							if (isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
							{
								num = -1734398298;
								num2 = num;
							}
							else
							{
								num = -1734398297;
								num2 = num;
							}
						}
						goto IL_0012;
						IL_003c:
						xIppThrUPlAeICTZPRDqXVIVcJP2 = new xIppThrUPlAeICTZPRDqXVIVcJP(0);
						xIppThrUPlAeICTZPRDqXVIVcJP2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
						num = -1734398302;
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
							switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
							{
							default:
								num = 1326748896;
								goto IL_001e;
							case 0:
								goto IL_00b0;
							case 2:
								goto IL_011e;
							case 1:
								break;
								IL_001e:
								while (true)
								{
									switch (num ^ 0x4F1494E1)
									{
									case 9:
										break;
									case 0:
										goto IL_005e;
									case 11:
										if (!sFWQghnjOXwiWfwPIToaAbBfczBg.MoveNext())
										{
											YlArLWvBEFbDKOuOZGmflIDcfwC();
											qAfupoOZyxfKylwvBusGQdhiUnf++;
											num = 1326748897;
											continue;
										}
										goto case 3;
									case 10:
										goto IL_00b0;
									case 2:
										isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
										num = 1326748906;
										continue;
									case 7:
										num = 1326748897;
										continue;
									case 4:
										sFWQghnjOXwiWfwPIToaAbBfczBg = xRoVOUmNJQvsUhOehwiMMMhpuhX[qAfupoOZyxfKylwvBusGQdhiUnf].PollForAllButtonsDown().GetEnumerator();
										num = 1326748899;
										continue;
									case 6:
										goto IL_011e;
									case 3:
										UWVEiBHHbCJTcyajgmZkJCvucFqI = sFWQghnjOXwiWfwPIToaAbBfczBg.Current;
										ubyTdixGSFKGaFQFZdQnpwgWIvJ = UWVEiBHHbCJTcyajgmZkJCvucFqI;
										isaqVUvqwfWYqOUtovbpbCbxgPc = 2;
										result = true;
										num = 1326748905;
										continue;
									case 8:
										goto end_IL_0000;
									case 1:
										num = 1326748900;
										continue;
									default:
										goto end_IL_0008;
									}
									break;
									IL_005e:
									int num2;
									if (qAfupoOZyxfKylwvBusGQdhiUnf < xRoVOUmNJQvsUhOehwiMMMhpuhX.Count)
									{
										num = 1326748901;
										num2 = num;
									}
									else
									{
										num = 1326748900;
										num2 = num;
									}
								}
								goto default;
								IL_011e:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								num = 1326748906;
								goto IL_001e;
								IL_00b0:
								isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
								xRoVOUmNJQvsUhOehwiMMMhpuhX = akUdmKMbrqFLXkjqdKLUZOPTArx.CustomControllers_readOnly;
								qAfupoOZyxfKylwvBusGQdhiUnf = 0;
								num = 1326748902;
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
						switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								YlArLWvBEFbDKOuOZGmflIDcfwC();
							}
						}
					}

					[DebuggerHidden]
					public xIppThrUPlAeICTZPRDqXVIVcJP(int _003C_003E1__state)
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
						TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
					}

					private void YlArLWvBEFbDKOuOZGmflIDcfwC()
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						while (true)
						{
							int num = 888471897;
							while (true)
							{
								switch (num ^ 0x34F50158)
								{
								case 2:
									break;
								default:
									return;
								case 1:
									if (sFWQghnjOXwiWfwPIToaAbBfczBg != null)
									{
										goto IL_002d;
									}
									return;
								case 0:
									return;
								}
								break;
								IL_002d:
								sFWQghnjOXwiWfwPIToaAbBfczBg.Dispose();
								num = 888471896;
							}
						}
					}
				}

				private sealed class FmcmhibysAuXzaiXjEZYgTfzggY : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo ubyTdixGSFKGaFQFZdQnpwgWIvJ;

					private int isaqVUvqwfWYqOUtovbpbCbxgPc;

					private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

					public IList<CustomController> syrTYrThPGwIHylJGdCkGFuGqWQg;

					public int bRYBoRvIJvbXTdaYvAcJuYBwzIsg;

					public ControllerPollingInfo fdiShnpUZUKTEwFnUcnPDGOfCLFy;

					public PollingHelper syCPfFbHYMDOvEPjTnPLBqiOhsPv;

					public IEnumerator<ControllerPollingInfo> DLWpbdlfsThWWvfkSgwlAxrbpMS;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT)
						{
							goto IL_0012;
						}
						goto IL_0040;
						IL_0012:
						int num = -574542915;
						goto IL_0017;
						IL_0017:
						FmcmhibysAuXzaiXjEZYgTfzggY fmcmhibysAuXzaiXjEZYgTfzggY = default(FmcmhibysAuXzaiXjEZYgTfzggY);
						while (true)
						{
							switch (num ^ -574542916)
							{
							case 4:
								break;
							case 0:
								goto IL_0040;
							case 2:
								fmcmhibysAuXzaiXjEZYgTfzggY = this;
								num = -574542919;
								continue;
							case 3:
								fmcmhibysAuXzaiXjEZYgTfzggY.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
								num = -574542919;
								continue;
							case 1:
								goto IL_006a;
							case 6:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
								num = -574542914;
								continue;
							default:
								return fmcmhibysAuXzaiXjEZYgTfzggY;
							}
							break;
							IL_006a:
							int num2;
							if (isaqVUvqwfWYqOUtovbpbCbxgPc != -2)
							{
								num = -574542916;
								num2 = num;
							}
							else
							{
								num = -574542918;
								num2 = num;
							}
						}
						goto IL_0012;
						IL_0040:
						fmcmhibysAuXzaiXjEZYgTfzggY = new FmcmhibysAuXzaiXjEZYgTfzggY(0);
						num = -574542913;
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
							switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
							{
							default:
								goto IL_00a8;
							case 0:
								goto IL_010f;
							case 2:
								goto IL_018e;
								IL_00a8:
								result = false;
								num = 402968774;
								goto IL_0023;
								IL_0023:
								while (true)
								{
									switch (num ^ 0x1804D0C6)
									{
									case 7:
										num = 402968781;
										continue;
									case 4:
										isaqVUvqwfWYqOUtovbpbCbxgPc = 2;
										result = true;
										break;
									case 13:
										num = 402968768;
										continue;
									case 1:
										goto IL_0087;
									case 3:
										goto IL_00a8;
									case 12:
										ubyTdixGSFKGaFQFZdQnpwgWIvJ = fdiShnpUZUKTEwFnUcnPDGOfCLFy;
										num = 402968770;
										continue;
									case 2:
										OpNjXHoAuAjroZFoOrkQfbcjUiq();
										bRYBoRvIJvbXTdaYvAcJuYBwzIsg++;
										num = 402968768;
										continue;
									case 6:
										goto IL_00e8;
									case 11:
										goto IL_010f;
									case 8:
										num = 402968775;
										continue;
									case 5:
										fdiShnpUZUKTEwFnUcnPDGOfCLFy = DLWpbdlfsThWWvfkSgwlAxrbpMS.Current;
										num = 402968778;
										continue;
									case 9:
										DLWpbdlfsThWWvfkSgwlAxrbpMS = syrTYrThPGwIHylJGdCkGFuGqWQg[bRYBoRvIJvbXTdaYvAcJuYBwzIsg].PollForAllAxes().GetEnumerator();
										isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
										num = 402968782;
										continue;
									case 10:
										goto IL_018e;
									case 0:
										break;
									}
									break;
									IL_00e8:
									int num2;
									if (bRYBoRvIJvbXTdaYvAcJuYBwzIsg < syrTYrThPGwIHylJGdCkGFuGqWQg.Count)
									{
										num = 402968783;
										num2 = num;
									}
									else
									{
										num = 402968773;
										num2 = num;
									}
									continue;
									IL_0087:
									int num3;
									if (!DLWpbdlfsThWWvfkSgwlAxrbpMS.MoveNext())
									{
										num = 402968772;
										num3 = num;
									}
									else
									{
										num = 402968771;
										num3 = num;
									}
								}
								break;
								IL_018e:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								num = 402968775;
								goto IL_0023;
								IL_010f:
								isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
								syrTYrThPGwIHylJGdCkGFuGqWQg = akUdmKMbrqFLXkjqdKLUZOPTArx.CustomControllers_readOnly;
								bRYBoRvIJvbXTdaYvAcJuYBwzIsg = 0;
								num = 402968779;
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
						switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								OpNjXHoAuAjroZFoOrkQfbcjUiq();
							}
						}
					}

					[DebuggerHidden]
					public FmcmhibysAuXzaiXjEZYgTfzggY(int _003C_003E1__state)
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
						TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
					}

					private void OpNjXHoAuAjroZFoOrkQfbcjUiq()
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						while (true)
						{
							int num = 220982398;
							while (true)
							{
								switch (num ^ 0xD2BEC7C)
								{
								case 0:
									break;
								default:
									return;
								case 2:
								{
									int num2;
									if (DLWpbdlfsThWWvfkSgwlAxrbpMS == null)
									{
										num = 220982399;
										num2 = num;
									}
									else
									{
										num = 220982397;
										num2 = num;
									}
									continue;
								}
								case 1:
									DLWpbdlfsThWWvfkSgwlAxrbpMS.Dispose();
									num = 220982399;
									continue;
								case 3:
									return;
								}
								break;
							}
						}
					}
				}

				private static PollingHelper ilVQEiENSgAnwgRreWwIUWTqyneQ;

				internal static PollingHelper Instance => ilVQEiENSgAnwgRreWwIUWTqyneQ ?? (ilVQEiENSgAnwgRreWwIUWTqyneQ = new PollingHelper());

				private PollingHelper()
				{
				}

				public ControllerPollingInfo PollAllControllersForFirstElement()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.czsDbiqQNWsvQguTJNJasHdCGwp();
					}
					ControllerPollingInfo result = rdRbacMUnvNXqxoxYsokYmfygPR();
					if (result.success)
					{
						return result;
					}
					result = RXvXBwZvNGOQBQuJIaONOFOOqQB();
					if (result.success)
					{
						return result;
					}
					result = zcKsksPOOJCIZZTJKkGuiFBaxJT();
					if (result.success)
					{
						return result;
					}
					result = wzCfgemcQOjoqjeQAunokCUNDYU();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.czsDbiqQNWsvQguTJNJasHdCGwp();
				}

				public ControllerPollingInfo PollAllControllersForFirstElementDown()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.czsDbiqQNWsvQguTJNJasHdCGwp();
					}
					ControllerPollingInfo result = fkXytPQgZRZnrgDoUjbxufmCIKS();
					if (result.success)
					{
						return result;
					}
					result = iNMLSNrWFPHbktMPpnoGjBpuPxB();
					if (result.success)
					{
						return result;
					}
					result = wLTgRcOAmBDiGMPICarWBcGtyQAb();
					if (result.success)
					{
						return result;
					}
					result = NZvYSYavkUCGXMfBIjnkNExXxaC();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.czsDbiqQNWsvQguTJNJasHdCGwp();
				}

				public ControllerPollingInfo PollAllControllersForFirstButton()
				{
					if (!CheckInitialized())
					{
						goto IL_0007;
					}
					ControllerPollingInfo result = REiidKNUKquakKqhOSRqFcJENkE();
					if (result.success)
					{
						return result;
					}
					result = RXvXBwZvNGOQBQuJIaONOFOOqQB();
					int num = -1395153060;
					goto IL_000c;
					IL_0007:
					num = -1395153059;
					goto IL_000c;
					IL_000c:
					switch (num ^ -1395153060)
					{
					case 2:
						break;
					case 1:
						return ControllerPollingInfo.czsDbiqQNWsvQguTJNJasHdCGwp();
					default:
						if (result.success)
						{
							return result;
						}
						result = qkldOXyGdjseGaSXVqOVTReAmeb();
						if (result.success)
						{
							return result;
						}
						result = hOcjJQnGuCZcasFuqvqHbCJEuDf();
						if (result.success)
						{
							return result;
						}
						return ControllerPollingInfo.czsDbiqQNWsvQguTJNJasHdCGwp();
					}
					goto IL_0007;
				}

				public ControllerPollingInfo PollAllControllersForFirstButtonDown()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.czsDbiqQNWsvQguTJNJasHdCGwp();
					}
					ControllerPollingInfo result = TinACdDwnZUzamaxzSJRenLrYpS();
					if (result.success)
					{
						goto IL_001d;
					}
					result = iNMLSNrWFPHbktMPpnoGjBpuPxB();
					if (result.success)
					{
						return result;
					}
					result = ATlESuZHpodKQjDURgYZrgfkGXqV();
					if (result.success)
					{
						return result;
					}
					result = XzcgwafzjFdjOVPUIzRYmkqAdAL();
					int num;
					if (result.success)
					{
						num = 1812090337;
						goto IL_0022;
					}
					return ControllerPollingInfo.czsDbiqQNWsvQguTJNJasHdCGwp();
					IL_001d:
					num = 1812090336;
					goto IL_0022;
					IL_0022:
					switch (num ^ 0x6C024DE1)
					{
					case 2:
						break;
					case 1:
						return result;
					default:
						return result;
					}
					goto IL_001d;
				}

				public ControllerPollingInfo PollAllControllersForFirstAxis()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.czsDbiqQNWsvQguTJNJasHdCGwp();
					}
					ControllerPollingInfo result = UsISpUmLRMCESCdknWXGExiknoJ();
					if (result.success)
					{
						return result;
					}
					result = ControllerPollingInfo.czsDbiqQNWsvQguTJNJasHdCGwp();
					if (result.success)
					{
						return result;
					}
					result = aCLBFMkbautxgnpMvtTHMyGDctW();
					if (result.success)
					{
						goto IL_0040;
					}
					result = wFkhrgettGFuTwBggYOjaMkdprY();
					int num = -578664103;
					goto IL_0045;
					IL_0040:
					num = -578664102;
					goto IL_0045;
					IL_0045:
					switch (num ^ -578664104)
					{
					case 0:
						break;
					case 2:
						return result;
					default:
						if (result.success)
						{
							return result;
						}
						return ControllerPollingInfo.czsDbiqQNWsvQguTJNJasHdCGwp();
					}
					goto IL_0040;
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstElement(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.czsDbiqQNWsvQguTJNJasHdCGwp();
					}
					switch (controllerType)
					{
					case ControllerType.Joystick:
						return rdRbacMUnvNXqxoxYsokYmfygPR();
					case ControllerType.Keyboard:
						return RXvXBwZvNGOQBQuJIaONOFOOqQB();
					case ControllerType.Mouse:
						return zcKsksPOOJCIZZTJKkGuiFBaxJT();
					case ControllerType.Custom:
						return wzCfgemcQOjoqjeQAunokCUNDYU();
					default:
						throw new NotImplementedException();
					}
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstElementDown(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.czsDbiqQNWsvQguTJNJasHdCGwp();
					}
					switch (controllerType)
					{
					case ControllerType.Joystick:
						return fkXytPQgZRZnrgDoUjbxufmCIKS();
					case ControllerType.Keyboard:
						return iNMLSNrWFPHbktMPpnoGjBpuPxB();
					case ControllerType.Mouse:
						return wLTgRcOAmBDiGMPICarWBcGtyQAb();
					case ControllerType.Custom:
						return NZvYSYavkUCGXMfBIjnkNExXxaC();
					default:
						throw new NotImplementedException();
					}
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstButton(ControllerType controllerType)
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
						return RXvXBwZvNGOQBQuJIaONOFOOqQB();
					case ControllerType.Mouse:
						return qkldOXyGdjseGaSXVqOVTReAmeb();
					}
					int num = 1293287713;
					goto IL_000c;
					IL_0007:
					num = 1293287715;
					goto IL_000c;
					IL_004a:
					if (controllerType2 == ControllerType.Custom)
					{
						return hOcjJQnGuCZcasFuqvqHbCJEuDf();
					}
					throw new NotImplementedException();
					IL_0058:
					return REiidKNUKquakKqhOSRqFcJENkE();
					IL_000c:
					switch (num ^ 0x4D160120)
					{
					case 0:
						break;
					case 3:
						return ControllerPollingInfo.czsDbiqQNWsvQguTJNJasHdCGwp();
					case 1:
						goto IL_004a;
					default:
						goto IL_0058;
					}
					goto IL_0007;
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstButtonDown(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.czsDbiqQNWsvQguTJNJasHdCGwp();
					}
					switch (controllerType)
					{
					case ControllerType.Joystick:
						return TinACdDwnZUzamaxzSJRenLrYpS();
					case ControllerType.Keyboard:
						return iNMLSNrWFPHbktMPpnoGjBpuPxB();
					case ControllerType.Mouse:
						return ATlESuZHpodKQjDURgYZrgfkGXqV();
					case ControllerType.Custom:
						return XzcgwafzjFdjOVPUIzRYmkqAdAL();
					default:
						throw new NotImplementedException();
					}
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstAxis(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.czsDbiqQNWsvQguTJNJasHdCGwp();
					}
					while (true)
					{
						switch (-2147404669 ^ -2147404671)
						{
						case 0:
							continue;
						case 2:
							switch (controllerType)
							{
							case ControllerType.Joystick:
								break;
							case ControllerType.Keyboard:
								return ControllerPollingInfo.czsDbiqQNWsvQguTJNJasHdCGwp();
							case ControllerType.Mouse:
								return aCLBFMkbautxgnpMvtTHMyGDctW();
							case ControllerType.Custom:
								return wFkhrgettGFuTwBggYOjaMkdprY();
							default:
								throw new NotImplementedException();
							}
							break;
						}
						break;
					}
					return UsISpUmLRMCESCdknWXGExiknoJ();
				}

				public ControllerPollingInfo PollControllerForFirstElement(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						while (true)
						{
							switch (0x3F1E42C9 ^ 0x3F1E42C8)
							{
							case 0:
								continue;
							case 1:
								return ControllerPollingInfo.czsDbiqQNWsvQguTJNJasHdCGwp();
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
							return RXvXBwZvNGOQBQuJIaONOFOOqQB();
						case ControllerType.Mouse:
							return zcKsksPOOJCIZZTJKkGuiFBaxJT();
						case ControllerType.Custom:
							return qRBXyhwFznUuUjHLhOQyTGLWfJw(controllerId);
						default:
							throw new NotImplementedException();
						}
					}
					return dPJGTcfnzOYzHqpHpNONPIyEHCc(controllerId);
				}

				public ControllerPollingInfo PollControllerForFirstElementDown(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.czsDbiqQNWsvQguTJNJasHdCGwp();
					}
					switch (controllerType)
					{
					case ControllerType.Joystick:
						return jWfdaspiTMCOiStjCcvSnMLorjT(controllerId);
					case ControllerType.Keyboard:
						return iNMLSNrWFPHbktMPpnoGjBpuPxB();
					case ControllerType.Mouse:
						return wLTgRcOAmBDiGMPICarWBcGtyQAb();
					case ControllerType.Custom:
						return WAblsogNAWKPzBWYmNNYlrKbIFp(controllerId);
					default:
						throw new NotImplementedException();
					}
				}

				public ControllerPollingInfo PollControllerForFirstButton(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.czsDbiqQNWsvQguTJNJasHdCGwp();
					}
					switch (controllerType)
					{
					default:
						while (true)
						{
							int num = 642879701;
							while (true)
							{
								switch (num ^ 0x265190D6)
								{
								case 2:
									break;
								case 3:
									goto IL_0043;
								default:
									goto end_IL_0021;
								case 0:
									throw new NotImplementedException();
								}
								break;
								IL_0043:
								if (controllerType != ControllerType.Custom)
								{
									num = 642879702;
									continue;
								}
								return JFIDziFChiJbMdCjTKzMXdhljQU(controllerId);
							}
							continue;
							end_IL_0021:
							break;
						}
						goto case ControllerType.Joystick;
					case ControllerType.Joystick:
						return HBwYfOfXCdVGYmfZDjCgkuVAYWt(controllerId);
					case ControllerType.Keyboard:
						return RXvXBwZvNGOQBQuJIaONOFOOqQB();
					case ControllerType.Mouse:
						return qkldOXyGdjseGaSXVqOVTReAmeb();
					}
				}

				public ControllerPollingInfo PollControllerForFirstButtonDown(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.czsDbiqQNWsvQguTJNJasHdCGwp();
					}
					switch (controllerType)
					{
					case ControllerType.Joystick:
						return PwofcjbtaFTKmOrtPFlpgMAgQfEV(controllerId);
					case ControllerType.Keyboard:
						return iNMLSNrWFPHbktMPpnoGjBpuPxB();
					case ControllerType.Mouse:
						return ATlESuZHpodKQjDURgYZrgfkGXqV();
					case ControllerType.Custom:
						return QkntgRCktSWkOWmbuBzQANndhzZy(controllerId);
					default:
						throw new NotImplementedException();
					}
				}

				public ControllerPollingInfo PollControllerForFirstAxis(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.czsDbiqQNWsvQguTJNJasHdCGwp();
					}
					while (true)
					{
						int num = -248893438;
						while (true)
						{
							switch (num ^ -248893439)
							{
							case 2:
								break;
							case 3:
								switch (controllerType)
								{
								default:
									goto IL_0048;
								case ControllerType.Joystick:
									break;
								case ControllerType.Keyboard:
									return ControllerPollingInfo.czsDbiqQNWsvQguTJNJasHdCGwp();
								case ControllerType.Mouse:
									return aCLBFMkbautxgnpMvtTHMyGDctW();
								case ControllerType.Custom:
									return goNOOodEOohhDxtRJtXJKYUABpO(controllerId);
								}
								goto default;
							default:
								return szDCypbZgdLUYHRipkFpwVGkiMSe(controllerId);
							case 0:
								throw new NotImplementedException();
							}
							break;
							IL_0048:
							num = -248893439;
						}
					}
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllElements()
				{
					EkmAegIggPEEQJMdwdkcPHabWve ekmAegIggPEEQJMdwdkcPHabWve = new EkmAegIggPEEQJMdwdkcPHabWve(-2);
					ekmAegIggPEEQJMdwdkcPHabWve.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
					return ekmAegIggPEEQJMdwdkcPHabWve;
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllElementsDown()
				{
					cYVdUakcrcewVPgGfqRxOuqISWG cYVdUakcrcewVPgGfqRxOuqISWG2 = new cYVdUakcrcewVPgGfqRxOuqISWG(-2);
					cYVdUakcrcewVPgGfqRxOuqISWG2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
					return cYVdUakcrcewVPgGfqRxOuqISWG2;
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllButtons()
				{
					lpVlJfSZpGYbWfeISnUqxCtPXov lpVlJfSZpGYbWfeISnUqxCtPXov2 = new lpVlJfSZpGYbWfeISnUqxCtPXov(-2);
					lpVlJfSZpGYbWfeISnUqxCtPXov2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
					return lpVlJfSZpGYbWfeISnUqxCtPXov2;
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllButtonsDown()
				{
					yezJyfgTPrRTMSTqTuVkXnpNjILA yezJyfgTPrRTMSTqTuVkXnpNjILA2 = new yezJyfgTPrRTMSTqTuVkXnpNjILA(-2);
					yezJyfgTPrRTMSTqTuVkXnpNjILA2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
					return yezJyfgTPrRTMSTqTuVkXnpNjILA2;
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllAxes()
				{
					NQNGCMlghAaBBZoEfGomQfLTEuO nQNGCMlghAaBBZoEfGomQfLTEuO = new NQNGCMlghAaBBZoEfGomQfLTEuO(-2);
					nQNGCMlghAaBBZoEfGomQfLTEuO.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
					return nQNGCMlghAaBBZoEfGomQfLTEuO;
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllElements(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						goto IL_0007;
					}
					ControllerType controllerType2 = controllerType;
					int num = 1028946026;
					goto IL_000c;
					IL_000c:
					while (true)
					{
						switch (num ^ 0x3D54786E)
						{
						case 0:
							break;
						case 4:
							switch (controllerType2)
							{
							default:
								goto IL_004d;
							case ControllerType.Joystick:
								break;
							case ControllerType.Keyboard:
								return gDkkTbkjunDzYgomHuBtVHKKyugd();
							case ControllerType.Mouse:
								return LWvBSAgTxRsMyBxOdRmnheGbXFz();
							case ControllerType.Custom:
								return ohlelOCrMMtCnWQVuYVsMgRXOkQ(controllerId);
							}
							goto default;
						case 3:
							return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
						default:
							return FfhayehUtdqgqKFrOjGQzRSGixq(controllerId);
						case 1:
							throw new NotImplementedException();
						}
						break;
						IL_004d:
						num = 1028946031;
					}
					goto IL_0007;
					IL_0007:
					num = 1028946029;
					goto IL_000c;
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
						return BOuEdymszEGPSWkFCdktKXICsVK(controllerId);
					case ControllerType.Keyboard:
						return YFihCQKfLwUlPaHilGyRDWbGGEhs();
					case ControllerType.Mouse:
						return VkxyXiOCCUrUaenxypQwkZnutHW();
					case ControllerType.Custom:
						return DVUrtPvBLMXeiaznpYKDVgGvFsz(controllerId);
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
					while (true)
					{
						int num = -1898103634;
						while (true)
						{
							switch (num ^ -1898103633)
							{
							case 3:
								break;
							case 1:
								switch (controllerType)
								{
								default:
									goto IL_0048;
								case ControllerType.Joystick:
									break;
								case ControllerType.Keyboard:
									return gDkkTbkjunDzYgomHuBtVHKKyugd();
								case ControllerType.Mouse:
									return miHjzAcBEPKficFvHaAFHcLthBCU();
								case ControllerType.Custom:
									return MVaUIIRnHkkMPzaqBMiyYtDifjv(controllerId);
								}
								goto default;
							default:
								return jOPGNHCaPGcucngNNeZAVGknbm(controllerId);
							case 0:
								throw new NotImplementedException();
							}
							break;
							IL_0048:
							num = -1898103633;
						}
					}
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllButtonsDown(ControllerType controllerType, int controllerId)
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
							int num = 993769679;
							while (true)
							{
								switch (num ^ 0x3B3BB8CD)
								{
								case 3:
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
									num = 993769676;
									continue;
								}
								return CSmgQAhNztyBsMfkYyWVHEttgZM(controllerId);
							}
							continue;
							end_IL_0021:
							break;
						}
						goto case ControllerType.Joystick;
					case ControllerType.Joystick:
						return IfgEgbKtMqzzlbdToKwhiRXxWqcD(controllerId);
					case ControllerType.Keyboard:
						return YFihCQKfLwUlPaHilGyRDWbGGEhs();
					case ControllerType.Mouse:
						return UiOxmgBhnVCFFDwxMrlvZtxFpLb();
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
						return YeTNaUxKHwpcBUcxqVFBXqJQpoA();
					}
					int num = -130522689;
					goto IL_000c;
					IL_0007:
					num = -130522690;
					goto IL_000c;
					IL_004a:
					if (controllerType2 == ControllerType.Custom)
					{
						return BbLbbcBIwuDhQeaNcyXNCifxEvpe(controllerId);
					}
					throw new NotImplementedException();
					IL_0058:
					return OxNfqMwvTTjqkKgdsaTfekwgxx(controllerId);
					IL_000c:
					switch (num ^ -130522691)
					{
					case 0:
						break;
					case 3:
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					case 2:
						goto IL_004a;
					default:
						goto IL_0058;
					}
					goto IL_0007;
				}

				private ControllerPollingInfo rdRbacMUnvNXqxoxYsokYmfygPR()
				{
					IList<Joystick> joysticks_readOnly = akUdmKMbrqFLXkjqdKLUZOPTArx.Joysticks_readOnly;
					int num2 = default(int);
					ControllerPollingInfo result = default(ControllerPollingInfo);
					while (true)
					{
						int num = 930153615;
						while (true)
						{
							switch (num ^ 0x3771048D)
							{
							case 5:
								break;
							case 2:
								num2 = 0;
								num = 930153612;
								continue;
							case 0:
								result = joysticks_readOnly[num2].PollForFirstElement();
								num = 930153614;
								continue;
							case 3:
								if (result.success)
								{
									return result;
								}
								num2++;
								num = 930153609;
								continue;
							case 1:
								num = 930153609;
								continue;
							default:
								if (num2 >= joysticks_readOnly.Count)
								{
									return ControllerPollingInfo.czsDbiqQNWsvQguTJNJasHdCGwp();
								}
								goto case 0;
							}
							break;
						}
					}
				}

				private ControllerPollingInfo fkXytPQgZRZnrgDoUjbxufmCIKS()
				{
					IList<Joystick> joysticks_readOnly = akUdmKMbrqFLXkjqdKLUZOPTArx.Joysticks_readOnly;
					int num2 = default(int);
					ControllerPollingInfo result = default(ControllerPollingInfo);
					while (true)
					{
						int num = -160390662;
						while (true)
						{
							switch (num ^ -160390657)
							{
							case 0:
								break;
							case 5:
								num2 = 0;
								num = -160390658;
								continue;
							case 1:
								num = -160390661;
								continue;
							case 3:
								return result;
							case 2:
								result = joysticks_readOnly[num2].PollForFirstElementDown();
								if (!result.success)
								{
									num2++;
									num = -160390661;
								}
								else
								{
									num = -160390660;
								}
								continue;
							default:
								if (num2 >= joysticks_readOnly.Count)
								{
									return ControllerPollingInfo.czsDbiqQNWsvQguTJNJasHdCGwp();
								}
								goto case 2;
							}
							break;
						}
					}
				}

				private ControllerPollingInfo REiidKNUKquakKqhOSRqFcJENkE()
				{
					IList<Joystick> joysticks_readOnly = akUdmKMbrqFLXkjqdKLUZOPTArx.Joysticks_readOnly;
					int num2 = default(int);
					ControllerPollingInfo result = default(ControllerPollingInfo);
					while (true)
					{
						int num = -971892002;
						while (true)
						{
							switch (num ^ -971892001)
							{
							case 4:
								break;
							case 1:
								num2 = 0;
								num = -971892001;
								continue;
							case 2:
								result = joysticks_readOnly[num2].PollForFirstButton();
								num = -971892004;
								continue;
							case 3:
								if (result.success)
								{
									return result;
								}
								num2++;
								num = -971892001;
								continue;
							default:
								if (num2 >= joysticks_readOnly.Count)
								{
									return ControllerPollingInfo.czsDbiqQNWsvQguTJNJasHdCGwp();
								}
								goto case 2;
							}
							break;
						}
					}
				}

				private ControllerPollingInfo TinACdDwnZUzamaxzSJRenLrYpS()
				{
					IList<Joystick> joysticks_readOnly = akUdmKMbrqFLXkjqdKLUZOPTArx.Joysticks_readOnly;
					int num = 0;
					ControllerPollingInfo result = default(ControllerPollingInfo);
					while (true)
					{
						int num2 = 311810309;
						while (true)
						{
							switch (num2 ^ 0x1295D904)
							{
							case 5:
								break;
							case 0:
							{
								int num3;
								if (num < joysticks_readOnly.Count)
								{
									num2 = 311810304;
									num3 = num2;
								}
								else
								{
									num2 = 311810311;
									num3 = num2;
								}
								continue;
							}
							case 4:
								result = joysticks_readOnly[num].PollForFirstButtonDown();
								num2 = 311810310;
								continue;
							case 2:
								if (result.success)
								{
									num2 = 311810306;
									continue;
								}
								num++;
								num2 = 311810308;
								continue;
							case 1:
								num2 = 311810308;
								continue;
							case 6:
								return result;
							default:
								return ControllerPollingInfo.czsDbiqQNWsvQguTJNJasHdCGwp();
							}
							break;
						}
					}
				}

				private ControllerPollingInfo UsISpUmLRMCESCdknWXGExiknoJ()
				{
					IList<Joystick> joysticks_readOnly = akUdmKMbrqFLXkjqdKLUZOPTArx.Joysticks_readOnly;
					int num2 = default(int);
					ControllerPollingInfo result = default(ControllerPollingInfo);
					while (true)
					{
						int num = 1165114678;
						while (true)
						{
							switch (num ^ 0x45723D35)
							{
							case 2:
								break;
							case 3:
								num2 = 0;
								num = 1165114677;
								continue;
							case 1:
								result = joysticks_readOnly[num2].PollForFirstAxis();
								num = 1165114672;
								continue;
							case 5:
								if (result.success)
								{
									return result;
								}
								num2++;
								num = 1165114673;
								continue;
							case 0:
								num = 1165114673;
								continue;
							default:
								if (num2 >= joysticks_readOnly.Count)
								{
									return ControllerPollingInfo.czsDbiqQNWsvQguTJNJasHdCGwp();
								}
								goto case 1;
							}
							break;
						}
					}
				}

				private ControllerPollingInfo dPJGTcfnzOYzHqpHpNONPIyEHCc(int P_0)
				{
					return ControllerHelper.Instance.GetJoystick(P_0)?.PollForFirstElement() ?? ControllerPollingInfo.czsDbiqQNWsvQguTJNJasHdCGwp();
				}

				private ControllerPollingInfo jWfdaspiTMCOiStjCcvSnMLorjT(int P_0)
				{
					return ControllerHelper.Instance.GetJoystick(P_0)?.PollForFirstElementDown() ?? ControllerPollingInfo.czsDbiqQNWsvQguTJNJasHdCGwp();
				}

				private ControllerPollingInfo HBwYfOfXCdVGYmfZDjCgkuVAYWt(int P_0)
				{
					return ControllerHelper.Instance.GetJoystick(P_0)?.PollForFirstButton() ?? ControllerPollingInfo.czsDbiqQNWsvQguTJNJasHdCGwp();
				}

				private ControllerPollingInfo PwofcjbtaFTKmOrtPFlpgMAgQfEV(int P_0)
				{
					return ControllerHelper.Instance.GetJoystick(P_0)?.PollForFirstButtonDown() ?? ControllerPollingInfo.czsDbiqQNWsvQguTJNJasHdCGwp();
				}

				private ControllerPollingInfo szDCypbZgdLUYHRipkFpwVGkiMSe(int P_0)
				{
					return ControllerHelper.Instance.GetJoystick(P_0)?.PollForFirstAxis() ?? ControllerPollingInfo.czsDbiqQNWsvQguTJNJasHdCGwp();
				}

				private ControllerPollingInfo RXvXBwZvNGOQBQuJIaONOFOOqQB()
				{
					return ControllerHelper.Instance.Keyboard.PollForFirstKey();
				}

				private ControllerPollingInfo iNMLSNrWFPHbktMPpnoGjBpuPxB()
				{
					return ControllerHelper.Instance.Keyboard.PollForFirstKeyDown();
				}

				private ControllerPollingInfo zcKsksPOOJCIZZTJKkGuiFBaxJT()
				{
					return ControllerHelper.Instance.Mouse.PollForFirstElement();
				}

				private ControllerPollingInfo wLTgRcOAmBDiGMPICarWBcGtyQAb()
				{
					return ControllerHelper.Instance.Mouse.PollForFirstElementDown();
				}

				private ControllerPollingInfo qkldOXyGdjseGaSXVqOVTReAmeb()
				{
					return ControllerHelper.Instance.Mouse.PollForFirstButton();
				}

				private ControllerPollingInfo ATlESuZHpodKQjDURgYZrgfkGXqV()
				{
					return ControllerHelper.Instance.Mouse.PollForFirstButtonDown();
				}

				private ControllerPollingInfo aCLBFMkbautxgnpMvtTHMyGDctW()
				{
					return ControllerHelper.Instance.Mouse.PollForFirstAxis();
				}

				private ControllerPollingInfo wzCfgemcQOjoqjeQAunokCUNDYU()
				{
					IList<CustomController> customControllers_readOnly = akUdmKMbrqFLXkjqdKLUZOPTArx.CustomControllers_readOnly;
					int num = 0;
					while (num < customControllers_readOnly.Count)
					{
						while (true)
						{
							ControllerPollingInfo result = customControllers_readOnly[num].PollForFirstElement();
							if (result.success)
							{
								return result;
							}
							num++;
							int num2 = 1627777979;
							while (true)
							{
								switch (num2 ^ 0x6105EBBA)
								{
								case 0:
									num2 = 1627777976;
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
					return ControllerPollingInfo.czsDbiqQNWsvQguTJNJasHdCGwp();
				}

				private ControllerPollingInfo NZvYSYavkUCGXMfBIjnkNExXxaC()
				{
					IList<CustomController> customControllers_readOnly = akUdmKMbrqFLXkjqdKLUZOPTArx.CustomControllers_readOnly;
					int num = 0;
					while (true)
					{
						int num2;
						int num3;
						if (num < customControllers_readOnly.Count)
						{
							num2 = 1824087633;
							num3 = num2;
						}
						else
						{
							num2 = 1824087632;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ 0x6CB95E52)
							{
							case 0:
								num2 = 1824087633;
								continue;
							case 3:
							{
								ControllerPollingInfo result = customControllers_readOnly[num].PollForFirstElementDown();
								if (result.success)
								{
									return result;
								}
								num++;
								num2 = 1824087635;
								continue;
							}
							case 1:
								break;
							default:
								return ControllerPollingInfo.czsDbiqQNWsvQguTJNJasHdCGwp();
							}
							break;
						}
					}
				}

				private ControllerPollingInfo hOcjJQnGuCZcasFuqvqHbCJEuDf()
				{
					IList<CustomController> customControllers_readOnly = akUdmKMbrqFLXkjqdKLUZOPTArx.CustomControllers_readOnly;
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
							int num2 = 1935701056;
							while (true)
							{
								switch (num2 ^ 0x73607440)
								{
								case 2:
									num2 = 1935701057;
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
					return ControllerPollingInfo.czsDbiqQNWsvQguTJNJasHdCGwp();
				}

				private ControllerPollingInfo XzcgwafzjFdjOVPUIzRYmkqAdAL()
				{
					IList<CustomController> customControllers_readOnly = akUdmKMbrqFLXkjqdKLUZOPTArx.CustomControllers_readOnly;
					int num = 0;
					ControllerPollingInfo result = default(ControllerPollingInfo);
					while (true)
					{
						int num2 = -852843663;
						while (true)
						{
							switch (num2 ^ -852843662)
							{
							case 4:
								break;
							case 3:
								num2 = -852843662;
								continue;
							case 1:
								return result;
							case 2:
								result = customControllers_readOnly[num].PollForFirstButtonDown();
								if (!result.success)
								{
									num++;
									num2 = -852843662;
								}
								else
								{
									num2 = -852843661;
								}
								continue;
							default:
								if (num >= customControllers_readOnly.Count)
								{
									return ControllerPollingInfo.czsDbiqQNWsvQguTJNJasHdCGwp();
								}
								goto case 2;
							}
							break;
						}
					}
				}

				private ControllerPollingInfo wFkhrgettGFuTwBggYOjaMkdprY()
				{
					IList<CustomController> customControllers_readOnly = akUdmKMbrqFLXkjqdKLUZOPTArx.CustomControllers_readOnly;
					int num = 0;
					while (num < customControllers_readOnly.Count)
					{
						while (true)
						{
							ControllerPollingInfo result = customControllers_readOnly[num].PollForFirstAxis();
							int num2 = 275697905;
							while (true)
							{
								switch (num2 ^ 0x106ED0F2)
								{
								case 2:
									num2 = 275697907;
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
								num2 = 275697906;
							}
							continue;
							end_IL_0031:
							break;
						}
					}
					return ControllerPollingInfo.czsDbiqQNWsvQguTJNJasHdCGwp();
				}

				private ControllerPollingInfo qRBXyhwFznUuUjHLhOQyTGLWfJw(int P_0)
				{
					return ControllerHelper.Instance.GetCustomController(P_0)?.PollForFirstElement() ?? ControllerPollingInfo.czsDbiqQNWsvQguTJNJasHdCGwp();
				}

				private ControllerPollingInfo WAblsogNAWKPzBWYmNNYlrKbIFp(int P_0)
				{
					return ControllerHelper.Instance.GetCustomController(P_0)?.PollForFirstElementDown() ?? ControllerPollingInfo.czsDbiqQNWsvQguTJNJasHdCGwp();
				}

				private ControllerPollingInfo JFIDziFChiJbMdCjTKzMXdhljQU(int P_0)
				{
					return ControllerHelper.Instance.GetCustomController(P_0)?.PollForFirstButton() ?? ControllerPollingInfo.czsDbiqQNWsvQguTJNJasHdCGwp();
				}

				private ControllerPollingInfo QkntgRCktSWkOWmbuBzQANndhzZy(int P_0)
				{
					return ControllerHelper.Instance.GetCustomController(P_0)?.PollForFirstButtonDown() ?? ControllerPollingInfo.czsDbiqQNWsvQguTJNJasHdCGwp();
				}

				private ControllerPollingInfo goNOOodEOohhDxtRJtXJKYUABpO(int P_0)
				{
					return ControllerHelper.Instance.GetCustomController(P_0)?.PollForFirstAxis() ?? ControllerPollingInfo.czsDbiqQNWsvQguTJNJasHdCGwp();
				}

				private IEnumerable<ControllerPollingInfo> EryhAdvSAsRpSPxTBrqLynabLEN()
				{
					dkIDgLCpKXZMGYQQLNKDkcjaJGh dkIDgLCpKXZMGYQQLNKDkcjaJGh2 = new dkIDgLCpKXZMGYQQLNKDkcjaJGh(-2);
					dkIDgLCpKXZMGYQQLNKDkcjaJGh2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
					return dkIDgLCpKXZMGYQQLNKDkcjaJGh2;
				}

				private IEnumerable<ControllerPollingInfo> jFXsMOuBYvqPuajGjCPfHtTJlPD()
				{
					pZOjNisemGjFNZVPXFnTVhYbwti pZOjNisemGjFNZVPXFnTVhYbwti2 = new pZOjNisemGjFNZVPXFnTVhYbwti(-2);
					pZOjNisemGjFNZVPXFnTVhYbwti2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
					return pZOjNisemGjFNZVPXFnTVhYbwti2;
				}

				private IEnumerable<ControllerPollingInfo> BDXqaKgkdRXnsQDcZJDMqkzqcVE()
				{
					xsWzHrRPSUThAKavRAGqFEaAFlih xsWzHrRPSUThAKavRAGqFEaAFlih2 = new xsWzHrRPSUThAKavRAGqFEaAFlih(-2);
					while (true)
					{
						int num = -1954811376;
						while (true)
						{
							switch (num ^ -1954811375)
							{
							case 2:
								break;
							case 1:
								goto IL_0026;
							default:
								return xsWzHrRPSUThAKavRAGqFEaAFlih2;
							}
							break;
							IL_0026:
							xsWzHrRPSUThAKavRAGqFEaAFlih2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
							num = -1954811375;
						}
					}
				}

				private IEnumerable<ControllerPollingInfo> yfDsFsjsoHAnEBROnABWDkWqawLb()
				{
					mLlMreOaVeQADWdmmZyMbcAccsv mLlMreOaVeQADWdmmZyMbcAccsv2 = new mLlMreOaVeQADWdmmZyMbcAccsv(-2);
					mLlMreOaVeQADWdmmZyMbcAccsv2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
					return mLlMreOaVeQADWdmmZyMbcAccsv2;
				}

				private IEnumerable<ControllerPollingInfo> QvjbdreJYHJzNNJNaAIIcVLhlbRh()
				{
					OkxqYpsMDyntDaPWZdaQdXNvnDBw okxqYpsMDyntDaPWZdaQdXNvnDBw = new OkxqYpsMDyntDaPWZdaQdXNvnDBw(-2);
					okxqYpsMDyntDaPWZdaQdXNvnDBw.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
					return okxqYpsMDyntDaPWZdaQdXNvnDBw;
				}

				private IEnumerable<ControllerPollingInfo> FfhayehUtdqgqKFrOjGQzRSGixq(int P_0)
				{
					Joystick joystick = ControllerHelper.Instance.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllElements();
				}

				private IEnumerable<ControllerPollingInfo> BOuEdymszEGPSWkFCdktKXICsVK(int P_0)
				{
					Joystick joystick = ControllerHelper.Instance.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllElementsDown();
				}

				private IEnumerable<ControllerPollingInfo> jOPGNHCaPGcucngNNeZAVGknbm(int P_0)
				{
					Joystick joystick = ControllerHelper.Instance.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllButtons();
				}

				private IEnumerable<ControllerPollingInfo> IfgEgbKtMqzzlbdToKwhiRXxWqcD(int P_0)
				{
					Joystick joystick = ControllerHelper.Instance.GetJoystick(P_0);
					while (true)
					{
						int num = -1811332674;
						while (true)
						{
							switch (num ^ -1811332673)
							{
							case 2:
								break;
							case 1:
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
							num = -1811332673;
						}
					}
				}

				private IEnumerable<ControllerPollingInfo> OxNfqMwvTTjqkKgdsaTfekwgxx(int P_0)
				{
					Joystick joystick = ControllerHelper.Instance.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllAxes();
				}

				private IEnumerable<ControllerPollingInfo> gDkkTbkjunDzYgomHuBtVHKKyugd()
				{
					return ControllerHelper.Instance.Keyboard.PollForAllKeys();
				}

				private IEnumerable<ControllerPollingInfo> YFihCQKfLwUlPaHilGyRDWbGGEhs()
				{
					return ControllerHelper.Instance.Keyboard.PollForAllKeysDown();
				}

				private IEnumerable<ControllerPollingInfo> LWvBSAgTxRsMyBxOdRmnheGbXFz()
				{
					return ControllerHelper.Instance.Mouse.PollForAllElements();
				}

				private IEnumerable<ControllerPollingInfo> VkxyXiOCCUrUaenxypQwkZnutHW()
				{
					return ControllerHelper.Instance.Mouse.PollForAllElementsDown();
				}

				private IEnumerable<ControllerPollingInfo> miHjzAcBEPKficFvHaAFHcLthBCU()
				{
					return ControllerHelper.Instance.Mouse.PollForAllButtons();
				}

				private IEnumerable<ControllerPollingInfo> UiOxmgBhnVCFFDwxMrlvZtxFpLb()
				{
					return ControllerHelper.Instance.Mouse.PollForAllButtonsDown();
				}

				private IEnumerable<ControllerPollingInfo> YeTNaUxKHwpcBUcxqVFBXqJQpoA()
				{
					return ControllerHelper.Instance.Mouse.PollForAllAxes();
				}

				private IEnumerable<ControllerPollingInfo> zcUFwEBZayAeHYOLARPISCyDMtL()
				{
					HdxjWNEcFfXADtkIPncfcPMkJaBo hdxjWNEcFfXADtkIPncfcPMkJaBo = new HdxjWNEcFfXADtkIPncfcPMkJaBo(-2);
					hdxjWNEcFfXADtkIPncfcPMkJaBo.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
					return hdxjWNEcFfXADtkIPncfcPMkJaBo;
				}

				private IEnumerable<ControllerPollingInfo> BYftyvqdMQrIiCsPpQZLfkroaki()
				{
					GGuGsZnPFVFhJfjKEyitDpknMkv gGuGsZnPFVFhJfjKEyitDpknMkv = new GGuGsZnPFVFhJfjKEyitDpknMkv(-2);
					gGuGsZnPFVFhJfjKEyitDpknMkv.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
					return gGuGsZnPFVFhJfjKEyitDpknMkv;
				}

				private IEnumerable<ControllerPollingInfo> SVFjlkKxnzCeeHyjQdOjKFkasqY()
				{
					lFROYnFPJrUPIcImIFMPabhyDgnK lFROYnFPJrUPIcImIFMPabhyDgnK2 = new lFROYnFPJrUPIcImIFMPabhyDgnK(-2);
					lFROYnFPJrUPIcImIFMPabhyDgnK2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
					return lFROYnFPJrUPIcImIFMPabhyDgnK2;
				}

				private IEnumerable<ControllerPollingInfo> yANCwRtKvhWoObLgMNqrbnsSYcX()
				{
					xIppThrUPlAeICTZPRDqXVIVcJP xIppThrUPlAeICTZPRDqXVIVcJP2 = new xIppThrUPlAeICTZPRDqXVIVcJP(-2);
					xIppThrUPlAeICTZPRDqXVIVcJP2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
					return xIppThrUPlAeICTZPRDqXVIVcJP2;
				}

				private IEnumerable<ControllerPollingInfo> uIKiytJDnwrkAnLZdNXPAObcvAE()
				{
					FmcmhibysAuXzaiXjEZYgTfzggY fmcmhibysAuXzaiXjEZYgTfzggY = new FmcmhibysAuXzaiXjEZYgTfzggY(-2);
					fmcmhibysAuXzaiXjEZYgTfzggY.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
					return fmcmhibysAuXzaiXjEZYgTfzggY;
				}

				private IEnumerable<ControllerPollingInfo> ohlelOCrMMtCnWQVuYVsMgRXOkQ(int P_0)
				{
					CustomController customController = ControllerHelper.Instance.GetCustomController(P_0);
					while (true)
					{
						int num = -465107526;
						while (true)
						{
							switch (num ^ -465107528)
							{
							case 0:
								break;
							case 2:
								if (customController == null)
								{
									goto IL_002d;
								}
								return customController.PollForAllElements();
							default:
								return new List<ControllerPollingInfo>();
							}
							break;
							IL_002d:
							num = -465107527;
						}
					}
				}

				private IEnumerable<ControllerPollingInfo> DVUrtPvBLMXeiaznpYKDVgGvFsz(int P_0)
				{
					CustomController customController = ControllerHelper.Instance.GetCustomController(P_0);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllElementsDown();
				}

				private IEnumerable<ControllerPollingInfo> MVaUIIRnHkkMPzaqBMiyYtDifjv(int P_0)
				{
					CustomController customController = ControllerHelper.Instance.GetCustomController(P_0);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllButtons();
				}

				private IEnumerable<ControllerPollingInfo> CSmgQAhNztyBsMfkYyWVHEttgZM(int P_0)
				{
					CustomController customController = ControllerHelper.Instance.GetCustomController(P_0);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllButtonsDown();
				}

				private IEnumerable<ControllerPollingInfo> BbLbbcBIwuDhQeaNcyXNCifxEvpe(int P_0)
				{
					CustomController customController = ControllerHelper.Instance.GetCustomController(P_0);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllAxes();
				}
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			[Browsable(false)]
			public sealed class ConflictCheckingHelper : CodeHelper
			{
				private sealed class sCPzrzAkgvoXEzSEPulTyknMiRq : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo ubyTdixGSFKGaFQFZdQnpwgWIvJ;

					private int isaqVUvqwfWYqOUtovbpbCbxgPc;

					private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

					public int wdJNnMRgnpHAWIQUEkdXEsJWDJsH;

					public int kErIYVWJdlvWnebMUsTtlGzeFPE;

					public int GtleynpRxBpbQMTgQxfjKlwxnpk;

					public int XXVassdjVXBmMeHfiXDThqemgAeP;

					public JoystickMap vJYLrsUuWFUpsmeDHlIgzbxMaII;

					public JoystickMap aAZEnFDyNOCahrdvCVCCKkmeaGi;

					public ActionElementMap zQicwqAUPUbeBiHxZPkXWjzTovA;

					public ActionElementMap xJmIipGrdmNTzniNdfiLboREQWg;

					public bool gDMrNwHmEkVTACgeEefdCmJdpir;

					public bool dGwSNihzjCwVEkHXFGPpgtHVneEu;

					public bool WVELwlyAQCeMffWDxEBQGqUebODy;

					public bool jNymEHJVRXeHYcnwOCdElUZKBrm;

					public bool sxypfhtnUAsQxpWKXsTPuwCCcxz;

					public bool nhpwLZALUoBiqMohOtMMoimMVRO;

					public IList<Player> QvLoWhwAjmAAwRwplUtQjiLcbLy;

					public int LQFTgwHyeCZvNMzEjxXSCzBWzPx;

					public ElementAssignmentConflictInfo IYwQWYyamIkslDhmmGYhkDhhnKG;

					public ConflictCheckingHelper syCPfFbHYMDOvEPjTnPLBqiOhsPv;

					public IEnumerator<ElementAssignmentConflictInfo> DmLfvpGYqOQZxJaEtDUuAktxzCaF;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
						}
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId != TFdbdCIUKXTQPHFlNuiMVnWNXiVT || isaqVUvqwfWYqOUtovbpbCbxgPc != -2)
						{
							goto IL_0051;
						}
						isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
						sCPzrzAkgvoXEzSEPulTyknMiRq sCPzrzAkgvoXEzSEPulTyknMiRq2 = this;
						goto IL_006b;
						IL_002c:
						int num;
						while (true)
						{
							switch (num ^ -285681748)
							{
							case 0:
								num = -285681752;
								continue;
							case 4:
								break;
							case 2:
								goto IL_006b;
							case 3:
								sCPzrzAkgvoXEzSEPulTyknMiRq2.zQicwqAUPUbeBiHxZPkXWjzTovA = xJmIipGrdmNTzniNdfiLboREQWg;
								sCPzrzAkgvoXEzSEPulTyknMiRq2.gDMrNwHmEkVTACgeEefdCmJdpir = dGwSNihzjCwVEkHXFGPpgtHVneEu;
								sCPzrzAkgvoXEzSEPulTyknMiRq2.WVELwlyAQCeMffWDxEBQGqUebODy = jNymEHJVRXeHYcnwOCdElUZKBrm;
								num = -285681751;
								continue;
							case 1:
								sCPzrzAkgvoXEzSEPulTyknMiRq2.vJYLrsUuWFUpsmeDHlIgzbxMaII = aAZEnFDyNOCahrdvCVCCKkmeaGi;
								num = -285681745;
								continue;
							default:
								sCPzrzAkgvoXEzSEPulTyknMiRq2.sxypfhtnUAsQxpWKXsTPuwCCcxz = nhpwLZALUoBiqMohOtMMoimMVRO;
								return sCPzrzAkgvoXEzSEPulTyknMiRq2;
							}
							break;
						}
						goto IL_0051;
						IL_0051:
						sCPzrzAkgvoXEzSEPulTyknMiRq2 = new sCPzrzAkgvoXEzSEPulTyknMiRq(0);
						sCPzrzAkgvoXEzSEPulTyknMiRq2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
						num = -285681746;
						goto IL_002c;
						IL_006b:
						sCPzrzAkgvoXEzSEPulTyknMiRq2.wdJNnMRgnpHAWIQUEkdXEsJWDJsH = kErIYVWJdlvWnebMUsTtlGzeFPE;
						sCPzrzAkgvoXEzSEPulTyknMiRq2.GtleynpRxBpbQMTgQxfjKlwxnpk = XXVassdjVXBmMeHfiXDThqemgAeP;
						num = -285681747;
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
							switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
							{
							case 2:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								num = -1362784078;
								goto IL_0023;
							case 0:
								goto IL_01be;
								IL_0023:
								while (true)
								{
									switch (num ^ -1362784078)
									{
									case 3:
										num = -1362784071;
										continue;
									case 10:
										break;
									case 0:
										if (!DmLfvpGYqOQZxJaEtDUuAktxzCaF.MoveNext())
										{
											HLpgNgaYhxAUJKIrSLxuGqBMnd();
											LQFTgwHyeCZvNMzEjxXSCzBWzPx++;
											num = -1362784072;
											continue;
										}
										goto case 6;
									case 6:
										IYwQWYyamIkslDhmmGYhkDhhnKG = DmLfvpGYqOQZxJaEtDUuAktxzCaF.Current;
										ubyTdixGSFKGaFQFZdQnpwgWIvJ = IYwQWYyamIkslDhmmGYhkDhhnKG;
										isaqVUvqwfWYqOUtovbpbCbxgPc = 2;
										result = true;
										num = -1362784080;
										continue;
									case 9:
										num = -1362784078;
										continue;
									case 7:
										goto IL_00ec;
									case 4:
										goto end_IL_0023;
									case 5:
										DmLfvpGYqOQZxJaEtDUuAktxzCaF = QvLoWhwAjmAAwRwplUtQjiLcbLy[LQFTgwHyeCZvNMzEjxXSCzBWzPx].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Joystick, GtleynpRxBpbQMTgQxfjKlwxnpk, vJYLrsUuWFUpsmeDHlIgzbxMaII, zQicwqAUPUbeBiHxZPkXWjzTovA, gDMrNwHmEkVTACgeEefdCmJdpir, WVELwlyAQCeMffWDxEBQGqUebODy).GetEnumerator();
										isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
										num = -1362784069;
										continue;
									case 2:
										goto end_IL_0000;
									case 8:
										if (zQicwqAUPUbeBiHxZPkXWjzTovA != null)
										{
											QvLoWhwAjmAAwRwplUtQjiLcbLy = (sxypfhtnUAsQxpWKXsTPuwCCcxz ? WhcqAfYYqNfRCEGkYApjWYGKVjr.AllPlayers_readOnly : WhcqAfYYqNfRCEGkYApjWYGKVjr.Players_readOnly);
											LQFTgwHyeCZvNMzEjxXSCzBWzPx = 0;
											num = -1362784072;
											continue;
										}
										goto end_IL_0008;
									case 11:
										goto IL_01be;
									default:
										goto end_IL_0008;
									}
									int num2;
									if (LQFTgwHyeCZvNMzEjxXSCzBWzPx < QvLoWhwAjmAAwRwplUtQjiLcbLy.Count)
									{
										num = -1362784073;
										num2 = num;
									}
									else
									{
										num = -1362784077;
										num2 = num;
									}
									continue;
									IL_00ec:
									int num3;
									if (wdJNnMRgnpHAWIQUEkdXEsJWDJsH >= 0)
									{
										num = -1362784070;
										num3 = num;
									}
									else
									{
										num = -1362784077;
										num3 = num;
									}
									continue;
									end_IL_0023:
									break;
								}
								goto case 2;
								IL_01be:
								isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
								num = -1362784075;
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
						switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								HLpgNgaYhxAUJKIrSLxuGqBMnd();
							}
						}
					}

					[DebuggerHidden]
					public sCPzrzAkgvoXEzSEPulTyknMiRq(int _003C_003E1__state)
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
						TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
					}

					private void HLpgNgaYhxAUJKIrSLxuGqBMnd()
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						if (DmLfvpGYqOQZxJaEtDUuAktxzCaF != null)
						{
							DmLfvpGYqOQZxJaEtDUuAktxzCaF.Dispose();
						}
					}
				}

				private sealed class LLXvGrOqBbRlitKVcqDrBJmoZxH : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo ubyTdixGSFKGaFQFZdQnpwgWIvJ;

					private int isaqVUvqwfWYqOUtovbpbCbxgPc;

					private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

					public ElementAssignmentConflictCheck qmArylEXVEJqtrWPrThLlZZjSRU;

					public ElementAssignmentConflictCheck xMLCmAAGOtcBvnIylDFdJWNwMnF;

					public bool gDMrNwHmEkVTACgeEefdCmJdpir;

					public bool dGwSNihzjCwVEkHXFGPpgtHVneEu;

					public bool WVELwlyAQCeMffWDxEBQGqUebODy;

					public bool jNymEHJVRXeHYcnwOCdElUZKBrm;

					public bool sxypfhtnUAsQxpWKXsTPuwCCcxz;

					public bool nhpwLZALUoBiqMohOtMMoimMVRO;

					public IList<Player> OTUEhPLXcujXYINltMamNPzUPHP;

					public int kHnCOuEZUEWltcFwNOlsLIJHVio;

					public ElementAssignmentConflictInfo ILmdxzHDcrNNciycvAdLQMUNVej;

					public ConflictCheckingHelper syCPfFbHYMDOvEPjTnPLBqiOhsPv;

					public IEnumerator<ElementAssignmentConflictInfo> tDaKtcwOXZpzUsgTKqePZHJKAzPH;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
						}
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT)
						{
							goto IL_0012;
						}
						goto IL_005a;
						IL_0012:
						int num = 1407173643;
						goto IL_0017;
						IL_0017:
						LLXvGrOqBbRlitKVcqDrBJmoZxH lLXvGrOqBbRlitKVcqDrBJmoZxH = default(LLXvGrOqBbRlitKVcqDrBJmoZxH);
						while (true)
						{
							switch (num ^ 0x53DFC40F)
							{
							case 0:
								break;
							case 4:
								if (isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
								{
									isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
									lLXvGrOqBbRlitKVcqDrBJmoZxH = this;
									num = 1407173642;
									continue;
								}
								goto IL_005a;
							case 6:
								goto IL_005a;
							case 1:
								lLXvGrOqBbRlitKVcqDrBJmoZxH.sxypfhtnUAsQxpWKXsTPuwCCcxz = nhpwLZALUoBiqMohOtMMoimMVRO;
								num = 1407173644;
								continue;
							case 5:
								num = 1407173645;
								continue;
							case 2:
								lLXvGrOqBbRlitKVcqDrBJmoZxH.qmArylEXVEJqtrWPrThLlZZjSRU = xMLCmAAGOtcBvnIylDFdJWNwMnF;
								lLXvGrOqBbRlitKVcqDrBJmoZxH.gDMrNwHmEkVTACgeEefdCmJdpir = dGwSNihzjCwVEkHXFGPpgtHVneEu;
								lLXvGrOqBbRlitKVcqDrBJmoZxH.WVELwlyAQCeMffWDxEBQGqUebODy = jNymEHJVRXeHYcnwOCdElUZKBrm;
								num = 1407173646;
								continue;
							default:
								return lLXvGrOqBbRlitKVcqDrBJmoZxH;
							}
							break;
						}
						goto IL_0012;
						IL_005a:
						lLXvGrOqBbRlitKVcqDrBJmoZxH = new LLXvGrOqBbRlitKVcqDrBJmoZxH(0);
						lLXvGrOqBbRlitKVcqDrBJmoZxH.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
						num = 1407173645;
						goto IL_0017;
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
							int num = isaqVUvqwfWYqOUtovbpbCbxgPc;
							while (true)
							{
								IL_0007:
								int num2 = -691676155;
								while (true)
								{
									switch (num2 ^ -691676154)
									{
									case 4:
										break;
									case 16:
										tDaKtcwOXZpzUsgTKqePZHJKAzPH = OTUEhPLXcujXYINltMamNPzUPHP[kHnCOuEZUEWltcFwNOlsLIJHVio].controllers.conflictChecking.ElementAssignmentConflicts(qmArylEXVEJqtrWPrThLlZZjSRU, gDMrNwHmEkVTACgeEefdCmJdpir, WVELwlyAQCeMffWDxEBQGqUebODy).GetEnumerator();
										isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
										num2 = -691676156;
										continue;
									case 9:
										ILmdxzHDcrNNciycvAdLQMUNVej = tDaKtcwOXZpzUsgTKqePZHJKAzPH.Current;
										num2 = -691676157;
										continue;
									case 13:
										if (qmArylEXVEJqtrWPrThLlZZjSRU.elementAssignmentType != ElementAssignmentType.KeyboardKey)
										{
											OTUEhPLXcujXYINltMamNPzUPHP = (sxypfhtnUAsQxpWKXsTPuwCCcxz ? WhcqAfYYqNfRCEGkYApjWYGKVjr.AllPlayers_readOnly : WhcqAfYYqNfRCEGkYApjWYGKVjr.Players_readOnly);
											kHnCOuEZUEWltcFwNOlsLIJHVio = 0;
											num2 = -691676150;
											continue;
										}
										goto IL_021e;
									case 2:
									{
										int num5;
										if (tDaKtcwOXZpzUsgTKqePZHJKAzPH.MoveNext())
										{
											num2 = -691676145;
											num5 = num2;
										}
										else
										{
											num2 = -691676154;
											num5 = num2;
										}
										continue;
									}
									case 6:
										kHnCOuEZUEWltcFwNOlsLIJHVio++;
										num2 = -691676146;
										continue;
									case 7:
										isaqVUvqwfWYqOUtovbpbCbxgPc = 2;
										result = true;
										num2 = -691676151;
										continue;
									case 0:
										LiPBHThWgdRswxjadvghZKOgyzK();
										num2 = -691676160;
										continue;
									case 11:
									{
										isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
										int num4;
										if (qmArylEXVEJqtrWPrThLlZZjSRU.playerId < 0)
										{
											num2 = -691676152;
											num4 = num2;
										}
										else
										{
											num2 = -691676149;
											num4 = num2;
										}
										continue;
									}
									case 5:
										ubyTdixGSFKGaFQFZdQnpwgWIvJ = ILmdxzHDcrNNciycvAdLQMUNVej;
										num2 = -691676159;
										continue;
									case 15:
										goto end_IL_000c;
									case 8:
									{
										int num3;
										if (kHnCOuEZUEWltcFwNOlsLIJHVio >= OTUEhPLXcujXYINltMamNPzUPHP.Count)
										{
											num2 = -691676152;
											num3 = num2;
										}
										else
										{
											num2 = -691676138;
											num3 = num2;
										}
										continue;
									}
									case 12:
										num2 = -691676146;
										continue;
									case 1:
										num2 = -691676152;
										continue;
									case 10:
										goto IL_01f1;
									case 3:
										switch (num)
										{
										case 0:
											break;
										case 2:
											goto IL_01f1;
										default:
											goto IL_0214;
										case 1:
											goto IL_021e;
										}
										goto case 11;
									default:
										goto IL_021e;
										IL_0214:
										num2 = -691676153;
										continue;
										IL_01f1:
										isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
										num2 = -691676156;
										continue;
										IL_021e:
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
						switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								LiPBHThWgdRswxjadvghZKOgyzK();
							}
						}
					}

					[DebuggerHidden]
					public LLXvGrOqBbRlitKVcqDrBJmoZxH(int _003C_003E1__state)
					{
						while (true)
						{
							int num = 1016784661;
							while (true)
							{
								switch (num ^ 0x3C9AE717)
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
								isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
								TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
								num = 1016784662;
							}
						}
					}

					private void LiPBHThWgdRswxjadvghZKOgyzK()
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						if (tDaKtcwOXZpzUsgTKqePZHJKAzPH != null)
						{
							tDaKtcwOXZpzUsgTKqePZHJKAzPH.Dispose();
						}
					}
				}

				private sealed class qlNZbtXKtdAlTaJarJBkhCGLsSDQ : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo ubyTdixGSFKGaFQFZdQnpwgWIvJ;

					private int isaqVUvqwfWYqOUtovbpbCbxgPc;

					private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

					public int wdJNnMRgnpHAWIQUEkdXEsJWDJsH;

					public int kErIYVWJdlvWnebMUsTtlGzeFPE;

					public KeyboardMap VpBsQOBXOFhkanJWHPcWPIOqGtH;

					public KeyboardMap MzqOaouCXHECxACEPdvZImzyeUb;

					public ActionElementMap zQicwqAUPUbeBiHxZPkXWjzTovA;

					public ActionElementMap xJmIipGrdmNTzniNdfiLboREQWg;

					public bool gDMrNwHmEkVTACgeEefdCmJdpir;

					public bool dGwSNihzjCwVEkHXFGPpgtHVneEu;

					public bool WVELwlyAQCeMffWDxEBQGqUebODy;

					public bool jNymEHJVRXeHYcnwOCdElUZKBrm;

					public bool sxypfhtnUAsQxpWKXsTPuwCCcxz;

					public bool nhpwLZALUoBiqMohOtMMoimMVRO;

					public IList<Player> QHndiDfOhdFxgicbnjxbWXryesx;

					public int NdWbfJDuiVPigjAGJVzrjJSGIfj;

					public ElementAssignmentConflictInfo quXPdlUjVgFHuTukfrGHDjucats;

					public ConflictCheckingHelper syCPfFbHYMDOvEPjTnPLBqiOhsPv;

					public IEnumerator<ElementAssignmentConflictInfo> izswpKvvbMkxGezLLuszKARwvZU;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
						}
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
						{
							goto IL_0022;
						}
						goto IL_00b6;
						IL_00b6:
						qlNZbtXKtdAlTaJarJBkhCGLsSDQ qlNZbtXKtdAlTaJarJBkhCGLsSDQ2 = new qlNZbtXKtdAlTaJarJBkhCGLsSDQ(0);
						qlNZbtXKtdAlTaJarJBkhCGLsSDQ2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
						int num = -1592494429;
						goto IL_0027;
						IL_0022:
						num = -1592494432;
						goto IL_0027;
						IL_0027:
						while (true)
						{
							switch (num ^ -1592494430)
							{
							case 5:
								break;
							case 6:
								qlNZbtXKtdAlTaJarJBkhCGLsSDQ2.gDMrNwHmEkVTACgeEefdCmJdpir = dGwSNihzjCwVEkHXFGPpgtHVneEu;
								qlNZbtXKtdAlTaJarJBkhCGLsSDQ2.WVELwlyAQCeMffWDxEBQGqUebODy = jNymEHJVRXeHYcnwOCdElUZKBrm;
								qlNZbtXKtdAlTaJarJBkhCGLsSDQ2.sxypfhtnUAsQxpWKXsTPuwCCcxz = nhpwLZALUoBiqMohOtMMoimMVRO;
								num = -1592494430;
								continue;
							case 1:
								qlNZbtXKtdAlTaJarJBkhCGLsSDQ2.wdJNnMRgnpHAWIQUEkdXEsJWDJsH = kErIYVWJdlvWnebMUsTtlGzeFPE;
								qlNZbtXKtdAlTaJarJBkhCGLsSDQ2.VpBsQOBXOFhkanJWHPcWPIOqGtH = MzqOaouCXHECxACEPdvZImzyeUb;
								qlNZbtXKtdAlTaJarJBkhCGLsSDQ2.zQicwqAUPUbeBiHxZPkXWjzTovA = xJmIipGrdmNTzniNdfiLboREQWg;
								num = -1592494428;
								continue;
							case 3:
								num = -1592494429;
								continue;
							case 4:
								goto IL_00b6;
							case 2:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
								qlNZbtXKtdAlTaJarJBkhCGLsSDQ2 = this;
								num = -1592494431;
								continue;
							default:
								return qlNZbtXKtdAlTaJarJBkhCGLsSDQ2;
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
							int num = isaqVUvqwfWYqOUtovbpbCbxgPc;
							while (true)
							{
								IL_0007:
								int num2 = 65842739;
								while (true)
								{
									switch (num2 ^ 0x3ECAE36)
									{
									case 9:
										break;
									case 12:
										isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
										num2 = 65842750;
										continue;
									case 0:
										quXPdlUjVgFHuTukfrGHDjucats = izswpKvvbMkxGezLLuszKARwvZU.Current;
										num2 = 65842747;
										continue;
									case 1:
										result = true;
										num2 = 65842741;
										continue;
									case 3:
										goto end_IL_000c;
									case 7:
									{
										int num3;
										if (NdWbfJDuiVPigjAGJVzrjJSGIfj >= QHndiDfOhdFxgicbnjxbWXryesx.Count)
										{
											num2 = 65842740;
											num3 = num2;
										}
										else
										{
											num2 = 65842748;
											num3 = num2;
										}
										continue;
									}
									case 4:
										num2 = 65842750;
										continue;
									case 10:
										izswpKvvbMkxGezLLuszKARwvZU = QHndiDfOhdFxgicbnjxbWXryesx[NdWbfJDuiVPigjAGJVzrjJSGIfj].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Keyboard, 0, VpBsQOBXOFhkanJWHPcWPIOqGtH, zQicwqAUPUbeBiHxZPkXWjzTovA, gDMrNwHmEkVTACgeEefdCmJdpir, WVELwlyAQCeMffWDxEBQGqUebODy).GetEnumerator();
										isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
										num2 = 65842738;
										continue;
									case 6:
										NdWbfJDuiVPigjAGJVzrjJSGIfj = 0;
										num2 = 65842737;
										continue;
									case 11:
										goto IL_012a;
									case 5:
										switch (num)
										{
										case 2:
											break;
										case 0:
											goto IL_012a;
										default:
											goto IL_0188;
										case 1:
											goto IL_01dd;
										}
										goto case 12;
									case 13:
										ubyTdixGSFKGaFQFZdQnpwgWIvJ = quXPdlUjVgFHuTukfrGHDjucats;
										isaqVUvqwfWYqOUtovbpbCbxgPc = 2;
										num2 = 65842743;
										continue;
									case 8:
										if (!izswpKvvbMkxGezLLuszKARwvZU.MoveNext())
										{
											vaWMCGchdSpIhSifURuipVRJbfZ();
											NdWbfJDuiVPigjAGJVzrjJSGIfj++;
											num2 = 65842737;
											continue;
										}
										goto case 0;
									default:
										goto IL_01dd;
										IL_0188:
										num2 = 65842740;
										continue;
										IL_012a:
										isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
										if (wdJNnMRgnpHAWIQUEkdXEsJWDJsH >= 0 && zQicwqAUPUbeBiHxZPkXWjzTovA != null)
										{
											QHndiDfOhdFxgicbnjxbWXryesx = (sxypfhtnUAsQxpWKXsTPuwCCcxz ? WhcqAfYYqNfRCEGkYApjWYGKVjr.AllPlayers_readOnly : WhcqAfYYqNfRCEGkYApjWYGKVjr.Players_readOnly);
											num2 = 65842736;
											continue;
										}
										goto IL_01dd;
										IL_01dd:
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
						switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								vaWMCGchdSpIhSifURuipVRJbfZ();
							}
						}
					}

					[DebuggerHidden]
					public qlNZbtXKtdAlTaJarJBkhCGLsSDQ(int _003C_003E1__state)
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
						TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
					}

					private void vaWMCGchdSpIhSifURuipVRJbfZ()
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						if (izswpKvvbMkxGezLLuszKARwvZU != null)
						{
							izswpKvvbMkxGezLLuszKARwvZU.Dispose();
						}
					}
				}

				private sealed class XCEePkZmYsFrZcDEhLXyPrvPuYvp : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo ubyTdixGSFKGaFQFZdQnpwgWIvJ;

					private int isaqVUvqwfWYqOUtovbpbCbxgPc;

					private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

					public ElementAssignmentConflictCheck qmArylEXVEJqtrWPrThLlZZjSRU;

					public ElementAssignmentConflictCheck xMLCmAAGOtcBvnIylDFdJWNwMnF;

					public bool gDMrNwHmEkVTACgeEefdCmJdpir;

					public bool dGwSNihzjCwVEkHXFGPpgtHVneEu;

					public bool WVELwlyAQCeMffWDxEBQGqUebODy;

					public bool jNymEHJVRXeHYcnwOCdElUZKBrm;

					public bool sxypfhtnUAsQxpWKXsTPuwCCcxz;

					public bool nhpwLZALUoBiqMohOtMMoimMVRO;

					public IList<Player> QDAlsLAivtcjhDoHArGndwhFTwt;

					public int JomcjnvecMCJEBYIuLVZjYUYjnM;

					public ElementAssignmentConflictInfo CmpaBikSNedNtdXTfSWGzaFsKpAM;

					public ConflictCheckingHelper syCPfFbHYMDOvEPjTnPLBqiOhsPv;

					public IEnumerator<ElementAssignmentConflictInfo> bZWYoPgiNQyXzqHACbwxscJGnrQ;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
						}
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT)
						{
							goto IL_0012;
						}
						goto IL_004e;
						IL_0012:
						int num = -1326105798;
						goto IL_0017;
						IL_0017:
						XCEePkZmYsFrZcDEhLXyPrvPuYvp xCEePkZmYsFrZcDEhLXyPrvPuYvp = default(XCEePkZmYsFrZcDEhLXyPrvPuYvp);
						while (true)
						{
							switch (num ^ -1326105799)
							{
							case 0:
								break;
							case 3:
								if (isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
								{
									isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
									xCEePkZmYsFrZcDEhLXyPrvPuYvp = this;
									num = -1326105800;
									continue;
								}
								goto IL_004e;
							case 2:
								goto IL_004e;
							default:
								xCEePkZmYsFrZcDEhLXyPrvPuYvp.qmArylEXVEJqtrWPrThLlZZjSRU = xMLCmAAGOtcBvnIylDFdJWNwMnF;
								xCEePkZmYsFrZcDEhLXyPrvPuYvp.gDMrNwHmEkVTACgeEefdCmJdpir = dGwSNihzjCwVEkHXFGPpgtHVneEu;
								xCEePkZmYsFrZcDEhLXyPrvPuYvp.WVELwlyAQCeMffWDxEBQGqUebODy = jNymEHJVRXeHYcnwOCdElUZKBrm;
								xCEePkZmYsFrZcDEhLXyPrvPuYvp.sxypfhtnUAsQxpWKXsTPuwCCcxz = nhpwLZALUoBiqMohOtMMoimMVRO;
								return xCEePkZmYsFrZcDEhLXyPrvPuYvp;
							}
							break;
						}
						goto IL_0012;
						IL_004e:
						xCEePkZmYsFrZcDEhLXyPrvPuYvp = new XCEePkZmYsFrZcDEhLXyPrvPuYvp(0);
						xCEePkZmYsFrZcDEhLXyPrvPuYvp.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
						num = -1326105800;
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
							int num;
							switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
							{
							case 0:
								isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
								if (qmArylEXVEJqtrWPrThLlZZjSRU.playerId < 0 || qmArylEXVEJqtrWPrThLlZZjSRU.elementAssignmentType != ElementAssignmentType.KeyboardKey)
								{
									break;
								}
								QDAlsLAivtcjhDoHArGndwhFTwt = (sxypfhtnUAsQxpWKXsTPuwCCcxz ? WhcqAfYYqNfRCEGkYApjWYGKVjr.AllPlayers_readOnly : WhcqAfYYqNfRCEGkYApjWYGKVjr.Players_readOnly);
								num = -1038526379;
								goto IL_0023;
							case 2:
								goto IL_017b;
								IL_0023:
								while (true)
								{
									switch (num ^ -1038526380)
									{
									case 0:
										num = -1038526384;
										continue;
									case 6:
										JomcjnvecMCJEBYIuLVZjYUYjnM++;
										num = -1038526377;
										continue;
									case 8:
										bZWYoPgiNQyXzqHACbwxscJGnrQ = QDAlsLAivtcjhDoHArGndwhFTwt[JomcjnvecMCJEBYIuLVZjYUYjnM].controllers.conflictChecking.ElementAssignmentConflicts(qmArylEXVEJqtrWPrThLlZZjSRU, gDMrNwHmEkVTACgeEefdCmJdpir, WVELwlyAQCeMffWDxEBQGqUebODy).GetEnumerator();
										isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
										num = -1038526383;
										continue;
									case 9:
										CmpaBikSNedNtdXTfSWGzaFsKpAM = bZWYoPgiNQyXzqHACbwxscJGnrQ.Current;
										ubyTdixGSFKGaFQFZdQnpwgWIvJ = CmpaBikSNedNtdXTfSWGzaFsKpAM;
										isaqVUvqwfWYqOUtovbpbCbxgPc = 2;
										return true;
									case 1:
										JomcjnvecMCJEBYIuLVZjYUYjnM = 0;
										num = -1038526377;
										continue;
									case 4:
										break;
									case 5:
										if (!bZWYoPgiNQyXzqHACbwxscJGnrQ.MoveNext())
										{
											mkRDQgvWPwTGHJDlsalvcrjXCFwk();
											num = -1038526382;
											continue;
										}
										goto case 9;
									case 2:
										goto IL_017b;
									case 3:
										goto IL_018c;
									default:
										goto end_IL_0008;
									}
									break;
									IL_018c:
									int num2;
									if (JomcjnvecMCJEBYIuLVZjYUYjnM < QDAlsLAivtcjhDoHArGndwhFTwt.Count)
									{
										num = -1038526372;
										num2 = num;
									}
									else
									{
										num = -1038526381;
										num2 = num;
									}
								}
								goto case 0;
								IL_017b:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								num = -1038526383;
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
						switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								mkRDQgvWPwTGHJDlsalvcrjXCFwk();
							}
						}
					}

					[DebuggerHidden]
					public XCEePkZmYsFrZcDEhLXyPrvPuYvp(int _003C_003E1__state)
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
						TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
					}

					private void mkRDQgvWPwTGHJDlsalvcrjXCFwk()
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						if (bZWYoPgiNQyXzqHACbwxscJGnrQ != null)
						{
							bZWYoPgiNQyXzqHACbwxscJGnrQ.Dispose();
						}
					}
				}

				private sealed class AMjGnrMVZoxTPHbiyurNnJmogSu : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo ubyTdixGSFKGaFQFZdQnpwgWIvJ;

					private int isaqVUvqwfWYqOUtovbpbCbxgPc;

					private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

					public int wdJNnMRgnpHAWIQUEkdXEsJWDJsH;

					public int kErIYVWJdlvWnebMUsTtlGzeFPE;

					public MouseMap DRJFJPLzfqHyyOfdVcHBEcEtnPr;

					public MouseMap vftSVbwqFzaUIhqmHqcyIzXndZb;

					public ActionElementMap zQicwqAUPUbeBiHxZPkXWjzTovA;

					public ActionElementMap xJmIipGrdmNTzniNdfiLboREQWg;

					public bool gDMrNwHmEkVTACgeEefdCmJdpir;

					public bool dGwSNihzjCwVEkHXFGPpgtHVneEu;

					public bool WVELwlyAQCeMffWDxEBQGqUebODy;

					public bool jNymEHJVRXeHYcnwOCdElUZKBrm;

					public bool sxypfhtnUAsQxpWKXsTPuwCCcxz;

					public bool nhpwLZALUoBiqMohOtMMoimMVRO;

					public IList<Player> kduDcnaKbkXhpKbmPJkRdlWqmYpe;

					public int MzkeMKIifXgedWwATCnUooPzkGWN;

					public ElementAssignmentConflictInfo CWZCeTkSGVuDNDrxVhpXfnjQpwE;

					public ConflictCheckingHelper syCPfFbHYMDOvEPjTnPLBqiOhsPv;

					public IEnumerator<ElementAssignmentConflictInfo> TJKcRfmjMkugOoBUJMxbJGIgvym;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
						}
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT)
						{
							goto IL_0015;
						}
						goto IL_009f;
						IL_0015:
						int num = -382269740;
						goto IL_001a;
						IL_001a:
						AMjGnrMVZoxTPHbiyurNnJmogSu aMjGnrMVZoxTPHbiyurNnJmogSu = default(AMjGnrMVZoxTPHbiyurNnJmogSu);
						while (true)
						{
							switch (num ^ -382269738)
							{
							case 6:
								break;
							case 4:
								aMjGnrMVZoxTPHbiyurNnJmogSu.wdJNnMRgnpHAWIQUEkdXEsJWDJsH = kErIYVWJdlvWnebMUsTtlGzeFPE;
								aMjGnrMVZoxTPHbiyurNnJmogSu.DRJFJPLzfqHyyOfdVcHBEcEtnPr = vftSVbwqFzaUIhqmHqcyIzXndZb;
								aMjGnrMVZoxTPHbiyurNnJmogSu.zQicwqAUPUbeBiHxZPkXWjzTovA = xJmIipGrdmNTzniNdfiLboREQWg;
								num = -382269738;
								continue;
							case 0:
								aMjGnrMVZoxTPHbiyurNnJmogSu.gDMrNwHmEkVTACgeEefdCmJdpir = dGwSNihzjCwVEkHXFGPpgtHVneEu;
								aMjGnrMVZoxTPHbiyurNnJmogSu.WVELwlyAQCeMffWDxEBQGqUebODy = jNymEHJVRXeHYcnwOCdElUZKBrm;
								aMjGnrMVZoxTPHbiyurNnJmogSu.sxypfhtnUAsQxpWKXsTPuwCCcxz = nhpwLZALUoBiqMohOtMMoimMVRO;
								num = -382269741;
								continue;
							case 3:
								goto IL_009f;
							case 2:
								goto IL_00bc;
							case 1:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
								aMjGnrMVZoxTPHbiyurNnJmogSu = this;
								num = -382269742;
								continue;
							default:
								return aMjGnrMVZoxTPHbiyurNnJmogSu;
							}
							break;
							IL_00bc:
							int num2;
							if (isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
							{
								num = -382269737;
								num2 = num;
							}
							else
							{
								num = -382269739;
								num2 = num;
							}
						}
						goto IL_0015;
						IL_009f:
						aMjGnrMVZoxTPHbiyurNnJmogSu = new AMjGnrMVZoxTPHbiyurNnJmogSu(0);
						aMjGnrMVZoxTPHbiyurNnJmogSu.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
						num = -382269742;
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
							int num = isaqVUvqwfWYqOUtovbpbCbxgPc;
							while (true)
							{
								IL_0007:
								int num2 = -1664755641;
								while (true)
								{
									switch (num2 ^ -1664755642)
									{
									case 10:
										break;
									default:
										goto end_IL_000c;
									case 0:
									{
										isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
										int num3;
										if (wdJNnMRgnpHAWIQUEkdXEsJWDJsH >= 0)
										{
											num2 = -1664755648;
											num3 = num2;
										}
										else
										{
											num2 = -1664755634;
											num3 = num2;
										}
										continue;
									}
									case 8:
										goto IL_0071;
									case 9:
										CWZCeTkSGVuDNDrxVhpXfnjQpwE = TJKcRfmjMkugOoBUJMxbJGIgvym.Current;
										ubyTdixGSFKGaFQFZdQnpwgWIvJ = CWZCeTkSGVuDNDrxVhpXfnjQpwE;
										isaqVUvqwfWYqOUtovbpbCbxgPc = 2;
										result = true;
										goto end_IL_000c;
									case 1:
										switch (num)
										{
										case 0:
											break;
										case 1:
											goto IL_0071;
										default:
											goto IL_00c1;
										case 2:
											goto IL_0192;
										}
										goto case 0;
									case 2:
									{
										int num4;
										if (MzkeMKIifXgedWwATCnUooPzkGWN < kduDcnaKbkXhpKbmPJkRdlWqmYpe.Count)
										{
											num2 = -1664755646;
											num4 = num2;
										}
										else
										{
											num2 = -1664755634;
											num4 = num2;
										}
										continue;
									}
									case 6:
										if (zQicwqAUPUbeBiHxZPkXWjzTovA != null)
										{
											kduDcnaKbkXhpKbmPJkRdlWqmYpe = (sxypfhtnUAsQxpWKXsTPuwCCcxz ? WhcqAfYYqNfRCEGkYApjWYGKVjr.AllPlayers_readOnly : WhcqAfYYqNfRCEGkYApjWYGKVjr.Players_readOnly);
											MzkeMKIifXgedWwATCnUooPzkGWN = 0;
											num2 = -1664755644;
											continue;
										}
										goto IL_0071;
									case 5:
										isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
										num2 = -1664755643;
										continue;
									case 4:
										TJKcRfmjMkugOoBUJMxbJGIgvym = kduDcnaKbkXhpKbmPJkRdlWqmYpe[MzkeMKIifXgedWwATCnUooPzkGWN].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Mouse, 0, DRJFJPLzfqHyyOfdVcHBEcEtnPr, zQicwqAUPUbeBiHxZPkXWjzTovA, gDMrNwHmEkVTACgeEefdCmJdpir, WVELwlyAQCeMffWDxEBQGqUebODy).GetEnumerator();
										num2 = -1664755645;
										continue;
									case 7:
										goto IL_0192;
									case 12:
										num2 = -1664755634;
										continue;
									case 3:
										if (!TJKcRfmjMkugOoBUJMxbJGIgvym.MoveNext())
										{
											RjKQoHtOXuJUqvGwkSTHVjiORzY();
											MzkeMKIifXgedWwATCnUooPzkGWN++;
											num2 = -1664755644;
											continue;
										}
										goto case 9;
									case 11:
										goto end_IL_000c;
										IL_00c1:
										num2 = -1664755638;
										continue;
										IL_0192:
										isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
										num2 = -1664755643;
										continue;
										IL_0071:
										result = false;
										num2 = -1664755635;
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
						switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								RjKQoHtOXuJUqvGwkSTHVjiORzY();
							}
						}
					}

					[DebuggerHidden]
					public AMjGnrMVZoxTPHbiyurNnJmogSu(int _003C_003E1__state)
					{
						while (true)
						{
							int num = -1314399437;
							while (true)
							{
								switch (num ^ -1314399438)
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
								isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
								TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
								num = -1314399440;
							}
						}
					}

					private void RjKQoHtOXuJUqvGwkSTHVjiORzY()
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						if (TJKcRfmjMkugOoBUJMxbJGIgvym != null)
						{
							TJKcRfmjMkugOoBUJMxbJGIgvym.Dispose();
						}
					}
				}

				private sealed class jFAilfAUezsbrJAsEkpaBeAHibO : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo ubyTdixGSFKGaFQFZdQnpwgWIvJ;

					private int isaqVUvqwfWYqOUtovbpbCbxgPc;

					private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

					public ElementAssignmentConflictCheck qmArylEXVEJqtrWPrThLlZZjSRU;

					public ElementAssignmentConflictCheck xMLCmAAGOtcBvnIylDFdJWNwMnF;

					public bool gDMrNwHmEkVTACgeEefdCmJdpir;

					public bool dGwSNihzjCwVEkHXFGPpgtHVneEu;

					public bool WVELwlyAQCeMffWDxEBQGqUebODy;

					public bool jNymEHJVRXeHYcnwOCdElUZKBrm;

					public bool sxypfhtnUAsQxpWKXsTPuwCCcxz;

					public bool nhpwLZALUoBiqMohOtMMoimMVRO;

					public IList<Player> GDfCpZQMSPiwZyisvRHIvgdXuRI;

					public int TzIDuwFsZZIdIMimWfNSbhiVbkeh;

					public ElementAssignmentConflictInfo dyGvRvpfcMcFqjGbSkIGBFUMcOx;

					public ConflictCheckingHelper syCPfFbHYMDOvEPjTnPLBqiOhsPv;

					public IEnumerator<ElementAssignmentConflictInfo> SezMcCKuiwMrWaTsseCuoxeLmgD;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
						}
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT)
						{
							goto IL_0012;
						}
						goto IL_004b;
						IL_0012:
						int num = -754563549;
						goto IL_0017;
						IL_0017:
						jFAilfAUezsbrJAsEkpaBeAHibO jFAilfAUezsbrJAsEkpaBeAHibO2 = default(jFAilfAUezsbrJAsEkpaBeAHibO);
						while (true)
						{
							switch (num ^ -754563545)
							{
							case 3:
								break;
							case 2:
								jFAilfAUezsbrJAsEkpaBeAHibO2.qmArylEXVEJqtrWPrThLlZZjSRU = xMLCmAAGOtcBvnIylDFdJWNwMnF;
								num = -754563546;
								continue;
							case 0:
								goto IL_004b;
							case 4:
								if (isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
								{
									isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
									jFAilfAUezsbrJAsEkpaBeAHibO2 = this;
									num = -754563547;
									continue;
								}
								goto IL_004b;
							default:
								jFAilfAUezsbrJAsEkpaBeAHibO2.gDMrNwHmEkVTACgeEefdCmJdpir = dGwSNihzjCwVEkHXFGPpgtHVneEu;
								jFAilfAUezsbrJAsEkpaBeAHibO2.WVELwlyAQCeMffWDxEBQGqUebODy = jNymEHJVRXeHYcnwOCdElUZKBrm;
								jFAilfAUezsbrJAsEkpaBeAHibO2.sxypfhtnUAsQxpWKXsTPuwCCcxz = nhpwLZALUoBiqMohOtMMoimMVRO;
								return jFAilfAUezsbrJAsEkpaBeAHibO2;
							}
							break;
						}
						goto IL_0012;
						IL_004b:
						jFAilfAUezsbrJAsEkpaBeAHibO2 = new jFAilfAUezsbrJAsEkpaBeAHibO(0);
						jFAilfAUezsbrJAsEkpaBeAHibO2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
						num = -754563547;
						goto IL_0017;
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
							int num = isaqVUvqwfWYqOUtovbpbCbxgPc;
							while (true)
							{
								IL_0007:
								int num2 = 1832776627;
								while (true)
								{
									switch (num2 ^ 0x6D3DF3BF)
									{
									case 10:
										break;
									default:
										goto end_IL_000c;
									case 8:
										TzIDuwFsZZIdIMimWfNSbhiVbkeh = 0;
										num2 = 1832776638;
										continue;
									case 3:
									{
										isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
										int num4;
										if (qmArylEXVEJqtrWPrThLlZZjSRU.playerId < 0)
										{
											num2 = 1832776637;
											num4 = num2;
										}
										else
										{
											num2 = 1832776632;
											num4 = num2;
										}
										continue;
									}
									case 1:
										num2 = 1832776634;
										continue;
									case 0:
										if (!SezMcCKuiwMrWaTsseCuoxeLmgD.MoveNext())
										{
											JBUhuVwkBymBxFkbGKjpAxuORzE();
											TzIDuwFsZZIdIMimWfNSbhiVbkeh++;
											num2 = 1832776634;
											continue;
										}
										goto case 6;
									case 4:
										SezMcCKuiwMrWaTsseCuoxeLmgD = GDfCpZQMSPiwZyisvRHIvgdXuRI[TzIDuwFsZZIdIMimWfNSbhiVbkeh].controllers.conflictChecking.ElementAssignmentConflicts(qmArylEXVEJqtrWPrThLlZZjSRU, gDMrNwHmEkVTACgeEefdCmJdpir, WVELwlyAQCeMffWDxEBQGqUebODy).GetEnumerator();
										isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
										num2 = 1832776628;
										continue;
									case 5:
									{
										int num3;
										if (TzIDuwFsZZIdIMimWfNSbhiVbkeh >= GDfCpZQMSPiwZyisvRHIvgdXuRI.Count)
										{
											num2 = 1832776637;
											num3 = num2;
										}
										else
										{
											num2 = 1832776635;
											num3 = num2;
										}
										continue;
									}
									case 12:
										switch (num)
										{
										case 0:
											break;
										default:
											goto IL_0147;
										case 2:
											goto IL_01c9;
										case 1:
											goto IL_01da;
										}
										goto case 3;
									case 7:
										if (qmArylEXVEJqtrWPrThLlZZjSRU.elementAssignmentType != ElementAssignmentType.KeyboardKey)
										{
											GDfCpZQMSPiwZyisvRHIvgdXuRI = (sxypfhtnUAsQxpWKXsTPuwCCcxz ? WhcqAfYYqNfRCEGkYApjWYGKVjr.AllPlayers_readOnly : WhcqAfYYqNfRCEGkYApjWYGKVjr.Players_readOnly);
											num2 = 1832776631;
											continue;
										}
										goto IL_01da;
									case 11:
										num2 = 1832776639;
										continue;
									case 6:
										dyGvRvpfcMcFqjGbSkIGBFUMcOx = SezMcCKuiwMrWaTsseCuoxeLmgD.Current;
										ubyTdixGSFKGaFQFZdQnpwgWIvJ = dyGvRvpfcMcFqjGbSkIGBFUMcOx;
										isaqVUvqwfWYqOUtovbpbCbxgPc = 2;
										result = true;
										goto end_IL_000c;
									case 13:
										goto IL_01c9;
									case 2:
										goto IL_01da;
									case 9:
										goto end_IL_000c;
										IL_01da:
										result = false;
										num2 = 1832776630;
										continue;
										IL_01c9:
										isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
										num2 = 1832776639;
										continue;
										IL_0147:
										num2 = 1832776637;
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
						switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								JBUhuVwkBymBxFkbGKjpAxuORzE();
							}
						}
					}

					[DebuggerHidden]
					public jFAilfAUezsbrJAsEkpaBeAHibO(int _003C_003E1__state)
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
						TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
					}

					private void JBUhuVwkBymBxFkbGKjpAxuORzE()
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						while (true)
						{
							int num = -1921577997;
							while (true)
							{
								switch (num ^ -1921577999)
								{
								case 0:
									break;
								default:
									return;
								case 2:
									if (SezMcCKuiwMrWaTsseCuoxeLmgD != null)
									{
										goto IL_002d;
									}
									return;
								case 1:
									return;
								}
								break;
								IL_002d:
								SezMcCKuiwMrWaTsseCuoxeLmgD.Dispose();
								num = -1921578000;
							}
						}
					}
				}

				private sealed class jehUOQdeTuRAFsblyHPvbfHJwIz : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo ubyTdixGSFKGaFQFZdQnpwgWIvJ;

					private int isaqVUvqwfWYqOUtovbpbCbxgPc;

					private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

					public int wdJNnMRgnpHAWIQUEkdXEsJWDJsH;

					public int kErIYVWJdlvWnebMUsTtlGzeFPE;

					public int GtleynpRxBpbQMTgQxfjKlwxnpk;

					public int XXVassdjVXBmMeHfiXDThqemgAeP;

					public CustomControllerMap vxIatcLxdFeZjbYwHSKbAPdRIOUi;

					public CustomControllerMap CZjAKSpSQwaWcMFrVKHWmloujSi;

					public ActionElementMap zQicwqAUPUbeBiHxZPkXWjzTovA;

					public ActionElementMap xJmIipGrdmNTzniNdfiLboREQWg;

					public bool gDMrNwHmEkVTACgeEefdCmJdpir;

					public bool dGwSNihzjCwVEkHXFGPpgtHVneEu;

					public bool WVELwlyAQCeMffWDxEBQGqUebODy;

					public bool jNymEHJVRXeHYcnwOCdElUZKBrm;

					public bool sxypfhtnUAsQxpWKXsTPuwCCcxz;

					public bool nhpwLZALUoBiqMohOtMMoimMVRO;

					public IList<Player> rUTAUvyFglvOqXGMSZNqpFQQuvU;

					public int TWWaHAUkbEOnKKMpFFZUSJuRLJP;

					public ElementAssignmentConflictInfo JLEUuOWWExaOoTjHFFRkCvUGNlZi;

					public ConflictCheckingHelper syCPfFbHYMDOvEPjTnPLBqiOhsPv;

					public IEnumerator<ElementAssignmentConflictInfo> jzFSuQRycEVBtuictjnEgHjsMOvY;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
						}
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						jehUOQdeTuRAFsblyHPvbfHJwIz jehUOQdeTuRAFsblyHPvbfHJwIz2;
						if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
						{
							isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
							jehUOQdeTuRAFsblyHPvbfHJwIz2 = this;
							goto IL_002b;
						}
						goto IL_00a6;
						IL_0030:
						int num;
						while (true)
						{
							switch (num ^ 0x68BF52E8)
							{
							case 5:
								break;
							case 2:
								num = 1757369064;
								continue;
							case 4:
								jehUOQdeTuRAFsblyHPvbfHJwIz2.vxIatcLxdFeZjbYwHSKbAPdRIOUi = CZjAKSpSQwaWcMFrVKHWmloujSi;
								jehUOQdeTuRAFsblyHPvbfHJwIz2.zQicwqAUPUbeBiHxZPkXWjzTovA = xJmIipGrdmNTzniNdfiLboREQWg;
								jehUOQdeTuRAFsblyHPvbfHJwIz2.gDMrNwHmEkVTACgeEefdCmJdpir = dGwSNihzjCwVEkHXFGPpgtHVneEu;
								num = 1757369067;
								continue;
							case 0:
								jehUOQdeTuRAFsblyHPvbfHJwIz2.wdJNnMRgnpHAWIQUEkdXEsJWDJsH = kErIYVWJdlvWnebMUsTtlGzeFPE;
								jehUOQdeTuRAFsblyHPvbfHJwIz2.GtleynpRxBpbQMTgQxfjKlwxnpk = XXVassdjVXBmMeHfiXDThqemgAeP;
								num = 1757369068;
								continue;
							case 1:
								goto IL_00a6;
							default:
								jehUOQdeTuRAFsblyHPvbfHJwIz2.WVELwlyAQCeMffWDxEBQGqUebODy = jNymEHJVRXeHYcnwOCdElUZKBrm;
								jehUOQdeTuRAFsblyHPvbfHJwIz2.sxypfhtnUAsQxpWKXsTPuwCCcxz = nhpwLZALUoBiqMohOtMMoimMVRO;
								return jehUOQdeTuRAFsblyHPvbfHJwIz2;
							}
							break;
						}
						goto IL_002b;
						IL_00a6:
						jehUOQdeTuRAFsblyHPvbfHJwIz2 = new jehUOQdeTuRAFsblyHPvbfHJwIz(0);
						jehUOQdeTuRAFsblyHPvbfHJwIz2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
						num = 1757369064;
						goto IL_0030;
						IL_002b:
						num = 1757369066;
						goto IL_0030;
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
							switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
							{
							default:
								goto IL_0058;
							case 2:
								goto IL_0093;
							case 0:
								goto IL_0159;
								IL_0058:
								result = false;
								num = -987077866;
								goto IL_0020;
								IL_0020:
								while (true)
								{
									switch (num ^ -987077870)
									{
									case 7:
										num = -987077871;
										continue;
									case 6:
										goto IL_0058;
									case 0:
										TWWaHAUkbEOnKKMpFFZUSJuRLJP++;
										num = -987077862;
										continue;
									case 9:
										if (!jzFSuQRycEVBtuictjnEgHjsMOvY.MoveNext())
										{
											gOloXYudpRzfXFMkVKtdbdxFFFl();
											num = -987077870;
											continue;
										}
										goto case 5;
									case 1:
										goto IL_0093;
									case 2:
										jzFSuQRycEVBtuictjnEgHjsMOvY = rUTAUvyFglvOqXGMSZNqpFQQuvU[TWWaHAUkbEOnKKMpFFZUSJuRLJP].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Custom, GtleynpRxBpbQMTgQxfjKlwxnpk, vxIatcLxdFeZjbYwHSKbAPdRIOUi, zQicwqAUPUbeBiHxZPkXWjzTovA, gDMrNwHmEkVTACgeEefdCmJdpir, WVELwlyAQCeMffWDxEBQGqUebODy).GetEnumerator();
										isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
										num = -987077861;
										continue;
									case 8:
										goto IL_0100;
									case 5:
										JLEUuOWWExaOoTjHFFRkCvUGNlZi = jzFSuQRycEVBtuictjnEgHjsMOvY.Current;
										ubyTdixGSFKGaFQFZdQnpwgWIvJ = JLEUuOWWExaOoTjHFFRkCvUGNlZi;
										isaqVUvqwfWYqOUtovbpbCbxgPc = 2;
										result = true;
										break;
									case 3:
										goto IL_0159;
									case 4:
										break;
									}
									break;
									IL_0100:
									int num2;
									if (TWWaHAUkbEOnKKMpFFZUSJuRLJP < rUTAUvyFglvOqXGMSZNqpFQQuvU.Count)
									{
										num = -987077872;
										num2 = num;
									}
									else
									{
										num = -987077868;
										num2 = num;
									}
								}
								break;
								IL_0159:
								isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
								if (wdJNnMRgnpHAWIQUEkdXEsJWDJsH >= 0 && zQicwqAUPUbeBiHxZPkXWjzTovA != null)
								{
									rUTAUvyFglvOqXGMSZNqpFQQuvU = (sxypfhtnUAsQxpWKXsTPuwCCcxz ? WhcqAfYYqNfRCEGkYApjWYGKVjr.AllPlayers_readOnly : WhcqAfYYqNfRCEGkYApjWYGKVjr.Players_readOnly);
									TWWaHAUkbEOnKKMpFFZUSJuRLJP = 0;
									num = -987077862;
									goto IL_0020;
								}
								goto IL_0058;
								IL_0093:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								num = -987077861;
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
						switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								gOloXYudpRzfXFMkVKtdbdxFFFl();
							}
						}
					}

					[DebuggerHidden]
					public jehUOQdeTuRAFsblyHPvbfHJwIz(int _003C_003E1__state)
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
						TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
					}

					private void gOloXYudpRzfXFMkVKtdbdxFFFl()
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						while (true)
						{
							int num = -655139571;
							while (true)
							{
								switch (num ^ -655139569)
								{
								case 0:
									break;
								default:
									return;
								case 2:
								{
									int num2;
									if (jzFSuQRycEVBtuictjnEgHjsMOvY == null)
									{
										num = -655139570;
										num2 = num;
									}
									else
									{
										num = -655139572;
										num2 = num;
									}
									continue;
								}
								case 3:
									jzFSuQRycEVBtuictjnEgHjsMOvY.Dispose();
									num = -655139570;
									continue;
								case 1:
									return;
								}
								break;
							}
						}
					}
				}

				private sealed class mRuFHhWlCZGOHSKOxcNXQSthCxs : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo ubyTdixGSFKGaFQFZdQnpwgWIvJ;

					private int isaqVUvqwfWYqOUtovbpbCbxgPc;

					private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

					public ElementAssignmentConflictCheck qmArylEXVEJqtrWPrThLlZZjSRU;

					public ElementAssignmentConflictCheck xMLCmAAGOtcBvnIylDFdJWNwMnF;

					public bool gDMrNwHmEkVTACgeEefdCmJdpir;

					public bool dGwSNihzjCwVEkHXFGPpgtHVneEu;

					public bool WVELwlyAQCeMffWDxEBQGqUebODy;

					public bool jNymEHJVRXeHYcnwOCdElUZKBrm;

					public bool sxypfhtnUAsQxpWKXsTPuwCCcxz;

					public bool nhpwLZALUoBiqMohOtMMoimMVRO;

					public IList<Player> qXyHaVtAGrBQGJWhoBtSGcFZxPsb;

					public int bbTzrjQhtMAtpbtUAdxcFRzEpcYJ;

					public ElementAssignmentConflictInfo rkTIqDAQaJXTqhAoWdJFaZPchMG;

					public ConflictCheckingHelper syCPfFbHYMDOvEPjTnPLBqiOhsPv;

					public IEnumerator<ElementAssignmentConflictInfo> nnTwtXMSQRvEIKQltTIcLslDheX;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
						}
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						if (Thread.CurrentThread.ManagedThreadId != TFdbdCIUKXTQPHFlNuiMVnWNXiVT || isaqVUvqwfWYqOUtovbpbCbxgPc != -2)
						{
							goto IL_0049;
						}
						isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
						mRuFHhWlCZGOHSKOxcNXQSthCxs mRuFHhWlCZGOHSKOxcNXQSthCxs2 = this;
						goto IL_0063;
						IL_002c:
						int num;
						while (true)
						{
							switch (num ^ 0x4CE97609)
							{
							case 3:
								num = 1290368520;
								continue;
							case 1:
								break;
							case 2:
								goto IL_0063;
							default:
								mRuFHhWlCZGOHSKOxcNXQSthCxs2.gDMrNwHmEkVTACgeEefdCmJdpir = dGwSNihzjCwVEkHXFGPpgtHVneEu;
								mRuFHhWlCZGOHSKOxcNXQSthCxs2.WVELwlyAQCeMffWDxEBQGqUebODy = jNymEHJVRXeHYcnwOCdElUZKBrm;
								mRuFHhWlCZGOHSKOxcNXQSthCxs2.sxypfhtnUAsQxpWKXsTPuwCCcxz = nhpwLZALUoBiqMohOtMMoimMVRO;
								return mRuFHhWlCZGOHSKOxcNXQSthCxs2;
							}
							break;
						}
						goto IL_0049;
						IL_0049:
						mRuFHhWlCZGOHSKOxcNXQSthCxs2 = new mRuFHhWlCZGOHSKOxcNXQSthCxs(0);
						mRuFHhWlCZGOHSKOxcNXQSthCxs2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
						num = 1290368523;
						goto IL_002c;
						IL_0063:
						mRuFHhWlCZGOHSKOxcNXQSthCxs2.qmArylEXVEJqtrWPrThLlZZjSRU = xMLCmAAGOtcBvnIylDFdJWNwMnF;
						num = 1290368521;
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
							int num = isaqVUvqwfWYqOUtovbpbCbxgPc;
							while (true)
							{
								IL_0007:
								int num2 = 1462520595;
								while (true)
								{
									switch (num2 ^ 0x572C4B16)
									{
									case 9:
										break;
									default:
										goto end_IL_000c;
									case 3:
										nnTwtXMSQRvEIKQltTIcLslDheX = qXyHaVtAGrBQGJWhoBtSGcFZxPsb[bbTzrjQhtMAtpbtUAdxcFRzEpcYJ].controllers.conflictChecking.ElementAssignmentConflicts(qmArylEXVEJqtrWPrThLlZZjSRU, gDMrNwHmEkVTACgeEefdCmJdpir, WVELwlyAQCeMffWDxEBQGqUebODy).GetEnumerator();
										isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
										num2 = 1462520604;
										continue;
									case 7:
										num2 = 1462520592;
										continue;
									case 10:
										if (!nnTwtXMSQRvEIKQltTIcLslDheX.MoveNext())
										{
											URvFxDYbdDMRIJVfQoexwSZbPLQ();
											bbTzrjQhtMAtpbtUAdxcFRzEpcYJ++;
											num2 = 1462520606;
											continue;
										}
										goto case 1;
									case 0:
										isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
										if (qmArylEXVEJqtrWPrThLlZZjSRU.playerId >= 0 && qmArylEXVEJqtrWPrThLlZZjSRU.elementAssignmentType != ElementAssignmentType.KeyboardKey)
										{
											qXyHaVtAGrBQGJWhoBtSGcFZxPsb = (sxypfhtnUAsQxpWKXsTPuwCCcxz ? WhcqAfYYqNfRCEGkYApjWYGKVjr.AllPlayers_readOnly : WhcqAfYYqNfRCEGkYApjWYGKVjr.Players_readOnly);
											bbTzrjQhtMAtpbtUAdxcFRzEpcYJ = 0;
											num2 = 1462520606;
											continue;
										}
										goto IL_01b2;
									case 8:
									{
										int num3;
										if (bbTzrjQhtMAtpbtUAdxcFRzEpcYJ >= qXyHaVtAGrBQGJWhoBtSGcFZxPsb.Count)
										{
											num2 = 1462520592;
											num3 = num2;
										}
										else
										{
											num2 = 1462520597;
											num3 = num2;
										}
										continue;
									}
									case 2:
										goto IL_0153;
									case 5:
										switch (num)
										{
										case 0:
											break;
										case 2:
											goto IL_0153;
										default:
											goto IL_0176;
										case 1:
											goto IL_01b2;
										}
										goto case 0;
									case 1:
										rkTIqDAQaJXTqhAoWdJFaZPchMG = nnTwtXMSQRvEIKQltTIcLslDheX.Current;
										ubyTdixGSFKGaFQFZdQnpwgWIvJ = rkTIqDAQaJXTqhAoWdJFaZPchMG;
										isaqVUvqwfWYqOUtovbpbCbxgPc = 2;
										result = true;
										goto end_IL_000c;
									case 6:
										goto IL_01b2;
									case 4:
										goto end_IL_000c;
										IL_0176:
										num2 = 1462520593;
										continue;
										IL_0153:
										isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
										num2 = 1462520604;
										continue;
										IL_01b2:
										result = false;
										num2 = 1462520594;
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
						switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								URvFxDYbdDMRIJVfQoexwSZbPLQ();
							}
						}
					}

					[DebuggerHidden]
					public mRuFHhWlCZGOHSKOxcNXQSthCxs(int _003C_003E1__state)
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
						TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
					}

					private void URvFxDYbdDMRIJVfQoexwSZbPLQ()
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						if (nnTwtXMSQRvEIKQltTIcLslDheX == null)
						{
							return;
						}
						while (true)
						{
							int num = -745608224;
							while (true)
							{
								switch (num ^ -745608223)
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
								nnTwtXMSQRvEIKQltTIcLslDheX.Dispose();
								num = -745608223;
							}
						}
					}
				}

				private static ConflictCheckingHelper ilVQEiENSgAnwgRreWwIUWTqyneQ;

				internal static ConflictCheckingHelper Instance => ilVQEiENSgAnwgRreWwIUWTqyneQ ?? (ilVQEiENSgAnwgRreWwIUWTqyneQ = new ConflictCheckingHelper());

				private ConflictCheckingHelper()
				{
				}

				public bool DoesAnyElementAssignmentConflict()
				{
					return DoesAnyElementAssignmentConflict(skipDisabledMaps: false, forceCheckAllCategories: false, includeSystemPlayer: true);
				}

				public bool DoesAnyElementAssignmentConflict(bool skipDisabledMaps)
				{
					return DoesAnyElementAssignmentConflict(skipDisabledMaps, forceCheckAllCategories: false, includeSystemPlayer: true);
				}

				public bool DoesAnyElementAssignmentConflict(bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					return DoesAnyElementAssignmentConflict(skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer: true);
				}

				public bool DoesAnyElementAssignmentConflict(bool skipDisabledMaps, bool forceCheckAllCategories, bool includeSystemPlayer)
				{
					if (!CheckInitialized())
					{
						goto IL_000a;
					}
					int num;
					if (!includeSystemPlayer)
					{
						num = 1622594724;
						goto IL_000f;
					}
					IList<Player> list = WhcqAfYYqNfRCEGkYApjWYGKVjr.AllPlayers_readOnly;
					goto IL_0283;
					IL_000f:
					Player player3 = default(Player);
					IList<Player> list2 = default(IList<Player>);
					int num7 = default(int);
					int num5 = default(int);
					IList<Joystick> joysticks = default(IList<Joystick>);
					Player player2 = default(Player);
					int num8 = default(int);
					int num13 = default(int);
					int num3 = default(int);
					int num11 = default(int);
					int num9 = default(int);
					int count = default(int);
					int num10 = default(int);
					Joystick joystick = default(Joystick);
					IList<JoystickMap> maps4 = default(IList<JoystickMap>);
					int num12 = default(int);
					Player player4 = default(Player);
					int count3 = default(int);
					IList<CustomControllerMap> maps3 = default(IList<CustomControllerMap>);
					int count2 = default(int);
					int num6 = default(int);
					CustomController customController = default(CustomController);
					IList<CustomController> customControllers = default(IList<CustomController>);
					int num4 = default(int);
					int num2 = default(int);
					IList<KeyboardMap> maps = default(IList<KeyboardMap>);
					IList<MouseMap> maps2 = default(IList<MouseMap>);
					Player player = default(Player);
					while (true)
					{
						switch (num ^ 0x60B6D4A0)
						{
						case 38:
							break;
						case 8:
							return false;
						case 9:
							player3 = list2[num7];
							num = 1622594742;
							continue;
						case 18:
							goto IL_00e5;
						case 11:
							num5 = 0;
							num = 1622594730;
							continue;
						case 5:
							joysticks = player2.controllers.Joysticks;
							num8 = 0;
							num = 1622594723;
							continue;
						case 30:
							goto IL_0148;
						case 1:
							num13 = num3;
							num = 1622594733;
							continue;
						case 39:
							goto IL_016e;
						case 21:
							goto IL_01a7;
						case 29:
							player2 = list2[num11];
							num = 1622594744;
							continue;
						case 26:
							num8++;
							num = 1622594723;
							continue;
						case 35:
							return true;
						case 23:
							if (num9 >= count)
							{
								num10++;
								num = 1622594741;
								continue;
							}
							goto IL_0474;
						case 17:
							joystick = joysticks[num8];
							maps4 = player2.controllers.maps.GetMaps<JoystickMap>(joystick.id);
							if (maps4 != null)
							{
								count = maps4.Count;
								num10 = num3;
								num = 1622594741;
								continue;
							}
							goto case 26;
						case 0:
							num12 = 0;
							num = 1622594726;
							continue;
						case 25:
							player4 = list2[num10];
							num = 1622594751;
							continue;
						case 4:
							goto IL_026d;
						case 32:
							if (num7 >= count3)
							{
								num5++;
								num = 1622594730;
								continue;
							}
							goto case 9;
						case 6:
							goto IL_02af;
						case 13:
							num = 1622594727;
							continue;
						case 31:
							num9 = 0;
							num = 1622594743;
							continue;
						case 28:
							if (maps3 != null)
							{
								count2 = maps3.Count;
								num = 1622594690;
								continue;
							}
							goto case 2;
						case 7:
							if (num13 >= count3)
							{
								num6++;
								num = 1622594747;
								continue;
							}
							goto IL_00e5;
						case 24:
							num3 = (forceCheckAllCategories ? num11 : 0);
							num = 1622594725;
							continue;
						case 16:
							customController = customControllers[num12];
							maps3 = player2.controllers.maps.GetMaps<CustomControllerMap>(customController.id);
							num = 1622594748;
							continue;
						case 19:
							if (num4 >= count2)
							{
								num2++;
								num = 1622594692;
								continue;
							}
							goto IL_016e;
						case 22:
							goto IL_0371;
						case 33:
							num11++;
							num = 1622594750;
							continue;
						case 36:
							goto IL_03b1;
						case 3:
							if (num8 >= joysticks.Count)
							{
								maps = player2.controllers.maps.GetMaps<KeyboardMap>(0);
								num = 1622594731;
								continue;
							}
							goto case 17;
						case 20:
							num7 = num3;
							num = 1622594688;
							continue;
						case 27:
							goto IL_0403;
						case 14:
							customControllers = player2.controllers.CustomControllers;
							num = 1622594720;
							continue;
						case 2:
							num12++;
							num = 1622594726;
							continue;
						case 10:
							if (num5 >= maps.Count)
							{
								maps2 = player2.controllers.maps.GetMaps<MouseMap>(0);
								num6 = 0;
								num = 1622594747;
								continue;
							}
							goto case 20;
						case 15:
							goto IL_0474;
						case 12:
							player = list2[num2];
							num4 = 0;
							num = 1622594739;
							continue;
						case 34:
							num2 = num3;
							num = 1622594692;
							continue;
						default:
							return false;
						}
						break;
						IL_0403:
						int num14;
						if (num6 >= maps2.Count)
						{
							num = 1622594734;
							num14 = num;
						}
						else
						{
							num = 1622594721;
							num14 = num;
						}
						continue;
						IL_016e:
						if (player.controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Custom, customController.id, maps3[num4], skipDisabledMaps, forceCheckAllCategories))
						{
							return true;
						}
						num4++;
						num = 1622594739;
						continue;
						IL_0474:
						if (!player4.controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Joystick, joystick.id, maps4[num9], skipDisabledMaps, forceCheckAllCategories))
						{
							num9++;
							num = 1622594743;
						}
						else
						{
							num = 1622594691;
						}
						continue;
						IL_03b1:
						int num15;
						if (num2 < count3)
						{
							num = 1622594732;
							num15 = num;
						}
						else
						{
							num = 1622594722;
							num15 = num;
						}
						continue;
						IL_02af:
						int num16;
						if (num12 >= customControllers.Count)
						{
							num = 1622594689;
							num16 = num;
						}
						else
						{
							num = 1622594736;
							num16 = num;
						}
						continue;
						IL_00e5:
						Player player5 = list2[num13];
						if (player5.controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Mouse, 0, maps2[num6], skipDisabledMaps, forceCheckAllCategories))
						{
							return true;
						}
						num13++;
						num = 1622594727;
						continue;
						IL_0371:
						if (player3.controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Keyboard, 0, maps[num5], skipDisabledMaps, forceCheckAllCategories))
						{
							return true;
						}
						num7++;
						num = 1622594688;
						continue;
						IL_01a7:
						int num17;
						if (num10 < count3)
						{
							num = 1622594745;
							num17 = num;
						}
						else
						{
							num = 1622594746;
							num17 = num;
						}
						continue;
						IL_0148:
						int num18;
						if (num11 < count3)
						{
							num = 1622594749;
							num18 = num;
						}
						else
						{
							num = 1622594693;
							num18 = num;
						}
					}
					goto IL_000a;
					IL_026d:
					list = WhcqAfYYqNfRCEGkYApjWYGKVjr.Players_readOnly;
					goto IL_0283;
					IL_0283:
					list2 = list;
					count3 = list2.Count;
					num11 = 0;
					num = 1622594750;
					goto IL_000f;
					IL_000a:
					num = 1622594728;
					goto IL_000f;
				}

				public bool DoesElementAssignmentConflict(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap)
				{
					return DoesElementAssignmentConflict(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps: false, forceCheckAllCategories: false, includeSystemPlayer: true);
				}

				public bool DoesElementAssignmentConflict(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps)
				{
					return DoesElementAssignmentConflict(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories: false, includeSystemPlayer: true);
				}

				public bool DoesElementAssignmentConflict(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					return DoesElementAssignmentConflict(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer: true);
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
							int num = -695021637;
							while (true)
							{
								switch (num ^ -695021638)
								{
								case 0:
									break;
								case 1:
									goto IL_002f;
								case 3:
									goto end_IL_000d;
								default:
									return LIJHivCeqbXKPlXMgxmdkBuwgUv(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
								}
								break;
								IL_002f:
								if (elementMap == null)
								{
									num = -695021639;
									continue;
								}
								switch (controllerType)
								{
								case ControllerType.Joystick:
									num = -695021640;
									break;
								case ControllerType.Keyboard:
									return oehvMzQEhEXDedBlVCnwFqKYHsh(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
								case ControllerType.Mouse:
									return kWPItgTssYnEajjZOdXfEdkjuSo(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
								case ControllerType.Custom:
									return LCqkXzOBTExxqVDScGvZKctsbsUD(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
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
					return DoesElementAssignmentConflict(conflictCheck, skipDisabledMaps: false, forceCheckAllCategories: false, includeSystemPlayer: true);
				}

				public bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
				{
					return DoesElementAssignmentConflict(conflictCheck, skipDisabledMaps, forceCheckAllCategories: false, includeSystemPlayer: true);
				}

				public bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					return DoesElementAssignmentConflict(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer: true);
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
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						return LIJHivCeqbXKPlXMgxmdkBuwgUv(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					int num;
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						num = -2022980837;
					}
					else
					{
						if (conflictCheck.controllerType != ControllerType.Mouse)
						{
							if (conflictCheck.controllerType == ControllerType.Custom)
							{
								return LCqkXzOBTExxqVDScGvZKctsbsUD(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
							}
							throw new NotImplementedException();
						}
						num = -2022980838;
					}
					goto IL_0018;
					IL_0018:
					switch (num ^ -2022980838)
					{
					case 3:
						break;
					case 2:
						return false;
					case 1:
						return oehvMzQEhEXDedBlVCnwFqKYHsh(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					default:
						return kWPItgTssYnEajjZOdXfEdkjuSo(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					goto IL_0013;
					IL_0013:
					num = -2022980840;
					goto IL_0018;
				}

				private bool LIJHivCeqbXKPlXMgxmdkBuwgUv(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					IList<Player> list = default(IList<Player>);
					int num;
					if (P_0 >= 0)
					{
						if (P_3 == null)
						{
							goto IL_000b;
						}
						list = (P_6 ? WhcqAfYYqNfRCEGkYApjWYGKVjr.AllPlayers_readOnly : WhcqAfYYqNfRCEGkYApjWYGKVjr.Players_readOnly);
						num = 305418470;
						goto IL_0010;
					}
					goto IL_0087;
					IL_0010:
					int num2 = default(int);
					while (true)
					{
						switch (num ^ 0x123450E4)
						{
						case 5:
							break;
						case 6:
							goto IL_003c;
						case 2:
							num2 = 0;
							num = 305418466;
							continue;
						case 3:
							goto IL_005f;
						case 4:
							goto IL_0087;
						case 1:
							return true;
						default:
							return false;
						}
						break;
						IL_005f:
						if (list[num2].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Joystick, P_1, P_2, P_3, P_4, P_5))
						{
							num = 305418469;
							continue;
						}
						num2++;
						num = 305418466;
						continue;
						IL_003c:
						int num3;
						if (num2 < list.Count)
						{
							num = 305418471;
							num3 = num;
						}
						else
						{
							num = 305418468;
							num3 = num;
						}
					}
					goto IL_000b;
					IL_000b:
					num = 305418464;
					goto IL_0010;
					IL_0087:
					return false;
				}

				private bool LIJHivCeqbXKPlXMgxmdkBuwgUv(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId >= 0)
					{
						int num2 = default(int);
						IList<Player> list = default(IList<Player>);
						while (true)
						{
							int num = 1902953440;
							while (true)
							{
								switch (num ^ 0x716CC3E5)
								{
								case 0:
									break;
								case 5:
									goto IL_0034;
								case 4:
									goto IL_0045;
								case 3:
									goto IL_006d;
								case 2:
									goto end_IL_000a;
								default:
									return false;
								}
								break;
								IL_006d:
								int num3;
								if (num2 < list.Count)
								{
									num = 1902953441;
									num3 = num;
								}
								else
								{
									num = 1902953444;
									num3 = num;
								}
								continue;
								IL_0045:
								if (list[num2].controllers.conflictChecking.DoesElementAssignmentConflict(P_0, P_1, P_2))
								{
									return true;
								}
								num2++;
								num = 1902953446;
								continue;
								IL_0034:
								if (P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
								{
									num = 1902953447;
									continue;
								}
								list = (P_3 ? WhcqAfYYqNfRCEGkYApjWYGKVjr.AllPlayers_readOnly : WhcqAfYYqNfRCEGkYApjWYGKVjr.Players_readOnly);
								num2 = 0;
								num = 1902953446;
							}
							continue;
							end_IL_000a:
							break;
						}
					}
					return false;
				}

				private bool oehvMzQEhEXDedBlVCnwFqKYHsh(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					IList<Player> list = default(IList<Player>);
					int num;
					if (P_0 >= 0)
					{
						if (P_2 == null)
						{
							goto IL_0007;
						}
						list = (P_5 ? WhcqAfYYqNfRCEGkYApjWYGKVjr.AllPlayers_readOnly : WhcqAfYYqNfRCEGkYApjWYGKVjr.Players_readOnly);
						num = -1640328300;
						goto IL_000c;
					}
					goto IL_0031;
					IL_000c:
					int num2 = default(int);
					while (true)
					{
						switch (num ^ -1640328303)
						{
						case 0:
							break;
						case 1:
							goto IL_0031;
						case 3:
							goto IL_0055;
						case 4:
							num = -1640328301;
							continue;
						case 5:
							num2 = 0;
							num = -1640328299;
							continue;
						default:
							if (num2 >= list.Count)
							{
								return false;
							}
							goto IL_0055;
						}
						break;
						IL_0055:
						if (list[num2].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Keyboard, 0, P_1, P_2, P_3, P_4))
						{
							return true;
						}
						num2++;
						num = -1640328301;
					}
					goto IL_0007;
					IL_0007:
					num = -1640328304;
					goto IL_000c;
					IL_0031:
					return false;
				}

				private bool oehvMzQEhEXDedBlVCnwFqKYHsh(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					IList<Player> list = default(IList<Player>);
					int num;
					if (P_0.playerId >= 0)
					{
						if (P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
						{
							goto IL_0014;
						}
						list = (P_3 ? WhcqAfYYqNfRCEGkYApjWYGKVjr.AllPlayers_readOnly : WhcqAfYYqNfRCEGkYApjWYGKVjr.Players_readOnly);
						num = 1900465887;
						goto IL_0019;
					}
					goto IL_0054;
					IL_0019:
					int num2 = default(int);
					while (true)
					{
						switch (num ^ 0x7146CEDA)
						{
						case 4:
							break;
						case 0:
							return true;
						case 5:
							num2 = 0;
							num = 1900465881;
							continue;
						case 2:
							goto IL_0054;
						case 1:
							goto IL_0078;
						default:
							if (num2 >= list.Count)
							{
								return false;
							}
							goto IL_0078;
						}
						break;
						IL_0078:
						if (!list[num2].controllers.conflictChecking.DoesElementAssignmentConflict(P_0, P_1, P_2))
						{
							num2++;
							num = 1900465881;
						}
						else
						{
							num = 1900465882;
						}
					}
					goto IL_0014;
					IL_0014:
					num = 1900465880;
					goto IL_0019;
					IL_0054:
					return false;
				}

				private bool kWPItgTssYnEajjZOdXfEdkjuSo(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0)
					{
						goto IL_002d;
					}
					if (P_2 == null)
					{
						goto IL_0007;
					}
					int num;
					if (!P_5)
					{
						num = 760422762;
						goto IL_000c;
					}
					IList<Player> list = WhcqAfYYqNfRCEGkYApjWYGKVjr.AllPlayers_readOnly;
					goto IL_007d;
					IL_000c:
					int num2 = default(int);
					IList<Player> list2 = default(IList<Player>);
					while (true)
					{
						switch (num ^ 0x2D53216A)
						{
						case 4:
							break;
						case 3:
							goto IL_002d;
						case 1:
							goto IL_003a;
						case 0:
							goto IL_0067;
						default:
							if (num2 >= list2.Count)
							{
								return false;
							}
							goto IL_003a;
						}
						break;
						IL_003a:
						if (list2[num2].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Mouse, 0, P_1, P_2, P_3, P_4))
						{
							return true;
						}
						num2++;
						num = 760422760;
					}
					goto IL_0007;
					IL_0067:
					list = WhcqAfYYqNfRCEGkYApjWYGKVjr.Players_readOnly;
					goto IL_007d;
					IL_002d:
					return false;
					IL_007d:
					list2 = list;
					num2 = 0;
					num = 760422760;
					goto IL_000c;
					IL_0007:
					num = 760422761;
					goto IL_000c;
				}

				private bool kWPItgTssYnEajjZOdXfEdkjuSo(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId >= 0)
					{
						int num2 = default(int);
						IList<Player> list = default(IList<Player>);
						while (true)
						{
							int num = 78292203;
							while (true)
							{
								switch (num ^ 0x4AAA4E9)
								{
								case 3:
									break;
								case 2:
									goto IL_0030;
								case 0:
									goto IL_0041;
								case 4:
									goto end_IL_000a;
								default:
									if (num2 >= list.Count)
									{
										return false;
									}
									goto IL_0041;
								}
								break;
								IL_0041:
								if (list[num2].controllers.conflictChecking.DoesElementAssignmentConflict(P_0, P_1, P_2))
								{
									return true;
								}
								num2++;
								num = 78292200;
								continue;
								IL_0030:
								if (P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
								{
									num = 78292205;
									continue;
								}
								list = (P_3 ? WhcqAfYYqNfRCEGkYApjWYGKVjr.AllPlayers_readOnly : WhcqAfYYqNfRCEGkYApjWYGKVjr.Players_readOnly);
								num2 = 0;
								num = 78292200;
							}
							continue;
							end_IL_000a:
							break;
						}
					}
					return false;
				}

				private bool LCqkXzOBTExxqVDScGvZKctsbsUD(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0)
					{
						goto IL_002e;
					}
					if (P_3 == null)
					{
						goto IL_0008;
					}
					int num;
					if (!P_6)
					{
						num = -558387887;
						goto IL_000d;
					}
					IList<Player> list = WhcqAfYYqNfRCEGkYApjWYGKVjr.AllPlayers_readOnly;
					goto IL_0080;
					IL_000d:
					int num2 = default(int);
					IList<Player> list2 = default(IList<Player>);
					while (true)
					{
						switch (num ^ -558387883)
						{
						case 0:
							break;
						case 2:
							goto IL_002e;
						case 3:
							goto IL_003b;
						case 4:
							goto IL_006a;
						default:
							if (num2 >= list2.Count)
							{
								return false;
							}
							goto IL_003b;
						}
						break;
						IL_003b:
						if (list2[num2].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Custom, P_1, P_2, P_3, P_4, P_5))
						{
							return true;
						}
						num2++;
						num = -558387884;
					}
					goto IL_0008;
					IL_002e:
					return false;
					IL_0080:
					list2 = list;
					num2 = 0;
					num = -558387884;
					goto IL_000d;
					IL_006a:
					list = WhcqAfYYqNfRCEGkYApjWYGKVjr.Players_readOnly;
					goto IL_0080;
					IL_0008:
					num = -558387881;
					goto IL_000d;
				}

				private bool LCqkXzOBTExxqVDScGvZKctsbsUD(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
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
						list = (P_3 ? WhcqAfYYqNfRCEGkYApjWYGKVjr.AllPlayers_readOnly : WhcqAfYYqNfRCEGkYApjWYGKVjr.Players_readOnly);
						num = 0;
						num2 = 733885864;
						goto IL_0019;
					}
					goto IL_003e;
					IL_0019:
					while (true)
					{
						switch (num2 ^ 0x2BBE35AA)
						{
						case 0:
							break;
						case 4:
							goto IL_003e;
						case 2:
							num2 = 733885865;
							continue;
						case 3:
							goto IL_006b;
						case 1:
							goto IL_0085;
						default:
							return false;
						}
						break;
						IL_0085:
						if (list[num].controllers.conflictChecking.DoesElementAssignmentConflict(P_0, P_1, P_2))
						{
							return true;
						}
						num++;
						num2 = 733885865;
						continue;
						IL_006b:
						int num3;
						if (num < list.Count)
						{
							num2 = 733885867;
							num3 = num2;
						}
						else
						{
							num2 = 733885871;
							num3 = num2;
						}
					}
					goto IL_0014;
					IL_0014:
					num2 = 733885870;
					goto IL_0019;
					IL_003e:
					return false;
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap)
				{
					return ElementAssignmentConflicts(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps: false, forceCheckAllCategories: false, includeSystemPlayer: true);
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps)
				{
					return ElementAssignmentConflicts(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories: false, includeSystemPlayer: true);
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					return ElementAssignmentConflicts(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer: true);
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
						num = -720718592;
						num2 = num;
					}
					else
					{
						num = -720718588;
						num2 = num;
					}
					goto IL_000f;
					IL_000a:
					num = -720718587;
					goto IL_000f;
					IL_000f:
					while (true)
					{
						switch (num ^ -720718588)
						{
						case 3:
							break;
						case 4:
							return new List<ElementAssignmentConflictInfo>();
						case 0:
							if (elementMap != null)
							{
								switch (controllerType)
								{
								case ControllerType.Joystick:
									return WKdyoALqUNKJLRRMSfVoPFkQiuG(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
								case ControllerType.Keyboard:
									return thOkNqGEblXJyMIJDekmhzjIbgBi(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
								case ControllerType.Mouse:
									return GmyHEbtGaeTHMJTPRPmDcchXeZR(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
								case ControllerType.Custom:
									num = -720718586;
									break;
								default:
									throw new NotImplementedException();
								}
							}
							else
							{
								num = -720718592;
							}
							continue;
						case 1:
							return EmptyObjects<ElementAssignmentConflictInfo>.EmptyReadOnlyIListT;
						default:
							return zliaNpJJJcuMplmqXoWSVMBzAQz(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
						}
						break;
					}
					goto IL_000a;
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
				{
					return ElementAssignmentConflicts(conflictCheck, skipDisabledMaps: false, forceCheckAllCategories: false, includeSystemPlayer: true);
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
				{
					return ElementAssignmentConflicts(conflictCheck, skipDisabledMaps, forceCheckAllCategories: false, includeSystemPlayer: true);
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					return ElementAssignmentConflicts(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer: true);
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories, bool includeSystemPlayer)
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<ElementAssignmentConflictInfo>.EmptyReadOnlyIListT;
					}
					if (conflictCheck.playerId < 0)
					{
						return new List<ElementAssignmentConflictInfo>();
					}
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						goto IL_0027;
					}
					int num;
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						num = -230528195;
					}
					else
					{
						if (conflictCheck.controllerType == ControllerType.Mouse)
						{
							return GmyHEbtGaeTHMJTPRPmDcchXeZR(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
						}
						if (conflictCheck.controllerType != ControllerType.Custom)
						{
							throw new NotImplementedException();
						}
						num = -230528193;
					}
					goto IL_002c;
					IL_0027:
					num = -230528196;
					goto IL_002c;
					IL_002c:
					switch (num ^ -230528194)
					{
					case 0:
						break;
					case 2:
						return WKdyoALqUNKJLRRMSfVoPFkQiuG(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					case 3:
						return thOkNqGEblXJyMIJDekmhzjIbgBi(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					default:
						return zliaNpJJJcuMplmqXoWSVMBzAQz(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					goto IL_0027;
				}

				private IEnumerable<ElementAssignmentConflictInfo> WKdyoALqUNKJLRRMSfVoPFkQiuG(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					sCPzrzAkgvoXEzSEPulTyknMiRq sCPzrzAkgvoXEzSEPulTyknMiRq2 = new sCPzrzAkgvoXEzSEPulTyknMiRq(-2);
					while (true)
					{
						int num = -649514781;
						while (true)
						{
							switch (num ^ -649514783)
							{
							case 0:
								break;
							case 2:
								sCPzrzAkgvoXEzSEPulTyknMiRq2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
								sCPzrzAkgvoXEzSEPulTyknMiRq2.kErIYVWJdlvWnebMUsTtlGzeFPE = P_0;
								num = -649514782;
								continue;
							case 3:
								sCPzrzAkgvoXEzSEPulTyknMiRq2.XXVassdjVXBmMeHfiXDThqemgAeP = P_1;
								num = -649514784;
								continue;
							default:
								sCPzrzAkgvoXEzSEPulTyknMiRq2.aAZEnFDyNOCahrdvCVCCKkmeaGi = P_2;
								sCPzrzAkgvoXEzSEPulTyknMiRq2.xJmIipGrdmNTzniNdfiLboREQWg = P_3;
								sCPzrzAkgvoXEzSEPulTyknMiRq2.dGwSNihzjCwVEkHXFGPpgtHVneEu = P_4;
								sCPzrzAkgvoXEzSEPulTyknMiRq2.jNymEHJVRXeHYcnwOCdElUZKBrm = P_5;
								sCPzrzAkgvoXEzSEPulTyknMiRq2.nhpwLZALUoBiqMohOtMMoimMVRO = P_6;
								return sCPzrzAkgvoXEzSEPulTyknMiRq2;
							}
							break;
						}
					}
				}

				private IEnumerable<ElementAssignmentConflictInfo> WKdyoALqUNKJLRRMSfVoPFkQiuG(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					LLXvGrOqBbRlitKVcqDrBJmoZxH lLXvGrOqBbRlitKVcqDrBJmoZxH = new LLXvGrOqBbRlitKVcqDrBJmoZxH(-2);
					lLXvGrOqBbRlitKVcqDrBJmoZxH.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
					lLXvGrOqBbRlitKVcqDrBJmoZxH.xMLCmAAGOtcBvnIylDFdJWNwMnF = P_0;
					lLXvGrOqBbRlitKVcqDrBJmoZxH.dGwSNihzjCwVEkHXFGPpgtHVneEu = P_1;
					lLXvGrOqBbRlitKVcqDrBJmoZxH.jNymEHJVRXeHYcnwOCdElUZKBrm = P_2;
					lLXvGrOqBbRlitKVcqDrBJmoZxH.nhpwLZALUoBiqMohOtMMoimMVRO = P_3;
					return lLXvGrOqBbRlitKVcqDrBJmoZxH;
				}

				private IEnumerable<ElementAssignmentConflictInfo> thOkNqGEblXJyMIJDekmhzjIbgBi(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					qlNZbtXKtdAlTaJarJBkhCGLsSDQ qlNZbtXKtdAlTaJarJBkhCGLsSDQ2 = new qlNZbtXKtdAlTaJarJBkhCGLsSDQ(-2);
					qlNZbtXKtdAlTaJarJBkhCGLsSDQ2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
					qlNZbtXKtdAlTaJarJBkhCGLsSDQ2.kErIYVWJdlvWnebMUsTtlGzeFPE = P_0;
					qlNZbtXKtdAlTaJarJBkhCGLsSDQ2.MzqOaouCXHECxACEPdvZImzyeUb = P_1;
					qlNZbtXKtdAlTaJarJBkhCGLsSDQ2.xJmIipGrdmNTzniNdfiLboREQWg = P_2;
					qlNZbtXKtdAlTaJarJBkhCGLsSDQ2.dGwSNihzjCwVEkHXFGPpgtHVneEu = P_3;
					qlNZbtXKtdAlTaJarJBkhCGLsSDQ2.jNymEHJVRXeHYcnwOCdElUZKBrm = P_4;
					qlNZbtXKtdAlTaJarJBkhCGLsSDQ2.nhpwLZALUoBiqMohOtMMoimMVRO = P_5;
					return qlNZbtXKtdAlTaJarJBkhCGLsSDQ2;
				}

				private IEnumerable<ElementAssignmentConflictInfo> thOkNqGEblXJyMIJDekmhzjIbgBi(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					XCEePkZmYsFrZcDEhLXyPrvPuYvp xCEePkZmYsFrZcDEhLXyPrvPuYvp = new XCEePkZmYsFrZcDEhLXyPrvPuYvp(-2);
					while (true)
					{
						int num = -302526728;
						while (true)
						{
							switch (num ^ -302526724)
							{
							case 0:
								break;
							case 4:
								xCEePkZmYsFrZcDEhLXyPrvPuYvp.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
								xCEePkZmYsFrZcDEhLXyPrvPuYvp.xMLCmAAGOtcBvnIylDFdJWNwMnF = P_0;
								num = -302526722;
								continue;
							case 3:
								xCEePkZmYsFrZcDEhLXyPrvPuYvp.jNymEHJVRXeHYcnwOCdElUZKBrm = P_2;
								num = -302526723;
								continue;
							case 2:
								xCEePkZmYsFrZcDEhLXyPrvPuYvp.dGwSNihzjCwVEkHXFGPpgtHVneEu = P_1;
								num = -302526721;
								continue;
							default:
								xCEePkZmYsFrZcDEhLXyPrvPuYvp.nhpwLZALUoBiqMohOtMMoimMVRO = P_3;
								return xCEePkZmYsFrZcDEhLXyPrvPuYvp;
							}
							break;
						}
					}
				}

				private IEnumerable<ElementAssignmentConflictInfo> GmyHEbtGaeTHMJTPRPmDcchXeZR(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					AMjGnrMVZoxTPHbiyurNnJmogSu aMjGnrMVZoxTPHbiyurNnJmogSu = new AMjGnrMVZoxTPHbiyurNnJmogSu(-2);
					aMjGnrMVZoxTPHbiyurNnJmogSu.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
					aMjGnrMVZoxTPHbiyurNnJmogSu.kErIYVWJdlvWnebMUsTtlGzeFPE = P_0;
					aMjGnrMVZoxTPHbiyurNnJmogSu.vftSVbwqFzaUIhqmHqcyIzXndZb = P_1;
					aMjGnrMVZoxTPHbiyurNnJmogSu.xJmIipGrdmNTzniNdfiLboREQWg = P_2;
					aMjGnrMVZoxTPHbiyurNnJmogSu.dGwSNihzjCwVEkHXFGPpgtHVneEu = P_3;
					aMjGnrMVZoxTPHbiyurNnJmogSu.jNymEHJVRXeHYcnwOCdElUZKBrm = P_4;
					aMjGnrMVZoxTPHbiyurNnJmogSu.nhpwLZALUoBiqMohOtMMoimMVRO = P_5;
					return aMjGnrMVZoxTPHbiyurNnJmogSu;
				}

				private IEnumerable<ElementAssignmentConflictInfo> GmyHEbtGaeTHMJTPRPmDcchXeZR(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					jFAilfAUezsbrJAsEkpaBeAHibO jFAilfAUezsbrJAsEkpaBeAHibO2 = new jFAilfAUezsbrJAsEkpaBeAHibO(-2);
					jFAilfAUezsbrJAsEkpaBeAHibO2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
					jFAilfAUezsbrJAsEkpaBeAHibO2.xMLCmAAGOtcBvnIylDFdJWNwMnF = P_0;
					jFAilfAUezsbrJAsEkpaBeAHibO2.dGwSNihzjCwVEkHXFGPpgtHVneEu = P_1;
					jFAilfAUezsbrJAsEkpaBeAHibO2.jNymEHJVRXeHYcnwOCdElUZKBrm = P_2;
					jFAilfAUezsbrJAsEkpaBeAHibO2.nhpwLZALUoBiqMohOtMMoimMVRO = P_3;
					return jFAilfAUezsbrJAsEkpaBeAHibO2;
				}

				private IEnumerable<ElementAssignmentConflictInfo> zliaNpJJJcuMplmqXoWSVMBzAQz(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					jehUOQdeTuRAFsblyHPvbfHJwIz jehUOQdeTuRAFsblyHPvbfHJwIz2 = new jehUOQdeTuRAFsblyHPvbfHJwIz(-2);
					jehUOQdeTuRAFsblyHPvbfHJwIz2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
					jehUOQdeTuRAFsblyHPvbfHJwIz2.kErIYVWJdlvWnebMUsTtlGzeFPE = P_0;
					jehUOQdeTuRAFsblyHPvbfHJwIz2.XXVassdjVXBmMeHfiXDThqemgAeP = P_1;
					jehUOQdeTuRAFsblyHPvbfHJwIz2.CZjAKSpSQwaWcMFrVKHWmloujSi = P_2;
					jehUOQdeTuRAFsblyHPvbfHJwIz2.xJmIipGrdmNTzniNdfiLboREQWg = P_3;
					jehUOQdeTuRAFsblyHPvbfHJwIz2.dGwSNihzjCwVEkHXFGPpgtHVneEu = P_4;
					jehUOQdeTuRAFsblyHPvbfHJwIz2.jNymEHJVRXeHYcnwOCdElUZKBrm = P_5;
					jehUOQdeTuRAFsblyHPvbfHJwIz2.nhpwLZALUoBiqMohOtMMoimMVRO = P_6;
					return jehUOQdeTuRAFsblyHPvbfHJwIz2;
				}

				private IEnumerable<ElementAssignmentConflictInfo> zliaNpJJJcuMplmqXoWSVMBzAQz(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					mRuFHhWlCZGOHSKOxcNXQSthCxs mRuFHhWlCZGOHSKOxcNXQSthCxs2 = new mRuFHhWlCZGOHSKOxcNXQSthCxs(-2);
					mRuFHhWlCZGOHSKOxcNXQSthCxs2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
					mRuFHhWlCZGOHSKOxcNXQSthCxs2.xMLCmAAGOtcBvnIylDFdJWNwMnF = P_0;
					mRuFHhWlCZGOHSKOxcNXQSthCxs2.dGwSNihzjCwVEkHXFGPpgtHVneEu = P_1;
					mRuFHhWlCZGOHSKOxcNXQSthCxs2.jNymEHJVRXeHYcnwOCdElUZKBrm = P_2;
					mRuFHhWlCZGOHSKOxcNXQSthCxs2.nhpwLZALUoBiqMohOtMMoimMVRO = P_3;
					return mRuFHhWlCZGOHSKOxcNXQSthCxs2;
				}

				public int RemoveElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap)
				{
					return RemoveElementAssignmentConflicts(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps: false, forceCheckAllCategories: false, includeSystemPlayer: true);
				}

				public int RemoveElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps)
				{
					return RemoveElementAssignmentConflicts(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories: false, includeSystemPlayer: true);
				}

				public int RemoveElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					return RemoveElementAssignmentConflicts(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer: true);
				}

				public int RemoveElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories, bool includeSystemPlayer)
				{
					if (!CheckInitialized())
					{
						return 0;
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
							return dLdFdlUuFSLFnThgkIWlhxiwANrZ(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
						}
						if (controllerType == ControllerType.Keyboard)
						{
							return SPyfiMTyXquoTssRmVhnnQDdgUD(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
						}
						if (controllerType == ControllerType.Mouse)
						{
							return eBMMIpymIYxKFwxTiNiQVJuIjUb(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
						}
						if (controllerType == ControllerType.Custom)
						{
							num = 960740457;
							goto IL_0016;
						}
						throw new NotImplementedException();
					}
					goto IL_002f;
					IL_002f:
					return 0;
					IL_0016:
					switch (num ^ 0x3943BC69)
					{
					case 2:
						break;
					case 1:
						goto IL_002f;
					default:
						return ytxSxwDYoLVUtWmyrkmKulgUEuDG(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					goto IL_0011;
					IL_0011:
					num = 960740456;
					goto IL_0016;
				}

				public int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
				{
					return RemoveElementAssignmentConflicts(conflictCheck, skipDisabledMaps: false, forceCheckAllCategories: false, includeSystemPlayer: true);
				}

				public int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
				{
					return RemoveElementAssignmentConflicts(conflictCheck, skipDisabledMaps, forceCheckAllCategories: false, includeSystemPlayer: true);
				}

				public int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					return RemoveElementAssignmentConflicts(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer: true);
				}

				public int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories, bool includeSystemPlayer)
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
						return dLdFdlUuFSLFnThgkIWlhxiwANrZ(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return SPyfiMTyXquoTssRmVhnnQDdgUD(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return eBMMIpymIYxKFwxTiNiQVJuIjUb(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return ytxSxwDYoLVUtWmyrkmKulgUEuDG(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					throw new NotImplementedException();
				}

				private int dLdFdlUuFSLFnThgkIWlhxiwANrZ(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					IList<Player> list;
					int num;
					if (P_0 >= 0)
					{
						if (P_3 == null)
						{
							goto IL_0008;
						}
						if (P_6)
						{
							list = WhcqAfYYqNfRCEGkYApjWYGKVjr.AllPlayers_readOnly;
							goto IL_0071;
						}
						num = 219119137;
						goto IL_000d;
					}
					goto IL_007d;
					IL_000d:
					int num3 = default(int);
					IList<Player> list2 = default(IList<Player>);
					int num2 = default(int);
					while (true)
					{
						switch (num ^ 0xD0F7E21)
						{
						case 2:
							break;
						case 1:
							num3 += list2[num2].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Joystick, P_1, P_2, P_3, P_4, P_5);
							num2++;
							num = 219119141;
							continue;
						case 0:
							goto IL_005b;
						case 3:
							goto IL_007d;
						default:
							if (num2 >= list2.Count)
							{
								return num3;
							}
							goto case 1;
						}
						break;
					}
					goto IL_0008;
					IL_005b:
					list = WhcqAfYYqNfRCEGkYApjWYGKVjr.Players_readOnly;
					goto IL_0071;
					IL_007d:
					return 0;
					IL_0071:
					list2 = list;
					num3 = 0;
					num2 = 0;
					num = 219119141;
					goto IL_000d;
					IL_0008:
					num = 219119138;
					goto IL_000d;
				}

				private int dLdFdlUuFSLFnThgkIWlhxiwANrZ(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId >= 0)
					{
						int num2 = default(int);
						int num3 = default(int);
						IList<Player> list = default(IList<Player>);
						while (true)
						{
							int num = 1784550557;
							while (true)
							{
								switch (num ^ 0x6A5E149F)
								{
								case 4:
									break;
								case 1:
									num2 = 0;
									num3 = 0;
									num = 1784550554;
									continue;
								case 6:
									num2 += list[num3].controllers.conflictChecking.RemoveElementAssignmentConflicts(P_0, P_1, P_2);
									num3++;
									num = 1784550554;
									continue;
								case 2:
									goto IL_006d;
								case 3:
									goto end_IL_000a;
								case 5:
									goto IL_00a5;
								default:
									return num2;
								}
								break;
								IL_00a5:
								int num4;
								if (num3 < list.Count)
								{
									num = 1784550553;
									num4 = num;
								}
								else
								{
									num = 1784550559;
									num4 = num;
								}
								continue;
								IL_006d:
								if (P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
								{
									num = 1784550556;
									continue;
								}
								list = (P_3 ? WhcqAfYYqNfRCEGkYApjWYGKVjr.AllPlayers_readOnly : WhcqAfYYqNfRCEGkYApjWYGKVjr.Players_readOnly);
								num = 1784550558;
							}
							continue;
							end_IL_000a:
							break;
						}
					}
					return 0;
				}

				private int SPyfiMTyXquoTssRmVhnnQDdgUD(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
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
						num = 226513487;
						goto IL_000c;
					}
					IList<Player> list = WhcqAfYYqNfRCEGkYApjWYGKVjr.AllPlayers_readOnly;
					goto IL_0054;
					IL_000c:
					int num3 = default(int);
					IList<Player> list2 = default(IList<Player>);
					int num2 = default(int);
					while (true)
					{
						switch (num ^ 0xD80524B)
						{
						case 0:
							break;
						case 3:
							goto IL_0031;
						case 4:
							goto IL_003e;
						case 1:
							num3 += list2[num2].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Keyboard, 0, P_1, P_2, P_3, P_4);
							num2++;
							num = 226513486;
							continue;
						case 2:
							num3 = 0;
							num2 = 0;
							num = 226513486;
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
					IL_0054:
					list2 = list;
					num = 226513481;
					goto IL_000c;
					IL_003e:
					list = WhcqAfYYqNfRCEGkYApjWYGKVjr.Players_readOnly;
					goto IL_0054;
					IL_0031:
					return 0;
					IL_0007:
					num = 226513480;
					goto IL_000c;
				}

				private int SPyfiMTyXquoTssRmVhnnQDdgUD(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					IList<Player> list = default(IList<Player>);
					int num = default(int);
					int num2 = default(int);
					int num3;
					if (P_0.playerId >= 0)
					{
						if (P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
						{
							goto IL_0014;
						}
						list = (P_3 ? WhcqAfYYqNfRCEGkYApjWYGKVjr.AllPlayers_readOnly : WhcqAfYYqNfRCEGkYApjWYGKVjr.Players_readOnly);
						num = 0;
						num2 = 0;
						num3 = 887868243;
						goto IL_0019;
					}
					goto IL_0068;
					IL_0019:
					while (true)
					{
						switch (num3 ^ 0x34EBCB53)
						{
						case 2:
							break;
						case 3:
							num2++;
							num3 = 887868243;
							continue;
						case 4:
							num += list[num2].controllers.conflictChecking.RemoveElementAssignmentConflicts(P_0, P_1, P_2);
							num3 = 887868240;
							continue;
						case 1:
							goto IL_0068;
						default:
							if (num2 >= list.Count)
							{
								return num;
							}
							goto case 4;
						}
						break;
					}
					goto IL_0014;
					IL_0014:
					num3 = 887868242;
					goto IL_0019;
					IL_0068:
					return 0;
				}

				private int eBMMIpymIYxKFwxTiNiQVJuIjUb(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 >= 0)
					{
						int num2 = default(int);
						int num3 = default(int);
						IList<Player> list = default(IList<Player>);
						while (true)
						{
							int num = 267820153;
							while (true)
							{
								switch (num ^ 0xFF69C7A)
								{
								case 0:
									break;
								case 2:
									num2 = 0;
									num = 267820158;
									continue;
								case 5:
									num3 += list[num2].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Mouse, 0, P_1, P_2, P_3, P_4);
									num2++;
									num = 267820158;
									continue;
								case 3:
									goto IL_0063;
								case 1:
									goto end_IL_0004;
								default:
									if (num2 >= list.Count)
									{
										return num3;
									}
									goto case 5;
								}
								break;
								IL_0063:
								if (P_2 == null)
								{
									num = 267820155;
									continue;
								}
								list = (P_5 ? WhcqAfYYqNfRCEGkYApjWYGKVjr.AllPlayers_readOnly : WhcqAfYYqNfRCEGkYApjWYGKVjr.Players_readOnly);
								num3 = 0;
								num = 267820152;
							}
							continue;
							end_IL_0004:
							break;
						}
					}
					return 0;
				}

				private int eBMMIpymIYxKFwxTiNiQVJuIjUb(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId >= 0)
					{
						int num2 = default(int);
						int num3 = default(int);
						IList<Player> list = default(IList<Player>);
						while (true)
						{
							int num = -644548121;
							while (true)
							{
								switch (num ^ -644548123)
								{
								case 0:
									break;
								case 6:
									num = -644548128;
									continue;
								case 4:
									goto end_IL_000a;
								case 1:
									num2 = 0;
									num = -644548125;
									continue;
								case 2:
									goto IL_0059;
								case 7:
									num3 += list[num2].controllers.conflictChecking.RemoveElementAssignmentConflicts(P_0, P_1, P_2);
									num2++;
									num = -644548128;
									continue;
								case 3:
									goto IL_0094;
								default:
									if (num2 >= list.Count)
									{
										return num3;
									}
									goto case 7;
								}
								break;
								IL_0094:
								IList<Player> list2 = WhcqAfYYqNfRCEGkYApjWYGKVjr.Players_readOnly;
								goto IL_00aa;
								IL_0059:
								if (P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
								{
									if (!P_3)
									{
										num = -644548122;
										continue;
									}
									list2 = WhcqAfYYqNfRCEGkYApjWYGKVjr.AllPlayers_readOnly;
									goto IL_00aa;
								}
								num = -644548127;
								continue;
								IL_00aa:
								list = list2;
								num3 = 0;
								num = -644548124;
							}
							continue;
							end_IL_000a:
							break;
						}
					}
					return 0;
				}

				private int ytxSxwDYoLVUtWmyrkmKulgUEuDG(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 >= 0)
					{
						int num3 = default(int);
						IList<Player> list = default(IList<Player>);
						int num2 = default(int);
						while (true)
						{
							int num = 138181824;
							while (true)
							{
								switch (num ^ 0x83C7CC5)
								{
								case 3:
									break;
								case 6:
									goto IL_0035;
								case 4:
									num = 138181829;
									continue;
								case 5:
									goto IL_005e;
								case 1:
									num3 += list[num2].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Custom, P_1, P_2, P_3, P_4, P_5);
									num2++;
									num = 138181829;
									continue;
								case 2:
									goto end_IL_0007;
								default:
									if (num2 >= list.Count)
									{
										return num3;
									}
									goto case 1;
								}
								break;
								IL_005e:
								if (P_3 == null)
								{
									num = 138181831;
									continue;
								}
								IList<Player> list2;
								if (P_6)
								{
									list2 = WhcqAfYYqNfRCEGkYApjWYGKVjr.AllPlayers_readOnly;
									goto IL_004b;
								}
								num = 138181827;
								continue;
								IL_0035:
								list2 = WhcqAfYYqNfRCEGkYApjWYGKVjr.Players_readOnly;
								goto IL_004b;
								IL_004b:
								list = list2;
								num3 = 0;
								num2 = 0;
								num = 138181825;
							}
							continue;
							end_IL_0007:
							break;
						}
					}
					return 0;
				}

				private int ytxSxwDYoLVUtWmyrkmKulgUEuDG(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
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
						list = (P_3 ? WhcqAfYYqNfRCEGkYApjWYGKVjr.AllPlayers_readOnly : WhcqAfYYqNfRCEGkYApjWYGKVjr.Players_readOnly);
						num = 0;
						num2 = 0;
						num3 = -1854386047;
						goto IL_0019;
					}
					goto IL_0068;
					IL_0019:
					while (true)
					{
						switch (num3 ^ -1854386043)
						{
						case 3:
							break;
						case 0:
							num += list[num2].controllers.conflictChecking.RemoveElementAssignmentConflicts(P_0, P_1, P_2);
							num2++;
							num3 = -1854386044;
							continue;
						case 4:
							num3 = -1854386044;
							continue;
						case 2:
							goto IL_0068;
						default:
							if (num2 >= list.Count)
							{
								return num;
							}
							goto case 0;
						}
						break;
					}
					goto IL_0014;
					IL_0014:
					num3 = -1854386041;
					goto IL_0019;
					IL_0068:
					return 0;
				}

				public int DisableElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap)
				{
					return DisableElementAssignmentConflicts(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps: false, forceCheckAllCategories: false, includeSystemPlayer: true);
				}

				public int DisableElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps)
				{
					return DisableElementAssignmentConflicts(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories: false, includeSystemPlayer: true);
				}

				public int DisableElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					return DisableElementAssignmentConflicts(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer: true);
				}

				public int DisableElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories, bool includeSystemPlayer)
				{
					if (!CheckInitialized())
					{
						goto IL_0007;
					}
					int num;
					int num2;
					if (playerId < 0)
					{
						num = 468022203;
						num2 = num;
					}
					else
					{
						num = 468022202;
						num2 = num;
					}
					goto IL_000c;
					IL_0007:
					num = 468022200;
					goto IL_000c;
					IL_000c:
					while (true)
					{
						switch (num ^ 0x1BE573B9)
						{
						case 0:
							break;
						case 1:
							return 0;
						case 3:
							if (elementMap == null)
							{
								goto IL_0044;
							}
							switch (controllerType)
							{
							case ControllerType.Joystick:
								return LpwdrsHEdNMjDHTEMVNWEoTGnzd(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
							case ControllerType.Keyboard:
								return EzwscNaRAaERanLYyeRoDddWiwIb(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
							case ControllerType.Mouse:
								return hAaOOzBucbfZfPNDjrCGLbPrjAz(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
							case ControllerType.Custom:
								return oqKojcsoKskouNlXFfIrnkvwiiQ(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
							default:
								throw new NotImplementedException();
							}
						default:
							return 0;
						}
						break;
						IL_0044:
						num = 468022203;
					}
					goto IL_0007;
				}

				public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
				{
					return DisableElementAssignmentConflicts(conflictCheck, skipDisabledMaps: false, forceCheckAllCategories: false, includeSystemPlayer: true);
				}

				public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
				{
					return DisableElementAssignmentConflicts(conflictCheck, skipDisabledMaps, forceCheckAllCategories: false, includeSystemPlayer: true);
				}

				public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					return DisableElementAssignmentConflicts(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer: true);
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
						goto IL_001f;
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return EzwscNaRAaERanLYyeRoDddWiwIb(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return hAaOOzBucbfZfPNDjrCGLbPrjAz(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					int num;
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						num = 1966292014;
						goto IL_0024;
					}
					throw new NotImplementedException();
					IL_001f:
					num = 1966292013;
					goto IL_0024;
					IL_0024:
					switch (num ^ 0x75333C2C)
					{
					case 0:
						break;
					case 1:
						return LpwdrsHEdNMjDHTEMVNWEoTGnzd(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					default:
						return oqKojcsoKskouNlXFfIrnkvwiiQ(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					goto IL_001f;
				}

				private int LpwdrsHEdNMjDHTEMVNWEoTGnzd(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					IList<Player> list = default(IList<Player>);
					int num;
					if (P_0 >= 0)
					{
						if (P_3 == null)
						{
							goto IL_0008;
						}
						list = (P_6 ? WhcqAfYYqNfRCEGkYApjWYGKVjr.AllPlayers_readOnly : WhcqAfYYqNfRCEGkYApjWYGKVjr.Players_readOnly);
						num = 49487010;
						goto IL_000d;
					}
					goto IL_0032;
					IL_000d:
					int num3 = default(int);
					int num2 = default(int);
					while (true)
					{
						switch (num ^ 0x2F31CA3)
						{
						case 5:
							break;
						case 3:
							goto IL_0032;
						case 4:
							num3 += list[num2].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Joystick, P_1, P_2, P_3, P_4, P_5);
							num2++;
							num = 49487011;
							continue;
						case 1:
							num3 = 0;
							num2 = 0;
							num = 49487009;
							continue;
						case 2:
							num = 49487011;
							continue;
						default:
							if (num2 >= list.Count)
							{
								return num3;
							}
							goto case 4;
						}
						break;
					}
					goto IL_0008;
					IL_0008:
					num = 49487008;
					goto IL_000d;
					IL_0032:
					return 0;
				}

				private int LpwdrsHEdNMjDHTEMVNWEoTGnzd(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
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
							list = WhcqAfYYqNfRCEGkYApjWYGKVjr.AllPlayers_readOnly;
							goto IL_00aa;
						}
						num = -712444202;
						goto IL_001f;
					}
					goto IL_00b5;
					IL_001f:
					int num2 = default(int);
					IList<Player> list2 = default(IList<Player>);
					int num3 = default(int);
					while (true)
					{
						switch (num ^ -712444206)
						{
						case 5:
							break;
						case 2:
							goto IL_0048;
						case 0:
							num2 += list2[num3].controllers.conflictChecking.DisableElementAssignmentConflicts(P_0, P_1, P_2);
							num3++;
							num = -712444208;
							continue;
						case 1:
							num2 = 0;
							num3 = 0;
							num = -712444208;
							continue;
						case 4:
							goto IL_0094;
						case 6:
							goto IL_00b5;
						default:
							return num2;
						}
						break;
						IL_0048:
						int num4;
						if (num3 >= list2.Count)
						{
							num = -712444207;
							num4 = num;
						}
						else
						{
							num = -712444206;
							num4 = num;
						}
					}
					goto IL_001a;
					IL_00aa:
					list2 = list;
					num = -712444205;
					goto IL_001f;
					IL_0094:
					list = WhcqAfYYqNfRCEGkYApjWYGKVjr.Players_readOnly;
					goto IL_00aa;
					IL_00b5:
					return 0;
					IL_001a:
					num = -712444204;
					goto IL_001f;
				}

				private int EzwscNaRAaERanLYyeRoDddWiwIb(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
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
						list = (P_5 ? WhcqAfYYqNfRCEGkYApjWYGKVjr.AllPlayers_readOnly : WhcqAfYYqNfRCEGkYApjWYGKVjr.Players_readOnly);
						num = 0;
						num2 = 132968648;
						goto IL_000c;
					}
					goto IL_0058;
					IL_000c:
					int num3 = default(int);
					while (true)
					{
						switch (num2 ^ 0x7ECF0C9)
						{
						case 3:
							break;
						case 5:
							goto IL_0035;
						case 1:
							num3 = 0;
							num2 = 132968649;
							continue;
						case 6:
							goto IL_0058;
						case 0:
							num2 = 132968652;
							continue;
						case 4:
							num += list[num3].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Keyboard, 0, P_1, P_2, P_3, P_4);
							num3++;
							num2 = 132968652;
							continue;
						default:
							return num;
						}
						break;
						IL_0035:
						int num4;
						if (num3 < list.Count)
						{
							num2 = 132968653;
							num4 = num2;
						}
						else
						{
							num2 = 132968651;
							num4 = num2;
						}
					}
					goto IL_0007;
					IL_0007:
					num2 = 132968655;
					goto IL_000c;
					IL_0058:
					return 0;
				}

				private int EzwscNaRAaERanLYyeRoDddWiwIb(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					IList<Player> list = default(IList<Player>);
					int num;
					if (P_0.playerId >= 0)
					{
						if (P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
						{
							goto IL_0014;
						}
						list = (P_3 ? WhcqAfYYqNfRCEGkYApjWYGKVjr.AllPlayers_readOnly : WhcqAfYYqNfRCEGkYApjWYGKVjr.Players_readOnly);
						num = 914703671;
						goto IL_0019;
					}
					goto IL_003e;
					IL_0019:
					int num2 = default(int);
					int num3 = default(int);
					while (true)
					{
						switch (num ^ 0x36854533)
						{
						case 0:
							break;
						case 1:
							goto IL_003e;
						case 4:
							num2 = 0;
							num3 = 0;
							num = 914703664;
							continue;
						case 5:
							num2 += list[num3].controllers.conflictChecking.DisableElementAssignmentConflicts(P_0, P_1, P_2);
							num3++;
							num = 914703664;
							continue;
						case 3:
							goto IL_0094;
						default:
							return num2;
						}
						break;
						IL_0094:
						int num4;
						if (num3 >= list.Count)
						{
							num = 914703665;
							num4 = num;
						}
						else
						{
							num = 914703670;
							num4 = num;
						}
					}
					goto IL_0014;
					IL_0014:
					num = 914703666;
					goto IL_0019;
					IL_003e:
					return 0;
				}

				private int hAaOOzBucbfZfPNDjrCGLbPrjAz(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
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
						list = (P_5 ? WhcqAfYYqNfRCEGkYApjWYGKVjr.AllPlayers_readOnly : WhcqAfYYqNfRCEGkYApjWYGKVjr.Players_readOnly);
						num = 0;
						num2 = 0;
						num3 = -1468200166;
						goto IL_000c;
					}
					goto IL_002d;
					IL_000c:
					while (true)
					{
						switch (num3 ^ -1468200165)
						{
						case 0:
							break;
						case 4:
							goto IL_002d;
						case 3:
							num2++;
							num3 = -1468200166;
							continue;
						case 2:
							num += list[num2].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Mouse, 0, P_1, P_2, P_3, P_4);
							num3 = -1468200168;
							continue;
						default:
							if (num2 >= list.Count)
							{
								return num;
							}
							goto case 2;
						}
						break;
					}
					goto IL_0007;
					IL_0007:
					num3 = -1468200161;
					goto IL_000c;
					IL_002d:
					return 0;
				}

				private int hAaOOzBucbfZfPNDjrCGLbPrjAz(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					IList<Player> list;
					int num;
					if (P_0.playerId >= 0)
					{
						if (P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
						{
							goto IL_0014;
						}
						if (P_3)
						{
							list = WhcqAfYYqNfRCEGkYApjWYGKVjr.AllPlayers_readOnly;
							goto IL_006e;
						}
						num = -570061416;
						goto IL_0019;
					}
					goto IL_0076;
					IL_0019:
					int num2 = default(int);
					int num3 = default(int);
					IList<Player> list2 = default(IList<Player>);
					while (true)
					{
						switch (num ^ -570061414)
						{
						case 4:
							break;
						case 5:
							num2 = 0;
							num = -570061412;
							continue;
						case 3:
							num3 = 0;
							num = -570061409;
							continue;
						case 2:
							goto IL_0058;
						case 1:
							goto IL_0076;
						case 0:
							num2++;
							num = -570061412;
							continue;
						case 7:
							num3 += list2[num2].controllers.conflictChecking.DisableElementAssignmentConflicts(P_0, P_1, P_2);
							num = -570061414;
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
					goto IL_0014;
					IL_006e:
					list2 = list;
					num = -570061415;
					goto IL_0019;
					IL_0058:
					list = WhcqAfYYqNfRCEGkYApjWYGKVjr.Players_readOnly;
					goto IL_006e;
					IL_0076:
					return 0;
					IL_0014:
					num = -570061413;
					goto IL_0019;
				}

				private int oqKojcsoKskouNlXFfIrnkvwiiQ(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					IList<Player> list = default(IList<Player>);
					int num;
					if (P_0 >= 0)
					{
						if (P_3 == null)
						{
							goto IL_0008;
						}
						list = (P_6 ? WhcqAfYYqNfRCEGkYApjWYGKVjr.AllPlayers_readOnly : WhcqAfYYqNfRCEGkYApjWYGKVjr.Players_readOnly);
						num = 1519156168;
						goto IL_000d;
					}
					goto IL_0032;
					IL_000d:
					int num3 = default(int);
					int num2 = default(int);
					while (true)
					{
						switch (num ^ 0x5A8C7BCA)
						{
						case 5:
							break;
						case 1:
							goto IL_0032;
						case 4:
							num3 += list[num2].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Custom, P_1, P_2, P_3, P_4, P_5);
							num2++;
							num = 1519156170;
							continue;
						case 2:
							num3 = 0;
							num = 1519156169;
							continue;
						case 3:
							num2 = 0;
							num = 1519156170;
							continue;
						default:
							if (num2 >= list.Count)
							{
								return num3;
							}
							goto case 4;
						}
						break;
					}
					goto IL_0008;
					IL_0008:
					num = 1519156171;
					goto IL_000d;
					IL_0032:
					return 0;
				}

				private int oqKojcsoKskouNlXFfIrnkvwiiQ(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId >= 0)
					{
						int num3 = default(int);
						IList<Player> list = default(IList<Player>);
						int num2 = default(int);
						while (true)
						{
							int num = 1388371584;
							while (true)
							{
								switch (num ^ 0x52C0DE82)
								{
								case 5:
									break;
								case 6:
									goto IL_0042;
								case 4:
									num3 += list[num2].controllers.conflictChecking.DisableElementAssignmentConflicts(P_0, P_1, P_2);
									num2++;
									num = 1388371586;
									continue;
								case 2:
									goto IL_0089;
								case 1:
									goto end_IL_000d;
								case 3:
									num2 = 0;
									num = 1388371589;
									continue;
								case 7:
									num = 1388371586;
									continue;
								default:
									if (num2 >= list.Count)
									{
										return num3;
									}
									goto case 4;
								}
								break;
								IL_0089:
								if (P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
								{
									num = 1388371587;
									continue;
								}
								IList<Player> list2;
								if (P_3)
								{
									list2 = WhcqAfYYqNfRCEGkYApjWYGKVjr.AllPlayers_readOnly;
									goto IL_0058;
								}
								num = 1388371588;
								continue;
								IL_0042:
								list2 = WhcqAfYYqNfRCEGkYApjWYGKVjr.Players_readOnly;
								goto IL_0058;
								IL_0058:
								list = list2;
								num3 = 0;
								num = 1388371585;
							}
							continue;
							end_IL_000d:
							break;
						}
					}
					return 0;
				}
			}

			private static ControllerHelper ilVQEiENSgAnwgRreWwIUWTqyneQ;

			public readonly PollingHelper polling = PollingHelper.Instance;

			public readonly ConflictCheckingHelper conflictChecking = ConflictCheckingHelper.Instance;

			internal static ControllerHelper Instance => ilVQEiENSgAnwgRreWwIUWTqyneQ ?? (ilVQEiENSgAnwgRreWwIUWTqyneQ = new ControllerHelper());

			public int controllerCount
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0;
					}
					return akUdmKMbrqFLXkjqdKLUZOPTArx.controllerCount;
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
					return akUdmKMbrqFLXkjqdKLUZOPTArx.Controllers;
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
					return akUdmKMbrqFLXkjqdKLUZOPTArx.Mouse;
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
					return akUdmKMbrqFLXkjqdKLUZOPTArx.Keyboard;
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
						return;
					}
					while (true)
					{
						Keyboard.enabled = value;
						int num = -610987408;
						while (true)
						{
							switch (num ^ -610987408)
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
							num = -610987407;
						}
					}
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
					return akUdmKMbrqFLXkjqdKLUZOPTArx.joystickCount;
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
					return akUdmKMbrqFLXkjqdKLUZOPTArx.Joysticks_readOnly;
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
					return akUdmKMbrqFLXkjqdKLUZOPTArx.customControllerCount;
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
					return akUdmKMbrqFLXkjqdKLUZOPTArx.CustomControllers_readOnly;
				}
			}

			private ControllerHelper()
			{
			}

			public T GetController<T>(int controllerId) where T : Controller
			{
				if (!CheckInitialized())
				{
					return null;
				}
				if (controllerId < 0)
				{
					return null;
				}
				Type typeFromHandle = typeof(T);
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
				{
					return GetJoystick(controllerId) as T;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Keyboard)))
				{
					return akUdmKMbrqFLXkjqdKLUZOPTArx.Keyboard as T;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(CustomController)))
				{
					return GetCustomController(controllerId) as T;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Mouse)))
				{
					return akUdmKMbrqFLXkjqdKLUZOPTArx.Mouse as T;
				}
				throw new NotImplementedException();
			}

			public int GetControllerCount(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					while (true)
					{
						switch (0x102D955C ^ 0x102D955D)
						{
						case 0:
							continue;
						case 1:
							return 0;
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
						return 1;
					case ControllerType.Mouse:
						return 1;
					case ControllerType.Custom:
						return customControllerCount;
					default:
						throw new NotImplementedException();
					}
				}
				return joystickCount;
			}

			public Controller GetController(ControllerType controllerType, int controllerId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return akUdmKMbrqFLXkjqdKLUZOPTArx.lRKToUyChtEIyMHppndqwlmeZVh(controllerType, controllerId);
			}

			public Controller GetController(ControllerIdentifier controllerIdentifier)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return akUdmKMbrqFLXkjqdKLUZOPTArx.lRKToUyChtEIyMHppndqwlmeZVh(controllerIdentifier);
			}

			public Controller[] GetControllers(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<Controller>.array;
				}
				return akUdmKMbrqFLXkjqdKLUZOPTArx.AxkkgCMCQqcIsfDohiuFmbZlGJKB(controllerType);
			}

			public string[] GetControllerNames(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return akUdmKMbrqFLXkjqdKLUZOPTArx.rzxEheGawXeGHOFLrCKbhzzXRLzc(controllerType);
			}

			public bool IsControllerAssigned(ControllerType controllerType, Controller controller)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return WhcqAfYYqNfRCEGkYApjWYGKVjr.uuChLUKXPXhvadoSFWyqGXcYaWr(controller);
			}

			public bool IsControllerAssigned(ControllerType controllerType, int controllerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return WhcqAfYYqNfRCEGkYApjWYGKVjr.uuChLUKXPXhvadoSFWyqGXcYaWr(controllerType, controllerId);
			}

			public bool IsControllerAssignedToPlayer(ControllerType controllerType, int controllerId, int playerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return WhcqAfYYqNfRCEGkYApjWYGKVjr.NnHfMvjJAnZEhWplfbSEfCMxYDR(controllerType, controllerId, playerId);
			}

			public void RemoveControllerFromAllPlayers(Controller controller, bool includeSystemPlayer = true)
			{
				if (!CheckInitialized())
				{
					while (true)
					{
						switch (0x27057844 ^ 0x27057846)
						{
						case 0:
							continue;
						case 2:
							return;
						}
						break;
					}
				}
				WhcqAfYYqNfRCEGkYApjWYGKVjr.iuZLrBzGFyvlgUxeviNoOPgtzSJ(controller, includeSystemPlayer);
			}

			public void RemoveControllerFromAllPlayers(ControllerType controllerType, int controllerId, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					WhcqAfYYqNfRCEGkYApjWYGKVjr.iuZLrBzGFyvlgUxeviNoOPgtzSJ(controllerType, controllerId, includeSystemPlayer);
				}
			}

			public Joystick GetJoystick(int joystickId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return akUdmKMbrqFLXkjqdKLUZOPTArx.JCDhdBcaJPtIabIaCiOxBLwtJEKK(joystickId);
			}

			public Joystick[] GetJoysticks()
			{
				return akUdmKMbrqFLXkjqdKLUZOPTArx.ynWdqHhVsmcAWewMQEUmudUWEbPd();
			}

			public string[] GetJoystickNames()
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return akUdmKMbrqFLXkjqdKLUZOPTArx.LzprbeIUmpBuFpLzcWjsheSUqTc();
			}

			public bool IsJoystickAssigned(Joystick joystick)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return WhcqAfYYqNfRCEGkYApjWYGKVjr.QieAqBkpTdqkilefxFMYCnvJkkWI(joystick);
			}

			public bool IsJoystickAssigned(int joystickId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return WhcqAfYYqNfRCEGkYApjWYGKVjr.QieAqBkpTdqkilefxFMYCnvJkkWI(joystickId);
			}

			public bool IsJoystickAssignedToPlayer(int joystickId, int playerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return WhcqAfYYqNfRCEGkYApjWYGKVjr.khHQWaSXMsvHxRVuOCZxHVYrGxY(joystickId, playerId);
			}

			public void RemoveJoystickFromAllPlayers(Joystick joystick, bool includeSystemPlayer = true)
			{
				if (!CheckInitialized())
				{
					while (true)
					{
						switch (-680458496 ^ -680458495)
						{
						case 2:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				WhcqAfYYqNfRCEGkYApjWYGKVjr.atTKHbDpLNgsWakgJGjYrOGBisbf(joystick, includeSystemPlayer);
			}

			public void RemoveJoystickFromAllPlayers(int joystickId, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					WhcqAfYYqNfRCEGkYApjWYGKVjr.atTKHbDpLNgsWakgJGjYrOGBisbf(joystickId, includeSystemPlayer);
				}
			}

			public int GetUnityJoystickIdFromAnyButtonPress()
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				if (!TxGduWEriXzpLaJgHFbGWOaDcLpz)
				{
					Logger.LogWarning("This can only used when Unity Input is handling input. This has no effect on this platform.");
					goto IL_001a;
				}
				CAPxYaYkuVddrltMCElRNfXaths();
				int num = 0;
				int num2 = -1224924080;
				goto IL_001f;
				IL_001a:
				num2 = -1224924077;
				goto IL_001f;
				IL_001f:
				bool flag = default(bool);
				int num3 = default(int);
				while (true)
				{
					switch (num2 ^ -1224924080)
					{
					case 6:
						break;
					case 3:
						return -1;
					case 2:
						flag = unityInputBuffer.IWIFIRpTzKautLzErLHXSoulUx(num, num3);
						num2 = -1224924075;
						continue;
					case 0:
					{
						int num4;
						if (num < 16)
						{
							num2 = -1224924079;
							num4 = num2;
						}
						else
						{
							num2 = -1224924076;
							num4 = num2;
						}
						continue;
					}
					case 1:
						num3 = 0;
						num2 = -1224924073;
						continue;
					case 7:
						if (num3 >= 20)
						{
							num++;
							num2 = -1224924080;
							continue;
						}
						goto case 2;
					case 5:
						if (flag)
						{
							return num + 1;
						}
						num3++;
						num2 = -1224924073;
						continue;
					default:
						return -1;
					}
					break;
				}
				goto IL_001a;
			}

			public int GetUnityJoystickIdFromAnyButtonOrAxisPress(float axisThreshold, bool positiveAxesOnly)
			{
				if (!CheckInitialized())
				{
					goto IL_000a;
				}
				int num = default(int);
				int num2;
				if (TxGduWEriXzpLaJgHFbGWOaDcLpz)
				{
					CAPxYaYkuVddrltMCElRNfXaths();
					num = 0;
					num2 = 1369542355;
				}
				else
				{
					num2 = 1369542366;
				}
				goto IL_000f;
				IL_000a:
				num2 = 1369542360;
				goto IL_000f;
				IL_000f:
				int num4 = default(int);
				int num3 = default(int);
				while (true)
				{
					switch (num2 ^ 0x51A18EDF)
					{
					case 0:
						break;
					case 11:
					{
						int num6;
						if (num < 16)
						{
							num2 = 1369542363;
							num6 = num2;
						}
						else
						{
							num2 = 1369542364;
							num6 = num2;
						}
						continue;
					}
					case 6:
						return -1;
					case 1:
						Logger.LogWarning("This can only used when Unity Input is handling input. This has no effect on this platform.");
						num2 = 1369542361;
						continue;
					case 8:
					{
						int num5;
						if (num4 < 20)
						{
							num2 = 1369542365;
							num5 = num2;
						}
						else
						{
							num2 = 1369542357;
							num5 = num2;
						}
						continue;
					}
					case 7:
						return -1;
					case 12:
						num2 = 1369542356;
						continue;
					case 9:
						if (unityInputBuffer.ejsfksCaqpcjIpvPgTqFmRGgrYAQ(num, num3, positiveAxesOnly))
						{
							return num + 1;
						}
						num3++;
						num2 = 1369542362;
						continue;
					case 2:
						if (unityInputBuffer.IWIFIRpTzKautLzErLHXSoulUx(num, num4))
						{
							return num + 1;
						}
						num4++;
						num2 = 1369542359;
						continue;
					case 5:
						if (num3 >= 29)
						{
							num++;
							num2 = 1369542356;
							continue;
						}
						goto case 9;
					case 4:
						num4 = 0;
						num2 = 1369542359;
						continue;
					case 10:
						num3 = 0;
						num2 = 1369542362;
						continue;
					default:
						return -1;
					}
					break;
				}
				goto IL_000a;
			}

			public void SetUnityJoystickId(int joystickId, int unityJoystickId)
			{
				if (!CheckInitialized())
				{
					return;
				}
				while (TxGduWEriXzpLaJgHFbGWOaDcLpz)
				{
					while (true)
					{
						IL_0043:
						hZJPCfIEEHEOdtoukvjGAEibgUIb.SetUnityJoystickId(joystickId, unityJoystickId);
						int num = -830447758;
						while (true)
						{
							switch (num ^ -830447757)
							{
							case 0:
								num = -830447760;
								continue;
							default:
								return;
							case 3:
								break;
							case 2:
								goto IL_0043;
							case 1:
								return;
							}
							break;
						}
						break;
					}
				}
				Logger.LogWarning("This can only used when Unity Input is handling input. This has no effect on this platform.");
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
					return false;
				}
				SetUnityJoystickId(joystickId, unityJoystickIdFromAnyButtonPress);
				return true;
			}

			public bool SetUnityJoystickIdFromAnyButtonOrAxisPress(int joystickId, float axisThreshold, bool positiveAxesOnly)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				int unityJoystickIdFromAnyButtonOrAxisPress = GetUnityJoystickIdFromAnyButtonOrAxisPress(axisThreshold, positiveAxesOnly);
				while (true)
				{
					int num = -30828558;
					while (true)
					{
						switch (num ^ -30828557)
						{
						case 0:
							break;
						case 1:
							if (unityJoystickIdFromAnyButtonOrAxisPress < 1)
							{
								goto IL_0034;
							}
							SetUnityJoystickId(joystickId, unityJoystickIdFromAnyButtonOrAxisPress);
							return true;
						default:
							return false;
						}
						break;
						IL_0034:
						num = -30828559;
					}
				}
			}

			public CustomController GetCustomController(int customControllerId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return akUdmKMbrqFLXkjqdKLUZOPTArx.nmdAXHdbPyfIGxYnapMeXnMTymF(customControllerId);
			}

			public CustomController[] GetCustomControllers()
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<CustomController>.array;
				}
				return akUdmKMbrqFLXkjqdKLUZOPTArx.AeUBzTrNjCYIgsFwrvdurqXcrHG();
			}

			public string[] GetCustomControllerNames()
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return akUdmKMbrqFLXkjqdKLUZOPTArx.YIUDaKDOYiYtfxTdvhBDLSkENBX();
			}

			public bool IsCustomControllerAssigned(CustomController customController)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return WhcqAfYYqNfRCEGkYApjWYGKVjr.TuGOPoiOKXbzulXNZumfijMOzoI(customController);
			}

			public bool IsCustomControllerAssigned(int customControllerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return WhcqAfYYqNfRCEGkYApjWYGKVjr.TuGOPoiOKXbzulXNZumfijMOzoI(customControllerId);
			}

			public bool IsCustomControllerAssignedToPlayer(int customControllerId, int playerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return WhcqAfYYqNfRCEGkYApjWYGKVjr.UboYCMBvmTXjgcxxJmCaynZNlDr(customControllerId, playerId);
			}

			public void RemoveCustomControllerFromAllPlayers(CustomController customController, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					WhcqAfYYqNfRCEGkYApjWYGKVjr.lUIddKOZzHEfCFUzonMtlUhLxNv(customController, includeSystemPlayer);
				}
			}

			public void RemoveCustomControllerFromAllPlayers(int customControllerId, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					WhcqAfYYqNfRCEGkYApjWYGKVjr.lUIddKOZzHEfCFUzonMtlUhLxNv(customControllerId, includeSystemPlayer);
				}
			}

			public CustomController CreateCustomController(int sourceControllerId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return akUdmKMbrqFLXkjqdKLUZOPTArx.WhUGCBoKUaVEhcUVTTDVyELczky(sourceControllerId);
			}

			public CustomController CreateCustomController(int sourceControllerId, string tag)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				CustomController customController = akUdmKMbrqFLXkjqdKLUZOPTArx.WhUGCBoKUaVEhcUVTTDVyELczky(sourceControllerId);
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
				return akUdmKMbrqFLXkjqdKLUZOPTArx.SsbVARSFfeFqnyEkTXfEirtgsbK(customController);
			}

			public CustomController GetFirstCustomControllerWithSourceId(int sourceId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return akUdmKMbrqFLXkjqdKLUZOPTArx.DsrZtBCOWkxAvxTTVlXGvEyPDHG(sourceId);
			}

			public CustomController GetFirstCustomControllerWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return akUdmKMbrqFLXkjqdKLUZOPTArx.CQnLgttbpkMrBARmscALfVKSeAKr(tag);
			}

			public IEnumerable<CustomController> CustomControllersWithSourceId(int sourceId)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<CustomController>.EmptyReadOnlyIListT;
				}
				return akUdmKMbrqFLXkjqdKLUZOPTArx.XgxlKdOopPOhRpdeDRwQIAkcNjv(sourceId);
			}

			public IEnumerable<CustomController> CustomControllersWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<CustomController>.EmptyReadOnlyIListT;
				}
				return akUdmKMbrqFLXkjqdKLUZOPTArx.zTENOlfKphGOkPVColUsEnmBBmR(tag);
			}

			public IList<TInterface> GetControllerTemplates<TInterface>() where TInterface : IControllerTemplate
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<TInterface>.EmptyReadOnlyIListT;
				}
				return akUdmKMbrqFLXkjqdKLUZOPTArx.FgQQMUzgEuQzAhjlHgysYegnaLn<TInterface>();
			}

			public Controller GetLastActiveController()
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return akUdmKMbrqFLXkjqdKLUZOPTArx.GAMsTblJkcwwHOWGaarBuZDFDmq();
			}

			public Controller GetLastActiveController(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return akUdmKMbrqFLXkjqdKLUZOPTArx.GAMsTblJkcwwHOWGaarBuZDFDmq(controllerType);
			}

			public T GetLastActiveController<T>() where T : Controller
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return akUdmKMbrqFLXkjqdKLUZOPTArx.GAMsTblJkcwwHOWGaarBuZDFDmq<T>();
			}

			public ControllerType GetLastActiveControllerType()
			{
				if (!CheckInitialized())
				{
					return ControllerType.Keyboard;
				}
				return akUdmKMbrqFLXkjqdKLUZOPTArx.WbfNMrBsIgebvERgcaqLCWaveDQ();
			}

			public void AddLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback)
			{
				if (!CheckInitialized())
				{
					return;
				}
				while (true)
				{
					akUdmKMbrqFLXkjqdKLUZOPTArx.MqDqxGWuOCyWAIdIkzOEoctTCyo(callback);
					int num = -1036506781;
					while (true)
					{
						switch (num ^ -1036506782)
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
						num = -1036506784;
					}
				}
			}

			public void AddLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback, ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					while (true)
					{
						switch (-1381443696 ^ -1381443695)
						{
						case 2:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				akUdmKMbrqFLXkjqdKLUZOPTArx.MqDqxGWuOCyWAIdIkzOEoctTCyo(callback, controllerType);
			}

			public void RemoveLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback)
			{
				if (!CheckInitialized())
				{
					return;
				}
				while (true)
				{
					akUdmKMbrqFLXkjqdKLUZOPTArx.SocWXTmgYYhVxfPvwjxVyFCgcBN(callback);
					int num = 270471672;
					while (true)
					{
						switch (num ^ 0x101F11F9)
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
						num = 270471675;
					}
				}
			}

			public void RemoveLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback, ControllerType controllerType)
			{
				if (CheckInitialized())
				{
					akUdmKMbrqFLXkjqdKLUZOPTArx.piCLvCEoDQKNaLuLzlawqKmTZAV(callback, controllerType);
				}
			}

			public void ClearLastActiveControllerChangedDelegates()
			{
				if (!CheckInitialized())
				{
					return;
				}
				while (true)
				{
					akUdmKMbrqFLXkjqdKLUZOPTArx.jIyPROmihxCpKwLjsbBzIhGZEHmh();
					int num = -1853322752;
					while (true)
					{
						switch (num ^ -1853322752)
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
						num = -1853322751;
					}
				}
			}

			public bool GetAnyButton()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return akUdmKMbrqFLXkjqdKLUZOPTArx.qMmkNDOMQzXPyMTDEAjnCqJcDZM();
			}

			public bool GetAnyButton(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return akUdmKMbrqFLXkjqdKLUZOPTArx.qMmkNDOMQzXPyMTDEAjnCqJcDZM(controllerType);
			}

			public bool GetAnyButtonDown()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return akUdmKMbrqFLXkjqdKLUZOPTArx.iWvHticXrAdWZFLviBzvsGPLFsf();
			}

			public bool GetAnyButtonDown(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return akUdmKMbrqFLXkjqdKLUZOPTArx.iWvHticXrAdWZFLviBzvsGPLFsf(controllerType);
			}

			public bool GetAnyButtonUp()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return akUdmKMbrqFLXkjqdKLUZOPTArx.YEsIScIAGladATFwkFhUTFweJNvB();
			}

			public bool GetAnyButtonUp(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return akUdmKMbrqFLXkjqdKLUZOPTArx.YEsIScIAGladATFwkFhUTFweJNvB(controllerType);
			}

			public bool GetAnyButtonChanged()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return akUdmKMbrqFLXkjqdKLUZOPTArx.DresfhJUXCtTWmWJwjrlJqaymvp();
			}

			public bool GetAnyButtonChanged(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return akUdmKMbrqFLXkjqdKLUZOPTArx.DresfhJUXCtTWmWJwjrlJqaymvp(controllerType);
			}

			public bool GetAnyButtonPrev()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return akUdmKMbrqFLXkjqdKLUZOPTArx.EqwgBzPiElvyaDTFfPlGplGnudu();
			}

			public bool GetAnyButtonPrev(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return akUdmKMbrqFLXkjqdKLUZOPTArx.EqwgBzPiElvyaDTFfPlGplGnudu(controllerType);
			}

			public bool AutoAssignJoystick(Joystick joystick)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				if (joystick == null)
				{
					return false;
				}
				if (IsJoystickAssigned(joystick))
				{
					return true;
				}
				WhcqAfYYqNfRCEGkYApjWYGKVjr.rLadaVaiWVUKvuGILgeiscwRnpq(joystick);
				return IsJoystickAssigned(joystick);
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
					int num3 = -229350307;
					while (true)
					{
						switch (num3 ^ -229350311)
						{
						case 0:
							num3 = -229350312;
							continue;
						case 1:
							break;
						case 4:
							num3 = -229350310;
							continue;
						case 2:
							AutoAssignJoystick(joysticks[num2]);
							num2++;
							num3 = -229350310;
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

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class MappingHelper : CodeHelper
		{
			private static MappingHelper ilVQEiENSgAnwgRreWwIUWTqyneQ;

			internal static MappingHelper Instance => ilVQEiENSgAnwgRreWwIUWTqyneQ ?? (ilVQEiENSgAnwgRreWwIUWTqyneQ = new MappingHelper());

			public IList<InputMapCategory> MapCategories
			{
				get
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<InputMapCategory>.EmptyReadOnlyIListT;
					}
					return NrWVrlwEDRnzNfQhnCmEXbpqELr.MapCategories_readOnly;
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
					return NrWVrlwEDRnzNfQhnCmEXbpqELr.UserAssignableMapCategories;
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
					return NrWVrlwEDRnzNfQhnCmEXbpqELr.ActionCategories_readOnly;
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
					return NrWVrlwEDRnzNfQhnCmEXbpqELr.UserAssignableActionCategories;
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
					return NrWVrlwEDRnzNfQhnCmEXbpqELr.JoystickLayouts_readOnly;
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
					return NrWVrlwEDRnzNfQhnCmEXbpqELr.KeyboardLayouts_readOnly;
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
					return NrWVrlwEDRnzNfQhnCmEXbpqELr.MouseLayouts_readOnly;
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
					return NrWVrlwEDRnzNfQhnCmEXbpqELr.CustomControllerLayouts_readOnly;
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
					return lUCgcEIquFfuykgBneGrfARQlcR.Actions;
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
					return NrWVrlwEDRnzNfQhnCmEXbpqELr.UserAssignableActions;
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
				return NrWVrlwEDRnzNfQhnCmEXbpqELr.GetMapCategoryById(mapCategoryId);
			}

			public InputMapCategory GetMapCategory(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return NrWVrlwEDRnzNfQhnCmEXbpqELr.GetMapCategory(name);
			}

			public int GetMapCategoryId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return NrWVrlwEDRnzNfQhnCmEXbpqELr.GetMapCategoryId(name);
			}

			public IEnumerable<InputMapCategory> MapCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputMapCategory>.EmptyReadOnlyIListT;
				}
				return NrWVrlwEDRnzNfQhnCmEXbpqELr.IfiNsBMejUeufcxVpwnTPNuJLBhh(tag);
			}

			public IEnumerable<InputMapCategory> UserAssignableMapCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputMapCategory>.EmptyReadOnlyIListT;
				}
				return NrWVrlwEDRnzNfQhnCmEXbpqELr.sajQIsOWHJkOuqGIGeBhlwaKwd(tag);
			}

			public bool IsMapCategoryUserAssignable(int mapCategoryId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return GetMapCategory(mapCategoryId)?.userAssignable ?? false;
			}

			public InputCategory GetActionCategory(int mapCategoryId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return NrWVrlwEDRnzNfQhnCmEXbpqELr.GetActionCategoryById(mapCategoryId);
			}

			public InputCategory GetActionCategory(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return NrWVrlwEDRnzNfQhnCmEXbpqELr.GetActionCategory(name);
			}

			public int GetActionCategoryId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return NrWVrlwEDRnzNfQhnCmEXbpqELr.GetActionCategoryId(name);
			}

			public IEnumerable<InputCategory> ActionCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputCategory>.EmptyReadOnlyIListT;
				}
				return NrWVrlwEDRnzNfQhnCmEXbpqELr.wBDOFeXdBIBakVRmvTpdwkLODAC(tag);
			}

			public IEnumerable<InputCategory> UserAssignableActionCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputCategory>.EmptyReadOnlyIListT;
				}
				return NrWVrlwEDRnzNfQhnCmEXbpqELr.GXaKhZUEomwUIWnmPLgoLAYSzhz(tag);
			}

			public bool IsActionCategoryUserAssignable(int mapCategoryId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return GetActionCategory(mapCategoryId)?.userAssignable ?? false;
			}

			public InputLayout GetLayout(ControllerType controllerType, int layoutId)
			{
				if (!CheckInitialized())
				{
					goto IL_0007;
				}
				ControllerType controllerType2 = controllerType;
				int num = -1111057034;
				goto IL_000c;
				IL_000c:
				while (true)
				{
					switch (num ^ -1111057036)
					{
					case 0:
						break;
					case 3:
						return null;
					case 4:
						if (controllerType2 == ControllerType.Custom)
						{
							return NrWVrlwEDRnzNfQhnCmEXbpqELr.GetCustomControllerLayoutById(layoutId);
						}
						throw new NotImplementedException();
					case 2:
						switch (controllerType2)
						{
						default:
							goto IL_0058;
						case ControllerType.Joystick:
							break;
						case ControllerType.Keyboard:
							return NrWVrlwEDRnzNfQhnCmEXbpqELr.GetKeyboardLayoutById(layoutId);
						case ControllerType.Mouse:
							return NrWVrlwEDRnzNfQhnCmEXbpqELr.GetMouseLayoutById(layoutId);
						}
						goto default;
					default:
						return NrWVrlwEDRnzNfQhnCmEXbpqELr.GetJoystickLayoutById(layoutId);
					}
					break;
					IL_0058:
					num = -1111057040;
				}
				goto IL_0007;
				IL_0007:
				num = -1111057033;
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
					int num = 1772454157;
					while (true)
					{
						switch (num ^ 0x69A5810E)
						{
						case 0:
							break;
						case 3:
							switch (controllerType)
							{
							default:
								num = 1772454154;
								continue;
							case ControllerType.Joystick:
								break;
							case ControllerType.Keyboard:
								return NrWVrlwEDRnzNfQhnCmEXbpqELr.GetKeyboardLayout(name);
							case ControllerType.Mouse:
								return NrWVrlwEDRnzNfQhnCmEXbpqELr.GetMouseLayout(name);
							}
							goto default;
						case 4:
							if (controllerType != ControllerType.Custom)
							{
								num = 1772454159;
								continue;
							}
							return NrWVrlwEDRnzNfQhnCmEXbpqELr.GetCustomControllerLayout(name);
						default:
							return NrWVrlwEDRnzNfQhnCmEXbpqELr.GetJoystickLayout(name);
						case 1:
							throw new NotImplementedException();
						}
						break;
					}
				}
			}

			public int GetLayoutId(ControllerType controllerType, string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				while (true)
				{
					switch (0x692237E2 ^ 0x692237E0)
					{
					case 0:
						continue;
					case 2:
						switch (controllerType)
						{
						case ControllerType.Joystick:
							break;
						case ControllerType.Keyboard:
							return NrWVrlwEDRnzNfQhnCmEXbpqELr.GetKeyboardLayoutId(name);
						case ControllerType.Mouse:
							return NrWVrlwEDRnzNfQhnCmEXbpqELr.GetMouseLayoutId(name);
						case ControllerType.Custom:
							return NrWVrlwEDRnzNfQhnCmEXbpqELr.GetCustomControllerLayoutId(name);
						default:
							throw new NotImplementedException();
						}
						break;
					}
					break;
				}
				return NrWVrlwEDRnzNfQhnCmEXbpqELr.GetJoystickLayoutId(name);
			}

			public InputLayout GetJoystickLayout(int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return NrWVrlwEDRnzNfQhnCmEXbpqELr.GetJoystickLayoutById(layoutId);
			}

			public InputLayout GetJoystickLayout(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return NrWVrlwEDRnzNfQhnCmEXbpqELr.GetJoystickLayout(name);
			}

			public int GetJoystickLayoutId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return NrWVrlwEDRnzNfQhnCmEXbpqELr.GetJoystickLayoutId(name);
			}

			public InputLayout GetKeyboardLayout(int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return NrWVrlwEDRnzNfQhnCmEXbpqELr.GetKeyboardLayoutById(layoutId);
			}

			public InputLayout GetKeyboardLayout(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return NrWVrlwEDRnzNfQhnCmEXbpqELr.GetKeyboardLayout(name);
			}

			public int GetKeyboardLayoutId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return NrWVrlwEDRnzNfQhnCmEXbpqELr.GetKeyboardLayoutId(name);
			}

			public InputLayout GetMouseLayout(int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return NrWVrlwEDRnzNfQhnCmEXbpqELr.GetMouseLayoutById(layoutId);
			}

			public InputLayout GetMouseLayout(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return NrWVrlwEDRnzNfQhnCmEXbpqELr.GetMouseLayout(name);
			}

			public int GetMouseLayoutId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return NrWVrlwEDRnzNfQhnCmEXbpqELr.GetMouseLayoutId(name);
			}

			public InputLayout GetCustomControllerLayout(int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return NrWVrlwEDRnzNfQhnCmEXbpqELr.GetCustomControllerLayoutById(layoutId);
			}

			public InputLayout GetCustomControllerLayout(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return NrWVrlwEDRnzNfQhnCmEXbpqELr.GetCustomControllerLayout(name);
			}

			public int GetCustomControllerLayoutId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return NrWVrlwEDRnzNfQhnCmEXbpqELr.GetCustomControllerLayoutId(name);
			}

			public IList<InputLayout> MapLayouts(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputLayout>.EmptyReadOnlyIListT;
				}
				switch (controllerType)
				{
				case ControllerType.Joystick:
					return JoystickLayouts;
				case ControllerType.Keyboard:
					return KeyboardLayouts;
				case ControllerType.Mouse:
					return MouseLayouts;
				case ControllerType.Custom:
					return CustomControllerLayouts;
				default:
					throw new NotImplementedException();
				}
			}

			public InputAction GetAction(int actionId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return NrWVrlwEDRnzNfQhnCmEXbpqELr.GetActionById(actionId);
			}

			public InputAction GetAction(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return NrWVrlwEDRnzNfQhnCmEXbpqELr.GetAction(name);
			}

			public int GetActionId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return NrWVrlwEDRnzNfQhnCmEXbpqELr.GetActionId(name);
			}

			public IEnumerable<InputAction> ActionsInCategory(string mapCategoryName)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return NrWVrlwEDRnzNfQhnCmEXbpqELr.bOufmmFjcvQxjzsprBazBUMMMgx(mapCategoryName, false);
			}

			public IEnumerable<InputAction> ActionsInCategory(string mapCategoryName, bool sort)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return NrWVrlwEDRnzNfQhnCmEXbpqELr.bOufmmFjcvQxjzsprBazBUMMMgx(mapCategoryName, sort);
			}

			public IEnumerable<InputAction> ActionsInCategory(int mapCategoryId)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return NrWVrlwEDRnzNfQhnCmEXbpqELr.bOufmmFjcvQxjzsprBazBUMMMgx(mapCategoryId, false);
			}

			public IEnumerable<InputAction> ActionsInCategory(int mapCategoryId, bool sort)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return NrWVrlwEDRnzNfQhnCmEXbpqELr.bOufmmFjcvQxjzsprBazBUMMMgx(mapCategoryId, sort);
			}

			public IEnumerable<InputAction> ActionsInCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return NrWVrlwEDRnzNfQhnCmEXbpqELr.wKLrKmkVBVKnSBlqcArVbRbNkwWq(tag);
			}

			public IEnumerable<InputAction> UserAssignableActionsInCategory(int mapCategoryId)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return NrWVrlwEDRnzNfQhnCmEXbpqELr.OXWMWqjANCeuPcmgxsxrtJEFSoh(mapCategoryId, false);
			}

			public IEnumerable<InputAction> UserAssignableActionsInCategory(int mapCategoryId, bool sort)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return NrWVrlwEDRnzNfQhnCmEXbpqELr.OXWMWqjANCeuPcmgxsxrtJEFSoh(mapCategoryId, sort);
			}

			public IEnumerable<InputAction> UserAssignableActionsInCategory(string mapCategoryName)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return NrWVrlwEDRnzNfQhnCmEXbpqELr.OXWMWqjANCeuPcmgxsxrtJEFSoh(mapCategoryName, false);
			}

			public IEnumerable<InputAction> UserAssignableActionsInCategory(string mapCategoryName, bool sort)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return NrWVrlwEDRnzNfQhnCmEXbpqELr.OXWMWqjANCeuPcmgxsxrtJEFSoh(mapCategoryName, sort);
			}

			public IList<InputBehavior> GetInputBehaviors(int playerId)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputBehavior>.EmptyReadOnlyIListT;
				}
				return akUdmKMbrqFLXkjqdKLUZOPTArx.SdbImvkWEfIudHcibMpfTKnAQlYO(playerId);
			}

			public IList<InputBehavior> GetSystemPlayerInputBehaviors()
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputBehavior>.EmptyReadOnlyIListT;
				}
				return akUdmKMbrqFLXkjqdKLUZOPTArx.SdbImvkWEfIudHcibMpfTKnAQlYO(9999999);
			}

			public InputBehavior GetInputBehavior(int playerId, int behaviorId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return akUdmKMbrqFLXkjqdKLUZOPTArx.TTAmgCjlFFXrThWPqNCvwWqLrMf(playerId, behaviorId);
			}

			public InputBehavior GetInputBehavior(int playerId, string behaviorName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return akUdmKMbrqFLXkjqdKLUZOPTArx.TTAmgCjlFFXrThWPqNCvwWqLrMf(playerId, behaviorName);
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
				return NrWVrlwEDRnzNfQhnCmEXbpqELr.GetInputBehaviorId(behaviorName);
			}

			internal InputBehavior LCBlTwSOZFBVudqRecZeDkCwyUh(int P_0)
			{
				return NrWVrlwEDRnzNfQhnCmEXbpqELr.GetInputBehaviorById(P_0);
			}

			internal InputBehavior LCBlTwSOZFBVudqRecZeDkCwyUh(string P_0)
			{
				return NrWVrlwEDRnzNfQhnCmEXbpqELr.GetInputBehavior(P_0);
			}

			public ControllerMap GetControllerMap(int id)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				IList<Player> allPlayers = players.AllPlayers;
				int num = 0;
				while (true)
				{
					int num2;
					int num3;
					if (num < allPlayers.Count)
					{
						num2 = 1712024321;
						num3 = num2;
					}
					else
					{
						num2 = 1712024322;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ 0x660B6B00)
						{
						case 3:
							num2 = 1712024321;
							continue;
						case 1:
						{
							ControllerMap map = allPlayers[num].controllers.maps.GetMap(id);
							if (map != null)
							{
								return map;
							}
							num++;
							num2 = 1712024320;
							continue;
						}
						case 0:
							break;
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
					return null;
				}
				IList<Player> allPlayers = players.AllPlayers;
				int num = 0;
				while (true)
				{
					switch (0x565BDEDF ^ 0x565BDEDD)
					{
					case 0:
						break;
					default:
					{
						using (IEnumerator<ControllerMap> enumerator = allPlayers[num].controllers.maps.GetAllMaps().GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								while (true)
								{
									ControllerMap current = enumerator.Current;
									if (current == null)
									{
										break;
									}
									ActionElementMap elementMap = current.GetElementMap(id);
									if (elementMap == null)
									{
										break;
									}
									ActionElementMap result = elementMap;
									int num2 = 1448861407;
									while (true)
									{
										switch (num2 ^ 0x565BDEDD)
										{
										case 0:
											num2 = 1448861404;
											continue;
										case 1:
											break;
										default:
											goto end_IL_0081;
										case 2:
											return result;
										}
										break;
									}
									continue;
									end_IL_0081:
									break;
								}
							}
						}
						num++;
						goto case 2;
					}
					case 2:
						if (num >= allPlayers.Count)
						{
							return null;
						}
						goto default;
					}
				}
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
				ControllerType type = controller.type;
				switch (type)
				{
				default:
					while (true)
					{
						switch (-804210604 ^ -804210603)
						{
						case 0:
							continue;
						case 1:
							if (type == ControllerType.Custom)
							{
								return GetCustomControllerMapInstance((CustomController)controller, mapCategoryId, layoutId);
							}
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
				}
			}

			public ControllerMap GetControllerMapInstance(Controller controller, string mapCategoryName, string layoutName)
			{
				if (!CheckInitialized())
				{
					goto IL_0007;
				}
				int mapCategoryId = default(int);
				int layoutId = default(int);
				int num;
				if (controller != null)
				{
					mapCategoryId = GetMapCategoryId(mapCategoryName);
					if (mapCategoryId < 0)
					{
						return null;
					}
					layoutId = GetLayoutId(controller.type, layoutName);
					num = 792413466;
				}
				else
				{
					num = 792413467;
				}
				goto IL_000c;
				IL_000c:
				while (true)
				{
					switch (num ^ 0x2F3B451B)
					{
					case 2:
						break;
					case 1:
						if (layoutId < 0)
						{
							goto IL_0031;
						}
						return GetControllerMapInstance(controller, mapCategoryId, layoutId);
					case 0:
						return null;
					case 4:
						return null;
					default:
						return null;
					}
					break;
					IL_0031:
					num = 792413464;
				}
				goto IL_0007;
				IL_0007:
				num = 792413471;
				goto IL_000c;
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
				Controller controller = akUdmKMbrqFLXkjqdKLUZOPTArx.lRKToUyChtEIyMHppndqwlmeZVh(controllerIdentifier);
				if (controller != null)
				{
					return GetControllerMapInstance(controller, mapCategoryId, layoutId);
				}
				ControllerType controllerType = controllerIdentifier.controllerType;
				while (true)
				{
					int num = -20837565;
					while (true)
					{
						switch (num ^ -20837568)
						{
						case 0:
							break;
						case 3:
							switch (controllerType)
							{
							default:
								num = -20837567;
								continue;
							case ControllerType.Joystick:
								break;
							case ControllerType.Keyboard:
								return GetKeyboardMapInstance(mapCategoryId, layoutId);
							case ControllerType.Mouse:
								return GetMouseMapInstance(mapCategoryId, layoutId);
							}
							goto default;
						case 1:
							if (controllerType != ControllerType.Custom)
							{
								num = -20837566;
								continue;
							}
							return GetCustomControllerMapInstance(controllerIdentifier, mapCategoryId, layoutId);
						default:
							return GetJoystickMapInstance(controllerIdentifier, mapCategoryId, layoutId);
						case 2:
							throw new NotImplementedException();
						}
						break;
					}
				}
			}

			public JoystickMap GetJoystickMapInstance(Joystick joystick, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				if (joystick == null)
				{
					return null;
				}
				JoystickMap joystickMap = NrWVrlwEDRnzNfQhnCmEXbpqELr.hMkypZTzfqeaSawZHpjeONQgshs(joystick, mapCategoryId, layoutId);
				if (joystickMap != null)
				{
					joystick.UdqTiJdOOubbIffCkHAnQYFKEiz(joystickMap);
				}
				return joystickMap;
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
					goto IL_0015;
				}
				int layoutId = GetLayoutId(ControllerType.Joystick, layoutName);
				int num;
				if (layoutId < 0)
				{
					num = -1064456879;
					goto IL_001a;
				}
				return GetJoystickMapInstance(joystick, mapCategoryId, layoutId);
				IL_001a:
				switch (num ^ -1064456877)
				{
				case 0:
					break;
				case 1:
					return null;
				default:
					return null;
				}
				goto IL_0015;
				IL_0015:
				num = -1064456878;
				goto IL_001a;
			}

			public JoystickMap GetJoystickMapInstance(Guid joystickTypeGuid, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					goto IL_0007;
				}
				int num4;
				if (!(joystickTypeGuid == Guid.Empty))
				{
					InputSource inputSourceType = hZJPCfIEEHEOdtoukvjGAEibgUIb.inputSourceType;
					HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager = OwRRKduusMuBHXVDcuLelTLPlsM.NmQvhsZTsJUUOTJuQxoZMWZoYzM(joystickTypeGuid, inputSourceType);
					if (hardwareJoystickMap_InputManager != null)
					{
						JoystickMap joystickMap = NrWVrlwEDRnzNfQhnCmEXbpqELr.IXQGteQrRsyvfPhwsbmlpoRVOZQ(hardwareJoystickMap_InputManager.hardwareMapIdentifier, mapCategoryId, layoutId);
						if (joystickMap != null)
						{
							joystickMap.controllerType = ControllerType.Joystick;
							HardwareControllerMap_Game hardwareControllerMap_Game = hardwareJoystickMap_InputManager.ToGameHardwareControllerMap();
							IEnumerator<ActionElementMap> enumerator = joystickMap.AllMaps.GetEnumerator();
							try
							{
								ActionElementMap current = default(ActionElementMap);
								while (true)
								{
									IL_00f6:
									int num;
									int num2;
									if (enumerator.MoveNext())
									{
										num = -1064222949;
										num2 = num;
									}
									else
									{
										num = -1064222950;
										num2 = num;
									}
									while (true)
									{
										switch (num ^ -1064222950)
										{
										case 3:
											num = -1064222949;
											continue;
										default:
											goto end_IL_00b5;
										case 1:
											current = enumerator.Current;
											num = -1064222952;
											continue;
										case 2:
											current.syoLKvwgLHlzNdcGEpvMJwQYhMw(joystickMap, hardwareControllerMap_Game);
											num = -1064222946;
											continue;
										case 4:
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
							finally
							{
								if (enumerator != null)
								{
									while (true)
									{
										IL_0116:
										int num3 = -1064222952;
										while (true)
										{
											switch (num3 ^ -1064222950)
											{
											case 0:
												break;
											default:
												goto end_IL_011b;
											case 2:
												goto IL_0134;
											case 1:
												goto end_IL_011b;
											}
											goto IL_0116;
											IL_0134:
											enumerator.Dispose();
											num3 = -1064222949;
											continue;
											end_IL_011b:
											break;
										}
										break;
									}
								}
							}
						}
						return joystickMap;
					}
					num4 = -1064222951;
				}
				else
				{
					num4 = -1064222950;
				}
				goto IL_000c;
				IL_000c:
				while (true)
				{
					switch (num4 ^ -1064222950)
					{
					case 2:
						break;
					case 3:
						goto IL_002d;
					case 0:
						return null;
					case 4:
						return null;
					default:
						return null;
					}
					break;
					IL_002d:
					Logger.LogError("No hardware map found.");
					num4 = -1064222949;
				}
				goto IL_0007;
				IL_0007:
				num4 = -1064222946;
				goto IL_000c;
			}

			public JoystickMap GetJoystickMapInstance(Guid joystickTypeGuid, string mapCategoryName, string layoutName)
			{
				if (!CheckInitialized())
				{
					goto IL_0007;
				}
				if (joystickTypeGuid == Guid.Empty)
				{
					return null;
				}
				int mapCategoryId = GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = GetLayoutId(ControllerType.Joystick, layoutName);
				int num = -1280747158;
				goto IL_000c;
				IL_000c:
				while (true)
				{
					switch (num ^ -1280747159)
					{
					case 2:
						break;
					case 1:
						return null;
					case 3:
						if (layoutId < 0)
						{
							goto IL_005c;
						}
						return GetJoystickMapInstance(joystickTypeGuid, mapCategoryId, layoutId);
					default:
						return null;
					}
					break;
					IL_005c:
					num = -1280747159;
				}
				goto IL_0007;
				IL_0007:
				num = -1280747160;
				goto IL_000c;
			}

			public JoystickMap GetJoystickMapInstance(ControllerIdentifier controllerIdentifier, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				if (controllerIdentifier.controllerType != ControllerType.Joystick)
				{
					return null;
				}
				if (akUdmKMbrqFLXkjqdKLUZOPTArx.lRKToUyChtEIyMHppndqwlmeZVh(controllerIdentifier) is Joystick joystick)
				{
					return GetJoystickMapInstance(joystick, mapCategoryId, layoutId);
				}
				return GetJoystickMapInstance(controllerIdentifier.hardwareTypeGuid, mapCategoryId, layoutId);
			}

			public JoystickMap GetJoystickMapInstance(ControllerIdentifier controllerIdentifier, string mapCategoryName, string layoutName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int mapCategoryId = GetMapCategoryId(mapCategoryName);
				while (true)
				{
					int num = -1886445692;
					while (true)
					{
						switch (num ^ -1886445690)
						{
						case 0:
							break;
						case 2:
						{
							if (mapCategoryId < 0)
							{
								return null;
							}
							int layoutId = GetLayoutId(ControllerType.Joystick, layoutName);
							if (layoutId < 0)
							{
								goto IL_0042;
							}
							return GetJoystickMapInstance(controllerIdentifier, mapCategoryId, layoutId);
						}
						default:
							return null;
						}
						break;
						IL_0042:
						num = -1886445689;
					}
				}
			}

			public KeyboardMap GetKeyboardMapInstance(int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				KeyboardMap keyboardMap = NrWVrlwEDRnzNfQhnCmEXbpqELr.FindKeyboardMap_Game(mapCategoryId, layoutId);
				if (keyboardMap != null)
				{
					controllers.Keyboard.UdqTiJdOOubbIffCkHAnQYFKEiz(keyboardMap);
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
				MouseMap mouseMap = NrWVrlwEDRnzNfQhnCmEXbpqELr.FindMouseMap_Game(mapCategoryId, layoutId);
				while (true)
				{
					int num = 368047459;
					while (true)
					{
						switch (num ^ 0x15EFF562)
						{
						case 2:
							break;
						case 1:
							if (mouseMap != null)
							{
								goto IL_0037;
							}
							goto default;
						default:
							return mouseMap;
						}
						break;
						IL_0037:
						controllers.Mouse.UdqTiJdOOubbIffCkHAnQYFKEiz(mouseMap);
						num = 368047458;
					}
				}
			}

			public MouseMap GetMouseMapInstance(string mapCategoryName, string layoutName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int mapCategoryId = GetMapCategoryId(mapCategoryName);
				while (true)
				{
					int num = 908123022;
					while (true)
					{
						switch (num ^ 0x3620DB8F)
						{
						case 3:
							break;
						case 1:
						{
							if (mapCategoryId < 0)
							{
								num = 908123023;
								continue;
							}
							int layoutId = GetLayoutId(ControllerType.Mouse, layoutName);
							if (layoutId < 0)
							{
								num = 908123021;
								continue;
							}
							return GetMouseMapInstance(mapCategoryId, layoutId);
						}
						case 0:
							return null;
						default:
							return null;
						}
						break;
					}
				}
			}

			public CustomControllerMap GetCustomControllerMapInstance(CustomController customController, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				CustomControllerMap customControllerMap = NrWVrlwEDRnzNfQhnCmEXbpqELr.QfrgqtjxgxKXOuevaNKXmvMWczo(customController.sourceControllerId, mapCategoryId, layoutId);
				if (customControllerMap != null)
				{
					customController.UdqTiJdOOubbIffCkHAnQYFKEiz(customControllerMap);
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
				while (true)
				{
					int num = -1061423976;
					while (true)
					{
						switch (num ^ -1061423975)
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
							return GetCustomControllerMapInstance(customController, mapCategoryId, layoutId);
						}
						default:
							return null;
						}
						break;
						IL_0043:
						num = -1061423973;
					}
				}
			}

			public CustomControllerMap GetCustomControllerMapInstance(ControllerIdentifier controllerIdentifier, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				if (controllerIdentifier.controllerType != ControllerType.Custom)
				{
					goto IL_0014;
				}
				if (akUdmKMbrqFLXkjqdKLUZOPTArx.lRKToUyChtEIyMHppndqwlmeZVh(controllerIdentifier) is CustomController customController)
				{
					return GetCustomControllerMapInstance(customController, mapCategoryId, layoutId);
				}
				if (controllerIdentifier.hardwareTypeGuid == Guid.Empty)
				{
					return null;
				}
				CustomController_Editor customControllerByHardwareTypeGuid = NrWVrlwEDRnzNfQhnCmEXbpqELr.GetCustomControllerByHardwareTypeGuid(controllerIdentifier.hardwareTypeGuid);
				int num;
				CustomControllerMap customControllerMap = default(CustomControllerMap);
				if (customControllerByHardwareTypeGuid == null)
				{
					num = 1198981575;
				}
				else
				{
					customControllerMap = NrWVrlwEDRnzNfQhnCmEXbpqELr.QfrgqtjxgxKXOuevaNKXmvMWczo(controllerIdentifier.hardwareTypeGuid, mapCategoryId, layoutId);
					num = 1198981573;
				}
				goto IL_0019;
				IL_0014:
				num = 1198981568;
				goto IL_0019;
				IL_0019:
				HardwareControllerMap_Game hardwareControllerMap_Game = default(HardwareControllerMap_Game);
				while (true)
				{
					switch (num ^ 0x477701C4)
					{
					case 0:
						break;
					case 4:
						return null;
					case 3:
						return null;
					case 1:
						if (customControllerMap != null)
						{
							goto IL_00b5;
						}
						goto IL_013a;
					default:
						{
							if (hardwareControllerMap_Game == null)
							{
								Logger.LogError("No hardware map found.");
								return null;
							}
							customControllerMap.controllerType = ControllerType.Custom;
							using (IEnumerator<ActionElementMap> enumerator = customControllerMap.AllMaps.GetEnumerator())
							{
								while (enumerator.MoveNext())
								{
									while (true)
									{
										ActionElementMap current = enumerator.Current;
										current.syoLKvwgLHlzNdcGEpvMJwQYhMw(customControllerMap, hardwareControllerMap_Game);
										int num2 = 1198981574;
										while (true)
										{
											switch (num2 ^ 0x477701C4)
											{
											case 0:
												num2 = 1198981573;
												continue;
											case 1:
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
							goto IL_013a;
						}
						IL_013a:
						return customControllerMap;
					}
					break;
					IL_00b5:
					hardwareControllerMap_Game = customControllerByHardwareTypeGuid.YucBUGhcNFqNsPLYijVdDVqvADJR();
					num = 1198981574;
				}
				goto IL_0014;
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
					return null;
				}
				ControllerMap controllerMap = null;
				IControllerMapStore controllerMapStore = userDataStore as IControllerMapStore;
				while (true)
				{
					int num = 1933086222;
					while (true)
					{
						switch (num ^ 0x73388E0C)
						{
						case 6:
							break;
						case 1:
							controller.UdqTiJdOOubbIffCkHAnQYFKEiz(controllerMap);
							num = 1933086216;
							continue;
						case 5:
							controllerMap = controllerMapStore.LoadControllerMap(playerId, controller.identifier, mapCategoryId, layoutId);
							num = 1933086220;
							continue;
						case 0:
							if (controllerMap == null)
							{
								controllerMap = NrWVrlwEDRnzNfQhnCmEXbpqELr.YfrotiMuknQjHOeFlUzPLpOYrQj(controller, mapCategoryId, layoutId);
								num = 1933086223;
								continue;
							}
							goto case 3;
						case 2:
						{
							int num2;
							if (controllerMapStore != null)
							{
								num = 1933086217;
								num2 = num;
							}
							else
							{
								num = 1933086220;
								num2 = num;
							}
							continue;
						}
						case 3:
							if (controllerMap != null)
							{
								Player player = players.GetPlayer(playerId);
								if (player != null)
								{
									player.controllers.maps.UdqTiJdOOubbIffCkHAnQYFKEiz(controller, controllerMap);
									num = 1933086216;
									continue;
								}
								goto case 1;
							}
							goto default;
						default:
							return controllerMap;
						}
						break;
					}
				}
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
				while (true)
				{
					int num = 2038538523;
					while (true)
					{
						switch (num ^ 0x7981A11A)
						{
						case 2:
							break;
						case 1:
						{
							if (mapCategoryId < 0)
							{
								return null;
							}
							int layoutId = GetLayoutId(controller.type, layoutName);
							if (layoutId < 0)
							{
								goto IL_004d;
							}
							return GetControllerMapInstanceSavedOrDefault(playerId, controller, mapCategoryId, layoutId);
						}
						default:
							return null;
						}
						break;
						IL_004d:
						num = 2038538522;
					}
				}
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

			public ControllerMap GetControllerMapInstanceSavedOrDefault(int playerId, ControllerIdentifier controllerIdentifier, string mapCategoryName, string layoutName)
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
				return GetControllerMapInstanceSavedOrDefault(playerId, controllerIdentifier, mapCategoryId, layoutId);
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
					goto IL_0007;
				}
				int mapCategoryId = GetMapCategoryId(mapCategoryName);
				int num;
				int layoutId = default(int);
				if (mapCategoryId < 0)
				{
					num = 134452238;
				}
				else
				{
					layoutId = GetLayoutId(ControllerType.Joystick, layoutName);
					num = 134452239;
				}
				goto IL_000c;
				IL_0007:
				num = 134452237;
				goto IL_000c;
				IL_000c:
				switch (num ^ 0x803940C)
				{
				case 0:
					break;
				case 1:
					return null;
				case 2:
					return null;
				default:
					if (layoutId < 0)
					{
						return null;
					}
					return GetJoystickMapInstanceSavedOrDefault(playerId, joystick, mapCategoryId, layoutId);
				}
				goto IL_0007;
			}

			public JoystickMap GetJoystickMapInstanceSavedOrDefault(int playerId, ControllerIdentifier controllerIdentifier, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				Joystick joystick = akUdmKMbrqFLXkjqdKLUZOPTArx.lRKToUyChtEIyMHppndqwlmeZVh(controllerIdentifier) as Joystick;
				if (joystick != null)
				{
					goto IL_001e;
				}
				InputSource inputSourceType = hZJPCfIEEHEOdtoukvjGAEibgUIb.inputSourceType;
				HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager = OwRRKduusMuBHXVDcuLelTLPlsM.NmQvhsZTsJUUOTJuQxoZMWZoYzM(controllerIdentifier.hardwareTypeGuid, inputSourceType);
				if (hardwareJoystickMap_InputManager == null)
				{
					Logger.LogError("No hardware map found.");
					return null;
				}
				JoystickMap joystickMap = null;
				IControllerMapStore controllerMapStore = userDataStore as IControllerMapStore;
				int num;
				int num2;
				if (controllerMapStore != null)
				{
					num = 1143805937;
					num2 = num;
				}
				else
				{
					num = 1143805940;
					num2 = num;
				}
				goto IL_0023;
				IL_001e:
				num = 1143805939;
				goto IL_0023;
				IL_0023:
				ActionElementMap current = default(ActionElementMap);
				while (true)
				{
					switch (num ^ 0x442D17F0)
					{
					case 6:
						break;
					case 3:
						return GetJoystickMapInstanceSavedOrDefault(playerId, joystick, mapCategoryId, layoutId);
					case 5:
						joystickMap.playerId = playerId;
						num = 1143805936;
						continue;
					case 4:
					{
						int num7;
						if (joystickMap != null)
						{
							num = 1143805943;
							num7 = num;
						}
						else
						{
							num = 1143805938;
							num7 = num;
						}
						continue;
					}
					case 7:
						if (joystickMap != null)
						{
							joystickMap.controllerType = ControllerType.Joystick;
							int num6;
							if (players.GetPlayer(playerId) == null)
							{
								num = 1143805936;
								num6 = num;
							}
							else
							{
								num = 1143805941;
								num6 = num;
							}
							continue;
						}
						goto IL_01ed;
					case 1:
						joystickMap = controllerMapStore.LoadControllerMap(playerId, controllerIdentifier, mapCategoryId, layoutId) as JoystickMap;
						num = 1143805940;
						continue;
					case 2:
						joystickMap = NrWVrlwEDRnzNfQhnCmEXbpqELr.IXQGteQrRsyvfPhwsbmlpoRVOZQ(hardwareJoystickMap_InputManager.hardwareMapIdentifier, mapCategoryId, layoutId);
						num = 1143805943;
						continue;
					default:
						{
							HardwareControllerMap_Game hardwareControllerMap_Game = hardwareJoystickMap_InputManager.ToGameHardwareControllerMap();
							IEnumerator<ActionElementMap> enumerator = joystickMap.AllMaps.GetEnumerator();
							try
							{
								while (true)
								{
									IL_018f:
									int num3;
									int num4;
									if (enumerator.MoveNext())
									{
										num3 = 1143805940;
										num4 = num3;
									}
									else
									{
										num3 = 1143805937;
										num4 = num3;
									}
									while (true)
									{
										switch (num3 ^ 0x442D17F0)
										{
										case 2:
											num3 = 1143805940;
											continue;
										default:
											goto end_IL_015e;
										case 4:
											current = enumerator.Current;
											num3 = 1143805936;
											continue;
										case 3:
											break;
										case 0:
											current.syoLKvwgLHlzNdcGEpvMJwQYhMw(joystickMap, hardwareControllerMap_Game);
											num3 = 1143805939;
											continue;
										case 1:
											goto end_IL_015e;
										}
										goto IL_018f;
										continue;
										end_IL_015e:
										break;
									}
									break;
								}
							}
							finally
							{
								if (enumerator != null)
								{
									while (true)
									{
										IL_01c0:
										int num5 = 1143805937;
										while (true)
										{
											switch (num5 ^ 0x442D17F0)
											{
											case 0:
												break;
											default:
												goto end_IL_01c5;
											case 1:
												goto IL_01de;
											case 2:
												goto end_IL_01c5;
											}
											goto IL_01c0;
											IL_01de:
											enumerator.Dispose();
											num5 = 1143805938;
											continue;
											end_IL_01c5:
											break;
										}
										break;
									}
								}
							}
							goto IL_01ed;
						}
						IL_01ed:
						return joystickMap;
					}
					break;
				}
				goto IL_001e;
			}

			public JoystickMap GetJoystickMapInstanceSavedOrDefault(int playerId, ControllerIdentifier controllerIdentifier, string mapCategoryName, string layoutName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int mapCategoryId = GetMapCategoryId(mapCategoryName);
				int layoutId = default(int);
				while (true)
				{
					int num = 1626055321;
					while (true)
					{
						switch (num ^ 0x60EBA298)
						{
						case 2:
							break;
						case 1:
							if (mapCategoryId < 0)
							{
								num = 1626055323;
								continue;
							}
							layoutId = GetLayoutId(ControllerType.Joystick, layoutName);
							num = 1626055320;
							continue;
						case 3:
							return null;
						default:
							if (layoutId < 0)
							{
								return null;
							}
							return GetJoystickMapInstanceSavedOrDefault(playerId, controllerIdentifier, mapCategoryId, layoutId);
						}
						break;
					}
				}
			}

			public CustomControllerMap GetCustomControllerMapInstanceSavedOrDefault(int playerId, CustomController customController, int mapCategoryId, int layoutId)
			{
				return GetControllerMapInstanceSavedOrDefault(playerId, customController, mapCategoryId, layoutId) as CustomControllerMap;
			}

			public CustomControllerMap GetCustomControllerMapInstanceSavedOrDefault(int playerId, CustomController customController, string mapCategoryName, string layoutName)
			{
				if (!CheckInitialized())
				{
					goto IL_0007;
				}
				int mapCategoryId = GetMapCategoryId(mapCategoryName);
				int num;
				if (mapCategoryId < 0)
				{
					num = -1210686339;
					goto IL_000c;
				}
				int layoutId = GetLayoutId(ControllerType.Custom, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return GetCustomControllerMapInstanceSavedOrDefault(playerId, customController, mapCategoryId, layoutId);
				IL_000c:
				switch (num ^ -1210686339)
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
				num = -1210686340;
				goto IL_000c;
			}

			public CustomControllerMap GetCustomControllerMapInstanceSavedOrDefault(int playerId, ControllerIdentifier controllerIdentifier, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				if (akUdmKMbrqFLXkjqdKLUZOPTArx.lRKToUyChtEIyMHppndqwlmeZVh(controllerIdentifier) is CustomController customController)
				{
					return GetCustomControllerMapInstanceSavedOrDefault(playerId, customController, mapCategoryId, layoutId);
				}
				CustomController_Editor customControllerByHardwareTypeGuid = NrWVrlwEDRnzNfQhnCmEXbpqELr.GetCustomControllerByHardwareTypeGuid(controllerIdentifier.hardwareTypeGuid);
				if (customControllerByHardwareTypeGuid == null)
				{
					goto IL_003f;
				}
				CustomControllerMap customControllerMap = null;
				int num = 1615409280;
				goto IL_0044;
				IL_003f:
				num = 1615409284;
				goto IL_0044;
				IL_0044:
				HardwareControllerMap_Game hardwareControllerMap_Game = default(HardwareControllerMap_Game);
				IControllerMapStore controllerMapStore = default(IControllerMapStore);
				while (true)
				{
					switch (num ^ 0x60493083)
					{
					case 9:
						break;
					case 7:
						return null;
					case 1:
						if (customControllerMap != null)
						{
							num = 1615409285;
							continue;
						}
						goto IL_01c5;
					case 6:
						hardwareControllerMap_Game = customControllerByHardwareTypeGuid.YucBUGhcNFqNsPLYijVdDVqvADJR();
						if (hardwareControllerMap_Game == null)
						{
							Logger.LogError("No hardware map found.");
							return null;
						}
						customControllerMap.controllerType = ControllerType.Custom;
						num = 1615409287;
						continue;
					case 2:
						if (controllerMapStore != null)
						{
							customControllerMap = controllerMapStore.LoadControllerMap(playerId, controllerIdentifier, mapCategoryId, layoutId) as CustomControllerMap;
							num = 1615409286;
							continue;
						}
						goto case 5;
					case 5:
						if (customControllerMap == null)
						{
							customControllerMap = NrWVrlwEDRnzNfQhnCmEXbpqELr.QfrgqtjxgxKXOuevaNKXmvMWczo(controllerIdentifier.hardwareTypeGuid, mapCategoryId, layoutId);
							num = 1615409282;
							continue;
						}
						goto case 1;
					case 4:
					{
						int num4;
						if (players.GetPlayer(playerId) != null)
						{
							num = 1615409291;
							num4 = num;
						}
						else
						{
							num = 1615409283;
							num4 = num;
						}
						continue;
					}
					case 3:
						controllerMapStore = userDataStore as IControllerMapStore;
						num = 1615409281;
						continue;
					case 8:
						customControllerMap.playerId = playerId;
						num = 1615409283;
						continue;
					default:
						{
							IEnumerator<ActionElementMap> enumerator = customControllerMap.AllMaps.GetEnumerator();
							try
							{
								while (enumerator.MoveNext())
								{
									while (true)
									{
										ActionElementMap current = enumerator.Current;
										current.syoLKvwgLHlzNdcGEpvMJwQYhMw(customControllerMap, hardwareControllerMap_Game);
										int num2 = 1615409282;
										while (true)
										{
											switch (num2 ^ 0x60493083)
											{
											case 0:
												num2 = 1615409281;
												continue;
											case 2:
												break;
											default:
												goto end_IL_016f;
											}
											break;
										}
										continue;
										end_IL_016f:
										break;
									}
								}
							}
							finally
							{
								if (enumerator != null)
								{
									while (true)
									{
										IL_0198:
										int num3 = 1615409281;
										while (true)
										{
											switch (num3 ^ 0x60493083)
											{
											case 0:
												break;
											default:
												goto end_IL_019d;
											case 2:
												goto IL_01b6;
											case 1:
												goto end_IL_019d;
											}
											goto IL_0198;
											IL_01b6:
											enumerator.Dispose();
											num3 = 1615409282;
											continue;
											end_IL_019d:
											break;
										}
										break;
									}
								}
							}
							goto IL_01c5;
						}
						IL_01c5:
						return customControllerMap;
					}
					break;
				}
				goto IL_003f;
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
					int num = -146528574;
					while (true)
					{
						switch (num ^ -146528576)
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
							return GetCustomControllerMapInstanceSavedOrDefault(playerId, controllerIdentifier, mapCategoryId, layoutId);
						}
						break;
						IL_0035:
						layoutId = GetLayoutId(ControllerType.Custom, layoutName);
						num = -146528575;
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
				Player player = default(Player);
				while (true)
				{
					int num = -246220240;
					while (true)
					{
						switch (num ^ -246220236)
						{
						case 0:
							break;
						case 4:
							if (userDataStore is IControllerMapStore controllerMapStore)
							{
								keyboardMap = controllerMapStore.LoadControllerMap(playerId, keyboard.identifier, mapCategoryId, layoutId) as KeyboardMap;
								num = -246220235;
								continue;
							}
							goto case 1;
						case 2:
							keyboard.UdqTiJdOOubbIffCkHAnQYFKEiz(keyboardMap);
							num = -246220233;
							continue;
						case 1:
							if (keyboardMap == null)
							{
								keyboardMap = NrWVrlwEDRnzNfQhnCmEXbpqELr.FindKeyboardMap_Game(mapCategoryId, layoutId);
								num = -246220238;
								continue;
							}
							goto case 6;
						case 7:
						{
							player = players.GetPlayer(playerId);
							int num2;
							if (player == null)
							{
								num = -246220234;
								num2 = num;
							}
							else
							{
								num = -246220239;
								num2 = num;
							}
							continue;
						}
						case 6:
						{
							int num3;
							if (keyboardMap != null)
							{
								num = -246220237;
								num3 = num;
							}
							else
							{
								num = -246220233;
								num3 = num;
							}
							continue;
						}
						case 5:
							player.controllers.maps.UdqTiJdOOubbIffCkHAnQYFKEiz(keyboard, keyboardMap);
							num = -246220233;
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
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = GetLayoutId(ControllerType.Keyboard, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return GetKeyboardMapInstanceSavedOrDefault(playerId, mapCategoryId, layoutId);
			}

			public MouseMap GetMouseMapInstanceSavedOrDefault(int playerId, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				Controller mouse = controllers.Mouse;
				MouseMap mouseMap = null;
				Player player = default(Player);
				IControllerMapStore controllerMapStore = default(IControllerMapStore);
				while (true)
				{
					int num = 657071351;
					while (true)
					{
						switch (num ^ 0x272A1CF3)
						{
						case 7:
							break;
						case 2:
							player.controllers.maps.UdqTiJdOOubbIffCkHAnQYFKEiz(mouse, mouseMap);
							num = 657071349;
							continue;
						case 5:
							mouse.UdqTiJdOOubbIffCkHAnQYFKEiz(mouseMap);
							num = 657071349;
							continue;
						case 0:
							if (mouseMap == null)
							{
								mouseMap = NrWVrlwEDRnzNfQhnCmEXbpqELr.FindMouseMap_Game(mapCategoryId, layoutId);
								num = 657071346;
								continue;
							}
							goto case 1;
						case 1:
							if (mouseMap != null)
							{
								player = players.GetPlayer(playerId);
								int num3;
								if (player != null)
								{
									num = 657071345;
									num3 = num;
								}
								else
								{
									num = 657071350;
									num3 = num;
								}
								continue;
							}
							goto default;
						case 4:
						{
							controllerMapStore = userDataStore as IControllerMapStore;
							int num2;
							if (controllerMapStore != null)
							{
								num = 657071344;
								num2 = num;
							}
							else
							{
								num = 657071347;
								num2 = num;
							}
							continue;
						}
						case 3:
							mouseMap = controllerMapStore.LoadControllerMap(playerId, mouse.identifier, mapCategoryId, layoutId) as MouseMap;
							num = 657071347;
							continue;
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
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = GetLayoutId(ControllerType.Mouse, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return GetMouseMapInstanceSavedOrDefault(playerId, mapCategoryId, layoutId);
			}

			[Obsolete("This method has been deprecated. Use the Controller Template system instead.", false)]
			public ControllerElementIdentifier GetFirstJoystickTemplateElementIdentifier(Joystick joystick, int joystickElementIdentifierId)
			{
				if (!CheckInitialized())
				{
					goto IL_0007;
				}
				int num;
				if (joystick == null)
				{
					num = -863318190;
					goto IL_000c;
				}
				return hddxNZjlOmDfwuLplaUiGenVzbH(joystick.hardwareTypeGuid, joystickElementIdentifierId);
				IL_0007:
				num = -863318191;
				goto IL_000c;
				IL_000c:
				switch (num ^ -863318192)
				{
				case 0:
					break;
				case 1:
					return null;
				default:
					return null;
				}
				goto IL_0007;
			}

			private ControllerElementIdentifier hddxNZjlOmDfwuLplaUiGenVzbH(Guid P_0, int P_1)
			{
				return OwRRKduusMuBHXVDcuLelTLPlsM.hddxNZjlOmDfwuLplaUiGenVzbH(P_0, P_1)?.ToControllerElementIdentifier();
			}

			public ControllerTemplateMap GetControllerTemplateMapInstance(Guid templateTypeGuid, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return NrWVrlwEDRnzNfQhnCmEXbpqELr.mlBpSGJBbWVCabYZEUfNXwmmhML(templateTypeGuid, mapCategoryId, layoutId);
			}

			public ControllerTemplateMap GetControllerTemplateMapInstance(Guid templateTypeGuid, string mapCategoryName, string layoutName)
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
				return GetControllerTemplateMapInstance(templateTypeGuid, mapCategoryId, layoutId);
			}

			public ControllerMapLayoutManager.RuleSet GetControllerMapLayoutManagerRuleSetInstance(int id)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return NrWVrlwEDRnzNfQhnCmEXbpqELr.GetControllerMapLayoutManagerRuleSetById(id)?.ToRuntime();
			}

			public ControllerMapLayoutManager.RuleSet GetControllerMapLayoutManagerRuleSetInstance(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int controllerMapLayoutManagerRuleSetId = NrWVrlwEDRnzNfQhnCmEXbpqELr.GetControllerMapLayoutManagerRuleSetId(name);
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
					goto IL_0007;
				}
				ControllerMapEnabler_RuleSet_Editor controllerMapEnablerRuleSetById = NrWVrlwEDRnzNfQhnCmEXbpqELr.GetControllerMapEnablerRuleSetById(id);
				int num = 793201263;
				goto IL_000c;
				IL_000c:
				switch (num ^ 0x2F474A6E)
				{
				case 0:
					break;
				case 2:
					return null;
				default:
					return controllerMapEnablerRuleSetById?.ToRuntime();
				}
				goto IL_0007;
				IL_0007:
				num = 793201260;
				goto IL_000c;
			}

			public ControllerMapEnabler.RuleSet GetControllerMapEnablerRuleSetInstance(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int controllerMapEnablerRuleSetId = NrWVrlwEDRnzNfQhnCmEXbpqELr.GetControllerMapEnablerRuleSetId(name);
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
			private static PlayerHelper ilVQEiENSgAnwgRreWwIUWTqyneQ;

			internal static PlayerHelper Instance => ilVQEiENSgAnwgRreWwIUWTqyneQ ?? (ilVQEiENSgAnwgRreWwIUWTqyneQ = new PlayerHelper());

			public int playerCount
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0;
					}
					return WhcqAfYYqNfRCEGkYApjWYGKVjr.gamePlayerCount;
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
					return WhcqAfYYqNfRCEGkYApjWYGKVjr.allPlayerCount;
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
					return WhcqAfYYqNfRCEGkYApjWYGKVjr.Players_readOnly;
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
					return WhcqAfYYqNfRCEGkYApjWYGKVjr.AllPlayers_readOnly;
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
					return WhcqAfYYqNfRCEGkYApjWYGKVjr.SJbqFeuTGPOUMrjgHHxfbLJovAZ();
				}
			}

			private PlayerHelper()
			{
			}

			public IList<Player> GetPlayers(bool includeSystemPlayer = false)
			{
				if (!CheckInitialized())
				{
					goto IL_0007;
				}
				int num;
				if (!includeSystemPlayer)
				{
					num = 335837780;
					goto IL_000c;
				}
				return WhcqAfYYqNfRCEGkYApjWYGKVjr.AllPlayers_readOnly;
				IL_0007:
				num = 335837781;
				goto IL_000c;
				IL_000c:
				switch (num ^ 0x14047A54)
				{
				case 2:
					break;
				case 1:
					return EmptyObjects<Player>.EmptyReadOnlyIListT;
				default:
					return WhcqAfYYqNfRCEGkYApjWYGKVjr.Players_readOnly;
				}
				goto IL_0007;
			}

			public Player GetPlayer(int playerId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return WhcqAfYYqNfRCEGkYApjWYGKVjr.LwwGNDEKhVGiAVsVapAOKLGgPGB(playerId);
			}

			public Player GetPlayer(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return WhcqAfYYqNfRCEGkYApjWYGKVjr.LwwGNDEKhVGiAVsVapAOKLGgPGB(name);
			}

			public Player GetSystemPlayer()
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return WhcqAfYYqNfRCEGkYApjWYGKVjr.SJbqFeuTGPOUMrjgHHxfbLJovAZ();
			}

			public int GetPlayerId(string playerName)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return WhcqAfYYqNfRCEGkYApjWYGKVjr.qSEOrEDcNqVnzNvwEWwOHIpkHbA(playerName);
			}

			public string[] GetPlayerNames(bool includeSystemPlayer = false)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return WhcqAfYYqNfRCEGkYApjWYGKVjr.jOrfQfojbAHbmHjpgeiwpmTrtHSJ(includeSystemPlayer);
			}

			public string[] GetPlayerDescriptiveNames(bool includeSystemPlayer = false)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return WhcqAfYYqNfRCEGkYApjWYGKVjr.lJqTfOWvHvWdpYHOOvDXEDLIHwt(includeSystemPlayer);
			}

			public int[] GetPlayerIds(bool includeSystemPlayer = false)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<int>.array;
				}
				return WhcqAfYYqNfRCEGkYApjWYGKVjr.frvGAVyFEksoXubEPwACMkmjoXL(includeSystemPlayer);
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class TimeHelper : CodeHelper
		{
			private static TimeHelper ilVQEiENSgAnwgRreWwIUWTqyneQ;

			internal static TimeHelper Instance => ilVQEiENSgAnwgRreWwIUWTqyneQ ?? (ilVQEiENSgAnwgRreWwIUWTqyneQ = new TimeHelper());

			public float unscaledDeltaTime
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0f;
					}
					return (float)zihLSZWgVImbQKlwMGYqfGJsEDS.unscaledDeltaTime;
				}
			}

			public double unscaledTime
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0.0;
					}
					return zihLSZWgVImbQKlwMGYqfGJsEDS.unscaledTime;
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
					return zihLSZWgVImbQKlwMGYqfGJsEDS.frame;
				}
			}

			private TimeHelper()
			{
			}
		}

		private class AgfHMtRduofcPgMWADlTmdpvlaMG
		{
			private class FQoCMrfXqerYuMpGNLREwZVbNdY
			{
				public readonly UpdateLoopType cmiDdQAFcgEckBbjnNTFEbMKLqrn;

				private double kPcECEntishmGKJfubVhUXmQHws;

				private double mrsJkAGXuIWvwvBssANVmjKnJUh;

				private double RsvJXtZKfDCUPOixtNBmDnRVdUu;

				private double eDxFVIHfMFaPoSIOHceKgItescfy;

				private uint cdygjBYOyAoVcUsoTCeYhFAJdnKX;

				private uint hKTpQszNJhkkkXRvmcMjRPJtGitF;

				private float GDWDtjwLVqMjXRAtfboybTIAjqAG;

				private float dIiTvXhJXOrFHUoBdfImiiufbroO;

				public double unscaledTime => kPcECEntishmGKJfubVhUXmQHws;

				public double unscaledTimePrev => mrsJkAGXuIWvwvBssANVmjKnJUh;

				public double unscaledDeltaTime => RsvJXtZKfDCUPOixtNBmDnRVdUu;

				public uint frame => cdygjBYOyAoVcUsoTCeYhFAJdnKX;

				public uint framePrev => hKTpQszNJhkkkXRvmcMjRPJtGitF;

				public float unityUnscaledDeltaTime => GDWDtjwLVqMjXRAtfboybTIAjqAG;

				public float unityUnscaledDeltaTimePrev => dIiTvXhJXOrFHUoBdfImiiufbroO;

				public FQoCMrfXqerYuMpGNLREwZVbNdY(UpdateLoopType updateLoop)
				{
					cmiDdQAFcgEckBbjnNTFEbMKLqrn = updateLoop;
					eDxFVIHfMFaPoSIOHceKgItescfy = Time.realtimeSinceStartup;
					cdygjBYOyAoVcUsoTCeYhFAJdnKX = 0u;
				}

				public void GzCliicOSMFLMvKajLgvnmGSSrh()
				{
					mrsJkAGXuIWvwvBssANVmjKnJUh = kPcECEntishmGKJfubVhUXmQHws;
					kPcECEntishmGKJfubVhUXmQHws = ReInput.realTime;
					while (true)
					{
						int num = 1297423272;
						while (true)
						{
							switch (num ^ 0x4D551BAB)
							{
							case 4:
								break;
							case 3:
								if (eDxFVIHfMFaPoSIOHceKgItescfy > kPcECEntishmGKJfubVhUXmQHws)
								{
									eDxFVIHfMFaPoSIOHceKgItescfy = 0.0;
									num = 1297423273;
									continue;
								}
								goto case 2;
							case 1:
								dIiTvXhJXOrFHUoBdfImiiufbroO = GDWDtjwLVqMjXRAtfboybTIAjqAG;
								GDWDtjwLVqMjXRAtfboybTIAjqAG = kexzTXbUFjefXrabyjYIBwEspvbK();
								previousFrame = hKTpQszNJhkkkXRvmcMjRPJtGitF;
								currentFrame = cdygjBYOyAoVcUsoTCeYhFAJdnKX;
								ReInput.unscaledTime = kPcECEntishmGKJfubVhUXmQHws;
								num = 1297423275;
								continue;
							case 2:
								RsvJXtZKfDCUPOixtNBmDnRVdUu = kPcECEntishmGKJfubVhUXmQHws - eDxFVIHfMFaPoSIOHceKgItescfy;
								eDxFVIHfMFaPoSIOHceKgItescfy = kPcECEntishmGKJfubVhUXmQHws;
								hKTpQszNJhkkkXRvmcMjRPJtGitF = cdygjBYOyAoVcUsoTCeYhFAJdnKX;
								cdygjBYOyAoVcUsoTCeYhFAJdnKX = MiscTools.Tick(cdygjBYOyAoVcUsoTCeYhFAJdnKX);
								num = 1297423274;
								continue;
							default:
								ReInput.unscaledTimePrev = mrsJkAGXuIWvwvBssANVmjKnJUh;
								ReInput.unscaledDeltaTime = RsvJXtZKfDCUPOixtNBmDnRVdUu;
								return;
							}
							break;
						}
					}
				}
			}

			private static class rfxBpPqkgBPUYJsAiVWHTOWLQzH
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

				public static StopwatchBase GIHuiEkmFihgdjpqkqIhwXanlmm()
				{
					if (!UnityTools.isEditor && UnityTools.platform == Platform.XboxOne)
					{
						return new UnityStopwatch();
					}
					return new Rewired.Utils.Classes.Utility.Stopwatch();
				}

				public static StopwatchBase ekXLozARNCAVXCCzqEkFsmITtNj()
				{
					if (!UnityTools.isEditor && UnityTools.platform == Platform.XboxOne)
					{
						return UnityStopwatch.StartNew();
					}
					return Rewired.Utils.Classes.Utility.Stopwatch.StartNew();
				}
			}

			private StopwatchBase WRTfPTSvUGeZlETUyGwPEpBeedQO;

			private double PsyBkiDadiWmEUQjQoHsqgMWQIye;

			private FQoCMrfXqerYuMpGNLREwZVbNdY xJelxxARcpUqLbOKEfSvpSFNBVn;

			private ADictionary<int, FQoCMrfXqerYuMpGNLREwZVbNdY> OAbghxIAVNubiPuQKdWEVeNFqZh;

			private uint tvASNbDlSCfucjVleflZGkhiFKZP;

			public double unscaledTime => xJelxxARcpUqLbOKEfSvpSFNBVn.unscaledTime;

			public double unscaledTimePrev => xJelxxARcpUqLbOKEfSvpSFNBVn.unscaledTimePrev;

			public double unscaledDeltaTime => xJelxxARcpUqLbOKEfSvpSFNBVn.unscaledDeltaTime;

			public float unityUnscaledDeltaTime => xJelxxARcpUqLbOKEfSvpSFNBVn.unityUnscaledDeltaTime;

			public float unityUnscaledDeltaTimePrev => xJelxxARcpUqLbOKEfSvpSFNBVn.unityUnscaledDeltaTimePrev;

			internal double realTime => WRTfPTSvUGeZlETUyGwPEpBeedQO.elapsedSeconds + PsyBkiDadiWmEUQjQoHsqgMWQIye;

			public uint frame => xJelxxARcpUqLbOKEfSvpSFNBVn.frame;

			public uint framePrev => xJelxxARcpUqLbOKEfSvpSFNBVn.framePrev;

			public uint absFrame => tvASNbDlSCfucjVleflZGkhiFKZP;

			public AgfHMtRduofcPgMWADlTmdpvlaMG()
			{
				while (true)
				{
					int num = -338418219;
					while (true)
					{
						switch (num ^ -338418217)
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
						WRTfPTSvUGeZlETUyGwPEpBeedQO = rfxBpPqkgBPUYJsAiVWHTOWLQzH.Global;
						CHWDoIJFbUPiCCQqjvBLnPoSWjTy();
						num = -338418218;
					}
				}
			}

			public void IOYlMWjyaBwKFkouFERJLnmbGOa()
			{
				PsyBkiDadiWmEUQjQoHsqgMWQIye = Time.realtimeSinceStartup;
			}

			public void CHWDoIJFbUPiCCQqjvBLnPoSWjTy()
			{
				xJelxxARcpUqLbOKEfSvpSFNBVn = null;
				OAbghxIAVNubiPuQKdWEVeNFqZh = new ADictionary<int, FQoCMrfXqerYuMpGNLREwZVbNdY>();
				using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
				{
					List<UpdateLoopType> list = tList.list;
					int num2 = default(int);
					while (true)
					{
						int num = -1860592013;
						while (true)
						{
							switch (num ^ -1860592011)
							{
							case 0:
								break;
							default:
								return;
							case 1:
							{
								FQoCMrfXqerYuMpGNLREwZVbNdY value = new FQoCMrfXqerYuMpGNLREwZVbNdY(list[num2]);
								OAbghxIAVNubiPuQKdWEVeNFqZh.Add((int)list[num2], value);
								if (xJelxxARcpUqLbOKEfSvpSFNBVn == null)
								{
									xJelxxARcpUqLbOKEfSvpSFNBVn = value;
									num = -1860592016;
									continue;
								}
								goto case 5;
							}
							case 3:
								num = -1860592009;
								continue;
							case 6:
								EnumConverter.ToUpdateLoopTypes((UpdateLoopSetting)2147483647, list);
								num2 = 0;
								num = -1860592010;
								continue;
							case 2:
							{
								int num3;
								if (num2 >= list.Count)
								{
									num = -1860592015;
									num3 = num;
								}
								else
								{
									num = -1860592012;
									num3 = num;
								}
								continue;
							}
							case 5:
								num2++;
								num = -1860592009;
								continue;
							case 4:
								return;
							}
							break;
						}
					}
				}
			}

			public void GzCliicOSMFLMvKajLgvnmGSSrh(UpdateLoopType P_0)
			{
				if (xJelxxARcpUqLbOKEfSvpSFNBVn.cmiDdQAFcgEckBbjnNTFEbMKLqrn != P_0)
				{
					xJelxxARcpUqLbOKEfSvpSFNBVn = OAbghxIAVNubiPuQKdWEVeNFqZh[(int)P_0];
					goto IL_0020;
				}
				goto IL_0042;
				IL_006c:
				xJelxxARcpUqLbOKEfSvpSFNBVn.GzCliicOSMFLMvKajLgvnmGSSrh();
				tvASNbDlSCfucjVleflZGkhiFKZP = MiscTools.Tick(tvASNbDlSCfucjVleflZGkhiFKZP);
				ReInput.absFrame = tvASNbDlSCfucjVleflZGkhiFKZP;
				return;
				IL_0020:
				int num = 270575238;
				goto IL_0025;
				IL_0025:
				switch (num ^ 0x1020A684)
				{
				case 3:
					break;
				case 2:
					goto IL_0042;
				case 1:
					return;
				default:
					goto IL_006c;
				}
				goto IL_0020;
				IL_0042:
				if (P_0 == UpdateLoopType.OnGUI)
				{
					int num2;
					if (Event.current.rawType != EventType.Layout)
					{
						num = 270575237;
						num2 = num;
					}
					else
					{
						num = 270575236;
						num2 = num;
					}
					goto IL_0025;
				}
				goto IL_006c;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public sealed class UnityTouch : CodeHelper
		{
			private static UnityTouch ilVQEiENSgAnwgRreWwIUWTqyneQ;

			internal static UnityTouch Instance => ilVQEiENSgAnwgRreWwIUWTqyneQ ?? (ilVQEiENSgAnwgRreWwIUWTqyneQ = new UnityTouch());

			public int touchCount => Input.touchCount;

			public Touch[] touches => Input.touches;

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

		internal class pIsCJOSSGyDWZLPplnQtQjpknsa
		{
			public readonly ValueWatcher<bool> fSwRDTaRQOOVWaLfOxtPkLuSgHU;

			public readonly ValueWatcher<bool> pUGQlQLhCOMLawdPESoYBBOGGAq;

			public readonly ValueWatcher<bool> CQqauVneSzLFCpXUJECBqoaCAzTA;

			public readonly ValueWatcher<int> AXWHETMEhFXfGVXdPEJOIPCYPSJ;

			public readonly ValueWatcher<float> ROPdHOevPemCWUNKMUKdtMfBEsZA;

			public readonly ValueWatcher<string> vaUkmZYsXOsxQWNrFzMoVmeBFhI;

			public readonly ValueWatcher<bool> HHugaYwSdUtjtVKNHsjMBhHaCsri;

			private int mICedzEpYJGivDfEiyrJDkmDJyEN;

			private readonly ValueWatcher[] vQuhekkJhUrqkICvtatGZcVEjEh;

			[CompilerGenerated]
			private static Func<bool> gpVrAueaAkHVmjoHiUllHLWnKLf;

			[CompilerGenerated]
			private static Func<bool> jDnTyWudgRuaClRHaIielvbXseM;

			[CompilerGenerated]
			private static Func<int> JaejdDmABMhHycDjoPvWuTzltkh;

			[CompilerGenerated]
			private static Func<float> OazrpLBgaMeklPbqLbhoLHsOdFu;

			[CompilerGenerated]
			private static Func<bool> pziQWWcDsqRaJHWXaqbyBQUrsdx;

			[CompilerGenerated]
			private static Func<string> bCsEJTgtceyEOfidjUAtIIYQuPTC;

			public int currentFrame => mICedzEpYJGivDfEiyrJDkmDJyEN;

			public pIsCJOSSGyDWZLPplnQtQjpknsa()
			{
				List<ValueWatcher> list = new List<ValueWatcher>
				{
					(fSwRDTaRQOOVWaLfOxtPkLuSgHU = new ValueWatcher<bool>(initialValue: true, autoTriggerEvent: false)),
					(pUGQlQLhCOMLawdPESoYBBOGGAq = new ValueWatcher<bool>(Screen.fullScreen, () => Screen.fullScreen, autoTriggerEvent: false)),
					(CQqauVneSzLFCpXUJECBqoaCAzTA = new ValueWatcher<bool>(Application.runInBackground, () => Application.runInBackground, autoTriggerEvent: false)),
					(AXWHETMEhFXfGVXdPEJOIPCYPSJ = new ValueWatcher<int>((int)Screen.fullScreenMode, () => (int)Screen.fullScreenMode, autoTriggerEvent: false)),
					(ROPdHOevPemCWUNKMUKdtMfBEsZA = new ValueWatcher<float>(Time.unscaledDeltaTime, () => Time.unscaledDeltaTime, autoTriggerEvent: false)),
					(HHugaYwSdUtjtVKNHsjMBhHaCsri = new ValueWatcher<bool>(MathTools.ApproximatelyZero(Time.timeScale), () => MathTools.ApproximatelyZero(Time.timeScale), MathTools.ApproximatelyZero(Time.timeScale)))
				};
				if (editorPlatform != EditorPlatform.None)
				{
					list.Add(vaUkmZYsXOsxQWNrFzMoVmeBFhI = new ValueWatcher<string>(UnityTools.externalTools.GetFocusedEditorWindowTitle(), () => UnityTools.externalTools.GetFocusedEditorWindowTitle(), autoTriggerEvent: false));
				}
				vQuhekkJhUrqkICvtatGZcVEjEh = list.ToArray();
				GzCliicOSMFLMvKajLgvnmGSSrh();
			}

			public void GzCliicOSMFLMvKajLgvnmGSSrh()
			{
				int num = 0;
				while (num < vQuhekkJhUrqkICvtatGZcVEjEh.Length)
				{
					while (true)
					{
						vQuhekkJhUrqkICvtatGZcVEjEh[num].Update();
						num++;
						int num2 = 1461160792;
						while (true)
						{
							switch (num2 ^ 0x57178B59)
							{
							case 0:
								num2 = 1461160795;
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
				mICedzEpYJGivDfEiyrJDkmDJyEN = Time.frameCount;
			}

			public void ZHQBpIGuifjDwrWDuwaBVnZZadbL()
			{
				int num = 0;
				while (num < vQuhekkJhUrqkICvtatGZcVEjEh.Length)
				{
					while (true)
					{
						vQuhekkJhUrqkICvtatGZcVEjEh[num].TriggerEvent();
						num++;
						int num2 = 1654135756;
						while (true)
						{
							switch (num2 ^ 0x62981BCE)
							{
							case 0:
								num2 = 1654135759;
								continue;
							case 1:
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
			private static bool RvTCbPhNPOdPaIGEQaRbctoREQT()
			{
				return Screen.fullScreen;
			}

			[CompilerGenerated]
			private static bool NZUselAHacdmZduLDkcLOUbHAqC()
			{
				return Application.runInBackground;
			}

			[CompilerGenerated]
			private static int QLlxGWlujgVFcGMIPccoCyscpkD()
			{
				return (int)Screen.fullScreenMode;
			}

			[CompilerGenerated]
			private static float HEmsDLwYKSUKyrQJteRckMJwgKA()
			{
				return Time.unscaledDeltaTime;
			}

			[CompilerGenerated]
			private static bool bhPAuxCRSpsRygyZIcrPfGtasXKj()
			{
				return MathTools.ApproximatelyZero(Time.timeScale);
			}

			[CompilerGenerated]
			private static string ttXLXqbwadnTMQRRSLJaZQSGKqW()
			{
				return UnityTools.externalTools.GetFocusedEditorWindowTitle();
			}
		}

		[CustomObfuscation(rename = false)]
		internal const int programVersion1 = 1;

		[CustomObfuscation(rename = false)]
		internal const int programVersion2 = 1;

		[CustomObfuscation(rename = false)]
		internal const int programVersion3 = 39;

		[CustomObfuscation(rename = false)]
		internal const int programVersion4 = 2;

		[CustomObfuscation(rename = false)]
		internal const int dataVersion = 1;

		[CustomObfuscation(rename = false)]
		internal const bool isTrial = false;

		[CustomObfuscation(rename = false)]
		internal const string majorBranch = "U2019";

		private static InputManager_Base oaHYsVKqotUxmLMRdTojIYzEOnG;

		private static PlatformInputManager hZJPCfIEEHEOdtoukvjGAEibgUIb;

		internal static GzivFFngdYeSyLbVIOLpLzJrrzu lUCgcEIquFfuykgBneGrfARQlcR;

		internal static IEFDteeOKlelVDYGidTLyloAfeYs akUdmKMbrqFLXkjqdKLUZOPTArx;

		internal static aQEMIPEePyEmScvmvEQnOdVcwpE WhcqAfYYqNfRCEGkYApjWYGKVjr;

		private static ControllerDataFiles OwRRKduusMuBHXVDcuLelTLPlsM;

		private static UserData NrWVrlwEDRnzNfQhnCmEXbpqELr;

		private static bool PwPWygBTznyByBIyaAyqEfnsXBM;

		private static ConfigVars voLkponRBHpiQNHOfOdnrjJJatj;

		private static UpdateLoopType wnqGmMFwEOPrgeTWAWNkAgXvkth;

		private static bool TxGduWEriXzpLaJgHFbGWOaDcLpz;

		private static Platform VORPOhYHnZnElXbVVvVHXAsptPH;

		private static WebplayerPlatform pbdljLEcAYJBRAXwyPMCkhsQxAz;

		private static EditorPlatform JlcjnOsxtYZFRoDQYarTuTByUtd;

		private static bool XFCoSmnBJmmgGMgkkApGgxaiwJwt;

		private static TimerAbs wdbCnLsglcIsFknhSwLWQBQgunw;

		private static AgfHMtRduofcPgMWADlTmdpvlaMG zihLSZWgVImbQKlwMGYqfGJsEDS;

		private static string RweQiXPlkoCYsHFejBNcirKSVMJc;

		private static bool GNGWQVuzRPRhKWsoNHaVFjABYxT;

		private static bool hpKBmKklQFBUAZCBUDXiaHmgRQbZ;

		private static bool FKAPECNZHRUvTsBQjzVuBeiYKeb;

		private static int vJvLEAQZqHQqtBrxQQYjRNKqctF;

		[CustomObfuscation(rename = false)]
		internal static int _id;

		private static int PQtreopDgZHsrleUPGVGFlQaTqFg;

		private static int dShbHpaFaWqRhaXncNRpduaBIzBf;

		private static bool cyXkQIQKdANaEeictmhYKVnwHui;

		private static readonly UnityTouch TIzJXIHodgDjRZiYjBBkDYrTkWXr;

		private static readonly PlayerHelper hoWOIotAuPPmMRPdGKXFFgiBfuu;

		private static readonly ControllerHelper xCXFDFhjXwdwaoJevpdkyXLLDPEh;

		private static readonly MappingHelper ZJZwAbJDqGxrRtFzUVoezlpXtsA;

		private static readonly TimeHelper JoZnDnqLCAQdHyKOCSkRkDzpPAW;

		private static readonly ConfigHelper OnVYwiiQsXHvGAXkibxdWcqcbKmj;

		private static fJiCCdOhMgsAbjxKCRBiftpwrmH HCyRFqzHqfUvhIAsovCHNCjeugY;

		private static UserDataStore uyXmBvsnRLLshJUthiyfkFfNHLbJ;

		private static IControllerAssigner pPOCiJAXNqcTBvgTPZJeIilAQJwE;

		private static pIsCJOSSGyDWZLPplnQtQjpknsa vlJgPqRvtYWbujUozIEYeDektkL;

		private static SafeAction<ControllerStatusChangedEventArgs> ZLcLOLXVSKeFugchZgnyNPKObmB;

		private static SafeAction<ControllerStatusChangedEventArgs> iBkUhdNUudWDUSUjKHEzsstzHGt;

		private static SafeAction<ControllerStatusChangedEventArgs> gqpOqXawDzaUvCOzNqVGzlFKfcj;

		private static SafeAction utkKCdLBfhoxxsXhbCAJlvPingt;

		private static SafeAction iLmGSiDwkSlWiLkonmvOhUHwQYhe;

		private static SafeAction yCdeVVnaMRLhGKxJqOLqoMoWnUC;

		private static SafeAction orMAkDPXrmayrtPVORSkgzIzrVb;

		private static SafeAction ELeXiUqHbCPEcxYcGoWHepoYNvQ;

		[CustomObfuscation(rename = false)]
		private static Action<bool> _ApplicationFocusChangedEvent;

		private static Action pWdFItfmrvfQhrhZtDjerEzolth;

		private static Action<UpdateLoopType> kcsbsiGiuZbVAkNwHSgcfOIhMuqC;

		private static Action<UpdateLoopType> yoiHjWBUVMihBCiXdHEnpldAVqV;

		private static Action<UpdateLoopType> sYesAVWKicAbGyYiDJeDrtnKQxh;

		private static Action MPSxyXvoClPcOHRiKftJMzoViSR;

		private static Action<bool> DaTMhvOTDOeELrbSmCkeeCtjHGFH;

		private static Action<bool> iXvdTEjqULMZzJFpXwYOeuKBXLE;

		private static Action<bool> nGlgCxSDXjwJuhWZtmkxSakDUUE;

		private static Action<FullScreenMode> jFfQodpYnLFdzMQpDeyHFtagLim;

		private static Action TDhUDprmSgmhhWqCkBVVSSaHgNX;

		private static Action<bool> sgZrtipPgdofXqFFeMmBfjeDpke;

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
		private static Action<Exception> EyBkQPbuchCaphJGejOOODWtaKP;

		[CompilerGenerated]
		private static Action<Exception> bpsDUSEXpyykcWJldajgxpogOph;

		[CompilerGenerated]
		private static Action<Exception> OgstaTqPAOzzFqCzJSUslPPVDpI;

		[CompilerGenerated]
		private static Action<Exception> gmAvcjyWGshkTcssusYxOZNlQzx;

		[CompilerGenerated]
		private static Action<Exception> JzBaUdlwHurNHsAdDtAfhdMolvT;

		[CompilerGenerated]
		private static Action<Exception> UfcPvNRbPeRZHsphQpaqIgDeGVG;

		[CompilerGenerated]
		private static Action<Exception> mZUUcRZQMYRMwkgVHEAnEszYcxxx;

		[CompilerGenerated]
		private static Action<Exception> GDswEDbawSjkEDQugEPLwdWcEzL;

		[CompilerGenerated]
		private static Action<Exception> ZZNMGygnOEPGbHWqFcHKZbWZPMf;

		[CompilerGenerated]
		private static Func<bool> wQhGoEgkfRAEOJCAzIJjymxYqCXj;

		private static fJiCCdOhMgsAbjxKCRBiftpwrmH unityInputBuffer => HCyRFqzHqfUvhIAsovCHNCjeugY ?? (HCyRFqzHqfUvhIAsovCHNCjeugY = new fJiCCdOhMgsAbjxKCRBiftpwrmH(voLkponRBHpiQNHOfOdnrjJJatj.updateLoop));

		public static PlayerHelper players
		{
			get
			{
				if (!PwPWygBTznyByBIyaAyqEfnsXBM)
				{
					qhpYubDckyjpJAnexwicPXmzqGYu();
					return null;
				}
				return hoWOIotAuPPmMRPdGKXFFgiBfuu;
			}
		}

		public static ControllerHelper controllers
		{
			get
			{
				if (!PwPWygBTznyByBIyaAyqEfnsXBM)
				{
					qhpYubDckyjpJAnexwicPXmzqGYu();
					return null;
				}
				return xCXFDFhjXwdwaoJevpdkyXLLDPEh;
			}
		}

		public static MappingHelper mapping
		{
			get
			{
				if (!PwPWygBTznyByBIyaAyqEfnsXBM)
				{
					qhpYubDckyjpJAnexwicPXmzqGYu();
					return null;
				}
				return ZJZwAbJDqGxrRtFzUVoezlpXtsA;
			}
		}

		public static UnityTouch touch
		{
			get
			{
				if (!PwPWygBTznyByBIyaAyqEfnsXBM)
				{
					qhpYubDckyjpJAnexwicPXmzqGYu();
					return null;
				}
				return TIzJXIHodgDjRZiYjBBkDYrTkWXr;
			}
		}

		public static TimeHelper time
		{
			get
			{
				if (!PwPWygBTznyByBIyaAyqEfnsXBM)
				{
					qhpYubDckyjpJAnexwicPXmzqGYu();
					return null;
				}
				return JoZnDnqLCAQdHyKOCSkRkDzpPAW;
			}
		}

		public static IUserDataStore userDataStore
		{
			get
			{
				if (!PwPWygBTznyByBIyaAyqEfnsXBM)
				{
					while (true)
					{
						int num = 897333753;
						while (true)
						{
							switch (num ^ 0x357C39F8)
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
							qhpYubDckyjpJAnexwicPXmzqGYu();
							num = 897333754;
						}
					}
				}
				return uyXmBvsnRLLshJUthiyfkFfNHLbJ;
			}
		}

		public static ConfigHelper configuration
		{
			get
			{
				if (!PwPWygBTznyByBIyaAyqEfnsXBM)
				{
					qhpYubDckyjpJAnexwicPXmzqGYu();
					return null;
				}
				return OnVYwiiQsXHvGAXkibxdWcqcbKmj;
			}
		}

		public static string programVersion
		{
			get
			{
				object[] array = new object[8] { 1, ".", 1, null, null, null, null, null };
				while (true)
				{
					int num = 1068115569;
					while (true)
					{
						switch (num ^ 0x3FAA2673)
						{
						case 0:
							break;
						case 1:
							array[5] = ".";
							num = 1068115568;
							continue;
						case 4:
							array[4] = 39;
							num = 1068115570;
							continue;
						case 2:
							array[3] = ".";
							num = 1068115575;
							continue;
						default:
							array[6] = 2;
							array[7] = ".U2019";
							return string.Concat(array);
						}
						break;
					}
				}
			}
		}

		public static bool usingUnityInput => TxGduWEriXzpLaJgHFbGWOaDcLpz;

		public static bool unityJoystickIdentificationRequired
		{
			get
			{
				if (!PwPWygBTznyByBIyaAyqEfnsXBM)
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

		public static bool isReady => PwPWygBTznyByBIyaAyqEfnsXBM;

		[CustomObfuscation(rename = false)]
		internal static int id => _id;

		[CustomObfuscation(rename = false)]
		internal static bool initialized => PwPWygBTznyByBIyaAyqEfnsXBM;

		[CustomObfuscation(rename = false)]
		internal static UpdateLoopType currentUpdateLoop => wnqGmMFwEOPrgeTWAWNkAgXvkth;

		[CustomObfuscation(rename = false)]
		internal static ConfigVars configVars => voLkponRBHpiQNHOfOdnrjJJatj;

		[CustomObfuscation(rename = false)]
		internal static IConfigVars_Internal pluginConfigVars => voLkponRBHpiQNHOfOdnrjJJatj;

		[CustomObfuscation(rename = false)]
		internal static UserData UserData => NrWVrlwEDRnzNfQhnCmEXbpqELr;

		[CustomObfuscation(rename = false)]
		internal static Platform currentPlatform => VORPOhYHnZnElXbVVvVHXAsptPH;

		[CustomObfuscation(rename = false)]
		internal static WebplayerPlatform webplayerPlatform => pbdljLEcAYJBRAXwyPMCkhsQxAz;

		[CustomObfuscation(rename = false)]
		internal static EditorPlatform editorPlatform => JlcjnOsxtYZFRoDQYarTuTByUtd;

		[CustomObfuscation(rename = false)]
		internal static bool checkNeverPressed
		{
			get
			{
				if (VORPOhYHnZnElXbVVvVHXAsptPH == Platform.Linux)
				{
					goto IL_0008;
				}
				goto IL_0044;
				IL_0008:
				int num = 638824662;
				goto IL_000d;
				IL_000d:
				while (true)
				{
					switch (num ^ 0x2613B0D7)
					{
					case 3:
						break;
					case 2:
						goto IL_002e;
					case 0:
						return true;
					case 1:
						goto IL_0064;
					default:
						return true;
					}
					break;
					IL_0064:
					if (TxGduWEriXzpLaJgHFbGWOaDcLpz)
					{
						num = 638824663;
						continue;
					}
					goto IL_0044;
					IL_002e:
					if (primaryInputManager.inputSourceType == InputSource.OSX)
					{
						num = 638824659;
						continue;
					}
					goto IL_0074;
				}
				goto IL_0008;
				IL_0074:
				if (UnityTools.isAndroidPlatform && TxGduWEriXzpLaJgHFbGWOaDcLpz)
				{
					return true;
				}
				if (VORPOhYHnZnElXbVVvVHXAsptPH == Platform.Webplayer && pbdljLEcAYJBRAXwyPMCkhsQxAz == WebplayerPlatform.OSX)
				{
					return true;
				}
				if (VORPOhYHnZnElXbVVvVHXAsptPH == Platform.WebGL)
				{
					return true;
				}
				return false;
				IL_0044:
				if (VORPOhYHnZnElXbVVvVHXAsptPH == Platform.OSX)
				{
					int num2;
					if (TxGduWEriXzpLaJgHFbGWOaDcLpz)
					{
						num = 638824659;
						num2 = num;
					}
					else
					{
						num = 638824661;
						num2 = num;
					}
					goto IL_000d;
				}
				goto IL_0074;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isEditor => JlcjnOsxtYZFRoDQYarTuTByUtd != EditorPlatform.None;

		[CustomObfuscation(rename = false)]
		internal static Guid defaultHardwareJoystickMapGuid
		{
			get
			{
				if (!PwPWygBTznyByBIyaAyqEfnsXBM)
				{
					return Guid.Empty;
				}
				return OwRRKduusMuBHXVDcuLelTLPlsM.defaultHardwareJoystickMapGuid;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isRunningInEditMode => hpKBmKklQFBUAZCBUDXiaHmgRQbZ;

		[CustomObfuscation(rename = false)]
		internal static bool isEditorPaused => UnityTools.externalTools.isEditorPaused;

		[CustomObfuscation(rename = false)]
		internal static float unityUnscaledDeltaTime => zihLSZWgVImbQKlwMGYqfGJsEDS.unityUnscaledDeltaTime;

		[CustomObfuscation(rename = false)]
		internal static float unityUnscaledDeltaTimePrev => zihLSZWgVImbQKlwMGYqfGJsEDS.unityUnscaledDeltaTimePrev;

		[CustomObfuscation(rename = false)]
		internal static double realTime
		{
			get
			{
				if (!PwPWygBTznyByBIyaAyqEfnsXBM)
				{
					return 0.0;
				}
				return zihLSZWgVImbQKlwMGYqfGJsEDS.realTime;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static int currentUnityFrame
		{
			get
			{
				if (!PwPWygBTznyByBIyaAyqEfnsXBM)
				{
					return 0;
				}
				return vlJgPqRvtYWbujUozIEYeDektkL.currentFrame;
			}
		}

		private static bool isEditorGameViewFocused
		{
			get
			{
				if (UnityTools.unityVersion >= UnityTools.UnityVersion.UNITY_5_1)
				{
					return RweQiXPlkoCYsHFejBNcirKSVMJc == "Game";
				}
				return RweQiXPlkoCYsHFejBNcirKSVMJc == "UnityEditor.GameView";
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isAllowedEditorWindowFocused
		{
			get
			{
				if (voLkponRBHpiQNHOfOdnrjJJatj.allowInputInEditorSceneView && UnityTools.externalTools.IsEditorSceneViewFocused())
				{
					return true;
				}
				if (!FKAPECNZHRUvTsBQjzVuBeiYKeb)
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
				if (hZJPCfIEEHEOdtoukvjGAEibgUIb is INativePlatformHelper nativePlatformHelper)
				{
					return nativePlatformHelper.isApplicationFocused;
				}
				return FKAPECNZHRUvTsBQjzVuBeiYKeb;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isWindowsStandaloneWebplayerOrEditorPlatform
		{
			get
			{
				if (!PwPWygBTznyByBIyaAyqEfnsXBM)
				{
					return false;
				}
				if (!TxGduWEriXzpLaJgHFbGWOaDcLpz)
				{
					goto IL_0010;
				}
				int num;
				if (VORPOhYHnZnElXbVVvVHXAsptPH != Platform.Windows)
				{
					num = -1442391531;
					goto IL_0015;
				}
				goto IL_0079;
				IL_0015:
				while (true)
				{
					switch (num ^ -1442391535)
					{
					case 2:
						break;
					case 3:
						return false;
					case 1:
						goto IL_0047;
					case 4:
						goto IL_0056;
					default:
						return JlcjnOsxtYZFRoDQYarTuTByUtd == EditorPlatform.Windows;
					}
					break;
					IL_0056:
					int num2;
					if (VORPOhYHnZnElXbVVvVHXAsptPH == Platform.Webplayer)
					{
						num = -1442391536;
						num2 = num;
					}
					else
					{
						num = -1442391535;
						num2 = num;
					}
					continue;
					IL_0047:
					if (pbdljLEcAYJBRAXwyPMCkhsQxAz != WebplayerPlatform.Windows)
					{
						num = -1442391535;
						continue;
					}
					goto IL_0079;
				}
				goto IL_0010;
				IL_0010:
				num = -1442391534;
				goto IL_0015;
				IL_0079:
				return true;
			}
		}

		private static bool inputAllowed
		{
			get
			{
				if (!PwPWygBTznyByBIyaAyqEfnsXBM)
				{
					return false;
				}
				if (!vlJgPqRvtYWbujUozIEYeDektkL.fSwRDTaRQOOVWaLfOxtPkLuSgHU.value)
				{
					while (true)
					{
						int num = -1604013458;
						while (true)
						{
							switch (num ^ -1604013460)
							{
							case 0:
								break;
							case 2:
								goto IL_0038;
							default:
								return false;
							}
							break;
							IL_0038:
							if (!cyXkQIQKdANaEeictmhYKVnwHui)
							{
								goto end_IL_001a;
							}
							num = -1604013459;
						}
						continue;
						end_IL_001a:
						break;
					}
					if (!isEditor && !vlJgPqRvtYWbujUozIEYeDektkL.CQqauVneSzLFCpXUJECBqoaCAzTA.value)
					{
						return false;
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
				if (PwPWygBTznyByBIyaAyqEfnsXBM)
				{
					return vlJgPqRvtYWbujUozIEYeDektkL.fSwRDTaRQOOVWaLfOxtPkLuSgHU.value;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool applicationIsFullScreen
		{
			get
			{
				if (PwPWygBTznyByBIyaAyqEfnsXBM)
				{
					return vlJgPqRvtYWbujUozIEYeDektkL.pUGQlQLhCOMLawdPESoYBBOGGAq.value;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool applicationRunInBackground
		{
			get
			{
				if (PwPWygBTznyByBIyaAyqEfnsXBM)
				{
					return vlJgPqRvtYWbujUozIEYeDektkL.CQqauVneSzLFCpXUJECBqoaCAzTA.value;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool timeScaleIsPaused
		{
			get
			{
				if (PwPWygBTznyByBIyaAyqEfnsXBM)
				{
					return vlJgPqRvtYWbujUozIEYeDektkL.HHugaYwSdUtjtVKNHsjMBhHaCsri.value;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static InputManager_Base rewiredInputManager => oaHYsVKqotUxmLMRdTojIYzEOnG;

		[CustomObfuscation(rename = false)]
		internal static PlatformInputManager primaryInputManager
		{
			get
			{
				if (!PwPWygBTznyByBIyaAyqEfnsXBM)
				{
					qhpYubDckyjpJAnexwicPXmzqGYu();
					return null;
				}
				return hZJPCfIEEHEOdtoukvjGAEibgUIb.primaryInputManager;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static IControllerAssigner controllerAssigner
		{
			get
			{
				return pPOCiJAXNqcTBvgTPZJeIilAQJwE;
			}
			set
			{
				pPOCiJAXNqcTBvgTPZJeIilAQJwE = value;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static RewiredVersion rewiredVersion => new RewiredVersion(programVersion);

		[CustomObfuscation(rename = false)]
		internal static int timeScalePauseChangedCount => dShbHpaFaWqRhaXncNRpduaBIzBf;

		public static event Action<ControllerStatusChangedEventArgs> ControllerConnectedEvent
		{
			add
			{
				ZLcLOLXVSKeFugchZgnyNPKObmB += value;
			}
			remove
			{
				ZLcLOLXVSKeFugchZgnyNPKObmB -= value;
			}
		}

		public static event Action<ControllerStatusChangedEventArgs> ControllerPreDisconnectEvent
		{
			add
			{
				iBkUhdNUudWDUSUjKHEzsstzHGt += value;
			}
			remove
			{
				iBkUhdNUudWDUSUjKHEzsstzHGt -= value;
			}
		}

		public static event Action<ControllerStatusChangedEventArgs> ControllerDisconnectedEvent
		{
			add
			{
				gqpOqXawDzaUvCOzNqVGzlFKfcj += value;
			}
			remove
			{
				gqpOqXawDzaUvCOzNqVGzlFKfcj -= value;
			}
		}

		public static event Action InputSourceUpdateEvent
		{
			add
			{
				utkKCdLBfhoxxsXhbCAJlvPingt += value;
			}
			remove
			{
				utkKCdLBfhoxxsXhbCAJlvPingt -= value;
			}
		}

		public static event Action EditorRecompileEvent
		{
			add
			{
				iLmGSiDwkSlWiLkonmvOhUHwQYhe += value;
			}
			remove
			{
				iLmGSiDwkSlWiLkonmvOhUHwQYhe -= value;
			}
		}

		public static event Action PreShutDownEvent
		{
			add
			{
				yCdeVVnaMRLhGKxJqOLqoMoWnUC += value;
			}
			remove
			{
				yCdeVVnaMRLhGKxJqOLqoMoWnUC -= value;
			}
		}

		public static event Action ShutDownEvent
		{
			add
			{
				orMAkDPXrmayrtPVORSkgzIzrVb += value;
			}
			remove
			{
				orMAkDPXrmayrtPVORSkgzIzrVb -= value;
			}
		}

		public static event Action InitializedEvent
		{
			add
			{
				ELeXiUqHbCPEcxYcGoWHepoYNvQ += value;
			}
			remove
			{
				ELeXiUqHbCPEcxYcGoWHepoYNvQ -= value;
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
				pWdFItfmrvfQhrhZtDjerEzolth = (Action)Delegate.Combine(pWdFItfmrvfQhrhZtDjerEzolth, value);
			}
			remove
			{
				pWdFItfmrvfQhrhZtDjerEzolth = (Action)Delegate.Remove(pWdFItfmrvfQhrhZtDjerEzolth, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<UpdateLoopType> BeforeTimeManagerUpdateEvent
		{
			add
			{
				kcsbsiGiuZbVAkNwHSgcfOIhMuqC = (Action<UpdateLoopType>)Delegate.Combine(kcsbsiGiuZbVAkNwHSgcfOIhMuqC, value);
			}
			remove
			{
				kcsbsiGiuZbVAkNwHSgcfOIhMuqC = (Action<UpdateLoopType>)Delegate.Remove(kcsbsiGiuZbVAkNwHSgcfOIhMuqC, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<UpdateLoopType> UpdateStartedEvent
		{
			add
			{
				yoiHjWBUVMihBCiXdHEnpldAVqV = (Action<UpdateLoopType>)Delegate.Combine(yoiHjWBUVMihBCiXdHEnpldAVqV, value);
			}
			remove
			{
				yoiHjWBUVMihBCiXdHEnpldAVqV = (Action<UpdateLoopType>)Delegate.Remove(yoiHjWBUVMihBCiXdHEnpldAVqV, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<UpdateLoopType> UpdateEndedEvent
		{
			add
			{
				sYesAVWKicAbGyYiDJeDrtnKQxh = (Action<UpdateLoopType>)Delegate.Combine(sYesAVWKicAbGyYiDJeDrtnKQxh, value);
			}
			remove
			{
				sYesAVWKicAbGyYiDJeDrtnKQxh = (Action<UpdateLoopType>)Delegate.Remove(sYesAVWKicAbGyYiDJeDrtnKQxh, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action LateUpdateEvent
		{
			add
			{
				MPSxyXvoClPcOHRiKftJMzoViSR = (Action)Delegate.Combine(MPSxyXvoClPcOHRiKftJMzoViSR, value);
			}
			remove
			{
				MPSxyXvoClPcOHRiKftJMzoViSR = (Action)Delegate.Remove(MPSxyXvoClPcOHRiKftJMzoViSR, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> ApplicationIsFullScreenChangedEvent
		{
			add
			{
				DaTMhvOTDOeELrbSmCkeeCtjHGFH = (Action<bool>)Delegate.Combine(DaTMhvOTDOeELrbSmCkeeCtjHGFH, value);
			}
			remove
			{
				DaTMhvOTDOeELrbSmCkeeCtjHGFH = (Action<bool>)Delegate.Remove(DaTMhvOTDOeELrbSmCkeeCtjHGFH, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> ApplicationRunInBackgroundChangedEvent
		{
			add
			{
				iXvdTEjqULMZzJFpXwYOeuKBXLE = (Action<bool>)Delegate.Combine(iXvdTEjqULMZzJFpXwYOeuKBXLE, value);
			}
			remove
			{
				iXvdTEjqULMZzJFpXwYOeuKBXLE = (Action<bool>)Delegate.Remove(iXvdTEjqULMZzJFpXwYOeuKBXLE, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> TimeScalePauseChangedEvent
		{
			add
			{
				nGlgCxSDXjwJuhWZtmkxSakDUUE = (Action<bool>)Delegate.Combine(nGlgCxSDXjwJuhWZtmkxSakDUUE, value);
			}
			remove
			{
				nGlgCxSDXjwJuhWZtmkxSakDUUE = (Action<bool>)Delegate.Remove(nGlgCxSDXjwJuhWZtmkxSakDUUE, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<FullScreenMode> ApplicationFullScreenModeChangedEvent
		{
			add
			{
				jFfQodpYnLFdzMQpDeyHFtagLim = (Action<FullScreenMode>)Delegate.Combine(jFfQodpYnLFdzMQpDeyHFtagLim, value);
			}
			remove
			{
				jFfQodpYnLFdzMQpDeyHFtagLim = (Action<FullScreenMode>)Delegate.Remove(jFfQodpYnLFdzMQpDeyHFtagLim, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action SceneLoadedEvent
		{
			add
			{
				TDhUDprmSgmhhWqCkBVVSSaHgNX = (Action)Delegate.Combine(TDhUDprmSgmhhWqCkBVVSSaHgNX, value);
			}
			remove
			{
				TDhUDprmSgmhhWqCkBVVSSaHgNX = (Action)Delegate.Remove(TDhUDprmSgmhhWqCkBVVSSaHgNX, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> EditorPauseChangedEvent
		{
			add
			{
				sgZrtipPgdofXqFFeMmBfjeDpke = (Action<bool>)Delegate.Combine(sgZrtipPgdofXqFFeMmBfjeDpke, value);
			}
			remove
			{
				sgZrtipPgdofXqFFeMmBfjeDpke = (Action<bool>)Delegate.Remove(sgZrtipPgdofXqFFeMmBfjeDpke, value);
			}
		}

		static ReInput()
		{
			FKAPECNZHRUvTsBQjzVuBeiYKeb = true;
			while (true)
			{
				int num = 686183609;
				while (true)
				{
					switch (num ^ 0x28E654BA)
					{
					case 4:
						break;
					default:
						return;
					case 19:
						ZLcLOLXVSKeFugchZgnyNPKObmB = new SafeAction<ControllerStatusChangedEventArgs>(EyBkQPbuchCaphJGejOOODWtaKP);
						if (bpsDUSEXpyykcWJldajgxpogOph == null)
						{
							bpsDUSEXpyykcWJldajgxpogOph = delegate(Exception P_0)
							{
								HandleCallbackException("Rewired.ReInput.ControllerPreDisconnectEvent", P_0);
							};
							num = 686183605;
							continue;
						}
						goto case 15;
					case 11:
						xCXFDFhjXwdwaoJevpdkyXLLDPEh = ControllerHelper.Instance;
						ZJZwAbJDqGxrRtFzUVoezlpXtsA = MappingHelper.Instance;
						JoZnDnqLCAQdHyKOCSkRkDzpPAW = TimeHelper.Instance;
						OnVYwiiQsXHvGAXkibxdWcqcbKmj = ConfigHelper.Instance;
						if (EyBkQPbuchCaphJGejOOODWtaKP == null)
						{
							EyBkQPbuchCaphJGejOOODWtaKP = delegate(Exception P_0)
							{
								HandleCallbackException("Rewired.ReInput.ControllerConnectedEvent", P_0);
							};
							num = 686183593;
							continue;
						}
						goto case 19;
					case 1:
						hoWOIotAuPPmMRPdGKXFFgiBfuu = PlayerHelper.Instance;
						num = 686183601;
						continue;
					case 12:
						iLmGSiDwkSlWiLkonmvOhUHwQYhe = new SafeAction(JzBaUdlwHurNHsAdDtAfhdMolvT);
						if (UfcPvNRbPeRZHsphQpaqIgDeGVG == null)
						{
							UfcPvNRbPeRZHsphQpaqIgDeGVG = delegate(Exception P_0)
							{
								HandleCallbackException("Rewired.ReInput.PreShutDownEvent", P_0);
							};
							num = 686183613;
							continue;
						}
						goto case 7;
					case 14:
						mZUUcRZQMYRMwkgVHEAnEszYcxxx = delegate(Exception P_0)
						{
							HandleCallbackException("Rewired.ReInput.ShutDownEvent", P_0);
						};
						num = 686183615;
						continue;
					case 0:
						gmAvcjyWGshkTcssusYxOZNlQzx = delegate(Exception P_0)
						{
							HandleCallbackException("Rewired.ReInput.InputSourceUpdateEvent", P_0);
						};
						num = 686183592;
						continue;
					case 6:
						JzBaUdlwHurNHsAdDtAfhdMolvT = delegate(Exception P_0)
						{
							HandleCallbackException("Rewired.ReInput.EditorRecompileEvent", P_0);
						};
						num = 686183606;
						continue;
					case 13:
						SafeDelegate.S_ExceptionHandler = ZZNMGygnOEPGbHWqFcHKZbWZPMf;
						num = 686183602;
						continue;
					case 17:
						ZZNMGygnOEPGbHWqFcHKZbWZPMf = delegate(Exception P_0)
						{
							HandleCallbackException("", P_0);
						};
						num = 686183607;
						continue;
					case 5:
						orMAkDPXrmayrtPVORSkgzIzrVb = new SafeAction(mZUUcRZQMYRMwkgVHEAnEszYcxxx);
						if (GDswEDbawSjkEDQugEPLwdWcEzL == null)
						{
							GDswEDbawSjkEDQugEPLwdWcEzL = delegate(Exception P_0)
							{
								HandleCallbackException("Rewired.ReInput.InitializedEvent", P_0);
							};
							num = 686183600;
							continue;
						}
						goto case 10;
					case 2:
						OgstaTqPAOzzFqCzJSUslPPVDpI = delegate(Exception P_0)
						{
							HandleCallbackException("Rewired.ReInput.ControllerDisconnectedEvent", P_0);
						};
						num = 686183594;
						continue;
					case 9:
						_id = -1;
						PQtreopDgZHsrleUPGVGFlQaTqFg = 0;
						TIzJXIHodgDjRZiYjBBkDYrTkWXr = UnityTouch.Instance;
						num = 686183611;
						continue;
					case 15:
					{
						iBkUhdNUudWDUSUjKHEzsstzHGt = new SafeAction<ControllerStatusChangedEventArgs>(bpsDUSEXpyykcWJldajgxpogOph);
						int num5;
						if (OgstaTqPAOzzFqCzJSUslPPVDpI != null)
						{
							num = 686183594;
							num5 = num;
						}
						else
						{
							num = 686183608;
							num5 = num;
						}
						continue;
					}
					case 18:
					{
						utkKCdLBfhoxxsXhbCAJlvPingt = new SafeAction(gmAvcjyWGshkTcssusYxOZNlQzx);
						int num3;
						if (JzBaUdlwHurNHsAdDtAfhdMolvT != null)
						{
							num = 686183606;
							num3 = num;
						}
						else
						{
							num = 686183612;
							num3 = num;
						}
						continue;
					}
					case 7:
					{
						yCdeVVnaMRLhGKxJqOLqoMoWnUC = new SafeAction(UfcPvNRbPeRZHsphQpaqIgDeGVG);
						int num4;
						if (mZUUcRZQMYRMwkgVHEAnEszYcxxx != null)
						{
							num = 686183615;
							num4 = num;
						}
						else
						{
							num = 686183604;
							num4 = num;
						}
						continue;
					}
					case 3:
						vJvLEAQZqHQqtBrxQQYjRNKqctF = -1;
						num = 686183603;
						continue;
					case 16:
					{
						gqpOqXawDzaUvCOzNqVGzlFKfcj = new SafeAction<ControllerStatusChangedEventArgs>(OgstaTqPAOzzFqCzJSUslPPVDpI);
						int num2;
						if (gmAvcjyWGshkTcssusYxOZNlQzx != null)
						{
							num = 686183592;
							num2 = num;
						}
						else
						{
							num = 686183610;
							num2 = num;
						}
						continue;
					}
					case 10:
					{
						ELeXiUqHbCPEcxYcGoWHepoYNvQ = new SafeAction(GDswEDbawSjkEDQugEPLwdWcEzL);
						int num6;
						if (ZZNMGygnOEPGbHWqFcHKZbWZPMf == null)
						{
							num = 686183595;
							num6 = num;
						}
						else
						{
							num = 686183607;
							num6 = num;
						}
						continue;
					}
					case 8:
						return;
					}
					break;
				}
			}
		}

		public static void Reset()
		{
			if (PwPWygBTznyByBIyaAyqEfnsXBM && !(oaHYsVKqotUxmLMRdTojIYzEOnG == null))
			{
				oaHYsVKqotUxmLMRdTojIYzEOnG.ResetAll();
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool IsInputAllowed(ControllerType controllerType)
		{
			if (!inputAllowed)
			{
				return false;
			}
			if (JlcjnOsxtYZFRoDQYarTuTByUtd != EditorPlatform.None)
			{
				while (true)
				{
					int num = -1579039999;
					while (true)
					{
						switch (num ^ -1579040000)
						{
						case 4:
							break;
						case 3:
							goto IL_0036;
						case 2:
							goto IL_0055;
						case 1:
							goto IL_0060;
						default:
							return false;
						}
						break;
						IL_0060:
						int num2;
						if (controllerType == ControllerType.Keyboard)
						{
							num = -1579039997;
							num2 = num;
						}
						else
						{
							num = -1579039998;
							num2 = num;
						}
						continue;
						IL_0055:
						if (controllerType != ControllerType.Mouse)
						{
							goto end_IL_0010;
						}
						num = -1579039997;
						continue;
						IL_0036:
						if (cyXkQIQKdANaEeictmhYKVnwHui)
						{
							if (vlJgPqRvtYWbujUozIEYeDektkL.fSwRDTaRQOOVWaLfOxtPkLuSgHU.value)
							{
								goto end_IL_0010;
							}
							num = -1579040000;
							continue;
						}
						goto IL_0076;
					}
					continue;
					IL_0076:
					if (!isAllowedEditorWindowFocused)
					{
						return false;
					}
					if (controllerType != ControllerType.Mouse || isUnityEditorFocused)
					{
						break;
					}
					return false;
					continue;
					end_IL_0010:
					break;
				}
			}
			return true;
		}

		internal static void SdmfoteCDVoXNaSlWEvRMBbwmDy(InputManager_Base P_0, Func<ConfigVars, object> P_1, ConfigVars P_2, ControllerDataFiles P_3, UserData P_4)
		{
			try
			{
				_id = PQtreopDgZHsrleUPGVGFlQaTqFg;
				while (true)
				{
					int num = 939080470;
					while (true)
					{
						int num2;
						switch (num ^ 0x37F93B07)
						{
						case 8:
							break;
						default:
							return;
						case 2:
							voLkponRBHpiQNHOfOdnrjJJatj = P_2;
							VORPOhYHnZnElXbVVvVHXAsptPH = UnityTools.platform;
							num = 939080471;
							continue;
						case 18:
							if (UnityTools.isEditor)
							{
								num = 939080460;
								continue;
							}
							num2 = 0;
							goto IL_01c8;
						case 0:
						{
							NrWVrlwEDRnzNfQhnCmEXbpqELr = P_4;
							P_4.SdmfoteCDVoXNaSlWEvRMBbwmDy();
							ThreadSafeUnityInput.Initialize();
							vlJgPqRvtYWbujUozIEYeDektkL = new pIsCJOSSGyDWZLPplnQtQjpknsa();
							vlJgPqRvtYWbujUozIEYeDektkL.fSwRDTaRQOOVWaLfOxtPkLuSgHU.Set(FKAPECNZHRUvTsBQjzVuBeiYKeb);
							vlJgPqRvtYWbujUozIEYeDektkL.fSwRDTaRQOOVWaLfOxtPkLuSgHU.Use();
							int num3;
							if (JlcjnOsxtYZFRoDQYarTuTByUtd == EditorPlatform.None)
							{
								num = 939080451;
								num3 = num;
							}
							else
							{
								num = 939080466;
								num3 = num;
							}
							continue;
						}
						case 7:
							OwRRKduusMuBHXVDcuLelTLPlsM = P_3;
							num = 939080455;
							continue;
						case 6:
							LJmXKcDqxRDAKLIufgGTZRbRmGI();
							GNGWQVuzRPRhKWsoNHaVFjABYxT = false;
							num = 939080468;
							continue;
						case 19:
							if (hpKBmKklQFBUAZCBUDXiaHmgRQbZ)
							{
								Logger.Log("Rewired is running in Edit mode.");
								num = 939080462;
								continue;
							}
							goto case 9;
						case 4:
							yrDhSykWYpUcCbEKhgyafjlZJVZp();
							wdbCnLsglcIsFknhSwLWQBQgunw = new TimerAbs(1.0);
							zihLSZWgVImbQKlwMGYqfGJsEDS = new AgfHMtRduofcPgMWADlTmdpvlaMG();
							nzKJVBylRGKzOZPVGCOtRTDFpUL(P_1);
							lUCgcEIquFfuykgBneGrfARQlcR = new GzivFFngdYeSyLbVIOLpLzJrrzu(P_4.GetActions_Copy());
							num = 939080457;
							continue;
						case 1:
							ThreadSafeUnityInput.PostInitialize2();
							uyXmBvsnRLLshJUthiyfkFfNHLbJ = UnityTools.GetComponent<UserDataStore>(oaHYsVKqotUxmLMRdTojIYzEOnG);
							if (uyXmBvsnRLLshJUthiyfkFfNHLbJ != null)
							{
								uyXmBvsnRLLshJUthiyfkFfNHLbJ.Initialize();
								num = 939080449;
								continue;
							}
							goto case 6;
						case 11:
							num2 = ((!Application.isPlaying) ? 1 : 0);
							goto IL_01c8;
						case 15:
							if (hpKBmKklQFBUAZCBUDXiaHmgRQbZ)
							{
								FKAPECNZHRUvTsBQjzVuBeiYKeb = isEditorGameViewFocused;
								num = 939080459;
								continue;
							}
							goto case 12;
						case 17:
							PQtreopDgZHsrleUPGVGFlQaTqFg++;
							PwPWygBTznyByBIyaAyqEfnsXBM = true;
							GNGWQVuzRPRhKWsoNHaVFjABYxT = true;
							num = 939080469;
							continue;
						case 16:
							pbdljLEcAYJBRAXwyPMCkhsQxAz = UnityTools.webplayerPlatform;
							JlcjnOsxtYZFRoDQYarTuTByUtd = UnityTools.editorPlatform;
							if (P_2.logToScreen)
							{
								Logger.logToScreen = true;
								num = 939080450;
								continue;
							}
							goto case 5;
						case 21:
							vlJgPqRvtYWbujUozIEYeDektkL.fSwRDTaRQOOVWaLfOxtPkLuSgHU.getValueDelegate = () => isUnityEditorFocused && isAllowedEditorWindowFocused;
							num = 939080456;
							continue;
						case 14:
							akUdmKMbrqFLXkjqdKLUZOPTArx = new IEFDteeOKlelVDYGidTLyloAfeYs(P_2, hZJPCfIEEHEOdtoukvjGAEibgUIb);
							num = 939080458;
							continue;
						case 20:
							oaHYsVKqotUxmLMRdTojIYzEOnG = P_0;
							num = 939080453;
							continue;
						case 3:
							hZJPCfIEEHEOdtoukvjGAEibgUIb.UpdateControllerInfoEvent += qgKooMRvkyBFJxENIzGOeknJInz;
							akUdmKMbrqFLXkjqdKLUZOPTArx.ControllerDisconnectStartedEvent += RBWlNpzgRiHMpzgqctXAShATpnM;
							akUdmKMbrqFLXkjqdKLUZOPTArx.JustBeforeControllerFullyDisconnectedEvent += WhcqAfYYqNfRCEGkYApjWYGKVjr.JfhtXHzUivDvEfCtJoOItmIJvaZ;
							ThreadSafeUnityInput.PostInitialize();
							CTsGPPxUyLPSWLqACIrQDSoNQYOu();
							num = 939080454;
							continue;
						case 9:
							if (ELeXiUqHbCPEcxYcGoWHepoYNvQ != null)
							{
								ELeXiUqHbCPEcxYcGoWHepoYNvQ.Invoke();
								num = 939080461;
								continue;
							}
							return;
						case 5:
							UnityTools.externalTools.EditorPausedStateChangedEvent += TMQpwufEBflaFFZUDwRxXdkXLcN;
							num = 939080448;
							continue;
						case 13:
							WhcqAfYYqNfRCEGkYApjWYGKVjr = new aQEMIPEePyEmScvmvEQnOdVcwpE(P_2);
							hZJPCfIEEHEOdtoukvjGAEibgUIb.DeviceConnectedEvent += PwSRZVQpIbNwCFCQnaehAzRVYALA;
							hZJPCfIEEHEOdtoukvjGAEibgUIb.DeviceDisconnectedEvent += kpDMCmRobliMkbzVroacRXkaxyKC;
							num = 939080452;
							continue;
						case 12:
							vlJgPqRvtYWbujUozIEYeDektkL.fSwRDTaRQOOVWaLfOxtPkLuSgHU.Set(isUnityEditorFocused && isAllowedEditorWindowFocused);
							num = 939080451;
							continue;
						case 10:
							return;
							IL_01c8:
							hpKBmKklQFBUAZCBUDXiaHmgRQbZ = (byte)num2 != 0;
							if (UnityTools.isEditor)
							{
								CheckRewiredVersionCompatibility();
								num = 939080467;
								continue;
							}
							goto case 20;
						}
						break;
					}
				}
			}
			catch (Exception ex)
			{
				PwPWygBTznyByBIyaAyqEfnsXBM = false;
				GNGWQVuzRPRhKWsoNHaVFjABYxT = false;
				throw ex;
			}
		}

		internal static void NoiITHOkBgdirKSZopWLLfLYZOJ()
		{
			if (zihLSZWgVImbQKlwMGYqfGJsEDS != null)
			{
				zihLSZWgVImbQKlwMGYqfGJsEDS.IOYlMWjyaBwKFkouFERJLnmbGOa();
				goto IL_0011;
			}
			goto IL_0037;
			IL_0037:
			int num = default(int);
			int num2;
			if (configVars.deferControllerConnectedEventsOnStart)
			{
				num = 0;
				num2 = 898184678;
				goto IL_0016;
			}
			return;
			IL_0011:
			num2 = 898184672;
			goto IL_0016;
			IL_0016:
			while (true)
			{
				switch (num2 ^ 0x358935E4)
				{
				case 0:
					break;
				default:
					return;
				case 4:
					goto IL_0037;
				case 2:
					goto IL_004c;
				case 1:
				{
					Joystick joystick = akUdmKMbrqFLXkjqdKLUZOPTArx.Joysticks_readOnly[num];
					ewWOQSbOTGYETSOKUUbJDipWSiE(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
					num++;
					num2 = 898184678;
					continue;
				}
				case 3:
					return;
				}
				break;
				IL_004c:
				int num3;
				if (num < akUdmKMbrqFLXkjqdKLUZOPTArx.joystickCount)
				{
					num2 = 898184677;
					num3 = num2;
				}
				else
				{
					num2 = 898184679;
					num3 = num2;
				}
			}
			goto IL_0011;
		}

		internal static void eoBDrzjTxJPKesIEIdxkrHuzYrvL(UpdateLoopType P_0)
		{
			if (!PwPWygBTznyByBIyaAyqEfnsXBM)
			{
				goto IL_0007;
			}
			goto IL_0058;
			IL_0007:
			int num = -404434773;
			goto IL_000c;
			IL_000c:
			UpdateLoopType updateLoopType = default(UpdateLoopType);
			while (true)
			{
				switch (num ^ -404434770)
				{
				case 2:
					break;
				case 1:
					updateLoopType = P_0;
					num = -404434771;
					continue;
				case 3:
					switch (updateLoopType)
					{
					default:
						return;
					case UpdateLoopType.Update:
					case UpdateLoopType.FixedUpdate:
						break;
					}
					goto default;
				case 5:
					return;
				case 0:
					goto IL_0058;
				default:
					ivuAxdaAoAbDOdItMwBxlDaxkCZb();
					return;
				}
				break;
			}
			goto IL_0007;
			IL_0058:
			YaidZICtwYmAhChJcSzxFBUkuwR(P_0);
			num = -404434769;
			goto IL_000c;
		}

		private static void YaidZICtwYmAhChJcSzxFBUkuwR(UpdateLoopType P_0)
		{
			if (vlJgPqRvtYWbujUozIEYeDektkL != null)
			{
				vlJgPqRvtYWbujUozIEYeDektkL.GzCliicOSMFLMvKajLgvnmGSSrh();
				goto IL_0011;
			}
			goto IL_002f;
			IL_002f:
			Action<UpdateLoopType> action = kcsbsiGiuZbVAkNwHSgcfOIhMuqC;
			int num = 766783322;
			goto IL_0016;
			IL_0011:
			num = 766783323;
			goto IL_0016;
			IL_0016:
			switch (num ^ 0x2DB42F5A)
			{
			case 2:
				break;
			case 1:
				goto IL_002f;
			default:
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
				zihLSZWgVImbQKlwMGYqfGJsEDS.GzCliicOSMFLMvKajLgvnmGSSrh(P_0);
				return;
			}
			goto IL_0011;
		}

		private static void ivuAxdaAoAbDOdItMwBxlDaxkCZb()
		{
			int frameCount = Time.frameCount;
			while (true)
			{
				int num = -441464401;
				while (true)
				{
					switch (num ^ -441464402)
					{
					case 3:
						break;
					case 1:
						if (vJvLEAQZqHQqtBrxQQYjRNKqctF != frameCount)
						{
							goto IL_0038;
						}
						return;
					case 0:
						goto IL_0038;
					default:
					{
						ThreadSafeUnityInput.Update();
						Action action = pWdFItfmrvfQhrhZtDjerEzolth;
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
					}
					break;
					IL_0038:
					vJvLEAQZqHQqtBrxQQYjRNKqctF = frameCount;
					num = -441464404;
				}
			}
		}

		internal static void GzCliicOSMFLMvKajLgvnmGSSrh(UpdateLoopType P_0)
		{
			if (!PwPWygBTznyByBIyaAyqEfnsXBM)
			{
				goto IL_000a;
			}
			goto IL_00a7;
			IL_000a:
			int num = -1172152293;
			goto IL_000f;
			IL_000f:
			while (true)
			{
				switch (num ^ -1172152294)
				{
				case 5:
					break;
				case 4:
					goto IL_003f;
				case 7:
					XFCoSmnBJmmgGMgkkApGgxaiwJwt = false;
					wdbCnLsglcIsFknhSwLWQBQgunw.Clear();
					num = -1172152295;
					continue;
				case 1:
					return;
				case 0:
					goto IL_0080;
				case 2:
					goto IL_00a7;
				case 6:
					unityInputBuffer.GzCliicOSMFLMvKajLgvnmGSSrh(P_0);
					num = -1172152295;
					continue;
				default:
					goto IL_00d4;
				}
				break;
			}
			goto IL_000a;
			IL_00a7:
			if (wnqGmMFwEOPrgeTWAWNkAgXvkth != P_0)
			{
				wnqGmMFwEOPrgeTWAWNkAgXvkth = P_0;
				num = -1172152290;
				goto IL_000f;
			}
			goto IL_003f;
			IL_0138:
			akUdmKMbrqFLXkjqdKLUZOPTArx.GzCliicOSMFLMvKajLgvnmGSSrh(P_0);
			int num2 = -1172152296;
			goto IL_011f;
			IL_003f:
			if (editorPlatform != EditorPlatform.None)
			{
				RweQiXPlkoCYsHFejBNcirKSVMJc = vlJgPqRvtYWbujUozIEYeDektkL.vaUkmZYsXOsxQWNrFzMoVmeBFhI.value;
				num = -1172152294;
				goto IL_000f;
			}
			goto IL_0080;
			IL_0080:
			if (XFCoSmnBJmmgGMgkkApGgxaiwJwt)
			{
				int num3;
				if (!wdbCnLsglcIsFknhSwLWQBQgunw.Update())
				{
					num = -1172152292;
					num3 = num;
				}
				else
				{
					num = -1172152291;
					num3 = num;
				}
				goto IL_000f;
			}
			goto IL_00d4;
			IL_011f:
			switch (num2 ^ -1172152294)
			{
			case 0:
				break;
			case 1:
				goto IL_0138;
			default:
			{
				Action<UpdateLoopType> action = sYesAVWKicAbGyYiDJeDrtnKQxh;
				if (action != null)
				{
					try
					{
						action(P_0);
						return;
					}
					catch (Exception exception)
					{
						HandleCallbackException("ReInput.UpdateEndedEvent", exception);
						return;
					}
				}
				return;
			}
			}
			goto IL_011a;
			IL_011a:
			num2 = -1172152293;
			goto IL_011f;
			IL_00d4:
			vlJgPqRvtYWbujUozIEYeDektkL.ZHQBpIGuifjDwrWDuwaBVnZZadbL();
			Action<UpdateLoopType> action2 = yoiHjWBUVMihBCiXdHEnpldAVqV;
			if (action2 != null)
			{
				try
				{
					action2(P_0);
				}
				catch (Exception exception2)
				{
					HandleCallbackException("ReInput.UpdateStartedEvent", exception2);
				}
			}
			hZJPCfIEEHEOdtoukvjGAEibgUIb.Update(P_0);
			if (utkKCdLBfhoxxsXhbCAJlvPingt != null)
			{
				utkKCdLBfhoxxsXhbCAJlvPingt.Invoke();
				goto IL_011a;
			}
			goto IL_0138;
		}

		internal static void KIEzPRxRUsoFFHqeHJExqHIpqcR()
		{
			Action mPSxyXvoClPcOHRiKftJMzoViSR = MPSxyXvoClPcOHRiKftJMzoViSR;
			if (mPSxyXvoClPcOHRiKftJMzoViSR != null)
			{
				try
				{
					mPSxyXvoClPcOHRiKftJMzoViSR();
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
			if (PwPWygBTznyByBIyaAyqEfnsXBM)
			{
				if (!hpKBmKklQFBUAZCBUDXiaHmgRQbZ)
				{
					goto IL_000e;
				}
				goto IL_0038;
			}
			return;
			IL_0038:
			eoBDrzjTxJPKesIEIdxkrHuzYrvL(UpdateLoopType.Update);
			int num = 199922615;
			goto IL_0013;
			IL_000e:
			num = 199922613;
			goto IL_0013;
			IL_0013:
			switch (num ^ 0xBEA93B4)
			{
			case 0:
				break;
			case 1:
				return;
			case 2:
				goto IL_0038;
			default:
				GzCliicOSMFLMvKajLgvnmGSSrh(UpdateLoopType.Update);
				KIEzPRxRUsoFFHqeHJExqHIpqcR();
				return;
			}
			goto IL_000e;
		}

		internal static void quspWzJVXrmjPHcaqaRsQonICCC()
		{
			if (yCdeVVnaMRLhGKxJqOLqoMoWnUC != null)
			{
				goto IL_0007;
			}
			goto IL_0064;
			IL_0007:
			int num = -901099925;
			goto IL_000c;
			IL_000c:
			while (true)
			{
				switch (num ^ -901099922)
				{
				case 4:
					break;
				default:
					return;
				case 5:
					yCdeVVnaMRLhGKxJqOLqoMoWnUC.Invoke();
					num = -901099922;
					continue;
				case 6:
					orMAkDPXrmayrtPVORSkgzIzrVb = null;
					num = -901099921;
					continue;
				case 2:
					hZJPCfIEEHEOdtoukvjGAEibgUIb.OnDestroy();
					num = -901099923;
					continue;
				case 0:
					goto IL_0064;
				case 3:
					xOEzrqxxcuFqCTLTGFeLnvqjYLD();
					if (orMAkDPXrmayrtPVORSkgzIzrVb != null)
					{
						orMAkDPXrmayrtPVORSkgzIzrVb.Invoke();
						num = -901099928;
						continue;
					}
					return;
				case 1:
					return;
				}
				break;
			}
			goto IL_0007;
			IL_0064:
			int num2;
			if (hZJPCfIEEHEOdtoukvjGAEibgUIb != null)
			{
				num = -901099924;
				num2 = num;
			}
			else
			{
				num = -901099923;
				num2 = num;
			}
			goto IL_000c;
		}

		internal static void SXofuRsarRbvQZOgnqnsdRXgTwh()
		{
			if (iLmGSiDwkSlWiLkonmvOhUHwQYhe != null)
			{
				iLmGSiDwkSlWiLkonmvOhUHwQYhe.Invoke();
			}
		}

		internal static void UmVdrbCFKTwOPTuExwjdgfMPOzM(bool P_0)
		{
			FKAPECNZHRUvTsBQjzVuBeiYKeb = P_0;
			if (JlcjnOsxtYZFRoDQYarTuTByUtd != EditorPlatform.None)
			{
				return;
			}
			while (PwPWygBTznyByBIyaAyqEfnsXBM)
			{
				while (true)
				{
					IL_003f:
					vlJgPqRvtYWbujUozIEYeDektkL.fSwRDTaRQOOVWaLfOxtPkLuSgHU.Set(P_0);
					vlJgPqRvtYWbujUozIEYeDektkL.fSwRDTaRQOOVWaLfOxtPkLuSgHU.TriggerEvent();
					int num = 1480906547;
					while (true)
					{
						switch (num ^ 0x5844D730)
						{
						case 0:
							num = 1480906546;
							continue;
						default:
							return;
						case 2:
							break;
						case 1:
							goto IL_003f;
						case 3:
							return;
						}
						break;
					}
					break;
				}
			}
		}

		internal static void CYKTSYbnXKEiLBWozMzHDlAGJERW()
		{
			if (!PwPWygBTznyByBIyaAyqEfnsXBM)
			{
				return;
			}
			while (true)
			{
				Action tDhUDprmSgmhhWqCkBVVSSaHgNX = TDhUDprmSgmhhWqCkBVVSSaHgNX;
				int num = -347893925;
				while (true)
				{
					switch (num ^ -347893926)
					{
					case 0:
						goto IL_0008;
					case 2:
						break;
					default:
						if (tDhUDprmSgmhhWqCkBVVSSaHgNX == null)
						{
							return;
						}
						try
						{
							tDhUDprmSgmhhWqCkBVVSSaHgNX();
							return;
						}
						catch (Exception exception)
						{
							while (true)
							{
								int num2 = -347893928;
								while (true)
								{
									switch (num2 ^ -347893926)
									{
									case 0:
										break;
									default:
										return;
									case 2:
										goto IL_005d;
									case 1:
										return;
									}
									break;
									IL_005d:
									HandleCallbackException("ReInput.SceneLoadedEvent", exception);
									num2 = -347893925;
								}
							}
						}
					}
					break;
					IL_0008:
					num = -347893928;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal static HardwareJoystickMap_InputManager GetHardwareJoystickMap_InputManager(BridgedControllerHWInfo bridgedController)
		{
			return OwRRKduusMuBHXVDcuLelTLPlsM.rtTBIFEIPTwHsdFjAgMAbUncZPh(bridgedController);
		}

		internal static HardwareJoystickMap EoOpRBJjGdsjzFYByddrqEnpIABD(Guid P_0)
		{
			return OwRRKduusMuBHXVDcuLelTLPlsM.GetHardwareJoystickMap(P_0);
		}

		internal static HardwareJoystickTemplateMap AkUcEkvnHgqlWfVhjztPFZUUQuC(Guid P_0)
		{
			return OwRRKduusMuBHXVDcuLelTLPlsM.GetJoystickTemplate(P_0);
		}

		internal static IHardwareControllerTemplateMap pSLHqenYotlZJRwsFYENzaJIYfl(Guid P_0)
		{
			return OwRRKduusMuBHXVDcuLelTLPlsM.GetControllerTemplate(P_0);
		}

		internal static IList<HardwareJoystickTemplateMap> quoVIvtygeuHBmJeXGCUKguhrtR(Guid P_0)
		{
			HardwareJoystickMap hardwareJoystickMap = OwRRKduusMuBHXVDcuLelTLPlsM.GetHardwareJoystickMap(P_0);
			string[] templateGuidsOrig = default(string[]);
			Guid guid = default(Guid);
			HardwareJoystickTemplateMap hardwareJoystickTemplateMap = default(HardwareJoystickTemplateMap);
			while (true)
			{
				int num = 2115330509;
				while (true)
				{
					switch (num ^ 0x7E1561C9)
					{
					case 3:
						break;
					case 1:
					{
						if (templateGuidsOrig.Length == 0)
						{
							num = 2115330505;
							continue;
						}
						List<HardwareJoystickTemplateMap> list = null;
						int num3 = 0;
						while (true)
						{
							IL_011e:
							if (num3 < templateGuidsOrig.Length)
							{
								try
								{
									guid = new Guid(templateGuidsOrig[num3]);
								}
								catch
								{
									Logger.LogWarning("Controller Template GUID is invalid: " + templateGuidsOrig[num3]);
									goto IL_00f8;
								}
								hardwareJoystickTemplateMap = AkUcEkvnHgqlWfVhjztPFZUUQuC(guid);
								goto IL_00b3;
							}
							if (list != null)
							{
								break;
							}
							int num4 = 2115330510;
							goto IL_00b8;
							IL_00b3:
							num4 = 2115330508;
							goto IL_00b8;
							IL_00b8:
							while (true)
							{
								switch (num4 ^ 0x7E1561C9)
								{
								case 3:
									break;
								case 0:
									if (list == null)
									{
										list = new List<HardwareJoystickTemplateMap>();
										num4 = 2115330509;
										continue;
									}
									goto case 4;
								case 6:
									goto IL_00f8;
								case 5:
									goto IL_0103;
								case 2:
									goto IL_011e;
								case 1:
									Logger.LogWarning("Controller Template was not found for GUID " + guid.ToString());
									num4 = 2115330511;
									continue;
								case 4:
									ListTools.AddIfUnique(list, hardwareJoystickTemplateMap);
									num4 = 2115330511;
									continue;
								default:
									return EmptyObjects<HardwareJoystickTemplateMap>.EmptyReadOnlyIListT;
								}
								break;
								IL_0103:
								int num5;
								if (!(hardwareJoystickTemplateMap == null))
								{
									num4 = 2115330505;
									num5 = num4;
								}
								else
								{
									num4 = 2115330504;
									num5 = num4;
								}
							}
							goto IL_00b3;
							IL_00f8:
							num3++;
							num4 = 2115330507;
							goto IL_00b8;
						}
						return list;
					}
					case 5:
						return EmptyObjects<HardwareJoystickTemplateMap>.EmptyReadOnlyIListT;
					case 4:
						if (!(hardwareJoystickMap == null))
						{
							templateGuidsOrig = hardwareJoystickMap.GetTemplateGuidsOrig();
							num = 2115330507;
						}
						else
						{
							num = 2115330508;
						}
						continue;
					case 2:
					{
						int num2;
						if (templateGuidsOrig == null)
						{
							num = 2115330505;
							num2 = num;
						}
						else
						{
							num = 2115330504;
							num2 = num;
						}
						continue;
					}
					default:
						return EmptyObjects<HardwareJoystickTemplateMap>.EmptyReadOnlyIListT;
					}
					break;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal static int GetNewJoystickId()
		{
			return akUdmKMbrqFLXkjqdKLUZOPTArx.GqtHeLqyYUhXhHTyUCxQvvzbhJH();
		}

		[CustomObfuscation(rename = false)]
		internal static void HandleCallbackException(string source, Exception exception)
		{
			object[] array = new object[4];
			while (true)
			{
				int num = -1319727351;
				while (true)
				{
					switch (num ^ -1319727349)
					{
					case 0:
						break;
					case 4:
						array[3] = ((exception.InnerException != null) ? exception.InnerException : exception);
						num = -1319727350;
						continue;
					case 3:
						array[2] = "\n\nThis happens if your event handler/callback code throws an exception. This means the error in your code, not Rewired. Read the exception message and the stack trace carefully to find the source of the exception being thrown by your code.\n\nThis can also happen if you forget to unsubscribe to an event in a MonoBehaviour class and that object gets destroyed. Make sure you unsubscribe to events in OnDisable or OnDestroy. Rewired will attempt to continue running.\n\nException:\n";
						num = -1319727345;
						continue;
					case 2:
						array[0] = "An exception occurred inside an event handler or callback.\nSource: ";
						array[1] = source;
						num = -1319727352;
						continue;
					default:
					{
						string msg = string.Concat(array);
						Logger.LogError(msg, requiredThreadSafety: true);
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
			object[] array = new object[4] { "An exception occurred inside an external function call.\nSource: ", source, null, null };
			while (true)
			{
				int num = -2119177633;
				while (true)
				{
					switch (num ^ -2119177634)
					{
					case 3:
						break;
					default:
						return;
					case 1:
						array[2] = "\n\nThis happens if the external function throws an exception. This could indicate the error is in your code if Rewired is calling a function in an interface implementation you created. Read the exception message and the stack trace carefully to find the source of the exception being thrown.\n\nThis can also happen if you forget to unsubscribe to an event in a MonoBehaviour class and that object gets destroyed.\n\nException:\n";
						array[3] = ((exception.InnerException != null) ? exception.InnerException : exception);
						num = -2119177636;
						continue;
					case 2:
					{
						string msg = string.Concat(array);
						Logger.LogError(msg, requiredThreadSafety: true);
						num = -2119177634;
						continue;
					}
					case 0:
						return;
					}
					break;
				}
			}
		}

		internal static void VwhkrGIDxEPPOgFLGvlHoIRGioH()
		{
			if (PwPWygBTznyByBIyaAyqEfnsXBM)
			{
				LJmXKcDqxRDAKLIufgGTZRbRmGI();
			}
		}

		[CustomObfuscation(rename = false)]
		internal static void CheckRewiredVersionCompatibility()
		{
			if (UnityTools.unityVersionObj != null && 2019 != UnityTools.unityVersionObj.major)
			{
				AFWFBpxRtzWbQOfrqghbalEKaxTu();
			}
		}

		internal static float kexzTXbUFjefXrabyjYIBwEspvbK()
		{
			return vlJgPqRvtYWbujUozIEYeDektkL.ROPdHOevPemCWUNKMUKdtMfBEsZA.value;
		}

		[CustomObfuscation(rename = false)]
		internal static bool CheckInitialized()
		{
			if (!PwPWygBTznyByBIyaAyqEfnsXBM)
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

		private static void CTsGPPxUyLPSWLqACIrQDSoNQYOu()
		{
			WhcqAfYYqNfRCEGkYApjWYGKVjr.SdmfoteCDVoXNaSlWEvRMBbwmDy();
			akUdmKMbrqFLXkjqdKLUZOPTArx.SdmfoteCDVoXNaSlWEvRMBbwmDy(hZJPCfIEEHEOdtoukvjGAEibgUIb.GetInputDataUpdateDelegate(), NrWVrlwEDRnzNfQhnCmEXbpqELr.GetInputBehaviors_Copy());
			hZJPCfIEEHEOdtoukvjGAEibgUIb.Initialize();
		}

		private static void xOEzrqxxcuFqCTLTGFeLnvqjYLD()
		{
			List<IExternalInputManager> componentsInSelfAndChildren = default(List<IExternalInputManager>);
			int num = default(int);
			if (oaHYsVKqotUxmLMRdTojIYzEOnG != null)
			{
				componentsInSelfAndChildren = UnityTools.GetComponentsInSelfAndChildren<IExternalInputManager>(oaHYsVKqotUxmLMRdTojIYzEOnG);
				num = 0;
				goto IL_001d;
			}
			goto IL_0220;
			IL_0220:
			oaHYsVKqotUxmLMRdTojIYzEOnG = null;
			int num2 = 1985042064;
			goto IL_0022;
			IL_001d:
			num2 = 1985042072;
			goto IL_0022;
			IL_0022:
			while (true)
			{
				switch (num2 ^ 0x7651569D)
				{
				case 2:
					break;
				default:
					return;
				case 22:
					pPOCiJAXNqcTBvgTPZJeIilAQJwE = null;
					num2 = 1985042057;
					continue;
				case 10:
					akUdmKMbrqFLXkjqdKLUZOPTArx = null;
					WhcqAfYYqNfRCEGkYApjWYGKVjr = null;
					OwRRKduusMuBHXVDcuLelTLPlsM = null;
					num2 = 1985042075;
					continue;
				case 18:
					_id = -1;
					num2 = 1985042078;
					continue;
				case 11:
					foZFIWQSbrQhitlvvhvqPqNIosL();
					num2 = 1985042077;
					continue;
				case 17:
					cyXkQIQKdANaEeictmhYKVnwHui = false;
					hpKBmKklQFBUAZCBUDXiaHmgRQbZ = false;
					FKAPECNZHRUvTsBQjzVuBeiYKeb = true;
					vJvLEAQZqHQqtBrxQQYjRNKqctF = -1;
					num2 = 1985042063;
					continue;
				case 7:
					nGlgCxSDXjwJuhWZtmkxSakDUUE = null;
					pWdFItfmrvfQhrhZtDjerEzolth = null;
					yoiHjWBUVMihBCiXdHEnpldAVqV = null;
					sYesAVWKicAbGyYiDJeDrtnKQxh = null;
					MPSxyXvoClPcOHRiKftJMzoViSR = null;
					yCdeVVnaMRLhGKxJqOLqoMoWnUC = null;
					TDhUDprmSgmhhWqCkBVVSSaHgNX = null;
					num2 = 1985042062;
					continue;
				case 12:
					componentsInSelfAndChildren[num].Deinitialize();
					num++;
					num2 = 1985042061;
					continue;
				case 0:
					vlJgPqRvtYWbujUozIEYeDektkL = null;
					num2 = 1985042067;
					continue;
				case 15:
					_ApplicationFocusChangedEvent = null;
					DaTMhvOTDOeELrbSmCkeeCtjHGFH = null;
					iXvdTEjqULMZzJFpXwYOeuKBXLE = null;
					jFfQodpYnLFdzMQpDeyHFtagLim = null;
					num2 = 1985042074;
					continue;
				case 16:
					goto IL_017c;
				case 5:
					num2 = 1985042061;
					continue;
				case 8:
					pbdljLEcAYJBRAXwyPMCkhsQxAz = WebplayerPlatform.None;
					JlcjnOsxtYZFRoDQYarTuTByUtd = EditorPlatform.None;
					XFCoSmnBJmmgGMgkkApGgxaiwJwt = false;
					num2 = 1985042058;
					continue;
				case 21:
					voLkponRBHpiQNHOfOdnrjJJatj = null;
					wnqGmMFwEOPrgeTWAWNkAgXvkth = UpdateLoopType.Update;
					TxGduWEriXzpLaJgHFbGWOaDcLpz = false;
					VORPOhYHnZnElXbVVvVHXAsptPH = Platform.Windows;
					num2 = 1985042069;
					continue;
				case 14:
					ThreadSafeUnityInput.Deinitialize();
					if (UnityTools.externalTools != null)
					{
						UnityTools.externalTools.EditorPausedStateChangedEvent -= TMQpwufEBflaFFZUDwRxXdkXLcN;
						num2 = 1985042068;
						continue;
					}
					return;
				case 3:
					dShbHpaFaWqRhaXncNRpduaBIzBf = 0;
					num2 = 1985042073;
					continue;
				case 1:
					goto IL_0220;
				case 20:
					PwPWygBTznyByBIyaAyqEfnsXBM = false;
					num2 = 1985042056;
					continue;
				case 4:
					ZLcLOLXVSKeFugchZgnyNPKObmB.Clear();
					iBkUhdNUudWDUSUjKHEzsstzHGt.Clear();
					gqpOqXawDzaUvCOzNqVGzlFKfcj.Clear();
					utkKCdLBfhoxxsXhbCAJlvPingt.Clear();
					iLmGSiDwkSlWiLkonmvOhUHwQYhe.Clear();
					num2 = 1985042066;
					continue;
				case 13:
					hZJPCfIEEHEOdtoukvjGAEibgUIb = null;
					lUCgcEIquFfuykgBneGrfARQlcR = null;
					if (akUdmKMbrqFLXkjqdKLUZOPTArx != null)
					{
						akUdmKMbrqFLXkjqdKLUZOPTArx.Dispose();
						num2 = 1985042071;
						continue;
					}
					goto case 10;
				case 19:
					sgZrtipPgdofXqFFeMmBfjeDpke = null;
					num2 = 1985042070;
					continue;
				case 23:
					wdbCnLsglcIsFknhSwLWQBQgunw = null;
					zihLSZWgVImbQKlwMGYqfGJsEDS = null;
					RweQiXPlkoCYsHFejBNcirKSVMJc = null;
					num2 = 1985042060;
					continue;
				case 6:
					NrWVrlwEDRnzNfQhnCmEXbpqELr = null;
					num2 = 1985042059;
					continue;
				case 9:
					return;
				}
				break;
				IL_017c:
				int num3;
				if (num < componentsInSelfAndChildren.Count)
				{
					num2 = 1985042065;
					num3 = num2;
				}
				else
				{
					num2 = 1985042076;
					num3 = num2;
				}
			}
			goto IL_001d;
		}

		private static void ppJAKHIyHVgcwdgrvOnNMIaDdyJB(string P_0 = null)
		{
			string text;
			if (P_0 != null)
			{
				text = P_0;
				goto IL_0005;
			}
			goto IL_002e;
			IL_002e:
			text = "This function";
			int num = -502561951;
			goto IL_000a;
			IL_0005:
			num = -502561952;
			goto IL_000a;
			IL_000a:
			while (true)
			{
				switch (num ^ -502561951)
				{
				case 3:
					break;
				case 1:
					num = -502561951;
					continue;
				case 2:
					goto IL_002e;
				default:
					Logger.LogError(text + " can only be called in Play mode!");
					return;
				}
				break;
			}
			goto IL_0005;
		}

		private static void CAPxYaYkuVddrltMCElRNfXaths()
		{
			if (!XFCoSmnBJmmgGMgkkApGgxaiwJwt)
			{
				XFCoSmnBJmmgGMgkkApGgxaiwJwt = true;
				while (true)
				{
					int num = -1322499089;
					while (true)
					{
						switch (num ^ -1322499090)
						{
						case 2:
							break;
						case 1:
							unityInputBuffer.tAgADqjTsMUxSqYXeDyJIdETYRAp();
							unityInputBuffer.HaBOvKvUIdSMsntTlUhVuRBYdtG();
							num = -1322499090;
							continue;
						default:
							goto end_IL_000d;
						}
						break;
					}
					continue;
					end_IL_000d:
					break;
				}
			}
			wdbCnLsglcIsFknhSwLWQBQgunw.Start();
		}

		private static void qhpYubDckyjpJAnexwicPXmzqGYu()
		{
			Logger.LogError("Rewired is not initialized. Do you have a Rewired Input Manager in the scene and enabled?");
		}

		private static void PwSRZVQpIbNwCFCQnaehAzRVYALA(BridgedController P_0)
		{
			if (P_0.sourceJoystick == null)
			{
				return;
			}
			while (true)
			{
				akUdmKMbrqFLXkjqdKLUZOPTArx.MJWeKyBbClPTNAqHSJTnvQCzNPib(P_0);
				Joystick joystick = akUdmKMbrqFLXkjqdKLUZOPTArx.JCDhdBcaJPtIabIaCiOxBLwtJEKK(P_0.sourceJoystick.rewiredId);
				if (joystick == null)
				{
					break;
				}
				while (true)
				{
					IL_008a:
					WhcqAfYYqNfRCEGkYApjWYGKVjr.OJyGtzSbKHgFXJYPNuiBAYnpEqg(joystick);
					int num = -1396044893;
					while (true)
					{
						switch (num ^ -1396044891)
						{
						case 3:
							num = -1396044892;
							continue;
						default:
							return;
						case 1:
							break;
						case 5:
							ewWOQSbOTGYETSOKUUbJDipWSiE(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
							num = -1396044889;
							continue;
						case 0:
							goto IL_008a;
						case 6:
							if (!configVars.deferControllerConnectedEventsOnStart)
							{
								goto case 5;
							}
							goto IL_00ab;
						case 4:
							return;
						case 2:
							return;
						}
						break;
						IL_00ab:
						int num2;
						if (!GNGWQVuzRPRhKWsoNHaVFjABYxT)
						{
							num = -1396044896;
							num2 = num;
						}
						else
						{
							num = -1396044895;
							num2 = num;
						}
					}
					break;
				}
			}
		}

		private static void kpDMCmRobliMkbzVroacRXkaxyKC(ControllerDisconnectedEventArgs P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			while (true)
			{
				Joystick joystick = akUdmKMbrqFLXkjqdKLUZOPTArx.JCDhdBcaJPtIabIaCiOxBLwtJEKK(P_0.rewiredId);
				int num;
				int num2;
				if (joystick == null)
				{
					num = -1983224316;
					num2 = num;
				}
				else
				{
					num = -1983224314;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1983224313)
					{
					case 0:
						num = -1983224315;
						continue;
					default:
						return;
					case 2:
						break;
					case 3:
						return;
					case 1:
						akUdmKMbrqFLXkjqdKLUZOPTArx.obzYfvJpmNnOeHtquiLiyGzGVCm(P_0.rewiredId);
						KIzgKAhLflTRjxeStjgCaLuyFjmc(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
						num = -1983224317;
						continue;
					case 4:
						return;
					}
					break;
				}
			}
		}

		private static void ewWOQSbOTGYETSOKUUbJDipWSiE(ControllerStatusChangedEventArgs P_0)
		{
			if (ZLcLOLXVSKeFugchZgnyNPKObmB != null)
			{
				ZLcLOLXVSKeFugchZgnyNPKObmB.Invoke(P_0);
			}
		}

		private static void RBWlNpzgRiHMpzgqctXAShATpnM(ControllerStatusChangedEventArgs P_0)
		{
			if (iBkUhdNUudWDUSUjKHEzsstzHGt != null)
			{
				iBkUhdNUudWDUSUjKHEzsstzHGt.Invoke(P_0);
			}
		}

		private static void KIzgKAhLflTRjxeStjgCaLuyFjmc(ControllerStatusChangedEventArgs P_0)
		{
			if (gqpOqXawDzaUvCOzNqVGzlFKfcj != null)
			{
				gqpOqXawDzaUvCOzNqVGzlFKfcj.Invoke(P_0);
			}
		}

		private static void qgKooMRvkyBFJxENIzGOeknJInz(UpdateControllerInfoEventArgs P_0)
		{
			akUdmKMbrqFLXkjqdKLUZOPTArx.IRJFWJaOnDcODSfXHIEgWEnaWif(P_0);
		}

		private static void MmtcKTFjtpegfEXXVAshFJeAqfIR(bool P_0)
		{
			if (!PwPWygBTznyByBIyaAyqEfnsXBM)
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

		private static void TeTdSQFDBfyhMTySLcZhUekFtvND(bool P_0)
		{
			Action<bool> daTMhvOTDOeELrbSmCkeeCtjHGFH = DaTMhvOTDOeELrbSmCkeeCtjHGFH;
			if (daTMhvOTDOeELrbSmCkeeCtjHGFH == null)
			{
				return;
			}
			try
			{
				daTMhvOTDOeELrbSmCkeeCtjHGFH(P_0);
			}
			catch (Exception exception)
			{
				while (true)
				{
					int num = 1047077214;
					while (true)
					{
						switch (num ^ 0x3E69215F)
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
						HandleCallbackException("ReInput.ApplicationIsFullScreenChangedEvent", exception);
						num = 1047077213;
					}
				}
			}
		}

		private static void ZRdETXebgXHIeEswfZiAjDkOQmO(int P_0)
		{
			if (jFfQodpYnLFdzMQpDeyHFtagLim == null)
			{
				return;
			}
			try
			{
				jFfQodpYnLFdzMQpDeyHFtagLim((FullScreenMode)P_0);
			}
			catch (Exception exception)
			{
				while (true)
				{
					int num = -908672342;
					while (true)
					{
						switch (num ^ -908672341)
						{
						case 2:
							break;
						default:
							return;
						case 1:
							goto IL_0033;
						case 0:
							return;
						}
						break;
						IL_0033:
						HandleCallbackException("ReInput.ApplicationFullScreenModeChangedEvent", exception);
						num = -908672341;
					}
				}
			}
		}

		private static void RXStAaqawBpItGHWqbisCfZGaoi(bool P_0)
		{
			Action<bool> action = iXvdTEjqULMZzJFpXwYOeuKBXLE;
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

		private static void jZzpzqjRLmrTZzhpYjaGFyWRfZ(bool P_0)
		{
			dShbHpaFaWqRhaXncNRpduaBIzBf++;
			Action<bool> action = nGlgCxSDXjwJuhWZtmkxSakDUUE;
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

		private static void yrDhSykWYpUcCbEKhgyafjlZJVZp()
		{
			if (vlJgPqRvtYWbujUozIEYeDektkL == null)
			{
				return;
			}
			while (true)
			{
				foZFIWQSbrQhitlvvhvqPqNIosL();
				int num = -1995667967;
				while (true)
				{
					switch (num ^ -1995667968)
					{
					case 3:
						num = -1995667966;
						continue;
					case 2:
						break;
					case 1:
						vlJgPqRvtYWbujUozIEYeDektkL.fSwRDTaRQOOVWaLfOxtPkLuSgHU.ChangedEvent += MmtcKTFjtpegfEXXVAshFJeAqfIR;
						vlJgPqRvtYWbujUozIEYeDektkL.pUGQlQLhCOMLawdPESoYBBOGGAq.ChangedEvent += TeTdSQFDBfyhMTySLcZhUekFtvND;
						num = -1995667968;
						continue;
					default:
						vlJgPqRvtYWbujUozIEYeDektkL.CQqauVneSzLFCpXUJECBqoaCAzTA.ChangedEvent += RXStAaqawBpItGHWqbisCfZGaoi;
						vlJgPqRvtYWbujUozIEYeDektkL.AXWHETMEhFXfGVXdPEJOIPCYPSJ.ChangedEvent += ZRdETXebgXHIeEswfZiAjDkOQmO;
						vlJgPqRvtYWbujUozIEYeDektkL.HHugaYwSdUtjtVKNHsjMBhHaCsri.ChangedEvent += jZzpzqjRLmrTZzhpYjaGFyWRfZ;
						return;
					}
					break;
				}
			}
		}

		private static void foZFIWQSbrQhitlvvhvqPqNIosL()
		{
			if (vlJgPqRvtYWbujUozIEYeDektkL != null)
			{
				vlJgPqRvtYWbujUozIEYeDektkL.fSwRDTaRQOOVWaLfOxtPkLuSgHU.ChangedEvent -= MmtcKTFjtpegfEXXVAshFJeAqfIR;
				vlJgPqRvtYWbujUozIEYeDektkL.pUGQlQLhCOMLawdPESoYBBOGGAq.ChangedEvent -= TeTdSQFDBfyhMTySLcZhUekFtvND;
				vlJgPqRvtYWbujUozIEYeDektkL.CQqauVneSzLFCpXUJECBqoaCAzTA.ChangedEvent -= RXStAaqawBpItGHWqbisCfZGaoi;
				vlJgPqRvtYWbujUozIEYeDektkL.AXWHETMEhFXfGVXdPEJOIPCYPSJ.ChangedEvent -= ZRdETXebgXHIeEswfZiAjDkOQmO;
				vlJgPqRvtYWbujUozIEYeDektkL.HHugaYwSdUtjtVKNHsjMBhHaCsri.ChangedEvent -= jZzpzqjRLmrTZzhpYjaGFyWRfZ;
			}
		}

		private static void TMQpwufEBflaFFZUDwRxXdkXLcN(bool P_0)
		{
			Action<bool> action = sgZrtipPgdofXqFFeMmBfjeDpke;
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

		private static void nzKJVBylRGKzOZPVGCOtRTDFpUL(Func<ConfigVars, object> P_0)
		{
			bool flag = configVars.DoesPlatformUseFallback(UnityTools.platform, UnityTools.webplayerPlatform, isEditor);
			if (flag)
			{
				goto IL_00c9;
			}
			List<IExternalInputManager> componentsInSelfAndChildren = UnityTools.GetComponentsInSelfAndChildren<IExternalInputManager>(oaHYsVKqotUxmLMRdTojIYzEOnG);
			int num = 0;
			goto IL_00dc;
			IL_00c9:
			int num2;
			if (flag)
			{
				TxGduWEriXzpLaJgHFbGWOaDcLpz = true;
				num2 = -1105842379;
				goto IL_0037;
			}
			goto IL_00f9;
			IL_00dc:
			int num3;
			if (num < componentsInSelfAndChildren.Count)
			{
				num2 = -1105842380;
				num3 = num2;
			}
			else
			{
				num2 = -1105842378;
				num3 = num2;
			}
			goto IL_0037;
			IL_0220:
			if (UnityTools.platform == Platform.WebGL && !isEditor)
			{
				try
				{
					hZJPCfIEEHEOdtoukvjGAEibgUIb = P_0(voLkponRBHpiQNHOfOdnrjJJatj) as PlatformInputManager;
					if (hZJPCfIEEHEOdtoukvjGAEibgUIb == null)
					{
						throw new Exception();
					}
				}
				catch
				{
					while (true)
					{
						IL_0258:
						int num4 = -1105842382;
						while (true)
						{
							switch (num4 ^ -1105842381)
							{
							case 2:
								break;
							default:
								goto end_IL_025d;
							case 1:
								Logger.LogError("WebGL platform could not be initialized! Is the Rewired WebGL library installed? See the documentation for more information.");
								num4 = -1105842384;
								continue;
							case 3:
								hZJPCfIEEHEOdtoukvjGAEibgUIb = null;
								num4 = -1105842381;
								continue;
							case 0:
								goto end_IL_025d;
							}
							goto IL_0258;
							continue;
							end_IL_025d:
							break;
						}
						break;
					}
				}
			}
			else if (UnityTools.platform == Platform.XboxOne && !isEditor)
			{
				try
				{
					XboxOneInputSource customInputSource = new XboxOneInputSource();
					hZJPCfIEEHEOdtoukvjGAEibgUIb = new CustomInputManager(customInputSource, voLkponRBHpiQNHOfOdnrjJJatj.updateLoop, GetHardwareJoystickMap_InputManager, GetNewJoystickId);
					while (true)
					{
						IL_02e8:
						int num5 = -1105842382;
						while (true)
						{
							switch (num5 ^ -1105842381)
							{
							case 2:
								break;
							default:
								goto end_IL_02ed;
							case 1:
							{
								int num6;
								if (hZJPCfIEEHEOdtoukvjGAEibgUIb != null)
								{
									num5 = -1105842384;
									num6 = num5;
								}
								else
								{
									num5 = -1105842381;
									num6 = num5;
								}
								continue;
							}
							case 0:
								throw new Exception();
							case 3:
								goto end_IL_02ed;
							}
							goto IL_02e8;
							continue;
							end_IL_02ed:
							break;
						}
						break;
					}
				}
				catch
				{
					Logger.LogError("Xbox One platform could not be initialized! Is the Rewired Xbox One library installed? See the documentation for more information.");
					hZJPCfIEEHEOdtoukvjGAEibgUIb = null;
				}
			}
			else if (UnityTools.platform == Platform.PS4 && !isEditor)
			{
				try
				{
					PS4InputSource customInputSource2 = new PS4InputSource();
					while (true)
					{
						IL_0367:
						int num7 = -1105842384;
						while (true)
						{
							switch (num7 ^ -1105842381)
							{
							case 2:
								break;
							default:
								goto end_IL_036c;
							case 3:
								goto IL_0389;
							case 0:
								if (hZJPCfIEEHEOdtoukvjGAEibgUIb == null)
								{
									throw new Exception();
								}
								goto end_IL_036c;
							case 1:
								goto end_IL_036c;
							}
							goto IL_0367;
							IL_0389:
							hZJPCfIEEHEOdtoukvjGAEibgUIb = new CustomInputManager(customInputSource2, voLkponRBHpiQNHOfOdnrjJJatj.updateLoop, GetHardwareJoystickMap_InputManager, GetNewJoystickId);
							num7 = -1105842381;
							continue;
							end_IL_036c:
							break;
						}
						break;
					}
				}
				catch
				{
					Logger.LogError("PS4 platform could not be initialized!");
					hZJPCfIEEHEOdtoukvjGAEibgUIb = null;
				}
			}
			else if (UnityTools.platform == Platform.Stadia && !isEditor)
			{
				try
				{
					hZJPCfIEEHEOdtoukvjGAEibgUIb = P_0(voLkponRBHpiQNHOfOdnrjJJatj) as PlatformInputManager;
					if (hZJPCfIEEHEOdtoukvjGAEibgUIb == null)
					{
						throw new Exception("Input Manager was null.");
					}
				}
				catch (Exception msg)
				{
					Logger.LogError("Stadia platform could not be initialized! Is the Rewired Stadia library installed? See the documentation for more information.");
					Logger.LogError(msg);
					hZJPCfIEEHEOdtoukvjGAEibgUIb = null;
				}
			}
			else if ((UnityTools.platform == Platform.GameCoreXboxOne || UnityTools.platform == Platform.GameCoreScarlett) && !isEditor)
			{
				try
				{
					hZJPCfIEEHEOdtoukvjGAEibgUIb = P_0(voLkponRBHpiQNHOfOdnrjJJatj) as PlatformInputManager;
					if (hZJPCfIEEHEOdtoukvjGAEibgUIb == null)
					{
						throw new Exception("Input Manager was null.");
					}
				}
				catch (Exception msg2)
				{
					string text = ((UnityTools.platform == Platform.GameCoreXboxOne) ? "Xbox One" : "Xbox Series X");
					Logger.LogError(text + " platform could not be initialized! Is the Rewired " + text + " library installed? See the documentation for more information.");
					Logger.LogError(msg2);
					hZJPCfIEEHEOdtoukvjGAEibgUIb = null;
				}
			}
			else if (UnityTools.platform == Platform.Ouya && !isEditor)
			{
				try
				{
					Type typeInUnityBuildAssembly = ReflectionTools.GetTypeInUnityBuildAssembly("OuyaSDK", ignoreCase: true);
					if ((object)typeInUnityBuildAssembly == null)
					{
						goto IL_04f9;
					}
					goto IL_057a;
					IL_04f9:
					int num8 = -1105842377;
					goto IL_04fe;
					IL_04fe:
					CustomInputSource customInputSource3 = default(CustomInputSource);
					while (true)
					{
						switch (num8 ^ -1105842381)
						{
						case 6:
							break;
						default:
							goto end_IL_04e5;
						case 4:
							Logger.LogError("OuyaEverywhereSDK was not found! Input may not function. See the documentation for building to the Ouya platform.");
							throw new Exception();
						case 0:
							if (hZJPCfIEEHEOdtoukvjGAEibgUIb == null)
							{
								throw new Exception();
							}
							goto end_IL_04e5;
						case 5:
							goto IL_0558;
						case 1:
							goto IL_057a;
						case 2:
							hZJPCfIEEHEOdtoukvjGAEibgUIb = new CustomInputManager(customInputSource3, voLkponRBHpiQNHOfOdnrjJJatj.updateLoop, GetHardwareJoystickMap_InputManager, GetNewJoystickId);
							num8 = -1105842381;
							continue;
						case 3:
							goto end_IL_04e5;
						}
						break;
					}
					goto IL_04f9;
					IL_057a:
					typeInUnityBuildAssembly = ReflectionTools.GetTypeInUnityBuildAssembly("Rewired.Platforms.Ouya.OuyaInputSource", ignoreCase: true);
					if ((object)typeInUnityBuildAssembly == null)
					{
						Logger.LogError("Required files for Ouya support are missing. Input may not function. Please completely reinstall Rewired.");
						throw new Exception();
					}
					goto IL_0558;
					IL_0558:
					customInputSource3 = (CustomInputSource)Assembly.GetAssembly(typeInUnityBuildAssembly).CreateInstance(typeInUnityBuildAssembly.FullName, ignoreCase: false);
					num8 = -1105842383;
					goto IL_04fe;
					end_IL_04e5:;
				}
				catch
				{
					Logger.LogError("Ouya platform could not be initialized! Please see the documentation for required dependencies. Rewired will fall back to Unity input. All features may not be available.");
					hZJPCfIEEHEOdtoukvjGAEibgUIb = null;
				}
			}
			else if (UnityTools.isAndroidPlatform && !isEditor)
			{
				try
				{
					UnityTools.androidFallbackPlatformHelper = P_0(voLkponRBHpiQNHOfOdnrjJJatj) as IAndroidFallbackPlatformHelper;
				}
				catch (Exception msg3)
				{
					Logger.LogError(msg3);
				}
			}
			goto IL_0622;
			IL_0622:
			if (hZJPCfIEEHEOdtoukvjGAEibgUIb == null)
			{
				TxGduWEriXzpLaJgHFbGWOaDcLpz = true;
				hZJPCfIEEHEOdtoukvjGAEibgUIb = new qePDAvGeOBieqfeOibcNbUsuVSqM(voLkponRBHpiQNHOfOdnrjJJatj.updateLoop);
			}
			return;
			IL_0037:
			while (true)
			{
				switch (num2 ^ -1105842381)
				{
				case 2:
					num2 = -1105842380;
					continue;
				case 7:
					if (componentsInSelfAndChildren[num].Initialize(UnityTools.platform, voLkponRBHpiQNHOfOdnrjJJatj) is PlatformInputManager platformInputManager)
					{
						hZJPCfIEEHEOdtoukvjGAEibgUIb = platformInputManager;
						return;
					}
					goto case 3;
				case 3:
					num++;
					num2 = -1105842381;
					continue;
				case 6:
					hZJPCfIEEHEOdtoukvjGAEibgUIb = new qePDAvGeOBieqfeOibcNbUsuVSqM(voLkponRBHpiQNHOfOdnrjJJatj.updateLoop);
					num2 = -1105842377;
					continue;
				case 5:
					break;
				case 0:
					goto IL_00dc;
				default:
					goto IL_00f9;
				case 4:
					goto IL_0622;
				}
				break;
			}
			goto IL_00c9;
			IL_00f9:
			if (configVars.DoesPlatformUseSDL2(UnityTools.platform, UnityTools.webplayerPlatform, isEditor))
			{
				try
				{
					hZJPCfIEEHEOdtoukvjGAEibgUIb = new RwuqjFZefeIiGvIajuPSbfDUEbG(voLkponRBHpiQNHOfOdnrjJJatj, GetHardwareJoystickMap_InputManager, GetNewJoystickId, handleJoysticks: true, handleUnifiedMouse: false, handleUnifiedKeyboard: false);
					if (hZJPCfIEEHEOdtoukvjGAEibgUIb == null)
					{
						throw new Exception();
					}
				}
				catch
				{
					while (true)
					{
						IL_0151:
						int num9 = -1105842383;
						while (true)
						{
							switch (num9 ^ -1105842381)
							{
							case 0:
								break;
							case 2:
								goto IL_016f;
							default:
								hZJPCfIEEHEOdtoukvjGAEibgUIb = null;
								goto end_IL_0156;
							}
							goto IL_0151;
							IL_016f:
							Logger.LogError("SDL2 could not be initialized! Make sure you have the SDL2 library installed. Please see the documentation for more information. Rewired will fall back to Unity input. Certain features may not be available.");
							num9 = -1105842382;
							continue;
							end_IL_0156:
							break;
						}
						break;
					}
				}
			}
			else
			{
				if (UnityTools.platform != Platform.Windows)
				{
					while (true)
					{
						int num10 = -1105842377;
						while (true)
						{
							switch (num10 ^ -1105842381)
							{
							case 0:
								break;
							case 1:
								goto end_IL_0193;
							case 2:
								goto IL_01da;
							case 4:
								goto IL_01fb;
							default:
								goto IL_0220;
							}
							break;
							IL_01fb:
							if (UnityTools.platform == Platform.WindowsAppStore)
							{
								goto end_IL_0193;
							}
							int num11;
							if (UnityTools.platform == Platform.WindowsUWP)
							{
								num10 = -1105842382;
								num11 = num10;
							}
							else
							{
								num10 = -1105842383;
								num11 = num10;
							}
							continue;
							IL_01da:
							if (UnityTools.platform == Platform.OSX)
							{
								goto end_IL_0193;
							}
							int num12;
							if (UnityTools.platform == Platform.Linux)
							{
								num10 = -1105842382;
								num12 = num10;
							}
							else
							{
								num10 = -1105842384;
								num12 = num10;
							}
						}
						continue;
						end_IL_0193:
						break;
					}
				}
				hZJPCfIEEHEOdtoukvjGAEibgUIb = P_0(voLkponRBHpiQNHOfOdnrjJJatj) as PlatformInputManager;
			}
			goto IL_0622;
		}

		private static void LJmXKcDqxRDAKLIufgGTZRbRmGI()
		{
			if (cyXkQIQKdANaEeictmhYKVnwHui != voLkponRBHpiQNHOfOdnrjJJatj.GetPlatformVar_ignoreInputWhenAppNotInFocus())
			{
				cyXkQIQKdANaEeictmhYKVnwHui = !cyXkQIQKdANaEeictmhYKVnwHui;
			}
		}

		private static void AFWFBpxRtzWbQOfrqghbalEKaxTu()
		{
			if (UnityTools.unityVersionObj == null)
			{
				return;
			}
			while (true)
			{
				object[] array = new object[7] { "The version of Rewired installed (", null, null, null, null, null, null };
				int num = 1085353996;
				while (true)
				{
					switch (num ^ 0x40B13008)
					{
					case 0:
						num = 1085353995;
						continue;
					case 3:
						break;
					case 4:
						array[1] = programVersion;
						array[2] = ") was not designed for Unity ";
						array[3] = UnityTools.unityVersionObj.major;
						array[4] = ". Please install Rewired for Unity ";
						num = 1085353994;
						continue;
					case 2:
						array[5] = UnityTools.unityVersionObj.major;
						num = 1085353993;
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
		private static void MRuNIRScJBCzKesVJREDbwrxsqN(Exception P_0)
		{
			HandleCallbackException("Rewired.ReInput.ControllerConnectedEvent", P_0);
		}

		[CompilerGenerated]
		private static void xgKRCNOfECjNtXItElsStZWhnN(Exception P_0)
		{
			HandleCallbackException("Rewired.ReInput.ControllerPreDisconnectEvent", P_0);
		}

		[CompilerGenerated]
		private static void UFeqhEgKGFWyEwdzzazYcSzMIkO(Exception P_0)
		{
			HandleCallbackException("Rewired.ReInput.ControllerDisconnectedEvent", P_0);
		}

		[CompilerGenerated]
		private static void tGqVjMwzwLbaBupjxYHqTJDfUQk(Exception P_0)
		{
			HandleCallbackException("Rewired.ReInput.InputSourceUpdateEvent", P_0);
		}

		[CompilerGenerated]
		private static void DlWcFrOmzQxVocVCkuNjUmNqcYD(Exception P_0)
		{
			HandleCallbackException("Rewired.ReInput.EditorRecompileEvent", P_0);
		}

		[CompilerGenerated]
		private static void OMGRDcPQxUMVGUBrEVObgeAqauM(Exception P_0)
		{
			HandleCallbackException("Rewired.ReInput.PreShutDownEvent", P_0);
		}

		[CompilerGenerated]
		private static void IGLftfoWsoCzRkwTcccYBNfAKFKL(Exception P_0)
		{
			HandleCallbackException("Rewired.ReInput.ShutDownEvent", P_0);
		}

		[CompilerGenerated]
		private static void McHstAkDXaEPgDyByuTANmKNeCxf(Exception P_0)
		{
			HandleCallbackException("Rewired.ReInput.InitializedEvent", P_0);
		}

		[CompilerGenerated]
		private static void KMtuYkxlRCgKZZiCIyWCaNyDuZH(Exception P_0)
		{
			HandleCallbackException("", P_0);
		}

		[CompilerGenerated]
		private static bool odEVGDEsvIefbhbufVtntMUWmze()
		{
			if (isUnityEditorFocused)
			{
				return isAllowedEditorWindowFocused;
			}
			return false;
		}
	}
}
