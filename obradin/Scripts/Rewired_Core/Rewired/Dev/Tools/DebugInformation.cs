using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Rewired.Platforms;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.Dev.Tools
{
	public class DebugInformation : MonoBehaviour
	{
		private class qdnMheaboQxTbfNHeFXhZezQcjfh : IDisposable
		{
			public readonly bool npNgcUPGCoMjSXwgumOyYMvfGWW;

			public qdnMheaboQxTbfNHeFXhZezQcjfh(string label, string key, IDictionary<string, bool> foldouts)
			{
				npNgcUPGCoMjSXwgumOyYMvfGWW = axtTfXfyNIlPmOqcDusmxrrhBws(label, key, foldouts);
				gbuFBaLTyEQDLZCgpIDDdhLRCZf.indentLevel++;
			}

			private bool axtTfXfyNIlPmOqcDusmxrrhBws(string P_0, string P_1, IDictionary<string, bool> P_2)
			{
				return klmDpdAfsBuEbynqxAOwspwDfEh(P_1, GUILayout.Toggle(OUEkBpHNxqyvrOegNjGUCBYviOtP(P_1, P_2), new GUIContent(P_0, P_0), GetToggleStyle()), P_2);
			}

			private bool OUEkBpHNxqyvrOegNjGUCBYviOtP(string P_0, IDictionary<string, bool> P_1)
			{
				if (!P_1.ContainsKey(P_0))
				{
					P_1.Add(P_0, false);
				}
				return P_1[P_0];
			}

			private bool klmDpdAfsBuEbynqxAOwspwDfEh(string P_0, bool P_1, IDictionary<string, bool> P_2)
			{
				if (!P_2.ContainsKey(P_0))
				{
					P_2.Add(P_0, P_1);
				}
				else
				{
					while (true)
					{
						P_2[P_0] = P_1;
						int num = 1456976865;
						while (true)
						{
							switch (num ^ 0x56D7B3E0)
							{
							case 0:
								num = 1456976866;
								continue;
							case 2:
								break;
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
				return P_1;
			}

			public void Dispose()
			{
				gbuFBaLTyEQDLZCgpIDDdhLRCZf.indentLevel--;
			}
		}

		private static class gbuFBaLTyEQDLZCgpIDDdhLRCZf
		{
			private static int FaWwdqzbqlFanMJNPYDuGgeWGNj;

			public static int indentLevel
			{
				get
				{
					return FaWwdqzbqlFanMJNPYDuGgeWGNj;
				}
				set
				{
					FaWwdqzbqlFanMJNPYDuGgeWGNj = Mathf.Max(0, value);
				}
			}
		}

		private static class hpyXVhdtbiFWFEVwktnGBdahHCR
		{
			public static void bvlhTWUXCrIODNVVCjTogdCnjnE()
			{
				GUILayout.BeginHorizontal();
			}

			public static void icOqQDfAnlqFkJpPovrtKBvElbV()
			{
				GUILayout.EndHorizontal();
			}

			public static void azjICJCPFtZpvnurwEJBMEPrJlX()
			{
				GUILayout.BeginVertical();
			}

			public static void GAcNzgPQmdsjeCCcJFfZZBSMqXA()
			{
				GUILayout.EndVertical();
			}

			public static void VUwYdtwNftAjVSaWOOtPzbIHvPe(string P_0, fEqkKoLvLSfTLGiavIDHaqoVTv P_1)
			{
				GUILayout.Label(P_0, EsMGihJDWSpYkwWqQfXVDXdaiaC());
			}

			public static void ZDxfqcFMGoCBygNNLeqpsdextAR(string P_0, string P_1)
			{
				GUILayout.Label(P_0 + ": " + P_1, EsMGihJDWSpYkwWqQfXVDXdaiaC());
			}

			public static void rbBIooRDmkizndzyyjvLzURQFYff(string P_0, AnimationCurve P_1)
			{
				GUILayout.Label(P_0 + ": Curves are not visualized by this tool.");
			}

			public static bool WrsHhyMekyOynchRHSziEyRCQFV(string P_0, bool P_1)
			{
				return GUILayout.Toggle(P_1, P_0, EsMGihJDWSpYkwWqQfXVDXdaiaC());
			}
		}

		private static class ZmMCDkpxSHnSVxOnSzlncGBHfgI
		{
			[CompilerGenerated]
			private static float UkSCxQbJFAjXPWmJcVGvbKUuapQg;

			[CompilerGenerated]
			private static float UroBPaEtkaqdWgVfTidaskBBSuGG;

			public static float labelWidth
			{
				[CompilerGenerated]
				get
				{
					return UkSCxQbJFAjXPWmJcVGvbKUuapQg;
				}
				[CompilerGenerated]
				set
				{
					UkSCxQbJFAjXPWmJcVGvbKUuapQg = value;
				}
			}

			public static float fieldWidth
			{
				[CompilerGenerated]
				get
				{
					return UroBPaEtkaqdWgVfTidaskBBSuGG;
				}
				[CompilerGenerated]
				set
				{
					UroBPaEtkaqdWgVfTidaskBBSuGG = value;
				}
			}
		}

		internal enum fEqkKoLvLSfTLGiavIDHaqoVTv
		{
			TCGihQKDgeeGtvEXifcuojmabzj = 0,
			JKuGYImDpiIXvNnGxLnsPWrKerU = 1,
			aibPPaLVlCbMkDAxBhunhoGOtsVQ = 2,
			VoYMRlwACsraKOTYBiskDczbVjo = 3
		}

		private sealed class HMcigQiVOxIAdRwvKwHjCdQdRpc
		{
			public InputCategory yLWxWdSFSmWBToqYYJSIYtZGAcS;

			public bool SeLLAGaYcRSkUiAPfslbLLmNOFt(InputAction P_0)
			{
				return P_0.categoryId == yLWxWdSFSmWBToqYYJSIYtZGAcS.id;
			}
		}

		private const string UuJyjREQumeQdUjUtufzlxFxMAa = "Rewired_DebugInformation";

		private const string mWIDMIfnPeZAWtwiebbxfGWQArs = "Rewired Debug Information";

		private const int WEqbRuDbXLTlkseXWAYKejFcvvyS = 20;

		private IDictionary<string, bool> LREGoczreByETNAGpToQHlOeVtw = new Dictionary<string, bool>();

		private static Vector2 lcthUFcPoljGPRVbmwoDILiLpQU;

		[CompilerGenerated]
		private static Comparison<InputAction> WCoGcdreuUiwhEhixVWoEqPFLcw;

		[CustomObfuscation(rename = false)]
		private void OnEnable()
		{
			if (LREGoczreByETNAGpToQHlOeVtw.Count != 0)
			{
				return;
			}
			while (true)
			{
				int num = -197569940;
				while (true)
				{
					switch (num ^ -197569938)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						goto IL_002b;
					case 1:
						return;
					}
					break;
					IL_002b:
					LREGoczreByETNAGpToQHlOeVtw.Add("Rewired_DebugInformation", true);
					num = -197569937;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		private void OnDisable()
		{
		}

		[CustomObfuscation(rename = false)]
		private void OnGUI()
		{
			gbuFBaLTyEQDLZCgpIDDdhLRCZf.indentLevel = 0;
			GUILayout.BeginArea(new Rect(0f, 0f, Screen.width, Screen.height));
			lcthUFcPoljGPRVbmwoDILiLpQU = GUILayout.BeginScrollView(lcthUFcPoljGPRVbmwoDILiLpQU, GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
			DrawDebugInformation(true, LREGoczreByETNAGpToQHlOeVtw);
			GUILayout.EndScrollView();
			GUILayout.EndArea();
		}

		public static void DrawDebugInformation(bool enabled, IDictionary<string, bool> foldouts)
		{
			bool flag = GUI.enabled;
			if (!ReInput.isReady)
			{
				goto IL_0036;
			}
			if (!enabled)
			{
				goto IL_0010;
			}
			goto IL_0043;
			IL_0036:
			GUI.enabled = false;
			int num = 413451259;
			goto IL_0015;
			IL_0010:
			num = 413451262;
			goto IL_0015;
			IL_0015:
			Rect lastRect = default(Rect);
			while (true)
			{
				switch (num ^ 0x18A4C3FA)
				{
				case 0:
					break;
				case 4:
					goto IL_0036;
				case 1:
					goto IL_0043;
				case 3:
				{
					float num2 = lastRect.width / 3f;
					ZmMCDkpxSHnSVxOnSzlncGBHfgI.labelWidth = lastRect.width - num2;
					ZmMCDkpxSHnSVxOnSzlncGBHfgI.fieldWidth = num2;
					evbENwGDzehiajZteapvkahLUXYO(enabled, foldouts);
					num = 413451256;
					continue;
				}
				default:
					GUI.enabled = flag;
					ZmMCDkpxSHnSVxOnSzlncGBHfgI.labelWidth = 0f;
					ZmMCDkpxSHnSVxOnSzlncGBHfgI.fieldWidth = 0f;
					return;
				}
				break;
			}
			goto IL_0010;
			IL_0043:
			hpyXVhdtbiFWFEVwktnGBdahHCR.bvlhTWUXCrIODNVVCjTogdCnjnE();
			GUILayout.FlexibleSpace();
			hpyXVhdtbiFWFEVwktnGBdahHCR.icOqQDfAnlqFkJpPovrtKBvElbV();
			lastRect = GUILayoutUtility.GetLastRect();
			num = 413451257;
			goto IL_0015;
		}

		private static void evbENwGDzehiajZteapvkahLUXYO(bool P_0, IDictionary<string, bool> P_1)
		{
			using (qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh2 = new qdnMheaboQxTbfNHeFXhZezQcjfh("Rewired Debug Information", "Rewired_DebugInformation", P_1))
			{
				if (!ReInput.isReady)
				{
					goto IL_00e4;
				}
				if (!P_0)
				{
					goto IL_0021;
				}
				goto IL_0103;
				IL_00e4:
				GUILayout.Label("There is no active Rewired Input Manager in the scene.");
				return;
				IL_0021:
				int num = 1144759828;
				goto IL_0026;
				IL_0026:
				bool flag = default(bool);
				while (true)
				{
					switch (num ^ 0x443BA615)
					{
					case 4:
						break;
					case 8:
						if (ReInput.primaryInputManager.inputSourceType == InputSource.Fallback)
						{
							flag = true;
							num = 1144759826;
							continue;
						}
						goto case 7;
					case 5:
						return;
					case 2:
						SXjayDgCuPzXyfuspfnxtBBXuPJU(P_1, "Rewired_DebugInformation");
						num = 1144759827;
						continue;
					case 7:
						if (flag)
						{
							hpyXVhdtbiFWFEVwktnGBdahHCR.VUwYdtwNftAjVSaWOOtPzbIHvPe("Native input is disabled. Many special features are unavailable without native input.", fEqkKoLvLSfTLGiavIDHaqoVTv.aibPPaLVlCbMkDAxBhunhoGOtsVQ);
							num = 1144759831;
							continue;
						}
						goto case 2;
					case 3:
						hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Rewired Version", ReInput.programVersion);
						flag = ReInput.configuration.disableNativeInput;
						if (flag)
						{
							goto case 7;
						}
						if (ReInput.currentPlatform == Platform.Windows)
						{
							goto case 8;
						}
						goto IL_00c8;
					case 1:
						goto IL_00e4;
					case 0:
						goto IL_0103;
					default:
					{
						string text = "Rewired_DebugInformation_controllers";
						qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh3 = new qdnMheaboQxTbfNHeFXhZezQcjfh("Controllers", text, P_1);
						try
						{
							if (!qdnMheaboQxTbfNHeFXhZezQcjfh3.npNgcUPGCoMjSXwgumOyYMvfGWW)
							{
								return;
							}
							kgjoHFqQSEfqgbDDwuOQKUNMVhW(ReInput.controllers.Joysticks, P_1, text);
							sYgEuIIiGfpSwYLkgkXZxhPiFdt(ReInput.controllers.CustomControllers, P_1, text);
							bxtRrMUqJwFyqCazPORlKAlsYlAd(P_1, "Rewired_DebugInformation");
							while (true)
							{
								int num2 = 1144759828;
								while (true)
								{
									switch (num2 ^ 0x443BA615)
									{
									case 0:
										break;
									default:
										return;
									case 1:
										goto IL_0185;
									case 2:
										return;
									}
									break;
									IL_0185:
									LHzvvqBnGRghZJIGlTrpBstOkpAN(P_1, "Rewired_DebugInformation");
									num2 = 1144759831;
								}
							}
						}
						finally
						{
							if (qdnMheaboQxTbfNHeFXhZezQcjfh3 != null)
							{
								while (true)
								{
									IL_019c:
									int num3 = 1144759828;
									while (true)
									{
										switch (num3 ^ 0x443BA615)
										{
										case 2:
											break;
										default:
											goto end_IL_01a1;
										case 1:
											goto IL_01ba;
										case 0:
											goto end_IL_01a1;
										}
										goto IL_019c;
										IL_01ba:
										((IDisposable)qdnMheaboQxTbfNHeFXhZezQcjfh3).Dispose();
										num3 = 1144759829;
										continue;
										end_IL_01a1:
										break;
									}
									break;
								}
							}
						}
					}
					}
					break;
					IL_00c8:
					int num4;
					if (ReInput.currentPlatform != Platform.OSX)
					{
						num = 1144759826;
						num4 = num;
					}
					else
					{
						num = 1144759837;
						num4 = num;
					}
				}
				goto IL_0021;
				IL_0103:
				int num5;
				if (qdnMheaboQxTbfNHeFXhZezQcjfh2.npNgcUPGCoMjSXwgumOyYMvfGWW)
				{
					num = 1144759830;
					num5 = num;
				}
				else
				{
					num = 1144759824;
					num5 = num;
				}
				goto IL_0026;
			}
		}

		private static void SXjayDgCuPzXyfuspfnxtBBXuPJU(IDictionary<string, bool> P_0, string P_1)
		{
			string text = P_1 + "_players";
			using (qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh2 = new qdnMheaboQxTbfNHeFXhZezQcjfh("Players (" + ReInput.players.allPlayerCount + ")", text, P_0))
			{
				if (!qdnMheaboQxTbfNHeFXhZezQcjfh2.npNgcUPGCoMjSXwgumOyYMvfGWW)
				{
					return;
				}
				int num2 = default(int);
				int playerCount = default(int);
				Player player = default(Player);
				while (true)
				{
					int num = 73937776;
					while (true)
					{
						switch (num ^ 0x4683376)
						{
						case 3:
							break;
						default:
							return;
						case 0:
							if (num2 >= playerCount)
							{
								KhiSdsvySiPfFtsDMwmhkRqrHOC(ReInput.players.SystemPlayer, -1, P_0, text);
								num = 73937783;
								continue;
							}
							goto case 5;
						case 2:
							KhiSdsvySiPfFtsDMwmhkRqrHOC(player, num2, P_0, text);
							num = 73937778;
							continue;
						case 5:
							player = ReInput.players.GetPlayer(num2);
							num = 73937780;
							continue;
						case 4:
							num2++;
							num = 73937782;
							continue;
						case 6:
							playerCount = ReInput.players.playerCount;
							num2 = 0;
							num = 73937782;
							continue;
						case 1:
							return;
						}
						break;
					}
				}
			}
		}

		private static void kgjoHFqQSEfqgbDDwuOQKUNMVhW(IList<Joystick> P_0, IDictionary<string, bool> P_1, string P_2)
		{
			int num = ((P_0 != null) ? P_0.Count : 0);
			using (qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh2 = new qdnMheaboQxTbfNHeFXhZezQcjfh("Joysticks (" + num + ")", P_2 + "_joysticks", P_1))
			{
				if (!qdnMheaboQxTbfNHeFXhZezQcjfh2.npNgcUPGCoMjSXwgumOyYMvfGWW)
				{
					return;
				}
				string text2 = default(string);
				int num8 = default(int);
				Player player = default(Player);
				object[] array = default(object[]);
				bool flag = default(bool);
				for (int i = 0; i < num; i++)
				{
					Joystick joystick = P_0[i];
					string text = P_2 + "_joystick" + joystick.id;
					qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh3 = new qdnMheaboQxTbfNHeFXhZezQcjfh(i + ": " + ((joystick.name == "Unknown Controller") ? joystick.hardwareName : joystick.name), text, P_1);
					try
					{
						if (!qdnMheaboQxTbfNHeFXhZezQcjfh3.npNgcUPGCoMjSXwgumOyYMvfGWW)
						{
							continue;
						}
						while (true)
						{
							IL_01b9:
							hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Id (unique id)", joystick.id.ToString());
							hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Name", joystick.name);
							int num2 = 665507273;
							while (true)
							{
								switch (num2 ^ 0x27AAD5C9)
								{
								case 4:
									num2 = 665507279;
									continue;
								case 13:
									cdryyLNyTTheQuBILYACYjekDAz(joystick.Axes, P_1, text);
									cJAsuOZfZsOvrZQvueNdlyYQwxa(joystick.Buttons, ControllerType.Joystick, P_1, text);
									num2 = 665507266;
									continue;
								case 0:
									hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Hardware Name", joystick.hardwareName);
									hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Is Recognized", (joystick.hardwareTypeGuid != Guid.Empty).ToString());
									hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Enabled", joystick.enabled.ToString());
									text2 = string.Empty;
									num8 = 0;
									num2 = 665507276;
									continue;
								case 3:
									num8++;
									num2 = 665507276;
									continue;
								case 6:
									break;
								case 2:
									hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Hardware Identifier", joystick.hardwareIdentifier);
									num2 = 665507269;
									continue;
								case 8:
									hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
									hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("System Id", joystick.systemId.ToString());
									hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Unity Id", ReInput.usingUnityInput ? joystick.unityId.ToString() : "--");
									num2 = 665507272;
									continue;
								case 7:
									player = ReInput.players.AllPlayers[num8];
									if (!ReInput.controllers.IsJoystickAssignedToPlayer(joystick.id, player.id))
									{
										goto case 3;
									}
									if (text2 != string.Empty)
									{
										text2 += ", ";
										num2 = 665507267;
										continue;
									}
									goto case 10;
								case 10:
									text2 += ((player.id == 9999999) ? "System" : player.id.ToString());
									num2 = 665507274;
									continue;
								case 11:
									hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Axis2D Count", joystick.axis2DCount.ToString());
									hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Hat Count", joystick.hatCount.ToString());
									QTLKZWjfpmedrzYWJJXDVpHFirV(joystick, P_1, text);
									num2 = 665507264;
									continue;
								case 5:
								{
									int num9;
									if (num8 < ReInput.players.allPlayerCount)
									{
										num2 = 665507278;
										num9 = num2;
									}
									else
									{
										num2 = 665507265;
										num9 = num2;
									}
									continue;
								}
								case 12:
									hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Device Instance Guid", joystick.deviceInstanceGuid.ToString());
									hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Tag", joystick.tag);
									num2 = 665507268;
									continue;
								case 1:
									hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Hardware Type Guid", joystick.hardwareTypeGuid.ToString());
									num2 = 665507275;
									continue;
								default:
								{
									CalibrationMap calibrationMap = joystick.calibrationMap;
									using (qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh4 = new qdnMheaboQxTbfNHeFXhZezQcjfh("Calibration Map", text + "_calibrationMap", P_1))
									{
										if (qdnMheaboQxTbfNHeFXhZezQcjfh4.npNgcUPGCoMjSXwgumOyYMvfGWW)
										{
											int axisCount = calibrationMap.axisCount;
											int num3 = 0;
											while (true)
											{
												if (num3 < axisCount)
												{
													AxisCalibration axisCalibration;
													while (true)
													{
														axisCalibration = calibrationMap.Axes[num3];
														int num4 = 665507273;
														while (true)
														{
															switch (num4 ^ 0x27AAD5C9)
															{
															case 3:
																num4 = 665507272;
																continue;
															case 1:
																break;
															case 0:
																array = new object[4] { num3, ": Axis Calibration (", null, null };
																num4 = 665507275;
																continue;
															default:
																goto end_IL_0428;
															}
															break;
														}
														continue;
														end_IL_0428:
														break;
													}
													array[2] = (axisCalibration.enabled ? "Enabled" : "Disabled");
													array[3] = ")";
													qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh5 = new qdnMheaboQxTbfNHeFXhZezQcjfh(string.Concat(array), text + "_AxisCalibration" + num3, P_1);
													try
													{
														if (qdnMheaboQxTbfNHeFXhZezQcjfh5.npNgcUPGCoMjSXwgumOyYMvfGWW)
														{
															while (true)
															{
																IL_059f:
																hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Enabled", axisCalibration.enabled.ToString());
																hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Apply Range Calibration", axisCalibration.applyRangeCalibration.ToString());
																hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Calibrated Max", axisCalibration.calibratedMax.ToString());
																hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Calibrated Min", axisCalibration.calibratedMin.ToString());
																int num5 = 665507277;
																while (true)
																{
																	switch (num5 ^ 0x27AAD5C9)
																	{
																	case 6:
																		num5 = 665507276;
																		continue;
																	default:
																		goto end_IL_04bc;
																	case 2:
																		if (axisCalibration.sensitivityCurve != null)
																		{
																			flag = GUI.enabled;
																			num5 = 665507272;
																			continue;
																		}
																		goto case 0;
																	case 4:
																		hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Calibrated Zero", axisCalibration.calibratedZero.ToString());
																		hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Dead Zone", axisCalibration.deadZone.ToString());
																		hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Invert", axisCalibration.invert.ToString());
																		num5 = 665507278;
																		continue;
																	case 1:
																		GUI.enabled = false;
																		hpyXVhdtbiFWFEVwktnGBdahHCR.rbBIooRDmkizndzyyjvLzURQFYff("Sensitivity Curve", axisCalibration.sensitivityCurve);
																		GUI.enabled = flag;
																		num5 = 665507274;
																		continue;
																	case 0:
																		hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Sensitivity Curve", "--");
																		num5 = 665507274;
																		continue;
																	case 5:
																		break;
																	case 7:
																		hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Sensitivity Type", axisCalibration.sensitivityType.ToString());
																		hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Sensitivity", axisCalibration.sensitivity.ToString());
																		num5 = 665507275;
																		continue;
																	case 3:
																		goto end_IL_04bc;
																	}
																	goto IL_059f;
																	continue;
																	end_IL_04bc:
																	break;
																}
																break;
															}
														}
													}
													finally
													{
														if (qdnMheaboQxTbfNHeFXhZezQcjfh5 != null)
														{
															while (true)
															{
																IL_0656:
																int num6 = 665507275;
																while (true)
																{
																	switch (num6 ^ 0x27AAD5C9)
																	{
																	case 0:
																		break;
																	default:
																		goto end_IL_065b;
																	case 2:
																		goto IL_0674;
																	case 1:
																		goto end_IL_065b;
																	}
																	goto IL_0656;
																	IL_0674:
																	((IDisposable)qdnMheaboQxTbfNHeFXhZezQcjfh5).Dispose();
																	num6 = 665507272;
																	continue;
																	end_IL_065b:
																	break;
																}
																break;
															}
														}
													}
													num3++;
													goto IL_0689;
												}
												int num7 = 665507272;
												goto IL_068e;
												IL_0689:
												num7 = 665507275;
												goto IL_068e;
												IL_068e:
												switch (num7 ^ 0x27AAD5C9)
												{
												case 0:
													break;
												default:
													goto end_IL_06a7;
												case 2:
													continue;
												case 1:
													goto end_IL_06a7;
												}
												goto IL_0689;
												continue;
												end_IL_06a7:
												break;
											}
										}
									}
									hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Supports Vibration", joystick.supportsVibration.ToString());
									hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Vibration Motor Count", joystick.vibrationMotorCount.ToString());
									hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Has Extension", (joystick.extension != null).ToString());
									hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Extension Type", (joystick.extension != null) ? joystick.extension.GetType().Name : "--");
									fsebqsOsBAfHXavOIxVgdKAeDJCd(joystick, P_1, text);
									goto end_IL_00dd;
								}
								}
								goto IL_01b9;
								continue;
								end_IL_00dd:
								break;
							}
							break;
						}
					}
					finally
					{
						if (qdnMheaboQxTbfNHeFXhZezQcjfh3 != null)
						{
							while (true)
							{
								IL_074e:
								int num10 = 665507272;
								while (true)
								{
									switch (num10 ^ 0x27AAD5C9)
									{
									case 2:
										break;
									default:
										goto end_IL_0753;
									case 1:
										goto IL_076c;
									case 0:
										goto end_IL_0753;
									}
									goto IL_074e;
									IL_076c:
									((IDisposable)qdnMheaboQxTbfNHeFXhZezQcjfh3).Dispose();
									num10 = 665507273;
									continue;
									end_IL_0753:
									break;
								}
								break;
							}
						}
					}
				}
			}
		}

		private static void bxtRrMUqJwFyqCazPORlKAlsYlAd(IDictionary<string, bool> P_0, string P_1)
		{
			string text = P_1 + "_mouse";
			using (qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh2 = new qdnMheaboQxTbfNHeFXhZezQcjfh("Mouse", text, P_0))
			{
				if (!qdnMheaboQxTbfNHeFXhZezQcjfh2.npNgcUPGCoMjSXwgumOyYMvfGWW)
				{
					return;
				}
				string text2 = default(string);
				Player player = default(Player);
				int num2 = default(int);
				while (true)
				{
					Mouse mouse = ReInput.controllers.Mouse;
					hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Enabled", mouse.enabled.ToString());
					int num = 1624347664;
					while (true)
					{
						switch (num ^ 0x60D19417)
						{
						case 9:
							num = 1624347667;
							continue;
						case 5:
							text2 += ((player.id == 9999999) ? "System" : player.id.ToString());
							num = 1624347677;
							continue;
						case 7:
							text2 = string.Empty;
							num = 1624347670;
							continue;
						case 0:
							hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Screen Position", mouse.screenPosition.ToString());
							hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Screen Position Prev", mouse.screenPositionPrev.ToString());
							hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Screen Position Delta", mouse.screenPositionDelta.ToString());
							num = 1624347669;
							continue;
						case 13:
						{
							int num4;
							if (num2 < ReInput.players.allPlayerCount)
							{
								num = 1624347675;
								num4 = num;
							}
							else
							{
								num = 1624347665;
								num4 = num;
							}
							continue;
						}
						case 10:
							num2++;
							num = 1624347674;
							continue;
						case 6:
							hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
							num = 1624347671;
							continue;
						case 4:
							break;
						case 2:
							cdryyLNyTTheQuBILYACYjekDAz(mouse.Axes, P_0, text);
							num = 1624347679;
							continue;
						case 12:
							player = ReInput.players.AllPlayers[num2];
							if (player.controllers.hasMouse)
							{
								int num3;
								if (text2 != string.Empty)
								{
									num = 1624347676;
									num3 = num;
								}
								else
								{
									num = 1624347666;
									num3 = num;
								}
								continue;
							}
							goto case 10;
						case 3:
							num = 1624347674;
							continue;
						case 1:
							num2 = 0;
							num = 1624347668;
							continue;
						case 11:
							text2 += ", ";
							num = 1624347666;
							continue;
						default:
							cJAsuOZfZsOvrZQvueNdlyYQwxa(mouse.Buttons, ControllerType.Mouse, P_0, text);
							QTLKZWjfpmedrzYWJJXDVpHFirV(mouse, P_0, text);
							fsebqsOsBAfHXavOIxVgdKAeDJCd(mouse, P_0, text);
							return;
						}
						break;
					}
				}
			}
		}

		private static void LHzvvqBnGRghZJIGlTrpBstOkpAN(IDictionary<string, bool> P_0, string P_1)
		{
			string text = P_1 + "_keyboard";
			using (qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh2 = new qdnMheaboQxTbfNHeFXhZezQcjfh("Keyboard", text, P_0))
			{
				if (!qdnMheaboQxTbfNHeFXhZezQcjfh2.npNgcUPGCoMjSXwgumOyYMvfGWW)
				{
					goto IL_0021;
				}
				goto IL_009c;
				IL_0021:
				int num = -441037893;
				goto IL_0026;
				IL_0026:
				int num2 = default(int);
				Keyboard keyboard = default(Keyboard);
				string text2 = default(string);
				Player player = default(Player);
				while (true)
				{
					switch (num ^ -441037902)
					{
					case 8:
						break;
					default:
						return;
					case 12:
						num2++;
						num = -441037895;
						continue;
					case 2:
						QTLKZWjfpmedrzYWJJXDVpHFirV(keyboard, P_0, text);
						num = -441037899;
						continue;
					case 13:
						num2 = 0;
						num = -441037896;
						continue;
					case 0:
						goto IL_009c;
					case 5:
						hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
						num = -441037892;
						continue;
					case 15:
						text2 += ((player.id == 9999999) ? "System" : player.id.ToString());
						num = -441037890;
						continue;
					case 11:
						goto IL_010b;
					case 10:
						num = -441037895;
						continue;
					case 6:
						goto IL_0137;
					case 3:
						hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Enabled", keyboard.enabled.ToString());
						text2 = string.Empty;
						num = -441037889;
						continue;
					case 7:
						fsebqsOsBAfHXavOIxVgdKAeDJCd(keyboard, P_0, text);
						num = -441037898;
						continue;
					case 9:
						return;
					case 1:
						if (text2 != string.Empty)
						{
							text2 += ", ";
							num = -441037891;
							continue;
						}
						goto case 15;
					case 14:
						cJAsuOZfZsOvrZQvueNdlyYQwxa(keyboard.Buttons, ControllerType.Keyboard, P_0, text);
						num = -441037904;
						continue;
					case 4:
						return;
					}
					break;
					IL_0137:
					player = ReInput.players.AllPlayers[num2];
					int num3;
					if (player.controllers.hasKeyboard)
					{
						num = -441037901;
						num3 = num;
					}
					else
					{
						num = -441037890;
						num3 = num;
					}
					continue;
					IL_010b:
					int num4;
					if (num2 < ReInput.players.allPlayerCount)
					{
						num = -441037900;
						num4 = num;
					}
					else
					{
						num = -441037897;
						num4 = num;
					}
				}
				goto IL_0021;
				IL_009c:
				keyboard = ReInput.controllers.Keyboard;
				num = -441037903;
				goto IL_0026;
			}
		}

		private static void sYgEuIIiGfpSwYLkgkXZxhPiFdt(IList<CustomController> P_0, IDictionary<string, bool> P_1, string P_2)
		{
			int num = ((P_0 != null) ? P_0.Count : 0);
			using (qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh2 = new qdnMheaboQxTbfNHeFXhZezQcjfh("Custom Controllers (" + num + ")", P_2 + "_customControllers", P_1))
			{
				if (!qdnMheaboQxTbfNHeFXhZezQcjfh2.npNgcUPGCoMjSXwgumOyYMvfGWW)
				{
					goto IL_003c;
				}
				goto IL_0092;
				IL_003c:
				int num2 = -1796633074;
				goto IL_0041;
				IL_0041:
				switch (num2 ^ -1796633073)
				{
				case 0:
					break;
				case 4:
					goto IL_0062;
				case 3:
					goto IL_0092;
				case 1:
					return;
				default:
					goto IL_00ac;
				}
				goto IL_003c;
				IL_0092:
				int num3 = 0;
				goto IL_09f8;
				IL_00ac:
				CustomController customController = default(CustomController);
				string text = default(string);
				using (qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh3 = new qdnMheaboQxTbfNHeFXhZezQcjfh(num3 + ": " + customController.name, text, P_1))
				{
					if (qdnMheaboQxTbfNHeFXhZezQcjfh3.npNgcUPGCoMjSXwgumOyYMvfGWW)
					{
						Player player = default(Player);
						int num5 = default(int);
						string text2 = default(string);
						int num6 = default(int);
						object[] array = default(object[]);
						ControllerElementIdentifier controllerElementIdentifier = default(ControllerElementIdentifier);
						object[] array2 = default(object[]);
						AxisCalibration axisCalibration = default(AxisCalibration);
						int num15 = default(int);
						object[] array3 = default(object[]);
						bool flag = default(bool);
						while (true)
						{
							IL_01b3:
							hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Id", customController.id.ToString());
							hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Name", customController.name);
							hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Hardware Name", customController.hardwareName);
							hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Tag", customController.tag);
							int num4 = -1796633079;
							while (true)
							{
								switch (num4 ^ -1796633073)
								{
								case 0:
									num4 = -1796633078;
									continue;
								case 2:
								{
									player = ReInput.players.AllPlayers[num5];
									int num19;
									if (!ReInput.controllers.IsCustomControllerAssignedToPlayer(customController.id, player.id))
									{
										num4 = -1796633077;
										num19 = num4;
									}
									else
									{
										num4 = -1796633080;
										num19 = num4;
									}
									continue;
								}
								case 6:
									hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Hardware Identifier", customController.hardwareIdentifier);
									num4 = -1796633076;
									continue;
								case 8:
									text2 += ((player.id == 9999999) ? "System" : player.id.ToString());
									num4 = -1796633077;
									continue;
								case 1:
									num4 = -1796633082;
									continue;
								case 5:
									break;
								case 7:
									if (text2 != string.Empty)
									{
										text2 += ", ";
										num4 = -1796633081;
										continue;
									}
									goto case 8;
								case 3:
									hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Enabled", customController.enabled.ToString());
									text2 = string.Empty;
									num5 = 0;
									num4 = -1796633074;
									continue;
								case 4:
									num5++;
									num4 = -1796633082;
									continue;
								default:
									if (num5 >= ReInput.players.allPlayerCount)
									{
										hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
										cdryyLNyTTheQuBILYACYjekDAz(customController.Axes, P_1, text);
										cJAsuOZfZsOvrZQvueNdlyYQwxa(customController.Buttons, ControllerType.Custom, P_1, text);
										hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Axis2D Count", customController.axis2DCount.ToString());
										using (qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh4 = new qdnMheaboQxTbfNHeFXhZezQcjfh("Element Identifiers", text + "_elementIdentifiers", P_1))
										{
											if (qdnMheaboQxTbfNHeFXhZezQcjfh4.npNgcUPGCoMjSXwgumOyYMvfGWW)
											{
												num6 = ((customController.AxisElementIdentifiers != null) ? customController.AxisElementIdentifiers.Count : 0);
												using (qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh5 = new qdnMheaboQxTbfNHeFXhZezQcjfh("Axis Element Identifiers (" + num6 + ")", text + "_axisEIs", P_1))
												{
													if (qdnMheaboQxTbfNHeFXhZezQcjfh5.npNgcUPGCoMjSXwgumOyYMvfGWW)
													{
														int num7 = 0;
														while (true)
														{
															IL_0346:
															int num8 = -1796633074;
															while (true)
															{
																int num9;
																switch (num8 ^ -1796633073)
																{
																case 2:
																	break;
																case 3:
																	goto IL_0374;
																default:
																{
																	array[0] = num7;
																	array[1] = ": ";
																	array[2] = controllerElementIdentifier.name;
																	array[3] = " (id: ";
																	array[4] = controllerElementIdentifier.id;
																	array[5] = ")";
																	using (qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh6 = new qdnMheaboQxTbfNHeFXhZezQcjfh(string.Concat(array), text + "_AxisEI" + num7 + "_" + controllerElementIdentifier.name, P_1))
																	{
																		if (qdnMheaboQxTbfNHeFXhZezQcjfh6.npNgcUPGCoMjSXwgumOyYMvfGWW)
																		{
																			hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Id", controllerElementIdentifier.id.ToString());
																			hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Name", controllerElementIdentifier.name);
																		}
																	}
																	num7++;
																	goto IL_0469;
																}
																case 1:
																	goto IL_0487;
																	IL_0487:
																	if (num7 < num6)
																	{
																		goto IL_0374;
																	}
																	num9 = -1796633073;
																	goto IL_046e;
																	IL_0469:
																	num9 = -1796633074;
																	goto IL_046e;
																	IL_046e:
																	switch (num9 ^ -1796633073)
																	{
																	case 2:
																		break;
																	default:
																		goto end_IL_034b;
																	case 1:
																		goto IL_0487;
																	case 0:
																		goto end_IL_034b;
																	}
																	goto IL_0469;
																}
																goto IL_0346;
																IL_0374:
																controllerElementIdentifier = customController.AxisElementIdentifiers[num7];
																array = new object[6];
																num8 = -1796633073;
																continue;
																end_IL_034b:
																break;
															}
															break;
														}
													}
												}
												num6 = ((customController.ButtonElementIdentifiers != null) ? customController.ButtonElementIdentifiers.Count : 0);
												qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh7 = new qdnMheaboQxTbfNHeFXhZezQcjfh("Button Element Identifiers (" + num6 + ")", text + "_buttonEIs", P_1);
												try
												{
													if (qdnMheaboQxTbfNHeFXhZezQcjfh7.npNgcUPGCoMjSXwgumOyYMvfGWW)
													{
														int num10 = 0;
														while (true)
														{
															if (num10 < num6)
															{
																ControllerElementIdentifier controllerElementIdentifier2;
																while (true)
																{
																	controllerElementIdentifier2 = customController.ButtonElementIdentifiers[num10];
																	int num11 = -1796633073;
																	while (true)
																	{
																		switch (num11 ^ -1796633073)
																		{
																		case 4:
																			num11 = -1796633074;
																			continue;
																		case 3:
																			array2[0] = num10;
																			num11 = -1796633075;
																			continue;
																		case 0:
																			array2 = new object[6];
																			num11 = -1796633076;
																			continue;
																		case 1:
																			break;
																		default:
																			goto end_IL_0542;
																		}
																		break;
																	}
																	continue;
																	end_IL_0542:
																	break;
																}
																array2[1] = ": ";
																array2[2] = controllerElementIdentifier2.name;
																array2[3] = " (id: ";
																array2[4] = controllerElementIdentifier2.id;
																array2[5] = ")";
																using (qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh8 = new qdnMheaboQxTbfNHeFXhZezQcjfh(string.Concat(array2), text + "_ButtonEI" + num10 + "_" + controllerElementIdentifier2.name, P_1))
																{
																	if (qdnMheaboQxTbfNHeFXhZezQcjfh8.npNgcUPGCoMjSXwgumOyYMvfGWW)
																	{
																		hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Id", controllerElementIdentifier2.id.ToString());
																		hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Name", controllerElementIdentifier2.name);
																	}
																}
																num10++;
																goto IL_0624;
															}
															int num12 = -1796633074;
															goto IL_0629;
															IL_0624:
															num12 = -1796633075;
															goto IL_0629;
															IL_0629:
															switch (num12 ^ -1796633073)
															{
															case 0:
																break;
															default:
																goto end_IL_0642;
															case 2:
																continue;
															case 1:
																goto end_IL_0642;
															}
															goto IL_0624;
															continue;
															end_IL_0642:
															break;
														}
													}
												}
												finally
												{
													if (qdnMheaboQxTbfNHeFXhZezQcjfh7 != null)
													{
														while (true)
														{
															IL_0658:
															int num13 = -1796633074;
															while (true)
															{
																switch (num13 ^ -1796633073)
																{
																case 2:
																	break;
																default:
																	goto end_IL_065d;
																case 1:
																	goto IL_0676;
																case 0:
																	goto end_IL_065d;
																}
																goto IL_0658;
																IL_0676:
																((IDisposable)qdnMheaboQxTbfNHeFXhZezQcjfh7).Dispose();
																num13 = -1796633073;
																continue;
																end_IL_065d:
																break;
															}
															break;
														}
													}
												}
											}
										}
										CalibrationMap calibrationMap = customController.calibrationMap;
										using (qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh9 = new qdnMheaboQxTbfNHeFXhZezQcjfh("Calibration Map", text + "_calibrationMap", P_1))
										{
											if (qdnMheaboQxTbfNHeFXhZezQcjfh9.npNgcUPGCoMjSXwgumOyYMvfGWW)
											{
												while (true)
												{
													IL_06c0:
													int num14 = -1796633077;
													while (true)
													{
														int num17;
														switch (num14 ^ -1796633073)
														{
														case 0:
															break;
														case 1:
															axisCalibration = calibrationMap.Axes[num15];
															array3 = new object[4];
															num14 = -1796633075;
															continue;
														case 5:
															num15 = 0;
															num14 = -1796633076;
															continue;
														case 4:
															num6 = calibrationMap.axisCount;
															num14 = -1796633078;
															continue;
														default:
														{
															array3[0] = num15;
															array3[1] = ": Axis Calibration (";
															array3[2] = (axisCalibration.enabled ? "Enabled" : "Disabled");
															array3[3] = ")";
															using (qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh10 = new qdnMheaboQxTbfNHeFXhZezQcjfh(string.Concat(array3), text + "_AxisCalibration" + num15, P_1))
															{
																if (qdnMheaboQxTbfNHeFXhZezQcjfh10.npNgcUPGCoMjSXwgumOyYMvfGWW)
																{
																	while (true)
																	{
																		IL_07c6:
																		hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Enabled", axisCalibration.enabled.ToString());
																		hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Apply Range Calibration", axisCalibration.applyRangeCalibration.ToString());
																		hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Calibrated Max", axisCalibration.calibratedMax.ToString());
																		int num16 = -1796633076;
																		while (true)
																		{
																			switch (num16 ^ -1796633073)
																			{
																			case 5:
																				num16 = -1796633077;
																				continue;
																			default:
																				goto end_IL_079a;
																			case 4:
																				break;
																			case 1:
																				GUI.enabled = flag;
																				num16 = -1796633079;
																				continue;
																			case 3:
																				hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Calibrated Min", axisCalibration.calibratedMin.ToString());
																				hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Calibrated Zero", axisCalibration.calibratedZero.ToString());
																				hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Dead Zone", axisCalibration.deadZone.ToString());
																				hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Invert", axisCalibration.invert.ToString());
																				hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Sensitivity Type", axisCalibration.sensitivityType.ToString());
																				num16 = -1796633075;
																				continue;
																			case 2:
																				hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Sensitivity", axisCalibration.sensitivity.ToString());
																				if (axisCalibration.sensitivityCurve != null)
																				{
																					flag = GUI.enabled;
																					GUI.enabled = false;
																					hpyXVhdtbiFWFEVwktnGBdahHCR.rbBIooRDmkizndzyyjvLzURQFYff("Sensitivity Curve", axisCalibration.sensitivityCurve);
																					num16 = -1796633074;
																					continue;
																				}
																				goto case 0;
																			case 0:
																				hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Sensitivity Curve", "--");
																				num16 = -1796633079;
																				continue;
																			case 6:
																				goto end_IL_079a;
																			}
																			goto IL_07c6;
																			continue;
																			end_IL_079a:
																			break;
																		}
																		break;
																	}
																}
															}
															num15++;
															goto IL_0934;
														}
														case 3:
															goto IL_0952;
															IL_0952:
															if (num15 < num6)
															{
																goto case 1;
															}
															num17 = -1796633074;
															goto IL_0939;
															IL_0934:
															num17 = -1796633075;
															goto IL_0939;
															IL_0939:
															switch (num17 ^ -1796633073)
															{
															case 0:
																break;
															default:
																goto end_IL_06c5;
															case 2:
																goto IL_0952;
															case 1:
																goto end_IL_06c5;
															}
															goto IL_0934;
														}
														goto IL_06c0;
														continue;
														end_IL_06c5:
														break;
													}
													break;
												}
											}
										}
										hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Has Extension", (customController.extension != null).ToString());
										while (true)
										{
											IL_098f:
											int num18 = -1796633074;
											while (true)
											{
												string obj;
												switch (num18 ^ -1796633073)
												{
												case 2:
													break;
												default:
													goto end_IL_0994;
												case 1:
													obj = ((customController.extension != null) ? customController.extension.GetType().Name : "--");
													goto IL_09d1;
												case 0:
													goto end_IL_0994;
												}
												goto IL_098f;
												IL_09d1:
												hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Extension Type", obj);
												fsebqsOsBAfHXavOIxVgdKAeDJCd(customController, P_1, text);
												num18 = -1796633073;
												continue;
												end_IL_0994:
												break;
											}
											break;
										}
										goto end_IL_00e2;
									}
									goto case 2;
								}
								goto IL_01b3;
								continue;
								end_IL_00e2:
								break;
							}
							break;
						}
					}
				}
				num3++;
				goto IL_09f8;
				IL_0062:
				customController = ReInput.controllers.CustomControllers[num3];
				text = P_2 + "_customController" + customController.id;
				num2 = -1796633075;
				goto IL_0041;
				IL_09f8:
				if (num3 >= num)
				{
					return;
				}
				goto IL_0062;
			}
		}

		private static void KhiSdsvySiPfFtsDMwmhkRqrHOC(Player P_0, int P_1, IDictionary<string, bool> P_2, string P_3)
		{
			string text = P_3 + "_player" + P_0.id;
			qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh2 = new qdnMheaboQxTbfNHeFXhZezQcjfh((P_0.id == 9999999) ? "System Player" : (P_1 + ": " + P_0.name), text, P_2);
			try
			{
				if (!qdnMheaboQxTbfNHeFXhZezQcjfh2.npNgcUPGCoMjSXwgumOyYMvfGWW)
				{
					goto IL_0051;
				}
				goto IL_009a;
				IL_0051:
				int num = 573225005;
				goto IL_0056;
				IL_0056:
				int num4 = default(int);
				Joystick joystick = default(Joystick);
				string text4 = default(string);
				object[] array = default(object[]);
				int num12 = default(int);
				int num15 = default(int);
				InputAction inputAction = default(InputAction);
				while (true)
				{
					switch (num ^ 0x222AB829)
					{
					case 3:
						break;
					case 4:
						return;
					case 0:
						hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Descriptive Name", P_0.descriptiveName);
						num = 573225000;
						continue;
					case 2:
						goto IL_009a;
					default:
					{
						hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Is Playing", P_0.isPlaying.ToString());
						using (qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh3 = new qdnMheaboQxTbfNHeFXhZezQcjfh("Controllers", text + "_controllers", P_2))
						{
							if (qdnMheaboQxTbfNHeFXhZezQcjfh3.npNgcUPGCoMjSXwgumOyYMvfGWW)
							{
								while (true)
								{
									IL_0105:
									int num2 = 573225000;
									while (true)
									{
										switch (num2 ^ 0x222AB829)
										{
										case 0:
											break;
										default:
											goto end_IL_010a;
										case 1:
											goto IL_0123;
										case 2:
											goto end_IL_010a;
										}
										goto IL_0105;
										IL_0123:
										Player.ControllerHelper controllers = P_0.controllers;
										kgjoHFqQSEfqgbDDwuOQKUNMVhW(controllers.Joysticks, P_2, text);
										sYgEuIIiGfpSwYLkgkXZxhPiFdt(controllers.CustomControllers, P_2, text);
										hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Has Mouse", controllers.hasMouse.ToString());
										hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Has Keyboard", controllers.hasKeyboard.ToString());
										hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Exclude From Controller Auto Assignment", controllers.excludeFromControllerAutoAssignment.ToString());
										num2 = 573225003;
										continue;
										end_IL_010a:
										break;
									}
									break;
								}
							}
						}
						string text2 = text + "_controllerMaps";
						using (qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh4 = new qdnMheaboQxTbfNHeFXhZezQcjfh("Controller Maps", text2, P_2))
						{
							if (qdnMheaboQxTbfNHeFXhZezQcjfh4.npNgcUPGCoMjSXwgumOyYMvfGWW)
							{
								MwfcNzNZlFnAzleJVJoFTFinmuW(ControllerType.Keyboard, P_0.controllers.maps.GetMaps<KeyboardMap>(0), "Keyboard Maps", P_2, text2 + "_keyboard");
								MwfcNzNZlFnAzleJVJoFTFinmuW(ControllerType.Mouse, P_0.controllers.maps.GetMaps<MouseMap>(0), "Mouse Maps", P_2, text2 + "_mouse");
								string text3 = text2 + "_joystickMaps";
								using (qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh5 = new qdnMheaboQxTbfNHeFXhZezQcjfh("Joysticks (" + P_0.controllers.joystickCount + ")", text3, P_2))
								{
									if (qdnMheaboQxTbfNHeFXhZezQcjfh5.npNgcUPGCoMjSXwgumOyYMvfGWW)
									{
										while (true)
										{
											IL_0262:
											int num3 = 573225004;
											while (true)
											{
												switch (num3 ^ 0x222AB829)
												{
												case 0:
													break;
												default:
													goto end_IL_0267;
												case 5:
													num4 = 0;
													num3 = 573225000;
													continue;
												case 2:
													joystick = P_0.controllers.Joysticks[num4];
													num3 = 573225002;
													continue;
												case 1:
												{
													int num5;
													if (num4 < P_0.controllers.joystickCount)
													{
														num3 = 573225003;
														num5 = num3;
													}
													else
													{
														num3 = 573225005;
														num5 = num3;
													}
													continue;
												}
												case 3:
												{
													IList<JoystickMap> maps = P_0.controllers.maps.GetMaps<JoystickMap>(joystick.id);
													text3 = text3 + "_joystickId" + joystick.id;
													MwfcNzNZlFnAzleJVJoFTFinmuW(ControllerType.Joystick, maps, (joystick.name != "Unknown Controller") ? joystick.name : joystick.hardwareName, P_2, text3);
													num4++;
													num3 = 573225000;
													continue;
												}
												case 4:
													goto end_IL_0267;
												}
												goto IL_0262;
												continue;
												end_IL_0267:
												break;
											}
											break;
										}
									}
								}
								text3 = text2 + "_customControllerMaps";
								qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh6 = new qdnMheaboQxTbfNHeFXhZezQcjfh("Custom Controllers (" + P_0.controllers.customControllerCount + ")", text3, P_2);
								try
								{
									if (qdnMheaboQxTbfNHeFXhZezQcjfh6.npNgcUPGCoMjSXwgumOyYMvfGWW)
									{
										int num6 = 0;
										while (true)
										{
											IL_0399:
											int num7 = 573225000;
											while (true)
											{
												switch (num7 ^ 0x222AB829)
												{
												case 3:
													break;
												default:
													goto end_IL_039e;
												case 4:
												{
													int num8;
													if (num6 < P_0.controllers.customControllerCount)
													{
														num7 = 573225001;
														num8 = num7;
													}
													else
													{
														num7 = 573225003;
														num8 = num7;
													}
													continue;
												}
												case 0:
												{
													CustomController customController = P_0.controllers.CustomControllers[num6];
													IList<CustomControllerMap> maps2 = P_0.controllers.maps.GetMaps<CustomControllerMap>(customController.id);
													text3 = text3 + "_customControllerId" + customController.id;
													MwfcNzNZlFnAzleJVJoFTFinmuW(ControllerType.Custom, maps2, customController.name, P_2, text3);
													num6++;
													num7 = 573225005;
													continue;
												}
												case 1:
													num7 = 573225005;
													continue;
												case 2:
													goto end_IL_039e;
												}
												goto IL_0399;
												continue;
												end_IL_039e:
												break;
											}
											break;
										}
									}
								}
								finally
								{
									if (qdnMheaboQxTbfNHeFXhZezQcjfh6 != null)
									{
										while (true)
										{
											IL_045c:
											int num9 = 573225000;
											while (true)
											{
												switch (num9 ^ 0x222AB829)
												{
												case 0:
													break;
												default:
													goto end_IL_0461;
												case 1:
													goto IL_047a;
												case 2:
													goto end_IL_0461;
												}
												goto IL_045c;
												IL_047a:
												((IDisposable)qdnMheaboQxTbfNHeFXhZezQcjfh6).Dispose();
												num9 = 573225003;
												continue;
												end_IL_0461:
												break;
											}
											break;
										}
									}
								}
							}
						}
						text2 = text + "_controllerMapLayoutManager";
						using (qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh7 = new qdnMheaboQxTbfNHeFXhZezQcjfh("Layout Manager", text2, P_2))
						{
							if (qdnMheaboQxTbfNHeFXhZezQcjfh7.npNgcUPGCoMjSXwgumOyYMvfGWW)
							{
								tjMFhQmsdLRjXUucVLZhcbRoaaf(P_0.controllers.maps.layoutManager, P_2, text2);
							}
						}
						text2 = text + "_controllerMapEnabler";
						using (qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh8 = new qdnMheaboQxTbfNHeFXhZezQcjfh("Map Enabler", text2, P_2))
						{
							if (qdnMheaboQxTbfNHeFXhZezQcjfh8.npNgcUPGCoMjSXwgumOyYMvfGWW)
							{
								eLXprxOOFHNXZdpFSeYcQFjBDYcC(P_0.controllers.maps.mapEnabler, P_2, text2);
							}
						}
						text2 = text + "_inputBehaviors";
						LzuaqUaBnxeKZnCjEVBELnQYFqrD(P_0.controllers.maps.InputBehaviors, P_2, text2);
						text2 = text + "_actions";
						List<InputAction> list = new List<InputAction>(ReInput.mapping.Actions);
						list.Sort((InputAction inputAction2, InputAction inputAction3) => inputAction2.name.CompareTo(inputAction3.name));
						IList<InputCategory> actionCategories = ReInput.mapping.ActionCategories;
						qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh9 = new qdnMheaboQxTbfNHeFXhZezQcjfh("Actions (" + list.Count + ")", text2, P_2);
						try
						{
							if (!qdnMheaboQxTbfNHeFXhZezQcjfh9.npNgcUPGCoMjSXwgumOyYMvfGWW)
							{
								return;
							}
							int num10 = 0;
							while (true)
							{
								if (num10 < actionCategories.Count)
								{
									HMcigQiVOxIAdRwvKwHjCdQdRpc hMcigQiVOxIAdRwvKwHjCdQdRpc;
									while (true)
									{
										hMcigQiVOxIAdRwvKwHjCdQdRpc = new HMcigQiVOxIAdRwvKwHjCdQdRpc();
										int num11 = 573225000;
										while (true)
										{
											switch (num11 ^ 0x222AB829)
											{
											case 6:
												num11 = 573225002;
												continue;
											case 7:
												text4 = text2 + "_actionCat" + hMcigQiVOxIAdRwvKwHjCdQdRpc.yLWxWdSFSmWBToqYYJSIYtZGAcS.id;
												num11 = 573225003;
												continue;
											case 4:
												array[0] = "id ";
												num11 = 573225001;
												continue;
											case 0:
												array[1] = hMcigQiVOxIAdRwvKwHjCdQdRpc.yLWxWdSFSmWBToqYYJSIYtZGAcS.id;
												array[2] = ": ";
												array[3] = hMcigQiVOxIAdRwvKwHjCdQdRpc.yLWxWdSFSmWBToqYYJSIYtZGAcS.name;
												array[4] = " (";
												array[5] = num12;
												array[6] = ")";
												num11 = 573225004;
												continue;
											case 2:
												num12 = ListTools.Count(list, hMcigQiVOxIAdRwvKwHjCdQdRpc.SeLLAGaYcRSkUiAPfslbLLmNOFt);
												array = new object[7];
												num11 = 573225005;
												continue;
											case 1:
												hMcigQiVOxIAdRwvKwHjCdQdRpc.yLWxWdSFSmWBToqYYJSIYtZGAcS = actionCategories[num10];
												num11 = 573225006;
												continue;
											case 3:
												break;
											default:
												goto end_IL_06db;
											}
											break;
										}
										continue;
										end_IL_06db:
										break;
									}
									qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh10 = new qdnMheaboQxTbfNHeFXhZezQcjfh(string.Concat(array), text4, P_2);
									try
									{
										if (qdnMheaboQxTbfNHeFXhZezQcjfh10.npNgcUPGCoMjSXwgumOyYMvfGWW)
										{
											while (true)
											{
												IL_0709:
												int num13 = 573225003;
												while (true)
												{
													int num16;
													switch (num13 ^ 0x222AB829)
													{
													case 3:
														break;
													case 2:
														num15 = 0;
														num13 = 573225000;
														continue;
													case 0:
														inputAction = list[num15];
														if (inputAction.categoryId == hMcigQiVOxIAdRwvKwHjCdQdRpc.yLWxWdSFSmWBToqYYJSIYtZGAcS.id)
														{
															num13 = 573225005;
															continue;
														}
														goto IL_09ca;
													default:
													{
														string key = text4 + "_actionId" + inputAction.id;
														using (qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh11 = new qdnMheaboQxTbfNHeFXhZezQcjfh("id " + inputAction.id + ": " + inputAction.name + ": " + P_0.GetAxis(inputAction.id).ToString("f3"), key, P_2))
														{
															if (qdnMheaboQxTbfNHeFXhZezQcjfh11.npNgcUPGCoMjSXwgumOyYMvfGWW)
															{
																hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Axis Value", P_0.GetAxis(inputAction.id).ToString());
																hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Axis Raw Value", P_0.GetAxisRaw(inputAction.id).ToString());
																hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Button Value", P_0.GetButton(inputAction.id).ToString());
																hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Button Double Press Value", P_0.GetButtonDoublePressHold(inputAction.id).ToString());
																hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Button Short Press Value", P_0.GetButtonShortPress(inputAction.id).ToString());
																hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Button Long Press Value", P_0.GetButtonLongPress(inputAction.id).ToString());
																hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Button Repeating Value", P_0.GetButtonRepeating(inputAction.id).ToString());
																hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Negative Button Value", P_0.GetNegativeButton(inputAction.id).ToString());
																while (true)
																{
																	IL_0903:
																	int num14 = 573225003;
																	while (true)
																	{
																		switch (num14 ^ 0x222AB829)
																		{
																		case 0:
																			break;
																		default:
																			goto end_IL_0908;
																		case 2:
																			hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Negative Button Double Press Value", P_0.GetNegativeButtonDoublePressHold(inputAction.id).ToString());
																			hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Negative Button Short Press Value", P_0.GetNegativeButtonShortPress(inputAction.id).ToString());
																			hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Negative Button Long Press Value", P_0.GetNegativeButtonLongPress(inputAction.id).ToString());
																			num14 = 573225002;
																			continue;
																		case 3:
																			hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Negative Button Repeating Value", P_0.GetNegativeButtonRepeating(inputAction.id).ToString());
																			num14 = 573225000;
																			continue;
																		case 1:
																			goto end_IL_0908;
																		}
																		goto IL_0903;
																		continue;
																		end_IL_0908:
																		break;
																	}
																	break;
																}
															}
														}
														goto IL_09ca;
													}
													case 1:
														goto IL_09ee;
														IL_09ca:
														num15++;
														goto IL_09d0;
														IL_09d0:
														num16 = 573225000;
														goto IL_09d5;
														IL_09d5:
														switch (num16 ^ 0x222AB829)
														{
														case 2:
															break;
														default:
															goto end_IL_070e;
														case 1:
															goto IL_09ee;
														case 0:
															goto end_IL_070e;
														}
														goto IL_09d0;
														IL_09ee:
														if (num15 < list.Count)
														{
															goto case 0;
														}
														num16 = 573225001;
														goto IL_09d5;
													}
													goto IL_0709;
													continue;
													end_IL_070e:
													break;
												}
												break;
											}
										}
									}
									finally
									{
										if (qdnMheaboQxTbfNHeFXhZezQcjfh10 != null)
										{
											while (true)
											{
												IL_0a09:
												int num17 = 573225000;
												while (true)
												{
													switch (num17 ^ 0x222AB829)
													{
													case 2:
														break;
													default:
														goto end_IL_0a0e;
													case 1:
														goto IL_0a27;
													case 0:
														goto end_IL_0a0e;
													}
													goto IL_0a09;
													IL_0a27:
													((IDisposable)qdnMheaboQxTbfNHeFXhZezQcjfh10).Dispose();
													num17 = 573225001;
													continue;
													end_IL_0a0e:
													break;
												}
												break;
											}
										}
									}
									num10++;
									goto IL_0a3c;
								}
								int num18 = 573225001;
								goto IL_0a41;
								IL_0a3c:
								num18 = 573225000;
								goto IL_0a41;
								IL_0a41:
								switch (num18 ^ 0x222AB829)
								{
								case 2:
									break;
								default:
									return;
								case 1:
									continue;
								case 0:
									return;
								}
								goto IL_0a3c;
							}
						}
						finally
						{
							if (qdnMheaboQxTbfNHeFXhZezQcjfh9 != null)
							{
								while (true)
								{
									IL_0a75:
									int num19 = 573225000;
									while (true)
									{
										switch (num19 ^ 0x222AB829)
										{
										case 2:
											break;
										default:
											goto end_IL_0a7a;
										case 1:
											goto IL_0a93;
										case 0:
											goto end_IL_0a7a;
										}
										goto IL_0a75;
										IL_0a93:
										((IDisposable)qdnMheaboQxTbfNHeFXhZezQcjfh9).Dispose();
										num19 = 573225001;
										continue;
										end_IL_0a7a:
										break;
									}
									break;
								}
							}
						}
					}
					}
					break;
				}
				goto IL_0051;
				IL_009a:
				hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Player Id", P_0.id.ToString());
				hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Name", P_0.name);
				num = 573225001;
				goto IL_0056;
			}
			finally
			{
				if (qdnMheaboQxTbfNHeFXhZezQcjfh2 != null)
				{
					while (true)
					{
						IL_0aa7:
						int num20 = 573225003;
						while (true)
						{
							switch (num20 ^ 0x222AB829)
							{
							case 0:
								break;
							default:
								goto end_IL_0aac;
							case 2:
								goto IL_0ac5;
							case 1:
								goto end_IL_0aac;
							}
							goto IL_0aa7;
							IL_0ac5:
							((IDisposable)qdnMheaboQxTbfNHeFXhZezQcjfh2).Dispose();
							num20 = 573225000;
							continue;
							end_IL_0aac:
							break;
						}
						break;
					}
				}
			}
		}

		private static void LzuaqUaBnxeKZnCjEVBELnQYFqrD(IList<InputBehavior> P_0, IDictionary<string, bool> P_1, string P_2)
		{
			int num = ((P_0 != null) ? P_0.Count : 0);
			using (qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh2 = new qdnMheaboQxTbfNHeFXhZezQcjfh("Input Behaviors (" + num + ")", P_2 + "_inputBehaviors", P_1))
			{
				if (!qdnMheaboQxTbfNHeFXhZezQcjfh2.npNgcUPGCoMjSXwgumOyYMvfGWW)
				{
					goto IL_003c;
				}
				goto IL_00ab;
				IL_003c:
				int num2 = 608910590;
				goto IL_0041;
				IL_0041:
				int num3 = default(int);
				while (true)
				{
					switch (num2 ^ 0x244B3CFA)
					{
					case 5:
						break;
					default:
						return;
					case 4:
						return;
					case 3:
					{
						InputBehavior inputBehavior = P_0[num3];
						FtLYKRBBOHGEyboXIKThpmxZWaR(inputBehavior, num3, P_1, P_2);
						num2 = 608910588;
						continue;
					}
					case 6:
						num3++;
						num2 = 608910586;
						continue;
					case 0:
						goto IL_0096;
					case 2:
						goto IL_00ab;
					case 1:
						return;
					}
					break;
					IL_0096:
					int num4;
					if (num3 < num)
					{
						num2 = 608910585;
						num4 = num2;
					}
					else
					{
						num2 = 608910587;
						num4 = num2;
					}
				}
				goto IL_003c;
				IL_00ab:
				num3 = 0;
				num2 = 608910586;
				goto IL_0041;
			}
		}

		private static void FtLYKRBBOHGEyboXIKThpmxZWaR(InputBehavior P_0, int P_1, IDictionary<string, bool> P_2, string P_3)
		{
			string key = P_3 + "_inputBehavior" + P_0.id;
			using (qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh2 = new qdnMheaboQxTbfNHeFXhZezQcjfh(P_1 + ": " + P_0.name, key, P_2))
			{
				if (!qdnMheaboQxTbfNHeFXhZezQcjfh2.npNgcUPGCoMjSXwgumOyYMvfGWW)
				{
					return;
				}
				while (true)
				{
					hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Id", P_0.id.ToString());
					int num = -88978676;
					while (true)
					{
						switch (num ^ -88978673)
						{
						case 0:
							num = -88978675;
							continue;
						case 1:
							hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Mouse XY Axis Sensitivity", P_0.mouseXYAxisSensitivity.ToString());
							hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Mouse XY Axis Delta Calc", P_0.mouseXYAxisDeltaCalc.ToString());
							hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Mouse Other Axis Mode", P_0.mouseOtherAxisMode.ToString());
							hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Mouse Other Axis Sensitivity", P_0.mouseOtherAxisSensitivity.ToString());
							hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Button Dead Zone", P_0.buttonDeadZone.ToString());
							num = -88978677;
							continue;
						case 3:
							hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Name", P_0.name);
							hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Digital Axis Gravity", P_0.digitalAxisGravity.ToString());
							hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Digital Axis Instant Reverse", P_0.digitalAxisInstantReverse.ToString());
							hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Digital Axis Sensitivity", P_0.digitalAxisSensitivity.ToString());
							hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Digital Axis Snap", P_0.digitalAxisSnap.ToString());
							hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Joystick Axis Sensitivity", P_0.joystickAxisSensitivity.ToString());
							hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Custom Controller Axis Sensitivity", P_0.customControllerAxisSensitivity.ToString());
							hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Mouse XY Axis Mode", P_0.mouseXYAxisMode.ToString());
							num = -88978674;
							continue;
						case 2:
							break;
						default:
							hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Button Double Press Speed", P_0.buttonDoublePressSpeed.ToString());
							hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Button Short Press Time", P_0.buttonShortPressTime.ToString());
							hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Button Short Press Expires In", P_0.buttonShortPressExpiresIn.ToString());
							hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Button Long Press Time", P_0.buttonLongPressTime.ToString());
							hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Button Long Press Expires In", P_0.buttonLongPressExpiresIn.ToString());
							hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Button Down Buffer", P_0.buttonDownBuffer.ToString());
							return;
						}
						break;
					}
				}
			}
		}

		private static void QTLKZWjfpmedrzYWJJXDVpHFirV(Controller P_0, IDictionary<string, bool> P_1, string P_2)
		{
			using (qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh2 = new qdnMheaboQxTbfNHeFXhZezQcjfh("Element Identifiers", P_2 + "_elementIdentifiers", P_1))
			{
				if (!qdnMheaboQxTbfNHeFXhZezQcjfh2.npNgcUPGCoMjSXwgumOyYMvfGWW)
				{
					return;
				}
				ControllerWithAxes controllerWithAxes = default(ControllerWithAxes);
				object[] array = default(object[]);
				Controller controller = default(Controller);
				object[] array2 = default(object[]);
				ControllerElementIdentifier controllerElementIdentifier2 = default(ControllerElementIdentifier);
				while (true)
				{
					int num = 1710467718;
					while (true)
					{
						switch (num ^ 0x65F3AA87)
						{
						case 2:
							break;
						case 1:
							if (P_0 is ControllerWithAxes)
							{
								num = 1710467716;
								continue;
							}
							goto IL_023b;
						case 3:
							controllerWithAxes = P_0 as ControllerWithAxes;
							num = 1710467719;
							continue;
						default:
							{
								int num2 = ((controllerWithAxes.AxisElementIdentifiers != null) ? controllerWithAxes.AxisElementIdentifiers.Count : 0);
								using (qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh3 = new qdnMheaboQxTbfNHeFXhZezQcjfh("Axis Element Identifiers (" + num2 + ")", P_2 + "_axisEIs", P_1))
								{
									if (qdnMheaboQxTbfNHeFXhZezQcjfh3.npNgcUPGCoMjSXwgumOyYMvfGWW)
									{
										int num3 = 0;
										while (true)
										{
											if (num3 < num2)
											{
												ControllerElementIdentifier controllerElementIdentifier;
												while (true)
												{
													controllerElementIdentifier = controllerWithAxes.AxisElementIdentifiers[num3];
													int num4 = 1710467718;
													while (true)
													{
														switch (num4 ^ 0x65F3AA87)
														{
														case 0:
															num4 = 1710467717;
															continue;
														case 2:
															break;
														case 1:
															array = new object[6] { num3, ": ", controllerElementIdentifier.name, " (id: ", null, null };
															num4 = 1710467716;
															continue;
														default:
															goto end_IL_00d7;
														}
														break;
													}
													continue;
													end_IL_00d7:
													break;
												}
												array[4] = controllerElementIdentifier.id;
												array[5] = ")";
												using (qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh4 = new qdnMheaboQxTbfNHeFXhZezQcjfh(string.Concat(array), P_2 + "_AxisEI" + num3 + "_" + controllerElementIdentifier.name, P_1))
												{
													if (qdnMheaboQxTbfNHeFXhZezQcjfh4.npNgcUPGCoMjSXwgumOyYMvfGWW)
													{
														while (true)
														{
															IL_01b5:
															hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Id", controllerElementIdentifier.id.ToString());
															int num5 = 1710467719;
															while (true)
															{
																switch (num5 ^ 0x65F3AA87)
																{
																case 2:
																	num5 = 1710467718;
																	continue;
																default:
																	goto end_IL_0198;
																case 1:
																	break;
																case 0:
																	hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Name", controllerElementIdentifier.name);
																	num5 = 1710467716;
																	continue;
																case 3:
																	goto end_IL_0198;
																}
																goto IL_01b5;
																continue;
																end_IL_0198:
																break;
															}
															break;
														}
													}
												}
												num3++;
												goto IL_0202;
											}
											int num6 = 1710467718;
											goto IL_0207;
											IL_0202:
											num6 = 1710467717;
											goto IL_0207;
											IL_0207:
											switch (num6 ^ 0x65F3AA87)
											{
											case 0:
												break;
											default:
												goto end_IL_0220;
											case 2:
												continue;
											case 1:
												goto end_IL_0220;
											}
											goto IL_0202;
											continue;
											end_IL_0220:
											break;
										}
									}
								}
								goto IL_023b;
							}
							IL_023b:
							if (P_0 == null)
							{
								return;
							}
							while (true)
							{
								int num7 = 1710467717;
								while (true)
								{
									switch (num7 ^ 0x65F3AA87)
									{
									case 0:
										break;
									case 2:
										goto IL_025f;
									default:
									{
										int num2 = ((controller.ButtonElementIdentifiers != null) ? controller.ButtonElementIdentifiers.Count : 0);
										qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh5 = new qdnMheaboQxTbfNHeFXhZezQcjfh("Button Element Identifiers (" + num2 + ")", P_2 + "_buttonEIs", P_1);
										try
										{
											if (!qdnMheaboQxTbfNHeFXhZezQcjfh5.npNgcUPGCoMjSXwgumOyYMvfGWW)
											{
												return;
											}
											int num8 = 0;
											while (true)
											{
												int num9 = 1710467718;
												while (true)
												{
													int num10;
													switch (num9 ^ 0x65F3AA87)
													{
													case 2:
														break;
													case 3:
														array2[2] = controllerElementIdentifier2.name;
														array2[3] = " (id: ";
														array2[4] = controllerElementIdentifier2.id;
														num9 = 1710467715;
														continue;
													case 0:
														controllerElementIdentifier2 = controller.ButtonElementIdentifiers[num8];
														array2 = new object[6] { num8, ": ", null, null, null, null };
														num9 = 1710467716;
														continue;
													default:
													{
														array2[5] = ")";
														using (qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh6 = new qdnMheaboQxTbfNHeFXhZezQcjfh(string.Concat(array2), P_2 + "_ButtonEI" + num8 + "_" + controllerElementIdentifier2.name, P_1))
														{
															if (qdnMheaboQxTbfNHeFXhZezQcjfh6.npNgcUPGCoMjSXwgumOyYMvfGWW)
															{
																hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Id", controllerElementIdentifier2.id.ToString());
																hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Name", controllerElementIdentifier2.name);
															}
														}
														num8++;
														goto IL_03ea;
													}
													case 1:
														goto IL_0408;
														IL_03ea:
														num10 = 1710467718;
														goto IL_03ef;
														IL_03ef:
														switch (num10 ^ 0x65F3AA87)
														{
														case 0:
															break;
														default:
															return;
														case 1:
															goto IL_0408;
														case 2:
															return;
														}
														goto IL_03ea;
														IL_0408:
														if (num8 < num2)
														{
															goto case 0;
														}
														num10 = 1710467717;
														goto IL_03ef;
													}
													break;
												}
											}
										}
										finally
										{
											if (qdnMheaboQxTbfNHeFXhZezQcjfh5 != null)
											{
												while (true)
												{
													IL_041d:
													int num11 = 1710467718;
													while (true)
													{
														switch (num11 ^ 0x65F3AA87)
														{
														case 2:
															break;
														default:
															goto end_IL_0422;
														case 1:
															goto IL_043b;
														case 0:
															goto end_IL_0422;
														}
														goto IL_041d;
														IL_043b:
														((IDisposable)qdnMheaboQxTbfNHeFXhZezQcjfh5).Dispose();
														num11 = 1710467719;
														continue;
														end_IL_0422:
														break;
													}
													break;
												}
											}
										}
									}
									}
									break;
									IL_025f:
									controller = P_0;
									num7 = 1710467718;
								}
							}
						}
						break;
					}
				}
			}
		}

		private static void cJAsuOZfZsOvrZQvueNdlyYQwxa(IList<Controller.Button> P_0, ControllerType P_1, IDictionary<string, bool> P_2, string P_3)
		{
			if (P_1 != ControllerType.Keyboard)
			{
				goto IL_0003;
			}
			object obj = "Key";
			goto IL_0035;
			IL_0040:
			int num = 0;
			goto IL_0049;
			IL_0003:
			int num2 = 1786005926;
			goto IL_0008;
			IL_0008:
			object[] array = default(object[]);
			string text = default(string);
			int num3 = default(int);
			while (true)
			{
				switch (num2 ^ 0x6A7449A7)
				{
				case 2:
					break;
				case 1:
					goto IL_0029;
				case 3:
					goto IL_0040;
				case 4:
					array[0] = text;
					array[1] = "s (";
					num2 = 1786005927;
					continue;
				default:
				{
					array[2] = num3;
					array[3] = ")";
					using (qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh2 = new qdnMheaboQxTbfNHeFXhZezQcjfh(string.Concat(array), P_3 + "_Buttons", P_2))
					{
						if (!qdnMheaboQxTbfNHeFXhZezQcjfh2.npNgcUPGCoMjSXwgumOyYMvfGWW)
						{
							return;
						}
						while (true)
						{
							int num4 = 0;
							while (true)
							{
								Controller.Button button;
								object[] array2;
								if (num4 < num3)
								{
									while (true)
									{
										button = P_0[num4];
										array2 = new object[8] { num4, null, null, null, null, null, null, null };
										int num5 = 1786005923;
										while (true)
										{
											switch (num5 ^ 0x6A7449A7)
											{
											case 0:
												num5 = 1786005925;
												continue;
											case 3:
												array2[6] = button.pressure.ToString("f3");
												num5 = 1786005921;
												continue;
											case 4:
												array2[1] = ": ";
												array2[2] = ((P_1 == ControllerType.Keyboard) ? Keyboard.GetKeyboardKeyCodeByButtonIndex(num4).ToString() : button.elementIdentifier.name);
												array2[3] = ": ";
												array2[4] = (button.value ? "Pressed" : "");
												array2[5] = " (";
												num5 = 1786005924;
												continue;
											case 1:
												break;
											case 2:
												goto end_IL_015e;
											case 6:
												array2[7] = ")";
												num5 = 1786005922;
												continue;
											default:
												goto IL_01a7;
											}
											break;
										}
										continue;
										end_IL_015e:
										break;
									}
									break;
								}
								int num6 = 1786005927;
								goto IL_039d;
								IL_039d:
								switch (num6 ^ 0x6A7449A7)
								{
								case 2:
									break;
								default:
									return;
								case 1:
									continue;
								case 0:
									return;
								}
								goto IL_0398;
								IL_0398:
								num6 = 1786005926;
								goto IL_039d;
								IL_01a7:
								using (qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh3 = new qdnMheaboQxTbfNHeFXhZezQcjfh(string.Concat(array2), P_3 + "_" + button.name, P_2))
								{
									if (qdnMheaboQxTbfNHeFXhZezQcjfh3.npNgcUPGCoMjSXwgumOyYMvfGWW)
									{
										while (true)
										{
											IL_01ff:
											hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Is Member Element", button.isMemberElement.ToString());
											hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Is Pressure Sensitive", button.isPressureSensitive.ToString());
											hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Value", button.value.ToString());
											int num7 = 1786005927;
											while (true)
											{
												switch (num7 ^ 0x6A7449A7)
												{
												case 2:
													num7 = 1786005924;
													continue;
												default:
													goto end_IL_01db;
												case 3:
													break;
												case 0:
													hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Value Prev", button.valuePrev.ToString());
													hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Pressure", button.pressure.ToString());
													hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Pressure Prev", button.pressurePrev.ToString());
													hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Just Pressed", button.justPressed.ToString());
													num7 = 1786005923;
													continue;
												case 4:
													hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Just Released", button.justReleased.ToString());
													hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Just Double Pressed", button.justDoublePressed.ToString());
													hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Double Pressed And Held", button.doublePressedAndHeld.ToString());
													hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Time Pressed", button.timePressed.ToString());
													hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Time Unpressed", button.timeUnpressed.ToString());
													hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Last Time Pressed", button.lastTimePressed.ToString());
													hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Last Time Unpressed", button.lastTimeUnpressed.ToString());
													num7 = 1786005926;
													continue;
												case 1:
													goto end_IL_01db;
												}
												goto IL_01ff;
												continue;
												end_IL_01db:
												break;
											}
											break;
										}
									}
								}
								num4++;
								goto IL_0398;
							}
						}
					}
				}
				}
				break;
			}
			goto IL_0003;
			IL_0029:
			obj = "Button";
			goto IL_0035;
			IL_0035:
			text = (string)obj;
			if (P_0 == null)
			{
				num2 = 1786005924;
				goto IL_0008;
			}
			num = P_0.Count;
			goto IL_0049;
			IL_0049:
			num3 = num;
			array = new object[4];
			num2 = 1786005923;
			goto IL_0008;
		}

		private static void cdryyLNyTTheQuBILYACYjekDAz(IList<Controller.Axis> P_0, IDictionary<string, bool> P_1, string P_2)
		{
			int num = ((P_0 != null) ? P_0.Count : 0);
			using (qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh2 = new qdnMheaboQxTbfNHeFXhZezQcjfh("Axes (" + num + ")", P_2 + "_Axes", P_1))
			{
				if (!qdnMheaboQxTbfNHeFXhZezQcjfh2.npNgcUPGCoMjSXwgumOyYMvfGWW)
				{
					return;
				}
				Controller.Axis axis = default(Controller.Axis);
				object[] array = default(object[]);
				while (true)
				{
					int num2 = 0;
					int num3 = 555305016;
					while (true)
					{
						switch (num3 ^ 0x2119483E)
						{
						case 2:
							num3 = 555305018;
							continue;
						case 5:
							axis = P_0[num2];
							array = new object[8] { num2, null, null, null, null, null, null, null };
							num3 = 555305023;
							continue;
						case 1:
							array[1] = ": ";
							array[2] = axis.elementIdentifier.name;
							array[3] = ": ";
							num3 = 555305021;
							continue;
						case 3:
							array[4] = axis.value.ToString("f3");
							array[5] = " (";
							array[6] = axis.valueRaw.ToString("f3");
							array[7] = ")";
							num3 = 555305022;
							continue;
						case 4:
							break;
						default:
						{
							using (qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh3 = new qdnMheaboQxTbfNHeFXhZezQcjfh(string.Concat(array), P_2 + "_" + axis.name, P_1))
							{
								if (qdnMheaboQxTbfNHeFXhZezQcjfh3.npNgcUPGCoMjSXwgumOyYMvfGWW)
								{
									while (true)
									{
										IL_0255:
										hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Is Member Element", axis.isMemberElement.ToString());
										hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Value", axis.value.ToString());
										int num4 = 555305020;
										while (true)
										{
											switch (num4 ^ 0x2119483E)
											{
											case 6:
												num4 = 555305021;
												continue;
											case 1:
												hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Value Prev", axis.valuePrev.ToString());
												hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Value Raw Prev", axis.valueRawPrev.ToString());
												num4 = 555305017;
												continue;
											case 5:
												hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Value Delta Raw", axis.valueDeltaRaw.ToString());
												hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Time Active", axis.timeActive.ToString());
												hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Time Active Raw", axis.timeActiveRaw.ToString());
												hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Time Inactive", axis.timeInactive.ToString());
												num4 = 555305022;
												continue;
											case 7:
												hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Value Delta", axis.valueDelta.ToString());
												num4 = 555305019;
												continue;
											case 3:
												break;
											case 0:
												hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Time Inactive Raw", axis.timeInactiveRaw.ToString());
												hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Last Time Active", axis.lastTimeActive.ToString());
												hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Last Time Active Raw", axis.lastTimeActiveRaw.ToString());
												num4 = 555305018;
												continue;
											case 2:
												hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Value Raw", axis.valueRaw.ToString());
												num4 = 555305023;
												continue;
											default:
												hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Last Time Inactive", axis.lastTimeInactive.ToString());
												hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Last Time Inactive Raw", axis.lastTimeInactiveRaw.ToString());
												goto end_IL_015b;
											}
											goto IL_0255;
											continue;
											end_IL_015b:
											break;
										}
										break;
									}
								}
							}
							num2++;
							goto case 6;
						}
						case 6:
							if (num2 >= num)
							{
								return;
							}
							goto case 5;
						}
						break;
					}
				}
			}
		}

		private static void MwfcNzNZlFnAzleJVJoFTFinmuW<T>(ControllerType P_0, IList<T> P_1, string P_2, IDictionary<string, bool> P_3, string P_4) where T : ControllerMap
		{
			string text = P_4 + "_controllerMaps";
			if (P_1 == null)
			{
				goto IL_0010;
			}
			int num = P_1.Count;
			goto IL_003f;
			IL_0036:
			num = 0;
			goto IL_003f;
			IL_0010:
			int num2 = 1819174893;
			goto IL_0015;
			IL_0015:
			object[] array = default(object[]);
			int num5 = default(int);
			object[] array2 = default(object[]);
			string text2 = default(string);
			T val3 = default(T);
			string text4 = default(string);
			InputLayout layout = default(InputLayout);
			int num4 = default(int);
			string text3 = default(string);
			while (true)
			{
				switch (num2 ^ 0x6C6E67EE)
				{
				case 2:
					break;
				case 3:
					goto IL_0036;
				case 0:
					array = new object[4] { P_2, " (", num5, null };
					num2 = 1819174890;
					continue;
				case 4:
					array[3] = ")";
					num2 = 1819174895;
					continue;
				default:
				{
					using (qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh2 = new qdnMheaboQxTbfNHeFXhZezQcjfh(string.Concat(array), text, P_3))
					{
						if (!qdnMheaboQxTbfNHeFXhZezQcjfh2.npNgcUPGCoMjSXwgumOyYMvfGWW)
						{
							goto IL_0098;
						}
						goto IL_01cb;
						IL_0098:
						int num3 = 1819174890;
						goto IL_009d;
						IL_009d:
						while (true)
						{
							object obj;
							ReInput.MappingHelper mapping;
							T val;
							InputMapCategory mapCategory;
							ReInput.MappingHelper mapping2;
							T val2;
							switch (num3 ^ 0x6C6E67EE)
							{
							case 8:
								break;
							case 4:
								return;
							case 2:
								goto IL_00e5;
							case 6:
								array2[3] = ", ";
								array2[4] = text2;
								num3 = 1819174887;
								continue;
							case 10:
								obj = "Disabled";
								goto IL_0117;
							case 1:
								if (val3.enabled)
								{
									obj = "Enabled";
									goto IL_0117;
								}
								num3 = 1819174884;
								continue;
							case 0:
								array2[2] = text4;
								num3 = 1819174888;
								continue;
							case 5:
								text2 = ((layout != null) ? layout.name : "n/a");
								array2 = new object[7];
								num3 = 1819174889;
								continue;
							case 3:
								goto IL_01cb;
							case 7:
								array2[0] = num4;
								array2[1] = ": ";
								num3 = 1819174894;
								continue;
							default:
								goto IL_01f9;
								IL_0117:
								text3 = (string)obj;
								mapping = ReInput.mapping;
								val = P_1[num4];
								mapCategory = mapping.GetMapCategory(val.categoryId);
								mapping2 = ReInput.mapping;
								val2 = P_1[num4];
								layout = mapping2.GetLayout(P_0, val2.layoutId);
								text4 = ((mapCategory != null) ? mapCategory.name : "n/a");
								num3 = 1819174891;
								continue;
							}
							break;
						}
						goto IL_0098;
						IL_02eb:
						if (num4 < num5)
						{
							goto IL_00e5;
						}
						int num6 = 1819174894;
						goto IL_02d2;
						IL_01f9:
						array2[5] = ": ";
						array2[6] = text3;
						using (qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh3 = new qdnMheaboQxTbfNHeFXhZezQcjfh(string.Concat(array2), P_4 + "_index" + num4, P_3))
						{
							if (!qdnMheaboQxTbfNHeFXhZezQcjfh3.npNgcUPGCoMjSXwgumOyYMvfGWW)
							{
								goto IL_0232;
							}
							goto IL_0261;
							IL_0232:
							int num7 = 1819174890;
							goto IL_0237;
							IL_0237:
							switch (num7 ^ 0x6C6E67EE)
							{
							case 3:
								break;
							default:
								goto end_IL_0229;
							case 4:
								goto end_IL_0229;
							case 2:
								goto IL_0261;
							case 0:
								goto IL_029e;
							case 1:
								goto end_IL_0229;
							}
							goto IL_0232;
							IL_0261:
							if (P_1[num4] is ControllerMapWithAxes)
							{
								PCHlMhLiOKWkekFNIZYeLFsuRXb(P_1[num4] as ControllerMapWithAxes, P_3, text + num4);
								num7 = 1819174895;
								goto IL_0237;
							}
							goto IL_029e;
							IL_029e:
							PCHlMhLiOKWkekFNIZYeLFsuRXb(P_1[num4], P_3, text);
							num7 = 1819174895;
							goto IL_0237;
							end_IL_0229:;
						}
						num4++;
						goto IL_02cd;
						IL_02d2:
						switch (num6 ^ 0x6C6E67EE)
						{
						case 2:
							break;
						default:
							return;
						case 1:
							goto IL_02eb;
						case 0:
							return;
						}
						goto IL_02cd;
						IL_02cd:
						num6 = 1819174895;
						goto IL_02d2;
						IL_01cb:
						num4 = 0;
						goto IL_02eb;
						IL_00e5:
						val3 = P_1[num4];
						num3 = 1819174895;
						goto IL_009d;
					}
				}
				}
				break;
			}
			goto IL_0010;
			IL_003f:
			num5 = num;
			num2 = 1819174894;
			goto IL_0015;
		}

		private static void PCHlMhLiOKWkekFNIZYeLFsuRXb(ControllerMap P_0, IDictionary<string, bool> P_1, string P_2)
		{
			hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Id (unique id)", P_0.id.ToString());
			hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Source Map Id", P_0.sourceMapId.ToString());
			hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Enabled", P_0.enabled.ToString());
			string text = default(string);
			int categoryId = default(int);
			while (true)
			{
				int num = -1915618061;
				while (true)
				{
					switch (num ^ -1915618057)
					{
					case 6:
						break;
					case 5:
						text = categoryId.ToString();
						num = -1915618059;
						continue;
					case 1:
						hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Controller Id", P_0.controllerId.ToString());
						num = -1915618060;
						continue;
					case 4:
						hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Controller Type", P_0.controllerType.ToString());
						num = -1915618057;
						continue;
					case 3:
						categoryId = P_0.categoryId;
						num = -1915618062;
						continue;
					case 0:
					{
						int num8;
						if (P_0.controllerType == ControllerType.Joystick)
						{
							num = -1915618058;
							num8 = num;
						}
						else
						{
							num = -1915618064;
							num8 = num;
						}
						continue;
					}
					case 7:
					{
						int num9;
						if (P_0.controllerType != ControllerType.Custom)
						{
							num = -1915618060;
							num9 = num;
						}
						else
						{
							num = -1915618058;
							num9 = num;
						}
						continue;
					}
					default:
					{
						if (P_0.categoryId >= 0)
						{
							try
							{
								InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(P_0.categoryId);
								while (true)
								{
									IL_0137:
									int num2 = -1915618058;
									while (true)
									{
										switch (num2 ^ -1915618057)
										{
										case 0:
											break;
										default:
											goto end_IL_013c;
										case 1:
											if (mapCategory != null)
											{
												goto IL_0158;
											}
											goto end_IL_013c;
										case 2:
											goto end_IL_013c;
										}
										goto IL_0137;
										IL_0158:
										text = text + " (" + mapCategory.name + ")";
										num2 = -1915618059;
										continue;
										end_IL_013c:
										break;
									}
									break;
								}
							}
							catch
							{
							}
						}
						hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Category Id", text);
						string text2 = P_0.layoutId.ToString();
						if (P_0.layoutId >= 0)
						{
							try
							{
								InputLayout layout = ReInput.mapping.GetLayout(P_0.controllerType, P_0.layoutId);
								if (layout != null)
								{
									while (true)
									{
										IL_01b9:
										int num3 = -1915618059;
										while (true)
										{
											switch (num3 ^ -1915618057)
											{
											case 0:
												break;
											default:
												goto end_IL_01be;
											case 2:
												goto IL_01d7;
											case 1:
												goto end_IL_01be;
											}
											goto IL_01b9;
											IL_01d7:
											text2 = text2 + " (" + layout.name + ")";
											num3 = -1915618058;
											continue;
											end_IL_01be:
											break;
										}
										break;
									}
								}
							}
							catch
							{
							}
						}
						hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Layout Id", text2);
						int buttonMapCount = P_0.buttonMapCount;
						string text3 = P_2 + "_buttonMaps";
						qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh2 = new qdnMheaboQxTbfNHeFXhZezQcjfh("Button Maps (" + buttonMapCount + ")", text3, P_1);
						try
						{
							if (!qdnMheaboQxTbfNHeFXhZezQcjfh2.npNgcUPGCoMjSXwgumOyYMvfGWW)
							{
								return;
							}
							int num4 = 0;
							while (true)
							{
								int num5 = -1915618061;
								while (true)
								{
									switch (num5 ^ -1915618057)
									{
									case 0:
										break;
									default:
										return;
									case 4:
										num5 = -1915618060;
										continue;
									case 3:
									{
										int num6;
										if (num4 >= buttonMapCount)
										{
											num5 = -1915618058;
											num6 = num5;
										}
										else
										{
											num5 = -1915618059;
											num6 = num5;
										}
										continue;
									}
									case 2:
										SBnuoXZadTXjHkyUVIvapeNfFARh(P_0.controllerType, P_0.ButtonMaps[num4], num4, P_1, text3 + num4);
										num4++;
										num5 = -1915618060;
										continue;
									case 1:
										return;
									}
									break;
								}
							}
						}
						finally
						{
							if (qdnMheaboQxTbfNHeFXhZezQcjfh2 != null)
							{
								while (true)
								{
									IL_02c6:
									int num7 = -1915618059;
									while (true)
									{
										switch (num7 ^ -1915618057)
										{
										case 0:
											break;
										default:
											goto end_IL_02cb;
										case 2:
											goto IL_02e4;
										case 1:
											goto end_IL_02cb;
										}
										goto IL_02c6;
										IL_02e4:
										((IDisposable)qdnMheaboQxTbfNHeFXhZezQcjfh2).Dispose();
										num7 = -1915618058;
										continue;
										end_IL_02cb:
										break;
									}
									break;
								}
							}
						}
					}
					}
					break;
				}
			}
		}

		private static void PCHlMhLiOKWkekFNIZYeLFsuRXb(ControllerMapWithAxes P_0, IDictionary<string, bool> P_1, string P_2)
		{
			PCHlMhLiOKWkekFNIZYeLFsuRXb((ControllerMap)P_0, P_1, P_2);
			string text = P_2 + "_axisMaps";
			int axisMapCount = P_0.axisMapCount;
			qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh2 = new qdnMheaboQxTbfNHeFXhZezQcjfh("Axis Maps (" + axisMapCount + ")", text, P_1);
			try
			{
				if (!qdnMheaboQxTbfNHeFXhZezQcjfh2.npNgcUPGCoMjSXwgumOyYMvfGWW)
				{
					return;
				}
				while (true)
				{
					int num = 0;
					int num2 = 2041322740;
					while (true)
					{
						switch (num2 ^ 0x79AC1CF4)
						{
						case 2:
							num2 = 2041322741;
							continue;
						case 1:
							break;
						case 3:
							SBnuoXZadTXjHkyUVIvapeNfFARh(P_0.controllerType, P_0.AxisMaps[num], num, P_1, text + num);
							num++;
							num2 = 2041322740;
							continue;
						default:
							if (num >= axisMapCount)
							{
								return;
							}
							goto case 3;
						}
						break;
					}
				}
			}
			finally
			{
				if (qdnMheaboQxTbfNHeFXhZezQcjfh2 != null)
				{
					while (true)
					{
						IL_00a9:
						int num3 = 2041322742;
						while (true)
						{
							switch (num3 ^ 0x79AC1CF4)
							{
							case 0:
								break;
							default:
								goto end_IL_00ae;
							case 2:
								goto IL_00c7;
							case 1:
								goto end_IL_00ae;
							}
							goto IL_00a9;
							IL_00c7:
							((IDisposable)qdnMheaboQxTbfNHeFXhZezQcjfh2).Dispose();
							num3 = 2041322741;
							continue;
							end_IL_00ae:
							break;
						}
						break;
					}
				}
			}
		}

		private static void SBnuoXZadTXjHkyUVIvapeNfFARh(ControllerType P_0, ActionElementMap P_1, int P_2, IDictionary<string, bool> P_3, string P_4)
		{
			string text3 = default(string);
			InputAction action = default(InputAction);
			string text = default(string);
			string text2 = default(string);
			while (true)
			{
				int num = 1155909426;
				while (true)
				{
					string empty;
					switch (num ^ 0x44E5C735)
					{
					case 0:
						break;
					case 3:
					{
						text3 = IsXfTwISQNOzSeirCvInuFFppsUO(P_1);
						int num3;
						if (string.IsNullOrEmpty(text3))
						{
							num = 1155909424;
							num3 = num;
						}
						else
						{
							num = 1155909428;
							num3 = num;
						}
						continue;
					}
					case 4:
						action = ReInput.mapping.GetAction(P_1.actionId);
						num = 1155909431;
						continue;
					case 7:
						text = "Action Element Map";
						num = 1155909425;
						continue;
					case 6:
						empty = string.Empty;
						goto IL_008c;
					case 1:
						text = P_1.elementIdentifierName + " (" + text3 + ")";
						num = 1155909424;
						continue;
					case 2:
						if (action != null)
						{
							empty = action.name;
							goto IL_008c;
						}
						num = 1155909427;
						continue;
					default:
						{
							using (qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh2 = new qdnMheaboQxTbfNHeFXhZezQcjfh(P_2 + ": " + text, P_4 + "_" + P_2, P_3))
							{
								if (!qdnMheaboQxTbfNHeFXhZezQcjfh2.npNgcUPGCoMjSXwgumOyYMvfGWW)
								{
									return;
								}
								while (true)
								{
									hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Id (unique id)", P_1.id.ToString());
									hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Enabled", P_1.enabled.ToString());
									hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Element Type", P_1.elementType.ToString());
									hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Action Id", P_1.actionId + " " + ((action != null) ? ("(" + text2 + ")") : ""));
									hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Element Identifier Id", P_1.elementIdentifierId.ToString());
									hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Element Identifier Name", P_1.elementIdentifierName);
									int num2 = 1155909436;
									while (true)
									{
										switch (num2 ^ 0x44E5C735)
										{
										case 2:
											num2 = 1155909424;
											continue;
										case 0:
											hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Modifier Key 1", P_1.modifierKey1.ToString());
											hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Modifier Key 2", P_1.modifierKey2.ToString());
											num2 = 1155909427;
											continue;
										case 4:
											if (P_1.elementType == ControllerElementType.Button)
											{
												hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Element Index", P_1.elementIndex.ToString());
												num2 = 1155909428;
												continue;
											}
											goto default;
										case 9:
											if (P_1.elementType == ControllerElementType.Axis)
											{
												hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Element Index", P_1.elementIndex.ToString());
												num2 = 1155909426;
												continue;
											}
											goto case 4;
										case 7:
											hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Axis Range", P_1.axisRange.ToString());
											num2 = 1155909437;
											continue;
										case 1:
											if (P_0 == ControllerType.Keyboard)
											{
												hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Key Code", P_1.keyCode.ToString());
												hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Keyboard Key Code", P_1.keyboardKeyCode.ToString());
												hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Has Modifiers", P_1.hasModifiers.ToString());
												num2 = 1155909429;
												continue;
											}
											goto default;
										case 10:
											num2 = 1155909430;
											continue;
										case 8:
											hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Axis Type", P_1.axisType.ToString());
											hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Invert", P_1.invert.ToString());
											num2 = 1155909439;
											continue;
										case 5:
											break;
										case 6:
											hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Modifier Key 3", P_1.modifierKey3.ToString());
											num2 = 1155909430;
											continue;
										default:
											hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Axis Contribution", P_1.axisContribution.ToString());
											return;
										}
										break;
									}
								}
							}
						}
						IL_008c:
						text2 = empty;
						num = 1155909430;
						continue;
					}
					break;
				}
			}
		}

		private static string IsXfTwISQNOzSeirCvInuFFppsUO(ActionElementMap P_0)
		{
			InputAction action = ReInput.mapping.GetAction(P_0.actionId);
			if (action == null)
			{
				goto IL_0017;
			}
			string text = string.Empty;
			int num;
			if (P_0.elementType != ControllerElementType.Button)
			{
				if (P_0.elementType == ControllerElementType.Axis)
				{
					int num2;
					if (P_0.axisType == AxisType.Split)
					{
						num = -1730507232;
						num2 = num;
					}
					else
					{
						num = -1730507221;
						num2 = num;
					}
					goto IL_001c;
				}
				goto IL_005e;
			}
			goto IL_00a9;
			IL_0017:
			num = -1730507226;
			goto IL_001c;
			IL_001c:
			while (true)
			{
				switch (num ^ -1730507229)
				{
				case 0:
					break;
				case 6:
					text = action.negativeDescriptiveName;
					num = -1730507230;
					continue;
				case 8:
					goto IL_005e;
				case 4:
					text = action.positiveDescriptiveName;
					num = -1730507231;
					continue;
				case 3:
					goto IL_00a9;
				case 1:
					if (string.IsNullOrEmpty(text))
					{
						text = ((!string.IsNullOrEmpty(action.descriptiveName)) ? (action.descriptiveName + " -") : (action.name + " -"));
						num = -1730507228;
						continue;
					}
					goto IL_0189;
				case 5:
					return string.Empty;
				case 2:
					if (string.IsNullOrEmpty(text))
					{
						text = ((!string.IsNullOrEmpty(action.descriptiveName)) ? (action.descriptiveName + " +") : (action.name + " +"));
						num = -1730507228;
						continue;
					}
					goto IL_0189;
				default:
					goto IL_0189;
				}
				break;
			}
			goto IL_0017;
			IL_005e:
			if (P_0.elementType == ControllerElementType.Axis && P_0.axisType == AxisType.Normal)
			{
				text = ((!string.IsNullOrEmpty(action.descriptiveName)) ? action.descriptiveName : action.name);
				num = -1730507228;
				goto IL_001c;
			}
			goto IL_0189;
			IL_0189:
			return text;
			IL_00a9:
			int num3;
			if (P_0.axisContribution != Pole.Positive)
			{
				num = -1730507227;
				num3 = num;
			}
			else
			{
				num = -1730507225;
				num3 = num;
			}
			goto IL_001c;
		}

		private static void tjMFhQmsdLRjXUucVLZhcbRoaaf(ControllerMapLayoutManager P_0, IDictionary<string, bool> P_1, string P_2)
		{
			if (WrsHhyMekyOynchRHSziEyRCQFV("Enabled", P_0.enabled))
			{
				P_0.enabled = !P_0.enabled;
				goto IL_0021;
			}
			goto IL_003f;
			IL_003f:
			hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Load from User Data Store", P_0.loadFromUserDataStore.ToString());
			int num = 699531687;
			goto IL_0026;
			IL_0021:
			num = 699531684;
			goto IL_0026;
			IL_0026:
			switch (num ^ 0x29B201A5)
			{
			case 0:
				break;
			case 1:
				goto IL_003f;
			default:
			{
				string text = P_2 + "_ruleSets";
				int count = P_0.ruleSets.Count;
				using (qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh2 = new qdnMheaboQxTbfNHeFXhZezQcjfh("Rule Sets (" + count + ")", text, P_1))
				{
					if (!qdnMheaboQxTbfNHeFXhZezQcjfh2.npNgcUPGCoMjSXwgumOyYMvfGWW)
					{
						return;
					}
					int num3 = default(int);
					while (true)
					{
						int num2 = 699531684;
						while (true)
						{
							switch (num2 ^ 0x29B201A5)
							{
							case 3:
								break;
							default:
								return;
							case 1:
								num3 = 0;
								num2 = 699531681;
								continue;
							case 5:
							{
								int num4;
								if (num3 < count)
								{
									num2 = 699531687;
									num4 = num2;
								}
								else
								{
									num2 = 699531685;
									num4 = num2;
								}
								continue;
							}
							case 4:
								num2 = 699531680;
								continue;
							case 2:
								jSGhbJzEKhJQXcIYAeGIFqEvfnM(P_0.ruleSets[num3], num3, P_1, text + num3);
								num3++;
								num2 = 699531680;
								continue;
							case 0:
								return;
							}
							break;
						}
					}
				}
			}
			}
			goto IL_0021;
		}

		private static void jSGhbJzEKhJQXcIYAeGIFqEvfnM(ControllerMapLayoutManager.RuleSet P_0, int P_1, IDictionary<string, bool> P_2, string P_3)
		{
			int num = ((P_0 != null) ? P_0.Count : 0);
			qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh2 = new qdnMheaboQxTbfNHeFXhZezQcjfh(P_1 + ": " + ((!string.IsNullOrEmpty(P_0.tag)) ? (P_0.tag + ", ") : "") + (P_0.enabled ? "Enabled" : "Disabled"), P_3, P_2);
			try
			{
				if (!qdnMheaboQxTbfNHeFXhZezQcjfh2.npNgcUPGCoMjSXwgumOyYMvfGWW)
				{
					return;
				}
				int[] categoryIds = default(int[]);
				int num6 = default(int);
				int num7 = default(int);
				object[] array = default(object[]);
				InputMapCategory mapCategory = default(InputMapCategory);
				while (true)
				{
					int num2;
					if (WrsHhyMekyOynchRHSziEyRCQFV("Enabled", P_0.enabled))
					{
						P_0.enabled = !P_0.enabled;
						num2 = -1720755235;
						goto IL_0089;
					}
					goto IL_00ce;
					IL_0089:
					while (true)
					{
						switch (num2 ^ -1720755234)
						{
						case 0:
							num2 = -1720755233;
							continue;
						case 1:
							break;
						case 3:
							goto IL_00ce;
						default:
						{
							string text = P_3 + "_rules";
							qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh3 = new qdnMheaboQxTbfNHeFXhZezQcjfh("Rules (" + P_0.Count + ")", text, P_2);
							try
							{
								if (!qdnMheaboQxTbfNHeFXhZezQcjfh3.npNgcUPGCoMjSXwgumOyYMvfGWW)
								{
									return;
								}
								int num3 = 0;
								while (true)
								{
									if (num3 < num)
									{
										ControllerMapLayoutManager.Rule rule;
										string text2;
										while (true)
										{
											rule = P_0[num3];
											text2 = text + num3;
											int num4 = -1720755233;
											while (true)
											{
												switch (num4 ^ -1720755234)
												{
												case 0:
													num4 = -1720755236;
													continue;
												case 2:
													break;
												default:
													goto end_IL_0144;
												}
												break;
											}
											continue;
											end_IL_0144:
											break;
										}
										using (qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh4 = new qdnMheaboQxTbfNHeFXhZezQcjfh(num3 + ": " + ((!string.IsNullOrEmpty(rule.tag)) ? rule.tag : ""), text2, P_2))
										{
											if (qdnMheaboQxTbfNHeFXhZezQcjfh4.npNgcUPGCoMjSXwgumOyYMvfGWW)
											{
												while (true)
												{
													IL_01a7:
													int num5 = -1720755233;
													while (true)
													{
														switch (num5 ^ -1720755234)
														{
														case 4:
															break;
														case 1:
															hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Tag", rule.tag);
															num5 = -1720755234;
															continue;
														case 0:
															lvlWEPClBVjUlokXFkBFUBzcXk(rule.controllerSetSelector, P_2, text2);
															categoryIds = rule.categoryIds;
															num5 = -1720755236;
															continue;
														case 2:
															num6 = ((categoryIds != null) ? categoryIds.Length : 0);
															num5 = -1720755235;
															continue;
														default:
														{
															using (qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh5 = new qdnMheaboQxTbfNHeFXhZezQcjfh("Map Categories (" + num6 + ")", text2 + "_categoryIds", P_2))
															{
																if (qdnMheaboQxTbfNHeFXhZezQcjfh5.npNgcUPGCoMjSXwgumOyYMvfGWW)
																{
																	if (num6 == 0)
																	{
																		goto IL_0255;
																	}
																	goto IL_032a;
																}
																goto end_IL_0242;
																IL_032a:
																num7 = 0;
																int num8 = -1720755237;
																goto IL_025a;
																IL_0255:
																num8 = -1720755236;
																goto IL_025a;
																IL_025a:
																while (true)
																{
																	object obj;
																	string text3;
																	switch (num8 ^ -1720755234)
																	{
																	case 4:
																		break;
																	default:
																		goto end_IL_0242;
																	case 2:
																		hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Category", "All Map Categories");
																		num8 = -1720755233;
																		continue;
																	case 6:
																		goto IL_02a8;
																	case 9:
																		array[0] = mapCategory.name;
																		array[1] = " (";
																		array[2] = mapCategory.id;
																		num8 = -1720755242;
																		continue;
																	case 5:
																		num8 = -1720755240;
																		continue;
																	case 3:
																		obj = string.Concat(array);
																		goto IL_0300;
																	case 7:
																		goto IL_032a;
																	case 0:
																		mapCategory = ReInput.mapping.GetMapCategory(categoryIds[num7]);
																		if (mapCategory == null)
																		{
																			obj = "[INVALID]";
																			goto IL_0300;
																		}
																		array = new object[4];
																		num8 = -1720755241;
																		continue;
																	case 8:
																		array[3] = ")";
																		num8 = -1720755235;
																		continue;
																	case 1:
																		goto end_IL_0242;
																		IL_0300:
																		text3 = (string)obj;
																		hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Category " + num7, text3);
																		num7++;
																		num8 = -1720755240;
																		continue;
																	}
																	break;
																	IL_02a8:
																	int num9;
																	if (num7 < categoryIds.Length)
																	{
																		num8 = -1720755234;
																		num9 = num8;
																	}
																	else
																	{
																		num8 = -1720755233;
																		num9 = num8;
																	}
																}
																goto IL_0255;
																end_IL_0242:;
															}
															InputLayout layout = ReInput.mapping.GetLayout(rule.controllerSetSelector.controllerType, rule.layoutId);
															hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR(rule.controllerSetSelector.controllerType.ToString() + " Layout", (layout != null) ? (layout.name + " (" + layout.id + ")") : "[INVALID]");
															goto end_IL_01ac;
														}
														}
														goto IL_01a7;
														continue;
														end_IL_01ac:
														break;
													}
													break;
												}
											}
										}
										num3++;
										goto IL_0425;
									}
									int num10 = -1720755233;
									goto IL_042a;
									IL_0425:
									num10 = -1720755236;
									goto IL_042a;
									IL_042a:
									switch (num10 ^ -1720755234)
									{
									case 0:
										break;
									default:
										return;
									case 2:
										continue;
									case 1:
										return;
									}
									goto IL_0425;
								}
							}
							finally
							{
								if (qdnMheaboQxTbfNHeFXhZezQcjfh3 != null)
								{
									while (true)
									{
										IL_0457:
										int num11 = -1720755236;
										while (true)
										{
											switch (num11 ^ -1720755234)
											{
											case 0:
												break;
											default:
												goto end_IL_045c;
											case 2:
												goto IL_0475;
											case 1:
												goto end_IL_045c;
											}
											goto IL_0457;
											IL_0475:
											((IDisposable)qdnMheaboQxTbfNHeFXhZezQcjfh3).Dispose();
											num11 = -1720755233;
											continue;
											end_IL_045c:
											break;
										}
										break;
									}
								}
							}
						}
						}
						break;
					}
					continue;
					IL_00ce:
					hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Tag", P_0.tag);
					num2 = -1720755236;
					goto IL_0089;
				}
			}
			finally
			{
				if (qdnMheaboQxTbfNHeFXhZezQcjfh2 != null)
				{
					while (true)
					{
						IL_0488:
						int num12 = -1720755233;
						while (true)
						{
							switch (num12 ^ -1720755234)
							{
							case 0:
								break;
							default:
								goto end_IL_048d;
							case 1:
								goto IL_04a6;
							case 2:
								goto end_IL_048d;
							}
							goto IL_0488;
							IL_04a6:
							((IDisposable)qdnMheaboQxTbfNHeFXhZezQcjfh2).Dispose();
							num12 = -1720755236;
							continue;
							end_IL_048d:
							break;
						}
						break;
					}
				}
			}
		}

		private static void eLXprxOOFHNXZdpFSeYcQFjBDYcC(ControllerMapEnabler P_0, IDictionary<string, bool> P_1, string P_2)
		{
			if (WrsHhyMekyOynchRHSziEyRCQFV("Enabled", P_0.enabled))
			{
				P_0.enabled = !P_0.enabled;
				goto IL_0021;
			}
			goto IL_003f;
			IL_003f:
			string text = P_2 + "_ruleSets";
			int num = 594633660;
			goto IL_0026;
			IL_0021:
			num = 594633663;
			goto IL_0026;
			IL_0026:
			switch (num ^ 0x237163BD)
			{
			case 0:
				break;
			case 2:
				goto IL_003f;
			default:
			{
				int count = P_0.ruleSets.Count;
				using (qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh2 = new qdnMheaboQxTbfNHeFXhZezQcjfh("Rule Sets (" + count + ")", text, P_1))
				{
					if (!qdnMheaboQxTbfNHeFXhZezQcjfh2.npNgcUPGCoMjSXwgumOyYMvfGWW)
					{
						return;
					}
					int num3 = default(int);
					while (true)
					{
						int num2 = 594633660;
						while (true)
						{
							switch (num2 ^ 0x237163BD)
							{
							case 3:
								break;
							default:
								return;
							case 1:
								num3 = 0;
								num2 = 594633661;
								continue;
							case 2:
								EYlGhCGcdiFcYxuIrvIGUiEOGVq(P_0.ruleSets[num3], num3, P_1, text + num3);
								num3++;
								num2 = 594633661;
								continue;
							case 0:
							{
								int num4;
								if (num3 < count)
								{
									num2 = 594633663;
									num4 = num2;
								}
								else
								{
									num2 = 594633657;
									num4 = num2;
								}
								continue;
							}
							case 4:
								return;
							}
							break;
						}
					}
				}
			}
			}
			goto IL_0021;
		}

		private static void EYlGhCGcdiFcYxuIrvIGUiEOGVq(ControllerMapEnabler.RuleSet P_0, int P_1, IDictionary<string, bool> P_2, string P_3)
		{
			int num = ((P_0 != null) ? P_0.Count : 0);
			object[] array = new object[4] { P_1, null, null, null };
			int num6 = default(int);
			ControllerMapEnabler.Rule rule = default(ControllerMapEnabler.Rule);
			int[] categoryIds = default(int[]);
			int num8 = default(int);
			int num10 = default(int);
			InputMapCategory mapCategory = default(InputMapCategory);
			object[] array2 = default(object[]);
			object[] array3 = default(object[]);
			InputLayout layout = default(InputLayout);
			int num14 = default(int);
			while (true)
			{
				int num2 = 1179407135;
				while (true)
				{
					switch (num2 ^ 0x464C531E)
					{
					case 2:
						break;
					case 1:
						array[1] = ": ";
						num2 = 1179407134;
						continue;
					case 0:
						array[2] = ((!string.IsNullOrEmpty(P_0.tag)) ? (P_0.tag + ", ") : "");
						num2 = 1179407130;
						continue;
					case 4:
						array[3] = (P_0.enabled ? "Enabled" : "Disabled");
						num2 = 1179407133;
						continue;
					default:
					{
						using (qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh2 = new qdnMheaboQxTbfNHeFXhZezQcjfh(string.Concat(array), P_3, P_2))
						{
							if (!qdnMheaboQxTbfNHeFXhZezQcjfh2.npNgcUPGCoMjSXwgumOyYMvfGWW)
							{
								return;
							}
							while (true)
							{
								int num3;
								int num4;
								if (!WrsHhyMekyOynchRHSziEyRCQFV("Enabled", P_0.enabled))
								{
									num3 = 1179407134;
									num4 = num3;
								}
								else
								{
									num3 = 1179407133;
									num4 = num3;
								}
								while (true)
								{
									switch (num3 ^ 0x464C531E)
									{
									case 2:
										num3 = 1179407135;
										continue;
									case 1:
										break;
									case 3:
										P_0.enabled = !P_0.enabled;
										num3 = 1179407134;
										continue;
									default:
									{
										hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Tag", P_0.tag);
										string text = P_3 + "_rules";
										using (qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh3 = new qdnMheaboQxTbfNHeFXhZezQcjfh("Rules (" + P_0.Count + ")", text, P_2))
										{
											if (!qdnMheaboQxTbfNHeFXhZezQcjfh3.npNgcUPGCoMjSXwgumOyYMvfGWW)
											{
												return;
											}
											while (true)
											{
												int num5 = 1179407133;
												while (true)
												{
													int num17;
													switch (num5 ^ 0x464C531E)
													{
													case 0:
														break;
													case 3:
														num6 = 0;
														goto IL_0620;
													case 1:
														goto IL_0194;
													default:
														{
															string text2 = text + num6;
															using (qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh4 = new qdnMheaboQxTbfNHeFXhZezQcjfh(num6 + ": " + ((!string.IsNullOrEmpty(rule.tag)) ? rule.tag : ""), text2, P_2))
															{
																if (qdnMheaboQxTbfNHeFXhZezQcjfh4.npNgcUPGCoMjSXwgumOyYMvfGWW)
																{
																	while (true)
																	{
																		IL_01f7:
																		int num7 = 1179407135;
																		while (true)
																		{
																			switch (num7 ^ 0x464C531E)
																			{
																			case 5:
																				break;
																			case 2:
																				hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Tag", rule.tag);
																				lvlWEPClBVjUlokXFkBFUBzcXk(rule.controllerSetSelector, P_2, text2);
																				num7 = 1179407134;
																				continue;
																			case 3:
																				rule.enable = !rule.enable;
																				num7 = 1179407132;
																				continue;
																			case 0:
																				categoryIds = rule.categoryIds;
																				num8 = ((categoryIds != null) ? categoryIds.Length : 0);
																				num7 = 1179407130;
																				continue;
																			case 1:
																			{
																				int num16;
																				if (WrsHhyMekyOynchRHSziEyRCQFV("Enable", rule.enable))
																				{
																					num7 = 1179407133;
																					num16 = num7;
																				}
																				else
																				{
																					num7 = 1179407132;
																					num16 = num7;
																				}
																				continue;
																			}
																			default:
																			{
																				using (qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh5 = new qdnMheaboQxTbfNHeFXhZezQcjfh("Map Categories (" + num8 + ")", text2 + "_categoryIds", P_2))
																				{
																					if (qdnMheaboQxTbfNHeFXhZezQcjfh5.npNgcUPGCoMjSXwgumOyYMvfGWW)
																					{
																						while (true)
																						{
																							IL_02e0:
																							int num9 = 1179407129;
																							while (true)
																							{
																								object obj;
																								string text3;
																								switch (num9 ^ 0x464C531E)
																								{
																								case 11:
																									break;
																								default:
																									goto end_IL_02e5;
																								case 10:
																								{
																									int num11;
																									if (num10 < categoryIds.Length)
																									{
																										num9 = 1179407132;
																										num11 = num9;
																									}
																									else
																									{
																										num9 = 1179407134;
																										num11 = num9;
																									}
																									continue;
																								}
																								case 9:
																									num9 = 1179407134;
																									continue;
																								case 2:
																									mapCategory = ReInput.mapping.GetMapCategory(categoryIds[num10]);
																									if (mapCategory == null)
																									{
																										num9 = 1179407133;
																										continue;
																									}
																									array2 = new object[4] { mapCategory.name, " (", null, null };
																									num9 = 1179407126;
																									continue;
																								case 8:
																									array2[2] = mapCategory.id;
																									num9 = 1179407130;
																									continue;
																								case 7:
																									if (num8 == 0)
																									{
																										hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Category", "All Map Categories");
																										num9 = 1179407127;
																										continue;
																									}
																									goto case 6;
																								case 1:
																									obj = string.Concat(array2);
																									goto IL_039f;
																								case 3:
																									obj = "[INVALID]";
																									goto IL_039f;
																								case 6:
																									num10 = 0;
																									num9 = 1179407124;
																									continue;
																								case 4:
																									array2[3] = ")";
																									num9 = 1179407135;
																									continue;
																								case 5:
																									num10++;
																									num9 = 1179407124;
																									continue;
																								case 0:
																									goto end_IL_02e5;
																									IL_039f:
																									text3 = (string)obj;
																									hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Category " + num10, text3);
																									num9 = 1179407131;
																									continue;
																								}
																								goto IL_02e0;
																								continue;
																								end_IL_02e5:
																								break;
																							}
																							break;
																						}
																					}
																				}
																				int[] layoutIds = rule.layoutIds;
																				int num12 = ((layoutIds != null) ? layoutIds.Length : 0);
																				using (qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh6 = new qdnMheaboQxTbfNHeFXhZezQcjfh("Layouts (" + num12 + ")", text2 + "_layoutIds", P_2))
																				{
																					if (qdnMheaboQxTbfNHeFXhZezQcjfh6.npNgcUPGCoMjSXwgumOyYMvfGWW)
																					{
																						if (num12 == 0)
																						{
																							hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Layout", (rule.controllerSetSelector.type == ControllerSetSelector.Type.All) ? "All Layouts" : string.Concat("All ", rule.controllerSetSelector.controllerType, " Layouts"));
																							goto IL_04c0;
																						}
																						goto IL_0522;
																					}
																					goto end_IL_046e;
																					IL_04c5:
																					int num13;
																					while (true)
																					{
																						object obj2;
																						string text4;
																						switch (num13 ^ 0x464C531E)
																						{
																						case 0:
																							break;
																						default:
																							goto end_IL_046e;
																						case 3:
																							goto IL_04f9;
																						case 2:
																							array3[1] = " (";
																							num13 = 1179407126;
																							continue;
																						case 4:
																							goto IL_0522;
																						case 7:
																							layout = ReInput.mapping.GetLayout(rule.controllerSetSelector.controllerType, layoutIds[num14]);
																							if (layout == null)
																							{
																								obj2 = "[INVALID]";
																								goto IL_05a5;
																							}
																							array3 = new object[4] { layout.name, null, null, null };
																							num13 = 1179407132;
																							continue;
																						case 5:
																							num13 = 1179407128;
																							continue;
																						case 8:
																							array3[2] = layout.id;
																							array3[3] = ")";
																							num13 = 1179407135;
																							continue;
																						case 1:
																							obj2 = string.Concat(array3);
																							goto IL_05a5;
																						case 6:
																							goto end_IL_046e;
																							IL_05a5:
																							text4 = (string)obj2;
																							hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR(string.Concat(rule.controllerSetSelector.controllerType, " Layout ", num14.ToString()), text4);
																							num14++;
																							num13 = 1179407133;
																							continue;
																						}
																						break;
																						IL_04f9:
																						int num15;
																						if (num14 < layoutIds.Length)
																						{
																							num13 = 1179407129;
																							num15 = num13;
																						}
																						else
																						{
																							num13 = 1179407128;
																							num15 = num13;
																						}
																					}
																					goto IL_04c0;
																					IL_04c0:
																					num13 = 1179407131;
																					goto IL_04c5;
																					IL_0522:
																					num14 = 0;
																					num13 = 1179407133;
																					goto IL_04c5;
																					end_IL_046e:;
																				}
																				goto end_IL_01fc;
																			}
																			}
																			goto IL_01f7;
																			continue;
																			end_IL_01fc:
																			break;
																		}
																		break;
																	}
																}
															}
															num6++;
															goto IL_0602;
														}
														IL_0620:
														if (num6 < num)
														{
															goto IL_0194;
														}
														num17 = 1179407134;
														goto IL_0607;
														IL_0602:
														num17 = 1179407135;
														goto IL_0607;
														IL_0607:
														switch (num17 ^ 0x464C531E)
														{
														case 2:
															break;
														default:
															return;
														case 1:
															goto IL_0620;
														case 0:
															return;
														}
														goto IL_0602;
													}
													break;
													IL_0194:
													rule = P_0[num6];
													num5 = 1179407132;
												}
											}
										}
									}
									}
									break;
								}
							}
						}
					}
					}
					break;
				}
			}
		}

		private static void lvlWEPClBVjUlokXFkBFUBzcXk(ControllerSetSelector P_0, IDictionary<string, bool> P_1, string P_2)
		{
			string key = P_2 + "_controllerSetSelector";
			qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh2 = new qdnMheaboQxTbfNHeFXhZezQcjfh("Controller Set Selector", key, P_1);
			try
			{
				if (qdnMheaboQxTbfNHeFXhZezQcjfh2.npNgcUPGCoMjSXwgumOyYMvfGWW)
				{
					hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Type", StringTools.AddSpacesToSentence(P_0.type.ToString(), false));
					if (P_0.type != ControllerSetSelector.Type.All)
					{
						hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Controller Type", P_0.controllerType.ToString());
						goto IL_0066;
					}
					goto IL_009b;
				}
				return;
				IL_006b:
				int num;
				while (true)
				{
					switch (num ^ 0x5A83684F)
					{
					case 2:
						break;
					default:
						return;
					case 7:
						goto IL_009b;
					case 0:
						hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Controller Template Type Guid", P_0.controllerTemplateTypeGuid.ToString());
						num = 1518561358;
						continue;
					case 5:
						if (P_0.type == ControllerSetSelector.Type.SessionControllerInstance)
						{
							hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Controller Id", P_0.controllerId.ToString());
							num = 1518561356;
							continue;
						}
						return;
					case 6:
						goto IL_0109;
					case 1:
						if (P_0.type == ControllerSetSelector.Type.PersistentControllerInstance)
						{
							hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Device Instance Guid", P_0.deviceInstanceGuid.ToString());
							num = 1518561354;
							continue;
						}
						goto case 5;
					case 4:
						hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Hardware Type Guid", P_0.hardwareTypeGuid.ToString());
						hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Hardware Identifier", P_0.hardwareIdentifier);
						num = 1518561353;
						continue;
					case 3:
						return;
					}
					break;
					IL_0109:
					int num2;
					if (P_0.type != ControllerSetSelector.Type.ControllerTemplateType)
					{
						num = 1518561358;
						num2 = num;
					}
					else
					{
						num = 1518561359;
						num2 = num;
					}
				}
				goto IL_0066;
				IL_009b:
				int num3;
				if (P_0.type != ControllerSetSelector.Type.HardwareType)
				{
					num = 1518561353;
					num3 = num;
				}
				else
				{
					num = 1518561355;
					num3 = num;
				}
				goto IL_006b;
				IL_0066:
				num = 1518561352;
				goto IL_006b;
			}
			finally
			{
				if (qdnMheaboQxTbfNHeFXhZezQcjfh2 != null)
				{
					while (true)
					{
						IL_0195:
						int num4 = 1518561358;
						while (true)
						{
							switch (num4 ^ 0x5A83684F)
							{
							case 2:
								break;
							default:
								goto end_IL_019a;
							case 1:
								goto IL_01b3;
							case 0:
								goto end_IL_019a;
							}
							goto IL_0195;
							IL_01b3:
							((IDisposable)qdnMheaboQxTbfNHeFXhZezQcjfh2).Dispose();
							num4 = 1518561359;
							continue;
							end_IL_019a:
							break;
						}
						break;
					}
				}
			}
		}

		private static void fsebqsOsBAfHXavOIxVgdKAeDJCd(Controller P_0, IDictionary<string, bool> P_1, string P_2)
		{
			P_2 += "_templates";
			using (qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh2 = new qdnMheaboQxTbfNHeFXhZezQcjfh("Templates (" + P_0.templateCount + ")", P_2, P_1))
			{
				if (!qdnMheaboQxTbfNHeFXhZezQcjfh2.npNgcUPGCoMjSXwgumOyYMvfGWW)
				{
					return;
				}
				int num = 0;
				while (true)
				{
					int num2;
					int num3;
					if (num < P_0.templateCount)
					{
						num2 = -570494557;
						num3 = num2;
					}
					else
					{
						num2 = -570494559;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ -570494560)
						{
						case 0:
							num2 = -570494557;
							continue;
						default:
							return;
						case 3:
							fgcjLXzuZgfjfXbtrdZyCxlnBYDq(P_0.Templates[num], num, P_2, P_1);
							num++;
							num2 = -570494558;
							continue;
						case 2:
							break;
						case 1:
							return;
						}
						break;
					}
				}
			}
		}

		private static void fgcjLXzuZgfjfXbtrdZyCxlnBYDq(IControllerTemplate P_0, int P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 += ((P_1 >= 0) ? ("_" + P_1) : "");
			while (true)
			{
				int num = -687398263;
				while (true)
				{
					object obj;
					switch (num ^ -687398264)
					{
					case 0:
						break;
					case 1:
						if (P_1 < 0)
						{
							goto IL_0046;
						}
						obj = P_1 + ": ";
						goto IL_0064;
					default:
						{
							obj = "";
							goto IL_0064;
						}
						IL_0064:
						using (qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh2 = new qdnMheaboQxTbfNHeFXhZezQcjfh((string)obj + P_0.name, P_2, P_3))
						{
							if (!qdnMheaboQxTbfNHeFXhZezQcjfh2.npNgcUPGCoMjSXwgumOyYMvfGWW)
							{
								return;
							}
							hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Type GUID", P_0.typeGuid.ToString());
							hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Class Type", P_0.GetType().ToString());
							P_2 += "_elements";
							using (qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh3 = new qdnMheaboQxTbfNHeFXhZezQcjfh("Elements (" + P_0.elementCount + ")", P_2, P_3))
							{
								if (!qdnMheaboQxTbfNHeFXhZezQcjfh3.npNgcUPGCoMjSXwgumOyYMvfGWW)
								{
									return;
								}
								int num2 = 0;
								while (true)
								{
									int num3;
									int num4;
									if (num2 < P_0.elementCount)
									{
										num3 = -687398263;
										num4 = num3;
									}
									else
									{
										num3 = -687398261;
										num4 = num3;
									}
									while (true)
									{
										switch (num3 ^ -687398264)
										{
										case 2:
											num3 = -687398263;
											continue;
										default:
											return;
										case 1:
											yRysoZbFoqoDKYHyVTeSmPgYQwo(P_0.elements[num2], num2, P_2, P_3);
											num2++;
											num3 = -687398264;
											continue;
										case 0:
											break;
										case 3:
											return;
										}
										break;
									}
								}
							}
						}
					}
					break;
					IL_0046:
					num = -687398262;
				}
			}
		}

		private static void yRysoZbFoqoDKYHyVTeSmPgYQwo(IControllerTemplateElement P_0, int P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 += ((P_1 >= 0) ? ("_" + P_1) : "");
			object[] array = new object[5]
			{
				(P_1 >= 0) ? ": " : "",
				null,
				null,
				null,
				null
			};
			IControllerTemplateStick6D controllerTemplateStick6D = default(IControllerTemplateStick6D);
			IControllerTemplateThrottle controllerTemplateThrottle = default(IControllerTemplateThrottle);
			IControllerTemplateYoke controllerTemplateYoke = default(IControllerTemplateYoke);
			IControllerTemplateDPad controllerTemplateDPad = default(IControllerTemplateDPad);
			while (true)
			{
				int num = 1332232600;
				while (true)
				{
					switch (num ^ 0x4F68419A)
					{
					case 0:
						break;
					case 2:
						goto IL_005e;
					default:
					{
						array[2] = " (id: ";
						array[3] = P_0.id;
						array[4] = ")";
						using (qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh2 = new qdnMheaboQxTbfNHeFXhZezQcjfh(string.Concat(array), P_2, P_3))
						{
							if (!qdnMheaboQxTbfNHeFXhZezQcjfh2.npNgcUPGCoMjSXwgumOyYMvfGWW)
							{
								return;
							}
							hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Id", P_0.id.ToString());
							while (true)
							{
								int num2 = 1332232588;
								while (true)
								{
									switch (num2 ^ 0x4F68419A)
									{
									case 17:
										break;
									default:
										return;
									case 19:
										controllerTemplateStick6D = P_0 as IControllerTemplateStick6D;
										num2 = 1332232600;
										continue;
									case 18:
										PjnmfndrEIjYRMHuWjSZSLjvhac(controllerTemplateThrottle.minDetent, "zeroDetent", P_2, P_3);
										num2 = 1332232602;
										continue;
									case 8:
										num2 = 1332232602;
										continue;
									case 12:
										if (P_0.type == ControllerTemplateElementType.Yoke)
										{
											controllerTemplateYoke = P_0 as IControllerTemplateYoke;
											hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Value", controllerTemplateYoke.value.ToString());
											hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Value Prev", controllerTemplateYoke.valuePrev.ToString());
											num2 = 1332232604;
											continue;
										}
										goto case 3;
									case 4:
										tTDiGJnOLmIWpYtwSfLIjBVFdPU(controllerTemplateStick6D.rotationZ, "RotationZ", P_2, P_3);
										num2 = 1332232602;
										continue;
									case 24:
										if (P_0.type == ControllerTemplateElementType.Throttle)
										{
											controllerTemplateThrottle = P_0 as IControllerTemplateThrottle;
											hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Value", controllerTemplateThrottle.value.ToString());
											hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Value Prev", controllerTemplateThrottle.valuePrev.ToString());
											num2 = 1332232605;
											continue;
										}
										goto case 11;
									case 15:
									{
										int num4;
										if (P_0.type != ControllerTemplateElementType.Axis)
										{
											num2 = 1332232607;
											num4 = num2;
										}
										else
										{
											num2 = 1332232595;
											num4 = num2;
										}
										continue;
									}
									case 22:
										hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Name", P_0.descriptiveName.ToString());
										hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Type", P_0.type.ToString());
										hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Exists", P_0.exists.ToString());
										if (P_0.type == ControllerTemplateElementType.Button)
										{
											IControllerTemplateButton controllerTemplateButton = P_0 as IControllerTemplateButton;
											lQRZbpCrySkKcMUgeGjswJgyYfO(controllerTemplateButton, P_2, P_3);
											num2 = 1332232602;
											continue;
										}
										goto case 15;
									case 14:
										controllerTemplateDPad = P_0 as IControllerTemplateDPad;
										num2 = 1332232586;
										continue;
									case 1:
										tTDiGJnOLmIWpYtwSfLIjBVFdPU(controllerTemplateStick6D.positionX, "PositionX", P_2, P_3);
										tTDiGJnOLmIWpYtwSfLIjBVFdPU(controllerTemplateStick6D.positionY, "PositionY", P_2, P_3);
										tTDiGJnOLmIWpYtwSfLIjBVFdPU(controllerTemplateStick6D.positionZ, "PositionZ", P_2, P_3);
										tTDiGJnOLmIWpYtwSfLIjBVFdPU(controllerTemplateStick6D.rotationX, "RotationX", P_2, P_3);
										tTDiGJnOLmIWpYtwSfLIjBVFdPU(controllerTemplateStick6D.rotationY, "RotationY", P_2, P_3);
										num2 = 1332232606;
										continue;
									case 9:
									{
										IControllerTemplateAxis controllerTemplateAxis = P_0 as IControllerTemplateAxis;
										ijiLWohcfkSQXYvTiKzydaRIRvF(controllerTemplateAxis, P_2, P_3);
										num2 = 1332232602;
										continue;
									}
									case 21:
										hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Rotation", controllerTemplateStick6D.rotation.ToString());
										hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Rotation Prev", controllerTemplateStick6D.rotationPrev.ToString());
										num2 = 1332232603;
										continue;
									case 13:
										if (P_0.type == ControllerTemplateElementType.Stick)
										{
											IControllerTemplateStick controllerTemplateStick = P_0 as IControllerTemplateStick;
											hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Value", controllerTemplateStick.value.ToString());
											hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Value Prev", controllerTemplateStick.valuePrev.ToString());
											tTDiGJnOLmIWpYtwSfLIjBVFdPU(controllerTemplateStick.horizontal, "horizontal", P_2, P_3);
											tTDiGJnOLmIWpYtwSfLIjBVFdPU(controllerTemplateStick.vertical, "vertical", P_2, P_3);
											tTDiGJnOLmIWpYtwSfLIjBVFdPU(controllerTemplateStick.rotation, "rotation", P_2, P_3);
											num2 = 1332232602;
											continue;
										}
										goto case 24;
									case 25:
										hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Unknown element type", P_0.type.ToString());
										num2 = 1332232602;
										continue;
									case 6:
										tTDiGJnOLmIWpYtwSfLIjBVFdPU(controllerTemplateYoke.rotation, "rotation", P_2, P_3);
										tTDiGJnOLmIWpYtwSfLIjBVFdPU(controllerTemplateYoke.pushPull, "pushPull", P_2, P_3);
										num2 = 1332232594;
										continue;
									case 16:
										hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Value", controllerTemplateDPad.value.ToString());
										hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Value Prev", controllerTemplateDPad.valuePrev.ToString());
										PjnmfndrEIjYRMHuWjSZSLjvhac(controllerTemplateDPad.up, "Up", P_2, P_3);
										num2 = 1332232589;
										continue;
									case 23:
										PjnmfndrEIjYRMHuWjSZSLjvhac(controllerTemplateDPad.right, "Right", P_2, P_3);
										PjnmfndrEIjYRMHuWjSZSLjvhac(controllerTemplateDPad.down, "Down", P_2, P_3);
										PjnmfndrEIjYRMHuWjSZSLjvhac(controllerTemplateDPad.left, "Left", P_2, P_3);
										num2 = 1332232602;
										continue;
									case 7:
										tTDiGJnOLmIWpYtwSfLIjBVFdPU(controllerTemplateThrottle.throttle, "throttle", P_2, P_3);
										num2 = 1332232584;
										continue;
									case 20:
										if (P_0.type == ControllerTemplateElementType.Hat)
										{
											IControllerTemplateHat controllerTemplateHat = P_0 as IControllerTemplateHat;
											hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Value", controllerTemplateHat.value.ToString());
											hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Value Prev", controllerTemplateHat.valuePrev.ToString());
											PjnmfndrEIjYRMHuWjSZSLjvhac(controllerTemplateHat.up, "up", P_2, P_3);
											PjnmfndrEIjYRMHuWjSZSLjvhac(controllerTemplateHat.upRight, "upRight", P_2, P_3);
											PjnmfndrEIjYRMHuWjSZSLjvhac(controllerTemplateHat.right, "right", P_2, P_3);
											PjnmfndrEIjYRMHuWjSZSLjvhac(controllerTemplateHat.downRight, "downRight", P_2, P_3);
											PjnmfndrEIjYRMHuWjSZSLjvhac(controllerTemplateHat.down, "down", P_2, P_3);
											PjnmfndrEIjYRMHuWjSZSLjvhac(controllerTemplateHat.downLeft, "downLeft", P_2, P_3);
											PjnmfndrEIjYRMHuWjSZSLjvhac(controllerTemplateHat.left, "left", P_2, P_3);
											PjnmfndrEIjYRMHuWjSZSLjvhac(controllerTemplateHat.upLeft, "upLeft", P_2, P_3);
											num2 = 1332232602;
											continue;
										}
										goto case 13;
									case 2:
										hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Position", controllerTemplateStick6D.position.ToString());
										num2 = 1332232592;
										continue;
									case 5:
									{
										int num3;
										if (P_0.type == ControllerTemplateElementType.DPad)
										{
											num2 = 1332232596;
											num3 = num2;
										}
										else
										{
											num2 = 1332232590;
											num3 = num2;
										}
										continue;
									}
									case 11:
										if (P_0.type == ControllerTemplateElementType.ThumbStick)
										{
											IControllerTemplateThumbStick controllerTemplateThumbStick = P_0 as IControllerTemplateThumbStick;
											hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Value", controllerTemplateThumbStick.value.ToString());
											hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Value Prev", controllerTemplateThumbStick.valuePrev.ToString());
											tTDiGJnOLmIWpYtwSfLIjBVFdPU(controllerTemplateThumbStick.horizontal, "horizontal", P_2, P_3);
											tTDiGJnOLmIWpYtwSfLIjBVFdPU(controllerTemplateThumbStick.vertical, "vertical", P_2, P_3);
											PjnmfndrEIjYRMHuWjSZSLjvhac(controllerTemplateThumbStick.press, "press", P_2, P_3);
											num2 = 1332232602;
											continue;
										}
										goto case 12;
									case 10:
										hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Position Prev", controllerTemplateStick6D.positionPrev.ToString());
										num2 = 1332232591;
										continue;
									case 3:
									{
										int num5;
										if (P_0.type != ControllerTemplateElementType.Stick6D)
										{
											num2 = 1332232579;
											num5 = num2;
										}
										else
										{
											num2 = 1332232585;
											num5 = num2;
										}
										continue;
									}
									case 0:
										return;
									}
									break;
								}
							}
						}
					}
					}
					break;
					IL_005e:
					array[1] = P_0.descriptiveName;
					num = 1332232603;
				}
			}
		}

		private static void tTDiGJnOLmIWpYtwSfLIjBVFdPU(IControllerTemplateAxis P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			using (qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh2 = new qdnMheaboQxTbfNHeFXhZezQcjfh(StringTools.VariableNameToDisplayName(P_1), P_2, P_3))
			{
				if (!qdnMheaboQxTbfNHeFXhZezQcjfh2.npNgcUPGCoMjSXwgumOyYMvfGWW)
				{
					return;
				}
				while (true)
				{
					int num = 1750168909;
					while (true)
					{
						switch (num ^ 0x6851754F)
						{
						case 0:
							break;
						default:
							return;
						case 2:
							goto IL_0042;
						case 1:
							return;
						}
						break;
						IL_0042:
						ijiLWohcfkSQXYvTiKzydaRIRvF(P_0, P_2, P_3);
						num = 1750168910;
					}
				}
			}
		}

		private static void PjnmfndrEIjYRMHuWjSZSLjvhac(IControllerTemplateButton P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh2 = new qdnMheaboQxTbfNHeFXhZezQcjfh(StringTools.VariableNameToDisplayName(P_1), P_2, P_3);
			try
			{
				if (qdnMheaboQxTbfNHeFXhZezQcjfh2.npNgcUPGCoMjSXwgumOyYMvfGWW)
				{
					lQRZbpCrySkKcMUgeGjswJgyYfO(P_0, P_2, P_3);
				}
			}
			finally
			{
				if (qdnMheaboQxTbfNHeFXhZezQcjfh2 != null)
				{
					while (true)
					{
						IL_0031:
						int num = 1790553913;
						while (true)
						{
							switch (num ^ 0x6AB9AF38)
							{
							case 2:
								break;
							default:
								goto end_IL_0036;
							case 1:
								goto IL_004f;
							case 0:
								goto end_IL_0036;
							}
							goto IL_0031;
							IL_004f:
							((IDisposable)qdnMheaboQxTbfNHeFXhZezQcjfh2).Dispose();
							num = 1790553912;
							continue;
							end_IL_0036:
							break;
						}
						break;
					}
				}
			}
		}

		private static void ijiLWohcfkSQXYvTiKzydaRIRvF(IControllerTemplateAxis P_0, string P_1, IDictionary<string, bool> P_2)
		{
			hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Value", P_0.value.ToString());
			hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Value Prev", P_0.valuePrev.ToString());
			gQYcCvHisrNBtxlJCmCeuXXqNPqe(P_0.source, "target", P_1, P_2);
		}

		private static void lQRZbpCrySkKcMUgeGjswJgyYfO(IControllerTemplateButton P_0, string P_1, IDictionary<string, bool> P_2)
		{
			hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Value", P_0.value.ToString());
			while (true)
			{
				int num = 1941351795;
				while (true)
				{
					switch (num ^ 0x73B6AD70)
					{
					case 2:
						break;
					case 3:
						hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Value Prev", P_0.valuePrev.ToString());
						num = 1941351792;
						continue;
					case 0:
						hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Pressure", P_0.pressure.ToString());
						hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Pressure Prev", P_0.pressurePrev.ToString());
						hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Just Pressed", P_0.justPressed.ToString());
						num = 1941351793;
						continue;
					default:
						hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Just Released", P_0.justReleased.ToString());
						GqyVsQWkIgiBCYletjNRKxhJAdi(P_0.source, "target", P_1, P_2);
						return;
					}
					break;
				}
			}
		}

		private static void gQYcCvHisrNBtxlJCmCeuXXqNPqe(IControllerTemplateAxisSource P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			using (qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh2 = new qdnMheaboQxTbfNHeFXhZezQcjfh("Axis Target", P_2, P_3))
			{
				if (!qdnMheaboQxTbfNHeFXhZezQcjfh2.npNgcUPGCoMjSXwgumOyYMvfGWW)
				{
					return;
				}
				hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Split Axis", P_0.splitAxis.ToString());
				while (true)
				{
					int num = 178941402;
					while (true)
					{
						switch (num ^ 0xAAA6DDB)
						{
						case 0:
							break;
						default:
							return;
						case 1:
							goto IL_0059;
						case 2:
							return;
						}
						break;
						IL_0059:
						ONAKzpCEhcXeZylMRfwtetPdjAM(P_0.fullTarget, "target", P_2, P_3);
						ONAKzpCEhcXeZylMRfwtetPdjAM(P_0.positiveTarget, "positiveTarget", P_2, P_3);
						ONAKzpCEhcXeZylMRfwtetPdjAM(P_0.negativeTarget, "negativeTarget", P_2, P_3);
						num = 178941401;
					}
				}
			}
		}

		private static void GqyVsQWkIgiBCYletjNRKxhJAdi(IControllerTemplateButtonSource P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			ONAKzpCEhcXeZylMRfwtetPdjAM(P_0.target, "target", P_2, P_3);
		}

		private static void ONAKzpCEhcXeZylMRfwtetPdjAM(IControllerElementTarget P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			qdnMheaboQxTbfNHeFXhZezQcjfh qdnMheaboQxTbfNHeFXhZezQcjfh2 = new qdnMheaboQxTbfNHeFXhZezQcjfh(StringTools.VariableNameToDisplayName(P_1), P_2, P_3);
			try
			{
				if (!qdnMheaboQxTbfNHeFXhZezQcjfh2.npNgcUPGCoMjSXwgumOyYMvfGWW)
				{
					return;
				}
				while (true)
				{
					int num = 428528000;
					while (true)
					{
						switch (num ^ 0x198AD181)
						{
						case 0:
							break;
						default:
							return;
						case 1:
							hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Element Identifier Id", P_0.elementIdentifierId.ToString());
							hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Axis Range", P_0.axisRange.ToString());
							hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Has Target", P_0.hasTarget.ToString());
							if (P_0.hasTarget)
							{
								goto IL_0097;
							}
							return;
						case 2:
							return;
						}
						break;
						IL_0097:
						hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR("Target Element", P_0.descriptiveName);
						num = 428528003;
					}
				}
			}
			finally
			{
				if (qdnMheaboQxTbfNHeFXhZezQcjfh2 != null)
				{
					while (true)
					{
						IL_00b6:
						int num2 = 428528003;
						while (true)
						{
							switch (num2 ^ 0x198AD181)
							{
							case 0:
								break;
							default:
								goto end_IL_00bb;
							case 2:
								goto IL_00d4;
							case 1:
								goto end_IL_00bb;
							}
							goto IL_00b6;
							IL_00d4:
							((IDisposable)qdnMheaboQxTbfNHeFXhZezQcjfh2).Dispose();
							num2 = 428528000;
							continue;
							end_IL_00bb:
							break;
						}
						break;
					}
				}
			}
		}

		private static bool WrsHhyMekyOynchRHSziEyRCQFV(string P_0, bool P_1)
		{
			hpyXVhdtbiFWFEVwktnGBdahHCR.ZDxfqcFMGoCBygNNLeqpsdextAR(P_0, P_1.ToString());
			return false;
		}

		private static GUIStyle EsMGihJDWSpYkwWqQfXVDXdaiaC()
		{
			GUIStyle gUIStyle = new GUIStyle(GUI.skin.label);
			gUIStyle.margin.top = 1;
			gUIStyle.margin.bottom = 1;
			return FVqjbgnrmqUZYhwrRksArMMePgC(gUIStyle);
		}

		public static GUIStyle GetToggleStyle()
		{
			GUIStyle gUIStyle = new GUIStyle(GUI.skin.toggle);
			while (true)
			{
				int num = -2112010305;
				while (true)
				{
					switch (num ^ -2112010306)
					{
					case 0:
						break;
					case 1:
						goto IL_002e;
					default:
						return gUIStyle;
					}
					break;
					IL_002e:
					gUIStyle.margin.top = 0;
					gUIStyle.margin.bottom = 0;
					gUIStyle = FVqjbgnrmqUZYhwrRksArMMePgC(gUIStyle);
					num = -2112010308;
				}
			}
		}

		private static GUIStyle FVqjbgnrmqUZYhwrRksArMMePgC(GUIStyle P_0)
		{
			P_0 = new GUIStyle(P_0);
			P_0.margin.left = gbuFBaLTyEQDLZCgpIDDdhLRCZf.indentLevel * 20;
			return P_0;
		}

		[CompilerGenerated]
		private static int azSlDzcZAbEVQMnIPRolQKGKitQ(InputAction P_0, InputAction P_1)
		{
			return P_0.name.CompareTo(P_1.name);
		}
	}
}
