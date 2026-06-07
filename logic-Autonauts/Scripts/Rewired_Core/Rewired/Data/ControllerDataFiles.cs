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

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private HardwareJoystickTemplateMap[] joystickTemplates;

		[NonSerialized]
		private bool uOwAYccruzzNORyQAmlloPjCVEz;

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
				goto IL_0008;
			}
			List<string> list = new List<string>();
			int num = 0;
			int num2 = 292830953;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ 0x11743EEA)
				{
				case 4:
					break;
				case 1:
					return null;
				case 0:
					if (!(hardwareJoystickMaps[num] == null) && !hardwareJoystickMaps[num].HideInLists)
					{
						list.Add(hardwareJoystickMaps[num].ControllerName);
						num2 = 292830952;
						continue;
					}
					goto case 2;
				case 2:
					num++;
					num2 = 292830953;
					continue;
				default:
					if (num >= hardwareJoystickMaps.Length)
					{
						list.Insert(0, defaultHardwareJoystickMap.ControllerName);
						return list.ToArray();
					}
					goto case 0;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = 292830955;
			goto IL_000d;
		}

		public string[] GetEditorJoystickNames()
		{
			if (hardwareJoystickMaps == null)
			{
				goto IL_0008;
			}
			List<string> list = new List<string>();
			int num = 0;
			int num2 = 289028734;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ 0x113A3A7B)
				{
				case 8:
					break;
				case 7:
					return null;
				case 4:
					num2 = 289028728;
					continue;
				case 9:
				{
					int num3;
					if (hardwareJoystickMaps[num] == null)
					{
						num2 = 289028728;
						num3 = num2;
					}
					else
					{
						num2 = 289028733;
						num3 = num2;
					}
					continue;
				}
				case 3:
					num++;
					num2 = 289028734;
					continue;
				case 2:
					list.Add(hardwareJoystickMaps[num].ControllerName);
					num2 = 289028728;
					continue;
				case 0:
					list.Insert(0, defaultHardwareJoystickMap.ControllerName);
					num2 = 289028730;
					continue;
				case 5:
				{
					int num4;
					if (num >= hardwareJoystickMaps.Length)
					{
						num2 = 289028731;
						num4 = num2;
					}
					else
					{
						num2 = 289028722;
						num4 = num2;
					}
					continue;
				}
				case 6:
					if (hardwareJoystickMaps[num].HideInLists)
					{
						goto case 3;
					}
					if (!string.IsNullOrEmpty(hardwareJoystickMaps[num].EditorControllerName))
					{
						list.Add(hardwareJoystickMaps[num].EditorControllerName);
						num2 = 289028735;
						continue;
					}
					goto case 2;
				default:
					return list.ToArray();
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = 289028732;
			goto IL_000d;
		}

		public Guid[] GetJoystickGuids()
		{
			if (hardwareJoystickMaps == null)
			{
				goto IL_0008;
			}
			List<Guid> list = new List<Guid>();
			int num = 0;
			int num2 = 1396244047;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ 0x5338FE4C)
				{
				case 2:
					break;
				case 1:
					return null;
				case 0:
					if (!(hardwareJoystickMaps[num] == null) && !hardwareJoystickMaps[num].HideInLists)
					{
						list.Add(hardwareJoystickMaps[num].Guid);
						num2 = 1396244040;
						continue;
					}
					goto case 4;
				case 4:
					num++;
					num2 = 1396244047;
					continue;
				case 3:
					if (num >= hardwareJoystickMaps.Length)
					{
						list.Insert(0, defaultHardwareJoystickMap.Guid);
						num2 = 1396244041;
						continue;
					}
					goto case 0;
				default:
					return list.ToArray();
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = 1396244045;
			goto IL_000d;
		}

		public string[] GetJoystickTemplateNames()
		{
			if (joystickTemplates == null)
			{
				return null;
			}
			List<string> list = new List<string>();
			int num = 0;
			while (num < joystickTemplates.Length)
			{
				while (true)
				{
					int num2;
					if (!(joystickTemplates[num] == null))
					{
						list.Add(joystickTemplates[num].ControllerName);
						num2 = -1462738076;
						goto IL_0019;
					}
					goto IL_0060;
					IL_0019:
					while (true)
					{
						switch (num2 ^ -1462738075)
						{
						case 0:
							num2 = -1462738074;
							continue;
						case 3:
							break;
						case 1:
							goto IL_0060;
						default:
							goto end_IL_0036;
						}
						break;
					}
					continue;
					IL_0060:
					num++;
					num2 = -1462738073;
					goto IL_0019;
					continue;
					end_IL_0036:
					break;
				}
			}
			return list.ToArray();
		}

		public Guid[] GetJoystickTemplateGuids()
		{
			if (joystickTemplates == null)
			{
				return null;
			}
			List<Guid> list = new List<Guid>();
			int num = 0;
			while (num < joystickTemplates.Length)
			{
				while (true)
				{
					int num2;
					int num3;
					if (joystickTemplates[num] == null)
					{
						num2 = -316084015;
						num3 = num2;
					}
					else
					{
						num2 = -316084014;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ -316084016)
						{
						case 0:
							num2 = -316084013;
							continue;
						case 3:
							break;
						case 1:
							num++;
							num2 = -316084012;
							continue;
						case 2:
							list.Add(joystickTemplates[num].Guid);
							num2 = -316084015;
							continue;
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
			return list.ToArray();
		}

		public HardwareJoystickMap GetHardwareJoystickMap(Guid guid)
		{
			if (hardwareJoystickMaps == null)
			{
				return null;
			}
			if (guid == defaultHardwareJoystickMap.Guid)
			{
				return defaultHardwareJoystickMap;
			}
			int num = 0;
			while (num < hardwareJoystickMaps.Length)
			{
				while (true)
				{
					if (!(hardwareJoystickMaps[num] == null) && hardwareJoystickMaps[num].Guid == guid)
					{
						return hardwareJoystickMaps[num];
					}
					num++;
					int num2 = 930439695;
					while (true)
					{
						switch (num2 ^ 0x3775620D)
						{
						case 0:
							num2 = 930439692;
							continue;
						case 1:
							break;
						default:
							goto end_IL_0046;
						}
						break;
					}
					continue;
					end_IL_0046:
					break;
				}
			}
			return null;
		}

		public HardwareJoystickTemplateMap GetJoystickTemplate(Guid guid)
		{
			if (joystickTemplates == null)
			{
				goto IL_0008;
			}
			int num = 0;
			int num2 = 715710452;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ 0x2AA8DFF1)
				{
				case 0:
					break;
				case 4:
					if (joystickTemplates[num].Guid == guid)
					{
						num2 = 715710450;
						continue;
					}
					goto IL_006e;
				case 2:
					if (!(joystickTemplates[num] == null))
					{
						num2 = 715710453;
						continue;
					}
					goto IL_006e;
				case 3:
					return joystickTemplates[num];
				case 1:
					return null;
				default:
					{
						if (num >= joystickTemplates.Length)
						{
							return null;
						}
						goto case 2;
					}
					IL_006e:
					num++;
					num2 = 715710452;
					continue;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = 715710448;
			goto IL_000d;
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

		internal ControllerTemplateElementIdentifier WhDeUxPrsOgrEHWkzdrHUJUQwmi(Guid P_0, int P_1)
		{
			if (P_1 < 0)
			{
				return null;
			}
			if (P_0 == Guid.Empty)
			{
				goto IL_0013;
			}
			HardwareJoystickMap hardwareJoystickMap = GetHardwareJoystickMap(P_0);
			int num;
			if (hardwareJoystickMap == null)
			{
				num = 1226801510;
				goto IL_0018;
			}
			using (IEnumerator<Guid> enumerator = hardwareJoystickMap.TemplateGuids.GetEnumerator())
			{
				HardwareJoystickTemplateMap joystickTemplate = default(HardwareJoystickTemplateMap);
				ControllerTemplateElementIdentifier result = default(ControllerTemplateElementIdentifier);
				while (true)
				{
					IL_00cf:
					int num2;
					int num3;
					if (!enumerator.MoveNext())
					{
						num2 = 1226801506;
						num3 = num2;
					}
					else
					{
						num2 = 1226801509;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ 0x491F8167)
						{
						case 4:
							num2 = 1226801509;
							continue;
						default:
							goto end_IL_0061;
						case 1:
						{
							ControllerTemplateElementIdentifier controllerTemplateElementIdentifier = joystickTemplate.RZwfCQeddpzqevuWGXSHMZWwIdo(P_0, P_1);
							if (controllerTemplateElementIdentifier != null)
							{
								result = controllerTemplateElementIdentifier;
								num2 = 1226801511;
								continue;
							}
							break;
						}
						case 2:
						{
							Guid current = enumerator.Current;
							joystickTemplate = GetJoystickTemplate(current);
							int num4;
							if (joystickTemplate == null)
							{
								num2 = 1226801508;
								num4 = num2;
							}
							else
							{
								num2 = 1226801510;
								num4 = num2;
							}
							continue;
						}
						case 3:
							break;
						case 5:
							goto end_IL_0061;
						case 0:
							return result;
						}
						goto IL_00cf;
						continue;
						end_IL_0061:
						break;
					}
					break;
				}
			}
			return null;
			IL_0013:
			num = 1226801509;
			goto IL_0018;
			IL_0018:
			switch (num ^ 0x491F8167)
			{
			case 0:
				break;
			case 2:
				return null;
			default:
				return null;
			}
			goto IL_0013;
		}

		internal HardwareJoystickMap_InputManager sqUGKjnZXTMNHehVVcGMEExpNDnK(Guid P_0, InputSource P_1)
		{
			lpacOKZgNhpOHawbWhhBytntQhC();
			BridgedController bridgedController2 = default(BridgedController);
			BridgedController bridgedController = default(BridgedController);
			HardwareJoystickMap hardwareJoystickMap = default(HardwareJoystickMap);
			HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager = default(HardwareJoystickMap_InputManager);
			while (true)
			{
				int num = 1004556993;
				while (true)
				{
					switch (num ^ 0x3BE052C2)
					{
					case 0:
						break;
					case 3:
						bridgedController2 = new BridgedController();
						bridgedController2.isMock = true;
						bridgedController2.inputManagerSource = P_1;
						bridgedController2.inputSource = P_1;
						num = 1004556998;
						continue;
					case 4:
						bridgedController = bridgedController2;
						hardwareJoystickMap = GetHardwareJoystickMap(P_0);
						if (hardwareJoystickMap != null)
						{
							num = 1004556992;
							continue;
						}
						goto IL_008c;
					case 2:
					{
						InputPlatform inputPlatform;
						int num2;
						HardwareJoystickMap.Platform platform;
						hardwareJoystickMap_InputManager = sJFWftxNLIpMIbThhCuHxvwZQYx(hardwareJoystickMap, bridgedController, true, out inputPlatform, out num2, out platform);
						num = 1004556995;
						continue;
					}
					default:
						{
							if (hardwareJoystickMap_InputManager != null)
							{
								return hardwareJoystickMap_InputManager;
							}
							goto IL_008c;
						}
						IL_008c:
						return defaultHardwareJoystickMap.GetDefaultHardwareJoystickMap_InputManager(bridgedController.inputSource);
					}
					break;
				}
			}
		}

		internal HardwareJoystickMap_InputManager WxVPhQkmgNwSnAqCPVfHhzPrFYU(BridgedControllerHWInfo P_0)
		{
			if (P_0 == null)
			{
				goto IL_0003;
			}
			lpacOKZgNhpOHawbWhhBytntQhC();
			int num;
			if (P_0.inputSource == InputSource.SDL2 && P_0.hw_isSDL2Gamepad)
			{
				num = -1520350665;
				goto IL_0008;
			}
			goto IL_00c9;
			IL_0008:
			HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager2 = default(HardwareJoystickMap_InputManager);
			HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager3 = default(HardwareJoystickMap_InputManager);
			HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager = default(HardwareJoystickMap_InputManager);
			int num2 = default(int);
			int num3 = default(int);
			HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager4 = default(HardwareJoystickMap_InputManager);
			while (true)
			{
				switch (num ^ -1520350659)
				{
				case 8:
					break;
				case 3:
					return null;
				case 7:
					hardwareJoystickMap_InputManager2.useSystemName = true;
					num = -1520350659;
					continue;
				case 11:
					num = -1520350661;
					continue;
				case 10:
					hardwareJoystickMap_InputManager3 = fEQRUpVXOVWpzOqIHIDQcyoIuOrS(P_0);
					num = -1520350668;
					continue;
				case 0:
					return hardwareJoystickMap_InputManager2;
				case 9:
					goto IL_00c4;
				case 5:
				{
					InputPlatform inputPlatform;
					int num4;
					HardwareJoystickMap.Platform platform;
					hardwareJoystickMap_InputManager = sJFWftxNLIpMIbThhCuHxvwZQYx(hardwareJoystickMaps[num2], P_0, true, out inputPlatform, out num4, out platform);
					num = -1520350663;
					continue;
				}
				case 4:
					goto IL_00f7;
				case 6:
					goto IL_010c;
				case 1:
					if (num2 >= hardwareJoystickMaps.Length)
					{
						num3 = 0;
						num = -1520350666;
						continue;
					}
					goto case 5;
				case 12:
					goto IL_015b;
				default:
					goto IL_018b;
				}
				break;
				IL_018b:
				if (hardwareJoystickMap_InputManager4 != null)
				{
					return hardwareJoystickMap_InputManager4;
				}
				goto IL_0192;
				IL_0192:
				return defaultHardwareJoystickMap.GetDefaultHardwareJoystickMap_InputManager(P_0.inputSource);
				IL_010c:
				if (num3 < hardwareJoystickMaps.Length)
				{
					goto IL_015b;
				}
				if (P_0.inputSource == InputSource.Fallback_PreConfigured)
				{
					hardwareJoystickMap_InputManager2 = TtrAPCVROyHxOoJYiaeqeVYELM(P_0, "[UNITY PRECONFIGURED JOYSTICK]");
					if (hardwareJoystickMap_InputManager2 != null)
					{
						num = -1520350662;
						continue;
					}
				}
				if (UnityTools.isAndroidPlatform && ReInput.configVars.android_supportUnknownGamepads)
				{
					hardwareJoystickMap_InputManager4 = fEQRUpVXOVWpzOqIHIDQcyoIuOrS(P_0);
					num = -1520350657;
					continue;
				}
				goto IL_0192;
				IL_015b:
				InputPlatform inputPlatform2;
				int num5;
				HardwareJoystickMap.Platform platform2;
				HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager5 = sJFWftxNLIpMIbThhCuHxvwZQYx(hardwareJoystickMaps[num3], P_0, false, out inputPlatform2, out num5, out platform2);
				if (hardwareJoystickMap_InputManager5 != null)
				{
					return hardwareJoystickMap_InputManager5;
				}
				num3++;
				num = -1520350661;
				continue;
				IL_00f7:
				if (hardwareJoystickMap_InputManager != null)
				{
					return hardwareJoystickMap_InputManager;
				}
				num2++;
				num = -1520350660;
			}
			goto IL_0003;
			IL_00c4:
			if (hardwareJoystickMap_InputManager3 != null)
			{
				return hardwareJoystickMap_InputManager3;
			}
			goto IL_00c9;
			IL_00c9:
			num2 = 0;
			num = -1520350660;
			goto IL_0008;
			IL_0003:
			num = -1520350658;
			goto IL_0008;
		}

		private HardwareJoystickMap_InputManager sJFWftxNLIpMIbThhCuHxvwZQYx(HardwareJoystickMap P_0, BridgedControllerHWInfo P_1, bool P_2, out InputPlatform P_3, out int P_4, out HardwareJoystickMap.Platform P_5)
		{
			P_3 = InputPlatform.XYhwUwaOlrfFTKoMRqftWpJVYyOD;
			while (true)
			{
				int num = -149963362;
				while (true)
				{
					switch (num ^ -149963363)
					{
					case 2:
						break;
					case 3:
						P_4 = -1;
						num = -149963363;
						continue;
					case 0:
						P_5 = null;
						num = -149963364;
						continue;
					default:
					{
						if (P_0 == null)
						{
							return null;
						}
						if (!P_0.Matches(P_1, P_2, false, out P_3, out P_4, out P_5))
						{
							return null;
						}
						HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager = P_5.ToHardwareJoystickMap_InputManager(P_0, P_1.inputSource, P_3, P_4);
						if (hardwareJoystickMap_InputManager == null)
						{
							return null;
						}
						return hardwareJoystickMap_InputManager;
					}
					}
					break;
				}
			}
		}

		private HardwareJoystickMap_InputManager TtrAPCVROyHxOoJYiaeqeVYELM(BridgedControllerHWInfo P_0, string P_1)
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo(P_0);
			bridgedControllerHWInfo.hw_productName = P_1;
			bridgedControllerHWInfo.hardwareButtonCount = 0;
			bridgedControllerHWInfo.hardwareAxisCount = 0;
			bridgedControllerHWInfo.hardwareHatCount = 0;
			int num = 0;
			HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager = default(HardwareJoystickMap_InputManager);
			while (true)
			{
				int num2;
				int num3;
				if (num >= hardwareJoystickMaps.Length)
				{
					num2 = -1936677141;
					num3 = num2;
				}
				else
				{
					num2 = -1936677142;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ -1936677141)
					{
					case 5:
						num2 = -1936677142;
						continue;
					case 1:
						if (!(hardwareJoystickMaps[num] == null))
						{
							num2 = -1936677143;
							continue;
						}
						goto IL_0072;
					case 4:
						if (hardwareJoystickMap_InputManager != null)
						{
							return hardwareJoystickMap_InputManager;
						}
						goto IL_0072;
					case 3:
						break;
					case 2:
					{
						InputPlatform actualInputPlatform;
						int variantIndex;
						HardwareJoystickMap.Platform platformMap;
						if (hardwareJoystickMaps[num].Matches(bridgedControllerHWInfo, false, false, out actualInputPlatform, out variantIndex, out platformMap))
						{
							hardwareJoystickMap_InputManager = platformMap.ToHardwareJoystickMap_InputManager(hardwareJoystickMaps[num], P_0.inputSource, actualInputPlatform, variantIndex);
							num2 = -1936677137;
							continue;
						}
						goto IL_0072;
					}
					default:
						{
							return null;
						}
						IL_0072:
						num++;
						num2 = -1936677144;
						continue;
					}
					break;
				}
			}
		}

		private HardwareJoystickMap_InputManager fEQRUpVXOVWpzOqIHIDQcyoIuOrS(BridgedControllerHWInfo P_0)
		{
			HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager = TtrAPCVROyHxOoJYiaeqeVYELM(P_0, "[STANDARDIZED GAMEPAD]");
			while (true)
			{
				int num = -1411380313;
				while (true)
				{
					switch (num ^ -1411380314)
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
					num = -1411380316;
				}
			}
		}

		private void lpacOKZgNhpOHawbWhhBytntQhC()
		{
			if (uOwAYccruzzNORyQAmlloPjCVEz)
			{
				return;
			}
			while (!ArrayTools.IsNullOrEmpty(hardwareJoystickMaps) && !(defaultHardwareJoystickMap == null))
			{
				int num;
				int num2;
				if (ArrayTools.IsNullOrEmpty(joystickTemplates))
				{
					num = 1098948182;
					num2 = num;
				}
				else
				{
					num = 1098948180;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x41809E54)
					{
					case 3:
						num = 1098948181;
						continue;
					case 1:
						break;
					case 2:
						goto end_IL_002b;
					default:
						uOwAYccruzzNORyQAmlloPjCVEz = true;
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
