using System;
using System.Collections.Generic;
using Rewired.Data.Mapping;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.Data
{
	public sealed class ControllerDataFiles : ScriptableObject
	{
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private HardwareJoystickMap defaultHardwareJoystickMap;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private HardwareJoystickMap[] hardwareJoystickMaps;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private HardwareJoystickTemplateMap[] joystickTemplates;

		[NonSerialized]
		private bool HAowDhQPepsRrtyHertvLKfYDig;

		public Guid defaultHardwareJoystickMapGuid
		{
			get
			{
				if (!(defaultHardwareJoystickMap == null))
				{
					return defaultHardwareJoystickMap.Guid;
				}
				return Guid.Empty;
			}
		}

		public HardwareJoystickTemplateMap[] JoystickTemplates
		{
			get
			{
				return joystickTemplates;
			}
			set
			{
				joystickTemplates = value;
			}
		}

		public HardwareJoystickMap[] HardwareJoystickMaps
		{
			get
			{
				return hardwareJoystickMaps;
			}
			set
			{
				hardwareJoystickMaps = value;
			}
		}

		public HardwareJoystickMap DefaultHardwareJoystickMap
		{
			get
			{
				return defaultHardwareJoystickMap;
			}
			set
			{
				defaultHardwareJoystickMap = value;
			}
		}

		public string[] GetJoystickNames()
		{
			if (hardwareJoystickMaps == null)
			{
				return null;
			}
			List<string> list = new List<string>();
			int num2 = default(int);
			while (true)
			{
				int num = 1231915795;
				while (true)
				{
					switch (num ^ 0x496D8B17)
					{
					case 0:
						break;
					case 5:
						num2++;
						num = 1231915796;
						continue;
					case 3:
					{
						int num3;
						if (num2 < hardwareJoystickMaps.Length)
						{
							num = 1231915797;
							num3 = num;
						}
						else
						{
							num = 1231915798;
							num3 = num;
						}
						continue;
					}
					case 4:
						num2 = 0;
						num = 1231915796;
						continue;
					case 2:
						if (!(hardwareJoystickMaps[num2] == null) && !hardwareJoystickMaps[num2].HideInLists)
						{
							list.Add(hardwareJoystickMaps[num2].ControllerName);
							num = 1231915794;
							continue;
						}
						goto case 5;
					default:
						list.Insert(0, defaultHardwareJoystickMap.ControllerName);
						return list.ToArray();
					}
					break;
				}
			}
		}

		public string[] GetEditorJoystickNames()
		{
			if (hardwareJoystickMaps == null)
			{
				return null;
			}
			List<string> list = new List<string>();
			int num = 0;
			while (num < hardwareJoystickMaps.Length)
			{
				while (true)
				{
					int num2;
					if (!(hardwareJoystickMaps[num] == null))
					{
						int num3;
						if (hardwareJoystickMaps[num].HideInLists)
						{
							num2 = -1139835576;
							num3 = num2;
						}
						else
						{
							num2 = -1139835574;
							num3 = num2;
						}
						goto IL_001c;
					}
					goto IL_00a0;
					IL_001c:
					while (true)
					{
						switch (num2 ^ -1139835569)
						{
						case 0:
							num2 = -1139835573;
							continue;
						case 4:
							break;
						case 1:
							list.Add(hardwareJoystickMaps[num].ControllerName);
							num2 = -1139835576;
							continue;
						case 2:
							num2 = -1139835576;
							continue;
						case 7:
							goto IL_00a0;
						case 6:
							list.Add(hardwareJoystickMaps[num].EditorControllerName);
							num2 = -1139835571;
							continue;
						case 5:
							goto IL_00cb;
						default:
							goto end_IL_004c;
						}
						break;
						IL_00cb:
						int num4;
						if (string.IsNullOrEmpty(hardwareJoystickMaps[num].EditorControllerName))
						{
							num2 = -1139835570;
							num4 = num2;
						}
						else
						{
							num2 = -1139835575;
							num4 = num2;
						}
					}
					continue;
					IL_00a0:
					num++;
					num2 = -1139835572;
					goto IL_001c;
					continue;
					end_IL_004c:
					break;
				}
			}
			list.Insert(0, defaultHardwareJoystickMap.ControllerName);
			return list.ToArray();
		}

		public Guid[] GetJoystickGuids()
		{
			if (hardwareJoystickMaps == null)
			{
				return null;
			}
			List<Guid> list = new List<Guid>();
			int num2 = default(int);
			while (true)
			{
				int num = -1214104642;
				while (true)
				{
					switch (num ^ -1214104646)
					{
					case 3:
						break;
					case 4:
						num2 = 0;
						num = -1214104641;
						continue;
					case 2:
						num2++;
						num = -1214104641;
						continue;
					case 1:
					{
						int num3;
						if (hardwareJoystickMaps[num2] == null)
						{
							num = -1214104648;
							num3 = num;
						}
						else
						{
							num = -1214104646;
							num3 = num;
						}
						continue;
					}
					case 0:
						if (!hardwareJoystickMaps[num2].HideInLists)
						{
							list.Add(hardwareJoystickMaps[num2].Guid);
							num = -1214104648;
							continue;
						}
						goto case 2;
					default:
						if (num2 >= hardwareJoystickMaps.Length)
						{
							list.Insert(0, defaultHardwareJoystickMap.Guid);
							return list.ToArray();
						}
						goto case 1;
					}
					break;
				}
			}
		}

		public string[] GetJoystickTemplateNames()
		{
			if (joystickTemplates == null)
			{
				return null;
			}
			List<string> list = new List<string>();
			int num2 = default(int);
			while (true)
			{
				int num = 1646481185;
				while (true)
				{
					switch (num ^ 0x62234F24)
					{
					case 0:
						break;
					case 5:
						num2 = 0;
						num = 1646481184;
						continue;
					case 1:
						if (!(joystickTemplates[num2] == null))
						{
							list.Add(joystickTemplates[num2].ControllerName);
							num = 1646481190;
							continue;
						}
						goto case 2;
					case 4:
					{
						int num3;
						if (num2 >= joystickTemplates.Length)
						{
							num = 1646481191;
							num3 = num;
						}
						else
						{
							num = 1646481189;
							num3 = num;
						}
						continue;
					}
					case 2:
						num2++;
						num = 1646481184;
						continue;
					default:
						return list.ToArray();
					}
					break;
				}
			}
		}

		public Guid[] GetJoystickTemplateGuids()
		{
			if (joystickTemplates == null)
			{
				goto IL_0008;
			}
			List<Guid> list = new List<Guid>();
			int num = 0;
			int num2 = 1236809012;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ 0x49B83534)
				{
				case 3:
					break;
				case 1:
					num++;
					num2 = 1236809009;
					continue;
				case 0:
					num2 = 1236809009;
					continue;
				case 2:
				{
					int num3;
					if (!(joystickTemplates[num] == null))
					{
						num2 = 1236809010;
						num3 = num2;
					}
					else
					{
						num2 = 1236809013;
						num3 = num2;
					}
					continue;
				}
				case 6:
					list.Add(joystickTemplates[num].Guid);
					num2 = 1236809013;
					continue;
				case 4:
					return null;
				default:
					if (num >= joystickTemplates.Length)
					{
						return list.ToArray();
					}
					goto case 2;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = 1236809008;
			goto IL_000d;
		}

		public HardwareJoystickMap GetHardwareJoystickMap(Guid guid)
		{
			if (hardwareJoystickMaps == null)
			{
				goto IL_0008;
			}
			if (guid == defaultHardwareJoystickMap.Guid)
			{
				return defaultHardwareJoystickMap;
			}
			int num = 0;
			int num2 = -201462494;
			goto IL_000d;
			IL_0008:
			num2 = -201462489;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ -201462490)
				{
				case 0:
					break;
				case 4:
				{
					int num3;
					if (num >= hardwareJoystickMaps.Length)
					{
						num2 = -201462492;
						num3 = num2;
					}
					else
					{
						num2 = -201462491;
						num3 = num2;
					}
					continue;
				}
				case 3:
					if (!(hardwareJoystickMaps[num] == null) && hardwareJoystickMaps[num].Guid == guid)
					{
						return hardwareJoystickMaps[num];
					}
					num++;
					num2 = -201462494;
					continue;
				case 1:
					return null;
				default:
					return null;
				}
				break;
			}
			goto IL_0008;
		}

		public HardwareJoystickTemplateMap GetJoystickTemplate(Guid guid)
		{
			if (joystickTemplates == null)
			{
				return null;
			}
			int num = 0;
			while (num < joystickTemplates.Length)
			{
				while (true)
				{
					if (!(joystickTemplates[num] == null) && joystickTemplates[num].Guid == guid)
					{
						return joystickTemplates[num];
					}
					num++;
					int num2 = -369055160;
					while (true)
					{
						switch (num2 ^ -369055160)
						{
						case 2:
							num2 = -369055159;
							continue;
						case 1:
							break;
						default:
							goto end_IL_002c;
						}
						break;
					}
					continue;
					end_IL_002c:
					break;
				}
			}
			return null;
		}

		public IHardwareControllerTemplateMap GetControllerTemplate(Guid guid)
		{
			return GetJoystickTemplate(guid);
		}

		public IHardwareControllerMap GetHardwareJoystickOrTemplateMap(Guid guid)
		{
			HardwareJoystickMap hardwareJoystickMap = GetHardwareJoystickMap(guid);
			if (hardwareJoystickMap != null)
			{
				return hardwareJoystickMap;
			}
			return GetJoystickTemplate(guid);
		}

		internal ControllerTemplateElementIdentifier dkzdqVbbCuZSSnRZYtTdtTrOfvn(Guid P_0, int P_1)
		{
			if (P_1 < 0)
			{
				return null;
			}
			if (P_0 == Guid.Empty)
			{
				return null;
			}
			HardwareJoystickMap hardwareJoystickMap = GetHardwareJoystickMap(P_0);
			if (hardwareJoystickMap == null)
			{
				return null;
			}
			using (IEnumerator<Guid> enumerator = hardwareJoystickMap.TemplateGuids.GetEnumerator())
			{
				HardwareJoystickTemplateMap joystickTemplate = default(HardwareJoystickTemplateMap);
				ControllerTemplateElementIdentifier result = default(ControllerTemplateElementIdentifier);
				while (true)
				{
					IL_006a:
					int num;
					int num2;
					if (!enumerator.MoveNext())
					{
						num = 1660906429;
						num2 = num;
					}
					else
					{
						num = 1660906430;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ 0x62FF6BBF)
						{
						case 3:
							num = 1660906430;
							continue;
						default:
							goto end_IL_003c;
						case 5:
							break;
						case 1:
						{
							Guid current = enumerator.Current;
							joystickTemplate = GetJoystickTemplate(current);
							num = 1660906431;
							continue;
						}
						case 0:
							if (!(joystickTemplate == null))
							{
								ControllerTemplateElementIdentifier controllerTemplateElementIdentifier = joystickTemplate.kZyebRAzUtSAJHkfiJvLlRHqLYz(P_0, P_1);
								if (controllerTemplateElementIdentifier != null)
								{
									result = controllerTemplateElementIdentifier;
									num = 1660906427;
									continue;
								}
							}
							break;
						case 2:
							goto end_IL_003c;
						case 4:
							return result;
						}
						goto IL_006a;
						continue;
						end_IL_003c:
						break;
					}
					break;
				}
			}
			return null;
		}

		internal HardwareJoystickMap_InputManager PPCLNwHdBLXamGlKfICMfvrfIOyx(Guid P_0, InputSource P_1)
		{
			SRurRvrLfzEucSwNsnDoLzRlLVf();
			BridgedController bridgedController2 = default(BridgedController);
			while (true)
			{
				int num = 1039815523;
				while (true)
				{
					switch (num ^ 0x3DFA5360)
					{
					case 0:
						break;
					case 3:
						bridgedController2 = new BridgedController();
						bridgedController2.isMock = true;
						bridgedController2.inputManagerSource = P_1;
						num = 1039815521;
						continue;
					case 1:
						bridgedController2.inputSource = P_1;
						num = 1039815522;
						continue;
					default:
					{
						BridgedController bridgedController = bridgedController2;
						HardwareJoystickMap hardwareJoystickMap = GetHardwareJoystickMap(P_0);
						if (hardwareJoystickMap != null)
						{
							InputPlatform inputPlatform;
							int num2;
							HardwareJoystickMap.Platform platform;
							HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager = HyNbegFTTSJlzYLwJEkPGSwEDHor(hardwareJoystickMap, bridgedController, true, out inputPlatform, out num2, out platform);
							if (hardwareJoystickMap_InputManager != null)
							{
								return hardwareJoystickMap_InputManager;
							}
						}
						return defaultHardwareJoystickMap.GetDefaultHardwareJoystickMap_InputManager(bridgedController.inputSource);
					}
					}
					break;
				}
			}
		}

		internal HardwareJoystickMap_InputManager pFLIeNMFmNtfEwbFvGhBCCBfeRDd(BridgedControllerHWInfo P_0)
		{
			if (P_0 == null)
			{
				goto IL_0006;
			}
			SRurRvrLfzEucSwNsnDoLzRlLVf();
			int num = 104200029;
			goto IL_000b;
			IL_000b:
			int num2 = default(int);
			int num4 = default(int);
			HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager2 = default(HardwareJoystickMap_InputManager);
			HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager = default(HardwareJoystickMap_InputManager);
			while (true)
			{
				switch (num ^ 0x635F75B)
				{
				case 11:
					break;
				case 4:
				{
					int num7;
					if (num2 >= hardwareJoystickMaps.Length)
					{
						num = 104200025;
						num7 = num;
					}
					else
					{
						num = 104200026;
						num7 = num;
					}
					continue;
				}
				case 2:
					num4 = 0;
					num = 104200017;
					continue;
				case 0:
				{
					InputPlatform inputPlatform2;
					int num5;
					HardwareJoystickMap.Platform platform2;
					HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager4 = HyNbegFTTSJlzYLwJEkPGSwEDHor(hardwareJoystickMaps[num4], P_0, false, out inputPlatform2, out num5, out platform2);
					if (hardwareJoystickMap_InputManager4 != null)
					{
						return hardwareJoystickMap_InputManager4;
					}
					num4++;
					num = 104200017;
					continue;
				}
				case 12:
					hardwareJoystickMap_InputManager2.useSystemName = true;
					return hardwareJoystickMap_InputManager2;
				case 7:
					hardwareJoystickMap_InputManager = CZYkTkvTUJSUUwZZlqJAHYyQAZi(P_0);
					num = 104200019;
					continue;
				case 5:
				{
					HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager5 = CZYkTkvTUJSUUwZZlqJAHYyQAZi(P_0);
					if (hardwareJoystickMap_InputManager5 != null)
					{
						return hardwareJoystickMap_InputManager5;
					}
					goto IL_00f3;
				}
				case 9:
					if (P_0.inputSource == InputSource.Fallback_PreConfigured)
					{
						hardwareJoystickMap_InputManager2 = udryzKePmWXjEirBkqvkNJZANNJ(P_0, "[UNITY PRECONFIGURED JOYSTICK]");
						if (hardwareJoystickMap_InputManager2 != null)
						{
							num = 104200023;
							continue;
						}
					}
					if (UnityTools.isAndroidPlatform && ReInput.configVars.android_supportUnknownGamepads)
					{
						num = 104200028;
						continue;
					}
					goto IL_01a6;
				case 10:
				{
					int num6;
					if (num4 >= hardwareJoystickMaps.Length)
					{
						num = 104200018;
						num6 = num;
					}
					else
					{
						num = 104200027;
						num6 = num;
					}
					continue;
				}
				case 6:
					if (P_0.inputSource == InputSource.SDL2 && P_0.hw_isSDL2Gamepad)
					{
						num = 104200030;
						continue;
					}
					goto IL_00f3;
				case 3:
					return null;
				case 1:
				{
					InputPlatform inputPlatform;
					int num3;
					HardwareJoystickMap.Platform platform;
					HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager3 = HyNbegFTTSJlzYLwJEkPGSwEDHor(hardwareJoystickMaps[num2], P_0, true, out inputPlatform, out num3, out platform);
					if (hardwareJoystickMap_InputManager3 != null)
					{
						return hardwareJoystickMap_InputManager3;
					}
					num2++;
					num = 104200031;
					continue;
				}
				default:
					{
						if (hardwareJoystickMap_InputManager != null)
						{
							return hardwareJoystickMap_InputManager;
						}
						goto IL_01a6;
					}
					IL_00f3:
					num2 = 0;
					num = 104200031;
					continue;
					IL_01a6:
					return defaultHardwareJoystickMap.GetDefaultHardwareJoystickMap_InputManager(P_0.inputSource);
				}
				break;
			}
			goto IL_0006;
			IL_0006:
			num = 104200024;
			goto IL_000b;
		}

		private HardwareJoystickMap_InputManager HyNbegFTTSJlzYLwJEkPGSwEDHor(HardwareJoystickMap P_0, BridgedControllerHWInfo P_1, bool P_2, out InputPlatform P_3, out int P_4, out HardwareJoystickMap.Platform P_5)
		{
			P_3 = InputPlatform.srbgNzJMznryeuABhpjzUCNZxjJP;
			P_4 = -1;
			HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager = default(HardwareJoystickMap_InputManager);
			while (true)
			{
				int num = -715821993;
				while (true)
				{
					switch (num ^ -715821994)
					{
					case 0:
						break;
					case 1:
						P_5 = null;
						if (P_0 == null)
						{
							return null;
						}
						if (P_0.Matches(P_1, P_2, false, out P_3, out P_4, out P_5))
						{
							goto IL_0048;
						}
						return null;
					default:
						if (hardwareJoystickMap_InputManager == null)
						{
							return null;
						}
						return hardwareJoystickMap_InputManager;
					}
					break;
					IL_0048:
					hardwareJoystickMap_InputManager = P_5.ToHardwareJoystickMap_InputManager(P_0, P_1.inputSource, P_3, P_4);
					num = -715821996;
				}
			}
		}

		private HardwareJoystickMap_InputManager udryzKePmWXjEirBkqvkNJZANNJ(BridgedControllerHWInfo P_0, string P_1)
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo(P_0);
			bridgedControllerHWInfo.hw_productName = P_1;
			bridgedControllerHWInfo.hardwareButtonCount = 0;
			bridgedControllerHWInfo.hardwareAxisCount = 0;
			int num2 = default(int);
			HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager = default(HardwareJoystickMap_InputManager);
			while (true)
			{
				int num = 1471725217;
				while (true)
				{
					switch (num ^ 0x57B8BEA0)
					{
					case 2:
						break;
					case 1:
						bridgedControllerHWInfo.hardwareHatCount = 0;
						num2 = 0;
						num = 1471725220;
						continue;
					case 5:
					{
						InputPlatform actualInputPlatform;
						int variantIndex;
						HardwareJoystickMap.Platform platformMap;
						if (hardwareJoystickMaps[num2].Matches(bridgedControllerHWInfo, false, false, out actualInputPlatform, out variantIndex, out platformMap))
						{
							hardwareJoystickMap_InputManager = platformMap.ToHardwareJoystickMap_InputManager(hardwareJoystickMaps[num2], P_0.inputSource, actualInputPlatform, variantIndex);
							num = 1471725222;
							continue;
						}
						goto IL_00d5;
					}
					case 4:
					{
						int num3;
						if (num2 < hardwareJoystickMaps.Length)
						{
							num = 1471725219;
							num3 = num;
						}
						else
						{
							num = 1471725216;
							num3 = num;
						}
						continue;
					}
					case 3:
						if (!(hardwareJoystickMaps[num2] == null))
						{
							num = 1471725221;
							continue;
						}
						goto IL_00d5;
					case 6:
						if (hardwareJoystickMap_InputManager != null)
						{
							return hardwareJoystickMap_InputManager;
						}
						goto IL_00d5;
					default:
						{
							return null;
						}
						IL_00d5:
						num2++;
						num = 1471725220;
						continue;
					}
					break;
				}
			}
		}

		private HardwareJoystickMap_InputManager CZYkTkvTUJSUUwZZlqJAHYyQAZi(BridgedControllerHWInfo P_0)
		{
			HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager = udryzKePmWXjEirBkqvkNJZANNJ(P_0, "[STANDARDIZED GAMEPAD]");
			while (true)
			{
				int num = 1745267370;
				while (true)
				{
					switch (num ^ 0x6806AAAB)
					{
					case 0:
						break;
					case 1:
						if (hardwareJoystickMap_InputManager != null)
						{
							goto IL_0030;
						}
						return null;
					default:
						return hardwareJoystickMap_InputManager;
					}
					break;
					IL_0030:
					hardwareJoystickMap_InputManager.useSystemName = true;
					num = 1745267369;
				}
			}
		}

		private void SRurRvrLfzEucSwNsnDoLzRlLVf()
		{
			if (HAowDhQPepsRrtyHertvLKfYDig)
			{
				return;
			}
			while (!ArrayTools.IsNullOrEmpty(hardwareJoystickMaps) && !(defaultHardwareJoystickMap == null))
			{
				int num;
				int num2;
				if (ArrayTools.IsNullOrEmpty(joystickTemplates))
				{
					num = 1255562303;
					num2 = num;
				}
				else
				{
					num = 1255562300;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x4AD65C3E)
					{
					case 0:
						num = 1255562301;
						continue;
					case 3:
						break;
					case 1:
						goto end_IL_002b;
					default:
						HAowDhQPepsRrtyHertvLKfYDig = true;
						return;
					}
					break;
				}
				continue;
				end_IL_002b:
				break;
			}
			Logger.LogError("ControllerDataFiles is missing critical data! The serialized data may have been corrupted. Please see the Known Issues in the documentation for possible causes and solutions.");
		}
	}
}
