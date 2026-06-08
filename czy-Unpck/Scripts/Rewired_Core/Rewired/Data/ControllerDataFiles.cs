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

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private HardwareJoystickMap[] hardwareJoystickMaps;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private HardwareJoystickTemplateMap[] joystickTemplates;

		[NonSerialized]
		private bool DHwrshOPZxMuLadVLAsooDCFNbS;

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
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num >= hardwareJoystickMaps.Length)
				{
					num2 = -139562711;
					num3 = num2;
				}
				else
				{
					num2 = -139562706;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ -139562710)
					{
					case 0:
						num2 = -139562706;
						continue;
					case 4:
						if (!(hardwareJoystickMaps[num] == null) && !hardwareJoystickMaps[num].HideInLists)
						{
							list.Add(hardwareJoystickMaps[num].ControllerName);
							num2 = -139562712;
							continue;
						}
						goto case 2;
					case 1:
						break;
					case 2:
						num++;
						num2 = -139562709;
						continue;
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
			int num2 = default(int);
			while (true)
			{
				int num = -446692577;
				while (true)
				{
					switch (num ^ -446692583)
					{
					case 0:
						break;
					case 2:
						if (num2 >= hardwareJoystickMaps.Length)
						{
							list.Insert(0, defaultHardwareJoystickMap.ControllerName);
							num = -446692579;
							continue;
						}
						goto case 5;
					case 5:
						if (hardwareJoystickMaps[num2] == null || hardwareJoystickMaps[num2].HideInLists)
						{
							goto case 1;
						}
						if (!string.IsNullOrEmpty(hardwareJoystickMaps[num2].EditorControllerName))
						{
							list.Add(hardwareJoystickMaps[num2].EditorControllerName);
							num = -446692584;
							continue;
						}
						goto case 3;
					case 6:
						num2 = 0;
						num = -446692581;
						continue;
					case 1:
						num2++;
						num = -446692581;
						continue;
					case 3:
						list.Add(hardwareJoystickMaps[num2].ControllerName);
						num = -446692584;
						continue;
					default:
						return list.ToArray();
					}
					break;
				}
			}
		}

		public Guid[] GetJoystickGuids()
		{
			if (hardwareJoystickMaps == null)
			{
				return null;
			}
			List<Guid> list = new List<Guid>();
			int num = 0;
			while (num < hardwareJoystickMaps.Length)
			{
				while (true)
				{
					int num2;
					if (!(hardwareJoystickMaps[num] == null))
					{
						int num3;
						if (!hardwareJoystickMaps[num].HideInLists)
						{
							num2 = 1735347486;
							num3 = num2;
						}
						else
						{
							num2 = 1735347483;
							num3 = num2;
						}
						goto IL_0019;
					}
					goto IL_0084;
					IL_0019:
					while (true)
					{
						switch (num2 ^ 0x676F4D1F)
						{
						case 3:
							num2 = 1735347485;
							continue;
						case 2:
							break;
						case 1:
							list.Add(hardwareJoystickMaps[num].Guid);
							num2 = 1735347483;
							continue;
						case 4:
							goto IL_0084;
						default:
							goto end_IL_003a;
						}
						break;
					}
					continue;
					IL_0084:
					num++;
					num2 = 1735347487;
					goto IL_0019;
					continue;
					end_IL_003a:
					break;
				}
			}
			list.Insert(0, defaultHardwareJoystickMap.Guid);
			return list.ToArray();
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
				int num = -1081973323;
				while (true)
				{
					switch (num ^ -1081973327)
					{
					case 3:
						break;
					case 4:
						num2 = 0;
						num = -1081973328;
						continue;
					case 0:
						num2++;
						num = -1081973328;
						continue;
					case 2:
						if (!(joystickTemplates[num2] == null))
						{
							list.Add(joystickTemplates[num2].ControllerName);
							num = -1081973327;
							continue;
						}
						goto case 0;
					default:
						if (num2 >= joystickTemplates.Length)
						{
							return list.ToArray();
						}
						goto case 2;
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
			int num2 = -1055736618;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ -1055736621)
				{
				case 3:
					break;
				case 2:
					list.Add(joystickTemplates[num].Guid);
					num2 = -1055736622;
					continue;
				case 1:
					num++;
					num2 = -1055736618;
					continue;
				case 4:
					return null;
				case 0:
				{
					int num3;
					if (!(joystickTemplates[num] == null))
					{
						num2 = -1055736623;
						num3 = num2;
					}
					else
					{
						num2 = -1055736622;
						num3 = num2;
					}
					continue;
				}
				default:
					if (num >= joystickTemplates.Length)
					{
						return list.ToArray();
					}
					goto case 0;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = -1055736617;
			goto IL_000d;
		}

		public HardwareJoystickMap GetHardwareJoystickMap(Guid guid)
		{
			if (hardwareJoystickMaps == null)
			{
				goto IL_000b;
			}
			int num;
			int num2 = default(int);
			if (guid == defaultHardwareJoystickMap.Guid)
			{
				num = 293285547;
			}
			else
			{
				num2 = 0;
				num = 293285545;
			}
			goto IL_0010;
			IL_000b:
			num = 293285550;
			goto IL_0010;
			IL_0010:
			while (true)
			{
				switch (num ^ 0x117B2EAD)
				{
				case 5:
					break;
				case 2:
					return hardwareJoystickMaps[num2];
				case 4:
				{
					int num3;
					if (num2 < hardwareJoystickMaps.Length)
					{
						num = 293285548;
						num3 = num;
					}
					else
					{
						num = 293285549;
						num3 = num;
					}
					continue;
				}
				case 1:
					if (hardwareJoystickMaps[num2] == null || !(hardwareJoystickMaps[num2].Guid == guid))
					{
						num2++;
						num = 293285545;
					}
					else
					{
						num = 293285551;
					}
					continue;
				case 3:
					return null;
				case 6:
					return defaultHardwareJoystickMap;
				default:
					return null;
				}
				break;
			}
			goto IL_000b;
		}

		public HardwareJoystickTemplateMap GetJoystickTemplate(Guid guid)
		{
			if (joystickTemplates == null)
			{
				goto IL_0008;
			}
			int num = 0;
			int num2 = -947392863;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ -947392861)
				{
				case 0:
					break;
				case 3:
					if (!(joystickTemplates[num] == null) && joystickTemplates[num].Guid == guid)
					{
						return joystickTemplates[num];
					}
					num++;
					num2 = -947392857;
					continue;
				case 2:
					num2 = -947392857;
					continue;
				case 1:
					return null;
				default:
					if (num >= joystickTemplates.Length)
					{
						return null;
					}
					goto case 3;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = -947392862;
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

		internal ControllerTemplateElementIdentifier hddxNZjlOmDfwuLplaUiGenVzbH(Guid P_0, int P_1)
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
				ControllerTemplateElementIdentifier controllerTemplateElementIdentifier = default(ControllerTemplateElementIdentifier);
				ControllerTemplateElementIdentifier result = default(ControllerTemplateElementIdentifier);
				while (true)
				{
					IL_0061:
					int num;
					int num2;
					if (!enumerator.MoveNext())
					{
						num = -593672727;
						num2 = num;
					}
					else
					{
						num = -593672724;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ -593672723)
						{
						case 2:
							num = -593672724;
							continue;
						default:
							goto end_IL_003c;
						case 3:
							break;
						case 0:
							if (controllerTemplateElementIdentifier != null)
							{
								result = controllerTemplateElementIdentifier;
								num = -593672728;
								continue;
							}
							break;
						case 1:
						{
							Guid current = enumerator.Current;
							HardwareJoystickTemplateMap joystickTemplate = GetJoystickTemplate(current);
							if (!(joystickTemplate == null))
							{
								controllerTemplateElementIdentifier = joystickTemplate.kBoaUJDYOnIujWXVVCmGUvtnFDH(P_0, P_1);
								num = -593672723;
								continue;
							}
							break;
						}
						case 4:
							goto end_IL_003c;
						case 5:
							return result;
						}
						goto IL_0061;
						continue;
						end_IL_003c:
						break;
					}
					break;
				}
			}
			return null;
		}

		internal HardwareJoystickMap_InputManager NmQvhsZTsJUUOTJuQxoZMWZoYzM(Guid P_0, InputSource P_1)
		{
			AwafDVAngdbkCfVETvKIjkLGoDrG();
			BridgedController bridgedController = new BridgedController();
			bridgedController.isMock = true;
			bridgedController.inputManagerSource = P_1;
			bridgedController.inputSource = P_1;
			BridgedController bridgedController2 = bridgedController;
			HardwareJoystickMap hardwareJoystickMap = GetHardwareJoystickMap(P_0);
			if (hardwareJoystickMap != null)
			{
				InputPlatform inputPlatform;
				int num;
				HardwareJoystickMap.Platform platform;
				HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager = JHLMiLTofKFEXGGroLCStQAUDPO(hardwareJoystickMap, bridgedController2, true, out inputPlatform, out num, out platform);
				if (hardwareJoystickMap_InputManager != null)
				{
					return hardwareJoystickMap_InputManager;
				}
			}
			return defaultHardwareJoystickMap.GetDefaultHardwareJoystickMap_InputManager(bridgedController2);
		}

		internal HardwareJoystickMap_InputManager rtTBIFEIPTwHsdFjAgMAbUncZPh(BridgedControllerHWInfo P_0)
		{
			if (P_0 == null)
			{
				return null;
			}
			AwafDVAngdbkCfVETvKIjkLGoDrG();
			HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager = default(HardwareJoystickMap_InputManager);
			if (P_0.inputSource == InputSource.SDL2 && P_0.hw_isSDL2Gamepad)
			{
				hardwareJoystickMap_InputManager = GACCxcnWhXWkmljdItoHcTEXiHG(P_0);
				goto IL_002b;
			}
			goto IL_0145;
			IL_0030:
			int num;
			int num2 = default(int);
			int num3 = default(int);
			HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager3 = default(HardwareJoystickMap_InputManager);
			HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager2 = default(HardwareJoystickMap_InputManager);
			HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager5 = default(HardwareJoystickMap_InputManager);
			while (true)
			{
				switch (num ^ -34513534)
				{
				case 0:
					break;
				case 9:
					if (num2 >= hardwareJoystickMaps.Length)
					{
						num3 = 0;
						num = -34513522;
						continue;
					}
					goto case 3;
				case 7:
					goto IL_008d;
				case 12:
					num = -34513528;
					continue;
				case 10:
					goto IL_00b8;
				case 6:
					goto IL_00d8;
				case 3:
				{
					hardwareJoystickMap_InputManager3 = JHLMiLTofKFEXGGroLCStQAUDPO(hardwareJoystickMaps[num2], P_0, true, out var _, out var _, out var _);
					num = -34513533;
					continue;
				}
				case 13:
					goto IL_0121;
				case 1:
					goto IL_012e;
				case 2:
					return hardwareJoystickMap_InputManager;
				case 11:
					num = -34513525;
					continue;
				case 5:
					return hardwareJoystickMap_InputManager2;
				case 8:
					goto IL_016e;
				default:
					goto IL_018e;
				}
				break;
				IL_018e:
				if (ReInput.configVars.android_supportUnknownGamepads)
				{
					HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager4 = GACCxcnWhXWkmljdItoHcTEXiHG(P_0);
					if (hardwareJoystickMap_InputManager4 != null)
					{
						return hardwareJoystickMap_InputManager4;
					}
				}
				goto IL_01aa;
				IL_01aa:
				return defaultHardwareJoystickMap.GetDefaultHardwareJoystickMap_InputManager(P_0);
				IL_00d8:
				hardwareJoystickMap_InputManager2 = JHLMiLTofKFEXGGroLCStQAUDPO(hardwareJoystickMaps[num3], P_0, false, out var _, out var _, out var _);
				if (hardwareJoystickMap_InputManager2 != null)
				{
					num = -34513529;
					continue;
				}
				num3++;
				num = -34513528;
				continue;
				IL_016e:
				if (hardwareJoystickMap_InputManager5 != null)
				{
					hardwareJoystickMap_InputManager5.useSystemName = true;
					return hardwareJoystickMap_InputManager5;
				}
				goto IL_017d;
				IL_017d:
				if (UnityTools.isAndroidPlatform)
				{
					num = -34513530;
					continue;
				}
				goto IL_01aa;
				IL_012e:
				if (hardwareJoystickMap_InputManager3 != null)
				{
					return hardwareJoystickMap_InputManager3;
				}
				num2++;
				num = -34513525;
				continue;
				IL_008d:
				if (P_0.inputSource == InputSource.Fallback_PreConfigured)
				{
					hardwareJoystickMap_InputManager5 = yiztGMoMoAetaAtJPyJznsdXNVlK(P_0, "[UNITY PRECONFIGURED JOYSTICK]");
					num = -34513526;
					continue;
				}
				goto IL_017d;
				IL_00b8:
				int num6;
				if (num3 < hardwareJoystickMaps.Length)
				{
					num = -34513532;
					num6 = num;
				}
				else
				{
					num = -34513531;
					num6 = num;
				}
				continue;
				IL_0121:
				if (hardwareJoystickMap_InputManager != null)
				{
					num = -34513536;
					continue;
				}
				goto IL_0145;
			}
			goto IL_002b;
			IL_002b:
			num = -34513521;
			goto IL_0030;
			IL_0145:
			num2 = 0;
			num = -34513527;
			goto IL_0030;
		}

		private HardwareJoystickMap_InputManager JHLMiLTofKFEXGGroLCStQAUDPO(HardwareJoystickMap P_0, BridgedControllerHWInfo P_1, bool P_2, out InputPlatform P_3, out int P_4, out HardwareJoystickMap.Platform P_5)
		{
			P_3 = InputPlatform.mWddvsAGGdWECRlxCOhehpBItyh;
			P_4 = -1;
			P_5 = null;
			HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager = default(HardwareJoystickMap_InputManager);
			while (true)
			{
				int num = -1690763005;
				while (true)
				{
					switch (num ^ -1690763008)
					{
					case 2:
						break;
					case 3:
						if (P_0 == null)
						{
							num = -1690763008;
							continue;
						}
						if (!P_0.Matches(P_1, P_2, isDefaultMap: false, out P_3, out P_4, out P_5))
						{
							return null;
						}
						hardwareJoystickMap_InputManager = P_5.ToHardwareJoystickMap_InputManager(P_0, P_1.inputSource, P_3, P_4);
						num = -1690763007;
						continue;
					case 0:
						return null;
					default:
						if (hardwareJoystickMap_InputManager == null)
						{
							return null;
						}
						return hardwareJoystickMap_InputManager;
					}
					break;
				}
			}
		}

		private HardwareJoystickMap_InputManager yiztGMoMoAetaAtJPyJznsdXNVlK(BridgedControllerHWInfo P_0, string P_1)
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo(P_0);
			bridgedControllerHWInfo.hw_productName = P_1;
			bridgedControllerHWInfo.hardwareButtonCount = 0;
			bridgedControllerHWInfo.hardwareAxisCount = 0;
			bridgedControllerHWInfo.hardwareHatCount = 0;
			int num = 0;
			while (num < hardwareJoystickMaps.Length)
			{
				while (true)
				{
					if (!(hardwareJoystickMaps[num] == null) && hardwareJoystickMaps[num].Matches(bridgedControllerHWInfo, strictMatch: false, isDefaultMap: false, out var actualInputPlatform, out var variantIndex, out var platformMap))
					{
						HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager = platformMap.ToHardwareJoystickMap_InputManager(hardwareJoystickMaps[num], P_0.inputSource, actualInputPlatform, variantIndex);
						if (hardwareJoystickMap_InputManager != null)
						{
							return hardwareJoystickMap_InputManager;
						}
					}
					num++;
					int num2 = -173823585;
					while (true)
					{
						switch (num2 ^ -173823585)
						{
						case 2:
							num2 = -173823586;
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
			return null;
		}

		private HardwareJoystickMap_InputManager GACCxcnWhXWkmljdItoHcTEXiHG(BridgedControllerHWInfo P_0)
		{
			HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager = yiztGMoMoAetaAtJPyJznsdXNVlK(P_0, "[STANDARDIZED GAMEPAD]");
			if (hardwareJoystickMap_InputManager == null)
			{
				return null;
			}
			hardwareJoystickMap_InputManager.useSystemName = true;
			return hardwareJoystickMap_InputManager;
		}

		private void AwafDVAngdbkCfVETvKIjkLGoDrG()
		{
			if (DHwrshOPZxMuLadVLAsooDCFNbS)
			{
				goto IL_0008;
			}
			goto IL_0048;
			IL_0008:
			int num = -287298059;
			goto IL_000d;
			IL_000d:
			switch (num ^ -287298057)
			{
			case 4:
				break;
			case 2:
				return;
			case 3:
				goto IL_0036;
			case 1:
				goto IL_0048;
			default:
				DHwrshOPZxMuLadVLAsooDCFNbS = true;
				return;
			}
			goto IL_0008;
			IL_0048:
			if (!ArrayTools.IsNullOrEmpty(hardwareJoystickMaps) && !(defaultHardwareJoystickMap == null))
			{
				int num2;
				if (!ArrayTools.IsNullOrEmpty(joystickTemplates))
				{
					num = -287298057;
					num2 = num;
				}
				else
				{
					num = -287298060;
					num2 = num;
				}
				goto IL_000d;
			}
			goto IL_0036;
			IL_0036:
			Logger.LogError("ControllerDataFiles is missing critical data! The serialized data may have been corrupted. Please see the Known Issues in the documentation for possible causes and solutions.");
		}
	}
}
