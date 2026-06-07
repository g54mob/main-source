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
		private class PdvratWBuExgULHQUZUruzxWsgi : IDisposable
		{
			public readonly bool SpZKjJhMWylOpfghINSctstbjVX;

			public PdvratWBuExgULHQUZUruzxWsgi(string label, string key, IDictionary<string, bool> foldouts)
			{
				SpZKjJhMWylOpfghINSctstbjVX = PbhIqIVIeSApDemrdoGcUZpbEtb(label, key, foldouts);
				VyyCMhxCVCrOcvHHRMFRKbLLfHq.indentLevel++;
			}

			private bool PbhIqIVIeSApDemrdoGcUZpbEtb(string P_0, string P_1, IDictionary<string, bool> P_2)
			{
				return VtoKkiwcmLLOAItWZQaqBuBPukz(P_1, GUILayout.Toggle(jJERCmjpdcYOIwLhfFCIcyWvKRmP(P_1, P_2), new GUIContent(P_0, P_0), GetToggleStyle()), P_2);
			}

			private bool jJERCmjpdcYOIwLhfFCIcyWvKRmP(string P_0, IDictionary<string, bool> P_1)
			{
				if (!P_1.ContainsKey(P_0))
				{
					while (true)
					{
						int num = 455279489;
						while (true)
						{
							switch (num ^ 0x1B230380)
							{
							case 0:
								break;
							case 1:
								P_1.Add(P_0, false);
								num = 455279490;
								continue;
							default:
								goto end_IL_0009;
							}
							break;
						}
						continue;
						end_IL_0009:
						break;
					}
				}
				return P_1[P_0];
			}

			private bool VtoKkiwcmLLOAItWZQaqBuBPukz(string P_0, bool P_1, IDictionary<string, bool> P_2)
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
						int num = -370431321;
						while (true)
						{
							switch (num ^ -370431323)
							{
							case 0:
								num = -370431324;
								continue;
							case 1:
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
				VyyCMhxCVCrOcvHHRMFRKbLLfHq.indentLevel--;
			}
		}

		private static class VyyCMhxCVCrOcvHHRMFRKbLLfHq
		{
			private static int iWWvonLbpxerOiOSlYmZpdsAIVE;

			public static int indentLevel
			{
				get
				{
					return iWWvonLbpxerOiOSlYmZpdsAIVE;
				}
				set
				{
					iWWvonLbpxerOiOSlYmZpdsAIVE = Mathf.Max(0, value);
				}
			}
		}

		private static class YtsAUmVGnyfimunrOBlQEainCWMR
		{
			public static void GlbyUHePQjrZypEGorKqLqEnidD()
			{
				GUILayout.BeginHorizontal();
			}

			public static void PcUlPEFWbhikTrDCAunplZzSiEY()
			{
				GUILayout.EndHorizontal();
			}

			public static void RIbHNIsXTdiaOPqcGIPLjTNrSYS()
			{
				GUILayout.BeginVertical();
			}

			public static void hoGupxPYdVXZsfKhBdLogMUpmP()
			{
				GUILayout.EndVertical();
			}

			public static void iuqDywQfvvxCmgIXglpDEaAFvCv(string P_0, MvWrJJUrtXMGkhdCUYqZygkwYpu P_1)
			{
				GUILayout.Label(P_0, nNGVjwnTDSOTFOPTgnSBoZKcxCL());
			}

			public static void agzptvdlSoBcREWCrkmdPyihERI(string P_0, string P_1)
			{
				GUILayout.Label(P_0 + ": " + P_1, nNGVjwnTDSOTFOPTgnSBoZKcxCL());
			}

			public static void QCDSjrxasyFMGCZtIVxNnYNCULuB(string P_0, AnimationCurve P_1)
			{
				GUILayout.Label(P_0 + ": Curves are not visualized by this tool.");
			}

			public static bool btyRilkCemQDQYvUxrdobnXUCSU(string P_0, bool P_1)
			{
				return GUILayout.Toggle(P_1, P_0, nNGVjwnTDSOTFOPTgnSBoZKcxCL());
			}
		}

		private static class wwCAPbBYIRsEgRIekprpTYZPKcN
		{
			[CompilerGenerated]
			private static float zWQiNZPoVCudoeyMMEefQAQqBwT;

			[CompilerGenerated]
			private static float bRiWKxBhiitSplLypOdiViPJurJ;

			public static float labelWidth
			{
				[CompilerGenerated]
				get
				{
					return zWQiNZPoVCudoeyMMEefQAQqBwT;
				}
				[CompilerGenerated]
				set
				{
					zWQiNZPoVCudoeyMMEefQAQqBwT = value;
				}
			}

			public static float fieldWidth
			{
				[CompilerGenerated]
				get
				{
					return bRiWKxBhiitSplLypOdiViPJurJ;
				}
				[CompilerGenerated]
				set
				{
					bRiWKxBhiitSplLypOdiViPJurJ = value;
				}
			}
		}

		internal enum MvWrJJUrtXMGkhdCUYqZygkwYpu
		{
			iOlZgcuFwLCPNAjSgaSDuxucio = 0,
			apkLqRKJUkxkufsKFZnbeIKClGw = 1,
			TvvfUnnpxItRZhgonEsxHVQCTzM = 2,
			grUBokGUZoYzRePQzgyPslflUhm = 3
		}

		private sealed class iRevELGEXfjBGdpbokXhxqSdIdb
		{
			public InputCategory HAKEPohyMmXooUcPgNOSxLBIAxZ;

			public bool veNGHTCsiRRFnQiOTtpnqouLOMg(InputAction P_0)
			{
				return P_0.categoryId == HAKEPohyMmXooUcPgNOSxLBIAxZ.id;
			}
		}

		private const string tuTdiUAiwoOhMtwDDBxdQMBrILvI = "Rewired_DebugInformation";

		private const string NQsCHValuDmhGHfMgfxcUAgADlQ = "Rewired Debug Information";

		private const int dfsgWteZRXXIXGaAwhYODODrxonl = 20;

		private IDictionary<string, bool> cpCRSrJbvBDbsrGXNLpEmirqMRu = new Dictionary<string, bool>();

		private static Vector2 SYxBmSIkgfDScdEwIlmTtrgRpcF;

		[CompilerGenerated]
		private static Comparison<InputAction> viDktHuvUPMnokGPFFcrsxLUFz;

		[CustomObfuscation(rename = false)]
		private void OnEnable()
		{
			if (cpCRSrJbvBDbsrGXNLpEmirqMRu.Count == 0)
			{
				cpCRSrJbvBDbsrGXNLpEmirqMRu.Add("Rewired_DebugInformation", true);
			}
		}

		[CustomObfuscation(rename = false)]
		private void OnDisable()
		{
		}

		[CustomObfuscation(rename = false)]
		private void OnGUI()
		{
			VyyCMhxCVCrOcvHHRMFRKbLLfHq.indentLevel = 0;
			while (true)
			{
				int num = -329382124;
				while (true)
				{
					switch (num ^ -329382123)
					{
					case 2:
						break;
					case 3:
						DrawDebugInformation(true, cpCRSrJbvBDbsrGXNLpEmirqMRu);
						GUILayout.EndScrollView();
						num = -329382123;
						continue;
					case 4:
						SYxBmSIkgfDScdEwIlmTtrgRpcF = GUILayout.BeginScrollView(SYxBmSIkgfDScdEwIlmTtrgRpcF, GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
						num = -329382122;
						continue;
					case 1:
						GUILayout.BeginArea(new Rect(0f, 0f, Screen.width, Screen.height));
						num = -329382127;
						continue;
					default:
						GUILayout.EndArea();
						return;
					}
					break;
				}
			}
		}

		public static void DrawDebugInformation(bool enabled, IDictionary<string, bool> foldouts)
		{
			bool flag = GUI.enabled;
			if (ReInput.isReady)
			{
				goto IL_000d;
			}
			goto IL_0080;
			IL_000d:
			int num = 1251765475;
			goto IL_0012;
			IL_0012:
			float num2 = default(float);
			Rect lastRect = default(Rect);
			while (true)
			{
				switch (num ^ 0x4A9C6CE9)
				{
				case 3:
					break;
				case 10:
					goto IL_004e;
				case 9:
					YtsAUmVGnyfimunrOBlQEainCWMR.GlbyUHePQjrZypEGorKqLqEnidD();
					GUILayout.FlexibleSpace();
					num = 1251765480;
					continue;
				case 2:
					wwCAPbBYIRsEgRIekprpTYZPKcN.fieldWidth = num2;
					num = 1251765487;
					continue;
				case 7:
					goto IL_0080;
				case 5:
					wwCAPbBYIRsEgRIekprpTYZPKcN.labelWidth = lastRect.width - num2;
					num = 1251765483;
					continue;
				case 8:
					wwCAPbBYIRsEgRIekprpTYZPKcN.labelWidth = 0f;
					num = 1251765485;
					continue;
				case 1:
					YtsAUmVGnyfimunrOBlQEainCWMR.PcUlPEFWbhikTrDCAunplZzSiEY();
					num = 1251765481;
					continue;
				case 6:
					LvzzItjtfwRVBdasAxxjZLfWDQH(enabled, foldouts);
					GUI.enabled = flag;
					num = 1251765473;
					continue;
				case 0:
					lastRect = GUILayoutUtility.GetLastRect();
					num2 = lastRect.width / 3f;
					num = 1251765484;
					continue;
				default:
					wwCAPbBYIRsEgRIekprpTYZPKcN.fieldWidth = 0f;
					return;
				}
				break;
				IL_004e:
				int num3;
				if (enabled)
				{
					num = 1251765472;
					num3 = num;
				}
				else
				{
					num = 1251765486;
					num3 = num;
				}
			}
			goto IL_000d;
			IL_0080:
			GUI.enabled = false;
			num = 1251765472;
			goto IL_0012;
		}

		private static void LvzzItjtfwRVBdasAxxjZLfWDQH(bool P_0, IDictionary<string, bool> P_1)
		{
			using (PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi = new PdvratWBuExgULHQUZUruzxWsgi("Rewired Debug Information", "Rewired_DebugInformation", P_1))
			{
				if (ReInput.isReady)
				{
					if (!P_0)
					{
						goto IL_0021;
					}
					goto IL_00b6;
				}
				goto IL_00e6;
				IL_00e6:
				GUILayout.Label("There is no active Rewired Input Manager in the scene.");
				return;
				IL_0021:
				int num = 2076317328;
				goto IL_0026;
				IL_0026:
				bool flag = default(bool);
				while (true)
				{
					switch (num ^ 0x7BC21696)
					{
					case 7:
						break;
					case 3:
						if (flag)
						{
							YtsAUmVGnyfimunrOBlQEainCWMR.iuqDywQfvvxCmgIXglpDEaAFvCv("Native input is disabled. Many special features are unavailable without native input.", MvWrJJUrtXMGkhdCUYqZygkwYpu.TvvfUnnpxItRZhgonEsxHVQCTzM);
							num = 2076317334;
							continue;
						}
						goto default;
					case 2:
						if (ReInput.primaryInputManager.inputSourceType == InputSource.Fallback)
						{
							flag = true;
							num = 2076317333;
							continue;
						}
						goto case 3;
					case 4:
						flag = ReInput.configuration.disableNativeInput;
						if (flag)
						{
							goto case 3;
						}
						if (ReInput.currentPlatform == Platform.Windows)
						{
							goto case 2;
						}
						goto IL_009a;
					case 1:
						goto IL_00b6;
					case 5:
						goto IL_00cd;
					case 6:
						goto IL_00e6;
					default:
					{
						rJlvdOmKmLbaRhMfTNrfuyTXRUWK(P_1, "Rewired_DebugInformation");
						string text = "Rewired_DebugInformation_controllers";
						using (PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi2 = new PdvratWBuExgULHQUZUruzxWsgi("Controllers", text, P_1))
						{
							if (!pdvratWBuExgULHQUZUruzxWsgi2.SpZKjJhMWylOpfghINSctstbjVX)
							{
								return;
							}
							LEpeMIKuMSGVBJdOGVKChBNCFqTd(ReInput.controllers.Joysticks, P_1, text);
							FBkHjTqMvbWLHcrnWoRLOZMsCDs(ReInput.controllers.CustomControllers, P_1, text);
							EJxksPumPmdNXdGclsJxhtpGcqTb(P_1, "Rewired_DebugInformation");
							while (true)
							{
								int num2 = 2076317332;
								while (true)
								{
									switch (num2 ^ 0x7BC21696)
									{
									case 0:
										break;
									default:
										return;
									case 2:
										goto IL_0176;
									case 1:
										return;
									}
									break;
									IL_0176:
									qHbAmfKtKJpCeKoNPnjzATjcCqFo(P_1, "Rewired_DebugInformation");
									num2 = 2076317335;
								}
							}
						}
					}
					}
					break;
					IL_009a:
					int num3;
					if (ReInput.currentPlatform != Platform.OSX)
					{
						num = 2076317333;
						num3 = num;
					}
					else
					{
						num = 2076317332;
						num3 = num;
					}
				}
				goto IL_0021;
				IL_00b6:
				if (!pdvratWBuExgULHQUZUruzxWsgi.SpZKjJhMWylOpfghINSctstbjVX)
				{
					return;
				}
				goto IL_00cd;
				IL_00cd:
				YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Rewired Version", ReInput.programVersion);
				num = 2076317330;
				goto IL_0026;
			}
		}

		private static void rJlvdOmKmLbaRhMfTNrfuyTXRUWK(IDictionary<string, bool> P_0, string P_1)
		{
			string text = P_1 + "_players";
			using (PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi = new PdvratWBuExgULHQUZUruzxWsgi("Players (" + ReInput.players.allPlayerCount + ")", text, P_0))
			{
				if (!pdvratWBuExgULHQUZUruzxWsgi.SpZKjJhMWylOpfghINSctstbjVX)
				{
					return;
				}
				int num2 = default(int);
				int playerCount = default(int);
				while (true)
				{
					int num = 547677949;
					while (true)
					{
						switch (num ^ 0x20A4E6FF)
						{
						case 3:
							break;
						default:
							return;
						case 6:
						{
							Player player = ReInput.players.GetPlayer(num2);
							rekCcfgBAaYIqCRWiZebmBcfgTNF(player, num2, P_0, text);
							num2++;
							num = 547677951;
							continue;
						}
						case 4:
							rekCcfgBAaYIqCRWiZebmBcfgTNF(ReInput.players.SystemPlayer, -1, P_0, text);
							num = 547677946;
							continue;
						case 0:
						{
							int num3;
							if (num2 < playerCount)
							{
								num = 547677945;
								num3 = num;
							}
							else
							{
								num = 547677947;
								num3 = num;
							}
							continue;
						}
						case 2:
							playerCount = ReInput.players.playerCount;
							num2 = 0;
							num = 547677950;
							continue;
						case 1:
							num = 547677951;
							continue;
						case 5:
							return;
						}
						break;
					}
				}
			}
		}

		private static void LEpeMIKuMSGVBJdOGVKChBNCFqTd(IList<Joystick> P_0, IDictionary<string, bool> P_1, string P_2)
		{
			int num = ((P_0 != null) ? P_0.Count : 0);
			PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi = new PdvratWBuExgULHQUZUruzxWsgi("Joysticks (" + num + ")", P_2 + "_joysticks", P_1);
			try
			{
				if (!pdvratWBuExgULHQUZUruzxWsgi.SpZKjJhMWylOpfghINSctstbjVX)
				{
					while (true)
					{
						switch (-1134765118 ^ -1134765120)
						{
						case 0:
							break;
						case 2:
							return;
						case 1:
							goto end_IL_003c;
						default:
							goto IL_0078;
						}
						continue;
						end_IL_003c:
						break;
					}
				}
				int num2 = 0;
				goto IL_0761;
				IL_0761:
				if (num2 >= num)
				{
					return;
				}
				goto IL_0078;
				IL_0078:
				Joystick joystick = P_0[num2];
				string text = P_2 + "_joystick" + joystick.id;
				using (PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi2 = new PdvratWBuExgULHQUZUruzxWsgi(num2 + ": " + ((joystick.name == "Unknown Controller") ? joystick.hardwareName : joystick.name), text, P_1))
				{
					if (!pdvratWBuExgULHQUZUruzxWsgi2.SpZKjJhMWylOpfghINSctstbjVX)
					{
						goto IL_00de;
					}
					goto IL_0319;
					IL_00de:
					int num3 = -1134765116;
					goto IL_00e3;
					IL_00e3:
					string text2 = default(string);
					int num10 = default(int);
					Player player = default(Player);
					object[] array = default(object[]);
					while (true)
					{
						switch (num3 ^ -1134765120)
						{
						case 11:
							break;
						case 4:
							goto end_IL_00d2;
						case 9:
							YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Enabled", joystick.enabled.ToString());
							text2 = string.Empty;
							num10 = 0;
							num3 = -1134765108;
							continue;
						case 8:
							player = ReInput.players.AllPlayers[num10];
							num3 = -1134765114;
							continue;
						case 5:
							num10++;
							num3 = -1134765108;
							continue;
						case 10:
							text2 += ((player.id == 9999999) ? "System" : player.id.ToString());
							num3 = -1134765115;
							continue;
						case 3:
							YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Hardware Type Guid", joystick.hardwareTypeGuid.ToString());
							YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Hardware Identifier", joystick.hardwareIdentifier);
							YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Device Instance Guid", joystick.deviceInstanceGuid.ToString());
							num3 = -1134765113;
							continue;
						case 6:
							if (!ReInput.controllers.IsJoystickAssignedToPlayer(joystick.id, player.id))
							{
								goto case 5;
							}
							if (text2 != string.Empty)
							{
								text2 += ", ";
								num3 = -1134765110;
								continue;
							}
							goto case 10;
						case 12:
							if (num10 >= ReInput.players.allPlayerCount)
							{
								YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
								YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("System Id", joystick.systemId.ToString());
								YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Unity Id", ReInput.usingUnityInput ? joystick.unityId.ToString() : "--");
								num3 = -1134765117;
								continue;
							}
							goto case 8;
						case 0:
							YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Hardware Name", joystick.hardwareName);
							YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Is Recognized", (joystick.hardwareTypeGuid != Guid.Empty).ToString());
							num3 = -1134765111;
							continue;
						case 1:
							goto IL_0319;
						case 7:
							YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Tag", joystick.tag);
							FflrVUtBcBEQxAgDrhEUgdakmXie(joystick.Axes, P_1, text);
							ZHFfildjfFpPAxiLTdkLEywAgtu(joystick.Buttons, ControllerType.Joystick, P_1, text);
							num3 = -1134765118;
							continue;
						default:
						{
							YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Axis2D Count", joystick.axis2DCount.ToString());
							YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Hat Count", joystick.hatCount.ToString());
							ftNPEXXPbkHYMHIJpPBBkZJJFwG(joystick, P_1, text);
							CalibrationMap calibrationMap = joystick.calibrationMap;
							PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi3 = new PdvratWBuExgULHQUZUruzxWsgi("Calibration Map", text + "_calibrationMap", P_1);
							try
							{
								if (pdvratWBuExgULHQUZUruzxWsgi3.SpZKjJhMWylOpfghINSctstbjVX)
								{
									int axisCount = calibrationMap.axisCount;
									int num4 = 0;
									while (true)
									{
										if (num4 < axisCount)
										{
											AxisCalibration axisCalibration;
											while (true)
											{
												axisCalibration = calibrationMap.Axes[num4];
												int num5 = -1134765117;
												while (true)
												{
													switch (num5 ^ -1134765120)
													{
													case 0:
														num5 = -1134765118;
														continue;
													case 2:
														break;
													case 3:
														array = new object[4];
														num5 = -1134765119;
														continue;
													default:
														goto end_IL_041e;
													}
													break;
												}
												continue;
												end_IL_041e:
												break;
											}
											array[0] = num4;
											array[1] = ": Axis Calibration (";
											array[2] = (axisCalibration.enabled ? "Enabled" : "Disabled");
											array[3] = ")";
											using (PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi4 = new PdvratWBuExgULHQUZUruzxWsgi(string.Concat(array), text + "_AxisCalibration" + num4, P_1))
											{
												if (pdvratWBuExgULHQUZUruzxWsgi4.SpZKjJhMWylOpfghINSctstbjVX)
												{
													while (true)
													{
														IL_04db:
														YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Enabled", axisCalibration.enabled.ToString());
														YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Apply Range Calibration", axisCalibration.applyRangeCalibration.ToString());
														int num6 = -1134765118;
														while (true)
														{
															switch (num6 ^ -1134765120)
															{
															case 6:
																num6 = -1134765115;
																continue;
															default:
																goto end_IL_04af;
															case 5:
																break;
															case 1:
																num6 = -1134765120;
																continue;
															case 3:
																YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Sensitivity Curve", "--");
																num6 = -1134765120;
																continue;
															case 4:
																YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Sensitivity Type", axisCalibration.sensitivityType.ToString());
																YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Sensitivity", axisCalibration.sensitivity.ToString());
																if (axisCalibration.sensitivityCurve != null)
																{
																	bool flag = GUI.enabled;
																	GUI.enabled = false;
																	YtsAUmVGnyfimunrOBlQEainCWMR.QCDSjrxasyFMGCZtIVxNnYNCULuB("Sensitivity Curve", axisCalibration.sensitivityCurve);
																	GUI.enabled = flag;
																	num6 = -1134765119;
																	continue;
																}
																goto case 3;
															case 2:
																YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Calibrated Max", axisCalibration.calibratedMax.ToString());
																YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Calibrated Min", axisCalibration.calibratedMin.ToString());
																YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Calibrated Zero", axisCalibration.calibratedZero.ToString());
																YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Dead Zone", axisCalibration.deadZone.ToString());
																YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Invert", axisCalibration.invert.ToString());
																num6 = -1134765116;
																continue;
															case 0:
																goto end_IL_04af;
															}
															goto IL_04db;
															continue;
															end_IL_04af:
															break;
														}
														break;
													}
												}
											}
											num4++;
											goto IL_0643;
										}
										int num7 = -1134765118;
										goto IL_0648;
										IL_0643:
										num7 = -1134765119;
										goto IL_0648;
										IL_0648:
										switch (num7 ^ -1134765120)
										{
										case 0:
											break;
										default:
											goto end_IL_0661;
										case 1:
											continue;
										case 2:
											goto end_IL_0661;
										}
										goto IL_0643;
										continue;
										end_IL_0661:
										break;
									}
								}
							}
							finally
							{
								if (pdvratWBuExgULHQUZUruzxWsgi3 != null)
								{
									while (true)
									{
										IL_0677:
										int num8 = -1134765119;
										while (true)
										{
											switch (num8 ^ -1134765120)
											{
											case 0:
												break;
											default:
												goto end_IL_067c;
											case 1:
												goto IL_0695;
											case 2:
												goto end_IL_067c;
											}
											goto IL_0677;
											IL_0695:
											((IDisposable)pdvratWBuExgULHQUZUruzxWsgi3).Dispose();
											num8 = -1134765118;
											continue;
											end_IL_067c:
											break;
										}
										break;
									}
								}
							}
							YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Supports Vibration", joystick.supportsVibration.ToString());
							while (true)
							{
								IL_06bd:
								int num9 = -1134765118;
								while (true)
								{
									string obj;
									switch (num9 ^ -1134765120)
									{
									case 0:
										break;
									case 2:
										YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Vibration Motor Count", joystick.vibrationMotorCount.ToString());
										YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Has Extension", (joystick.extension != null).ToString());
										obj = ((joystick.extension != null) ? joystick.extension.GetType().Name : "--");
										goto IL_0737;
									default:
										GngwrrgmLCFumJUTkbBytgMcRGT(joystick, P_1, text);
										goto end_IL_06c2;
									}
									goto IL_06bd;
									IL_0737:
									YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Extension Type", obj);
									num9 = -1134765119;
									continue;
									end_IL_06c2:
									break;
								}
								break;
							}
							goto end_IL_00d2;
						}
						}
						break;
					}
					goto IL_00de;
					IL_0319:
					YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Id (unique id)", joystick.id.ToString());
					YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Name", joystick.name);
					num3 = -1134765120;
					goto IL_00e3;
					end_IL_00d2:;
				}
				num2++;
				goto IL_0761;
			}
			finally
			{
				if (pdvratWBuExgULHQUZUruzxWsgi != null)
				{
					while (true)
					{
						IL_076d:
						int num11 = -1134765119;
						while (true)
						{
							switch (num11 ^ -1134765120)
							{
							case 0:
								break;
							default:
								goto end_IL_0772;
							case 1:
								goto IL_078b;
							case 2:
								goto end_IL_0772;
							}
							goto IL_076d;
							IL_078b:
							((IDisposable)pdvratWBuExgULHQUZUruzxWsgi).Dispose();
							num11 = -1134765118;
							continue;
							end_IL_0772:
							break;
						}
						break;
					}
				}
			}
		}

		private static void EJxksPumPmdNXdGclsJxhtpGcqTb(IDictionary<string, bool> P_0, string P_1)
		{
			string text = P_1 + "_mouse";
			PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi = new PdvratWBuExgULHQUZUruzxWsgi("Mouse", text, P_0);
			try
			{
				if (!pdvratWBuExgULHQUZUruzxWsgi.SpZKjJhMWylOpfghINSctstbjVX)
				{
					return;
				}
				Player player = default(Player);
				while (true)
				{
					Mouse mouse = ReInput.controllers.Mouse;
					YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Enabled", mouse.enabled.ToString());
					string text2 = string.Empty;
					int num = 0;
					int num2 = -1780192188;
					while (true)
					{
						switch (num2 ^ -1780192191)
						{
						case 7:
							num2 = -1780192192;
							continue;
						case 0:
							ZHFfildjfFpPAxiLTdkLEywAgtu(mouse.Buttons, ControllerType.Mouse, P_0, text);
							num2 = -1780192190;
							continue;
						case 8:
							text2 += ((player.id == 9999999) ? "System" : player.id.ToString());
							num2 = -1780192187;
							continue;
						case 4:
							num++;
							num2 = -1780192188;
							continue;
						case 6:
						{
							player = ReInput.players.AllPlayers[num];
							int num3;
							if (!player.controllers.hasMouse)
							{
								num2 = -1780192187;
								num3 = num2;
							}
							else
							{
								num2 = -1780192189;
								num3 = num2;
							}
							continue;
						}
						case 2:
							if (text2 != string.Empty)
							{
								text2 += ", ";
								num2 = -1780192183;
								continue;
							}
							goto case 8;
						case 1:
							break;
						case 5:
							if (num >= ReInput.players.allPlayerCount)
							{
								YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
								YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Screen Position", mouse.screenPosition.ToString());
								YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Screen Position Prev", mouse.screenPositionPrev.ToString());
								YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Screen Position Delta", mouse.screenPositionDelta.ToString());
								FflrVUtBcBEQxAgDrhEUgdakmXie(mouse.Axes, P_0, text);
								num2 = -1780192191;
								continue;
							}
							goto case 6;
						default:
							ftNPEXXPbkHYMHIJpPBBkZJJFwG(mouse, P_0, text);
							GngwrrgmLCFumJUTkbBytgMcRGT(mouse, P_0, text);
							return;
						}
						break;
					}
				}
			}
			finally
			{
				if (pdvratWBuExgULHQUZUruzxWsgi != null)
				{
					while (true)
					{
						IL_0200:
						int num4 = -1780192192;
						while (true)
						{
							switch (num4 ^ -1780192191)
							{
							case 0:
								break;
							default:
								goto end_IL_0205;
							case 1:
								goto IL_021e;
							case 2:
								goto end_IL_0205;
							}
							goto IL_0200;
							IL_021e:
							((IDisposable)pdvratWBuExgULHQUZUruzxWsgi).Dispose();
							num4 = -1780192189;
							continue;
							end_IL_0205:
							break;
						}
						break;
					}
				}
			}
		}

		private static void qHbAmfKtKJpCeKoNPnjzATjcCqFo(IDictionary<string, bool> P_0, string P_1)
		{
			string text = P_1 + "_keyboard";
			using (PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi = new PdvratWBuExgULHQUZUruzxWsgi("Keyboard", text, P_0))
			{
				if (!pdvratWBuExgULHQUZUruzxWsgi.SpZKjJhMWylOpfghINSctstbjVX)
				{
					goto IL_0024;
				}
				goto IL_00cd;
				IL_0024:
				int num = -1780193457;
				goto IL_0029;
				IL_0029:
				string text2 = default(string);
				int num2 = default(int);
				Player player = default(Player);
				Keyboard keyboard = default(Keyboard);
				while (true)
				{
					switch (num ^ -1780193462)
					{
					case 9:
						break;
					case 1:
						if (text2 != string.Empty)
						{
							text2 += ", ";
							num = -1780193463;
							continue;
						}
						goto case 3;
					case 7:
						goto IL_0088;
					case 2:
						num2++;
						num = -1780193458;
						continue;
					case 6:
						goto IL_00cd;
					case 3:
						text2 += ((player.id == 9999999) ? "System" : player.id.ToString());
						num = -1780193464;
						continue;
					case 5:
						return;
					case 0:
						num2 = 0;
						num = -1780193458;
						continue;
					case 4:
						if (num2 >= ReInput.players.allPlayerCount)
						{
							YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
							num = -1780193472;
							continue;
						}
						goto IL_0088;
					case 10:
						ZHFfildjfFpPAxiLTdkLEywAgtu(keyboard.Buttons, ControllerType.Keyboard, P_0, text);
						ftNPEXXPbkHYMHIJpPBBkZJJFwG(keyboard, P_0, text);
						num = -1780193470;
						continue;
					default:
						GngwrrgmLCFumJUTkbBytgMcRGT(keyboard, P_0, text);
						return;
					}
					break;
					IL_0088:
					player = ReInput.players.AllPlayers[num2];
					int num3;
					if (!player.controllers.hasKeyboard)
					{
						num = -1780193464;
						num3 = num;
					}
					else
					{
						num = -1780193461;
						num3 = num;
					}
				}
				goto IL_0024;
				IL_00cd:
				keyboard = ReInput.controllers.Keyboard;
				YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Enabled", keyboard.enabled.ToString());
				text2 = string.Empty;
				num = -1780193462;
				goto IL_0029;
			}
		}

		private static void FBkHjTqMvbWLHcrnWoRLOZMsCDs(IList<CustomController> P_0, IDictionary<string, bool> P_1, string P_2)
		{
			int num = ((P_0 != null) ? P_0.Count : 0);
			using (PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi = new PdvratWBuExgULHQUZUruzxWsgi("Custom Controllers (" + num + ")", P_2 + "_customControllers", P_1))
			{
				if (!pdvratWBuExgULHQUZUruzxWsgi.SpZKjJhMWylOpfghINSctstbjVX)
				{
					return;
				}
				CustomController customController = default(CustomController);
				string text2 = default(string);
				Player player = default(Player);
				int num20 = default(int);
				int num5 = default(int);
				object[] array = default(object[]);
				int num7 = default(int);
				ControllerElementIdentifier controllerElementIdentifier = default(ControllerElementIdentifier);
				int num16 = default(int);
				object[] array3 = default(object[]);
				AxisCalibration axisCalibration = default(AxisCalibration);
				while (true)
				{
					int num2 = 0;
					int num3 = 2013522127;
					while (true)
					{
						switch (num3 ^ 0x7803E8CC)
						{
						case 2:
							num3 = 2013522125;
							continue;
						case 1:
							break;
						case 4:
							customController = ReInput.controllers.CustomControllers[num2];
							num3 = 2013522124;
							continue;
						default:
						{
							string text = P_2 + "_customController" + customController.id;
							using (PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi2 = new PdvratWBuExgULHQUZUruzxWsgi(num2 + ": " + customController.name, text, P_1))
							{
								if (pdvratWBuExgULHQUZUruzxWsgi2.SpZKjJhMWylOpfghINSctstbjVX)
								{
									while (true)
									{
										IL_0117:
										YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Id", customController.id.ToString());
										YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Name", customController.name);
										int num4 = 2013522122;
										while (true)
										{
											switch (num4 ^ 0x7803E8CC)
											{
											case 9:
												num4 = 2013522121;
												continue;
											case 5:
												break;
											case 4:
												text2 += ((player.id == 9999999) ? "System" : player.id.ToString());
												num4 = 2013522125;
												continue;
											case 7:
												player = ReInput.players.AllPlayers[num20];
												if (ReInput.controllers.IsCustomControllerAssignedToPlayer(customController.id, player.id))
												{
													int num21;
													if (text2 != string.Empty)
													{
														num4 = 2013522127;
														num21 = num4;
													}
													else
													{
														num4 = 2013522120;
														num21 = num4;
													}
													continue;
												}
												goto case 1;
											case 1:
												num20++;
												num4 = 2013522124;
												continue;
											case 0:
												if (num20 >= ReInput.players.allPlayerCount)
												{
													YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
													FflrVUtBcBEQxAgDrhEUgdakmXie(customController.Axes, P_1, text);
													ZHFfildjfFpPAxiLTdkLEywAgtu(customController.Buttons, ControllerType.Custom, P_1, text);
													YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Axis2D Count", customController.axis2DCount.ToString());
													num4 = 2013522116;
													continue;
												}
												goto case 7;
											case 2:
												YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Enabled", customController.enabled.ToString());
												text2 = string.Empty;
												num20 = 0;
												num4 = 2013522124;
												continue;
											case 6:
												YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Hardware Name", customController.hardwareName);
												YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Tag", customController.tag);
												YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Hardware Identifier", customController.hardwareIdentifier);
												num4 = 2013522126;
												continue;
											case 3:
												text2 += ", ";
												num4 = 2013522120;
												continue;
											default:
											{
												using (PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi3 = new PdvratWBuExgULHQUZUruzxWsgi("Element Identifiers", text + "_elementIdentifiers", P_1))
												{
													if (pdvratWBuExgULHQUZUruzxWsgi3.SpZKjJhMWylOpfghINSctstbjVX)
													{
														num5 = ((customController.AxisElementIdentifiers != null) ? customController.AxisElementIdentifiers.Count : 0);
														PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi4 = new PdvratWBuExgULHQUZUruzxWsgi("Axis Element Identifiers (" + num5 + ")", text + "_axisEIs", P_1);
														try
														{
															if (pdvratWBuExgULHQUZUruzxWsgi4.SpZKjJhMWylOpfghINSctstbjVX)
															{
																while (true)
																{
																	IL_033a:
																	int num6 = 2013522120;
																	while (true)
																	{
																		int num9;
																		switch (num6 ^ 0x7803E8CC)
																		{
																		case 2:
																			break;
																		case 3:
																			array = new object[6] { num7, ": ", controllerElementIdentifier.name, null, null, null };
																			num6 = 2013522125;
																			continue;
																		case 0:
																			controllerElementIdentifier = customController.AxisElementIdentifiers[num7];
																			num6 = 2013522127;
																			continue;
																		case 4:
																			num7 = 0;
																			goto IL_04ae;
																		default:
																			{
																				array[3] = " (id: ";
																				array[4] = controllerElementIdentifier.id;
																				array[5] = ")";
																				using (PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi5 = new PdvratWBuExgULHQUZUruzxWsgi(string.Concat(array), text + "_AxisEI" + num7 + "_" + controllerElementIdentifier.name, P_1))
																				{
																					if (pdvratWBuExgULHQUZUruzxWsgi5.SpZKjJhMWylOpfghINSctstbjVX)
																					{
																						while (true)
																						{
																							IL_044a:
																							YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Id", controllerElementIdentifier.id.ToString());
																							YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Name", controllerElementIdentifier.name);
																							int num8 = 2013522125;
																							while (true)
																							{
																								switch (num8 ^ 0x7803E8CC)
																								{
																								case 0:
																									goto IL_042c;
																								default:
																									goto end_IL_0431;
																								case 2:
																									break;
																								case 1:
																									goto end_IL_0431;
																								}
																								goto IL_044a;
																								IL_042c:
																								num8 = 2013522126;
																								continue;
																								end_IL_0431:
																								break;
																							}
																							break;
																						}
																					}
																				}
																				num7++;
																				goto IL_0490;
																			}
																			IL_04ae:
																			if (num7 < num5)
																			{
																				goto case 0;
																			}
																			num9 = 2013522126;
																			goto IL_0495;
																			IL_0495:
																			switch (num9 ^ 0x7803E8CC)
																			{
																			case 0:
																				break;
																			default:
																				goto end_IL_033f;
																			case 1:
																				goto IL_04ae;
																			case 2:
																				goto end_IL_033f;
																			}
																			goto IL_0490;
																			IL_0490:
																			num9 = 2013522125;
																			goto IL_0495;
																		}
																		goto IL_033a;
																		continue;
																		end_IL_033f:
																		break;
																	}
																	break;
																}
															}
														}
														finally
														{
															if (pdvratWBuExgULHQUZUruzxWsgi4 != null)
															{
																while (true)
																{
																	IL_04c4:
																	int num10 = 2013522125;
																	while (true)
																	{
																		switch (num10 ^ 0x7803E8CC)
																		{
																		case 2:
																			break;
																		default:
																			goto end_IL_04c9;
																		case 1:
																			goto IL_04e2;
																		case 0:
																			goto end_IL_04c9;
																		}
																		goto IL_04c4;
																		IL_04e2:
																		((IDisposable)pdvratWBuExgULHQUZUruzxWsgi4).Dispose();
																		num10 = 2013522124;
																		continue;
																		end_IL_04c9:
																		break;
																	}
																	break;
																}
															}
														}
														num5 = ((customController.ButtonElementIdentifiers != null) ? customController.ButtonElementIdentifiers.Count : 0);
														using (PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi6 = new PdvratWBuExgULHQUZUruzxWsgi("Button Element Identifiers (" + num5 + ")", text + "_buttonEIs", P_1))
														{
															if (pdvratWBuExgULHQUZUruzxWsgi6.SpZKjJhMWylOpfghINSctstbjVX)
															{
																int num11 = 0;
																while (true)
																{
																	if (num11 < num5)
																	{
																		ControllerElementIdentifier controllerElementIdentifier2;
																		object[] array2;
																		while (true)
																		{
																			controllerElementIdentifier2 = customController.ButtonElementIdentifiers[num11];
																			array2 = new object[6] { num11, null, null, null, null, null };
																			int num12 = 2013522125;
																			while (true)
																			{
																				switch (num12 ^ 0x7803E8CC)
																				{
																				case 3:
																					num12 = 2013522126;
																					continue;
																				case 2:
																					break;
																				case 1:
																					array2[1] = ": ";
																					array2[2] = controllerElementIdentifier2.name;
																					array2[3] = " (id: ";
																					array2[4] = controllerElementIdentifier2.id;
																					array2[5] = ")";
																					num12 = 2013522124;
																					continue;
																				default:
																					goto end_IL_0569;
																				}
																				break;
																			}
																			continue;
																			end_IL_0569:
																			break;
																		}
																		using (PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi7 = new PdvratWBuExgULHQUZUruzxWsgi(string.Concat(array2), text + "_ButtonEI" + num11 + "_" + controllerElementIdentifier2.name, P_1))
																		{
																			if (!pdvratWBuExgULHQUZUruzxWsgi7.SpZKjJhMWylOpfghINSctstbjVX)
																			{
																				goto IL_0627;
																			}
																			goto IL_0656;
																			IL_0627:
																			int num13 = 2013522120;
																			goto IL_062c;
																			IL_062c:
																			while (true)
																			{
																				switch (num13 ^ 0x7803E8CC)
																				{
																				case 2:
																					break;
																				default:
																					goto end_IL_061e;
																				case 4:
																					goto end_IL_061e;
																				case 0:
																					goto IL_0656;
																				case 3:
																					YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Name", controllerElementIdentifier2.name);
																					num13 = 2013522125;
																					continue;
																				case 1:
																					goto end_IL_061e;
																				}
																				break;
																			}
																			goto IL_0627;
																			IL_0656:
																			YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Id", controllerElementIdentifier2.id.ToString());
																			num13 = 2013522127;
																			goto IL_062c;
																			end_IL_061e:;
																		}
																		num11++;
																		goto IL_06a3;
																	}
																	int num14 = 2013522126;
																	goto IL_06a8;
																	IL_06a3:
																	num14 = 2013522125;
																	goto IL_06a8;
																	IL_06a8:
																	switch (num14 ^ 0x7803E8CC)
																	{
																	case 0:
																		break;
																	default:
																		goto end_IL_06c1;
																	case 1:
																		continue;
																	case 2:
																		goto end_IL_06c1;
																	}
																	goto IL_06a3;
																	continue;
																	end_IL_06c1:
																	break;
																}
															}
														}
													}
												}
												CalibrationMap calibrationMap = customController.calibrationMap;
												PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi8 = new PdvratWBuExgULHQUZUruzxWsgi("Calibration Map", text + "_calibrationMap", P_1);
												try
												{
													if (pdvratWBuExgULHQUZUruzxWsgi8.SpZKjJhMWylOpfghINSctstbjVX)
													{
														while (true)
														{
															IL_071a:
															int num15 = 2013522125;
															while (true)
															{
																int num18;
																switch (num15 ^ 0x7803E8CC)
																{
																case 2:
																	break;
																case 1:
																	num5 = calibrationMap.axisCount;
																	num16 = 0;
																	goto IL_09b2;
																case 3:
																	goto IL_0754;
																default:
																	{
																		array3[0] = num16;
																		array3[1] = ": Axis Calibration (";
																		array3[2] = (axisCalibration.enabled ? "Enabled" : "Disabled");
																		array3[3] = ")";
																		using (PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi9 = new PdvratWBuExgULHQUZUruzxWsgi(string.Concat(array3), text + "_AxisCalibration" + num16, P_1))
																		{
																			if (pdvratWBuExgULHQUZUruzxWsgi9.SpZKjJhMWylOpfghINSctstbjVX)
																			{
																				while (true)
																				{
																					IL_08c6:
																					YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Enabled", axisCalibration.enabled.ToString());
																					YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Apply Range Calibration", axisCalibration.applyRangeCalibration.ToString());
																					YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Calibrated Max", axisCalibration.calibratedMax.ToString());
																					int num17 = 2013522124;
																					while (true)
																					{
																						switch (num17 ^ 0x7803E8CC)
																						{
																						case 6:
																							num17 = 2013522125;
																							continue;
																						default:
																							goto end_IL_07e1;
																						case 5:
																							YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Invert", axisCalibration.invert.ToString());
																							YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Sensitivity Type", axisCalibration.sensitivityType.ToString());
																							num17 = 2013522126;
																							continue;
																						case 0:
																							YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Calibrated Min", axisCalibration.calibratedMin.ToString());
																							num17 = 2013522116;
																							continue;
																						case 7:
																							YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Sensitivity Curve", "--");
																							num17 = 2013522127;
																							continue;
																						case 4:
																							if (axisCalibration.sensitivityCurve != null)
																							{
																								bool flag = GUI.enabled;
																								GUI.enabled = false;
																								YtsAUmVGnyfimunrOBlQEainCWMR.QCDSjrxasyFMGCZtIVxNnYNCULuB("Sensitivity Curve", axisCalibration.sensitivityCurve);
																								GUI.enabled = flag;
																								num17 = 2013522127;
																								continue;
																							}
																							goto case 7;
																						case 1:
																							break;
																						case 8:
																							YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Calibrated Zero", axisCalibration.calibratedZero.ToString());
																							YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Dead Zone", axisCalibration.deadZone.ToString());
																							num17 = 2013522121;
																							continue;
																						case 2:
																							YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Sensitivity", axisCalibration.sensitivity.ToString());
																							num17 = 2013522120;
																							continue;
																						case 3:
																							goto end_IL_07e1;
																						}
																						goto IL_08c6;
																						continue;
																						end_IL_07e1:
																						break;
																					}
																					break;
																				}
																			}
																		}
																		num16++;
																		goto IL_0994;
																	}
																	IL_09b2:
																	if (num16 < num5)
																	{
																		goto IL_0754;
																	}
																	num18 = 2013522126;
																	goto IL_0999;
																	IL_0994:
																	num18 = 2013522125;
																	goto IL_0999;
																	IL_0999:
																	switch (num18 ^ 0x7803E8CC)
																	{
																	case 0:
																		break;
																	default:
																		goto end_IL_071f;
																	case 1:
																		goto IL_09b2;
																	case 2:
																		goto end_IL_071f;
																	}
																	goto IL_0994;
																}
																goto IL_071a;
																IL_0754:
																axisCalibration = calibrationMap.Axes[num16];
																array3 = new object[4];
																num15 = 2013522124;
																continue;
																end_IL_071f:
																break;
															}
															break;
														}
													}
												}
												finally
												{
													if (pdvratWBuExgULHQUZUruzxWsgi8 != null)
													{
														while (true)
														{
															IL_09c8:
															int num19 = 2013522126;
															while (true)
															{
																switch (num19 ^ 0x7803E8CC)
																{
																case 0:
																	break;
																default:
																	goto end_IL_09cd;
																case 2:
																	goto IL_09e6;
																case 1:
																	goto end_IL_09cd;
																}
																goto IL_09c8;
																IL_09e6:
																((IDisposable)pdvratWBuExgULHQUZUruzxWsgi8).Dispose();
																num19 = 2013522125;
																continue;
																end_IL_09cd:
																break;
															}
															break;
														}
													}
												}
												YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Has Extension", (customController.extension != null).ToString());
												YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Extension Type", (customController.extension != null) ? customController.extension.GetType().Name : "--");
												GngwrrgmLCFumJUTkbBytgMcRGT(customController, P_1, text);
												goto end_IL_00df;
											}
											}
											goto IL_0117;
											continue;
											end_IL_00df:
											break;
										}
										break;
									}
								}
							}
							num2++;
							goto case 3;
						}
						case 3:
							if (num2 >= num)
							{
								return;
							}
							goto case 4;
						}
						break;
					}
				}
			}
		}

		private static void rekCcfgBAaYIqCRWiZebmBcfgTNF(Player P_0, int P_1, IDictionary<string, bool> P_2, string P_3)
		{
			string text = P_3 + "_player" + P_0.id;
			using (PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi = new PdvratWBuExgULHQUZUruzxWsgi((P_0.id == 9999999) ? "System Player" : (P_1 + ": " + P_0.name), text, P_2))
			{
				if (!pdvratWBuExgULHQUZUruzxWsgi.SpZKjJhMWylOpfghINSctstbjVX)
				{
					return;
				}
				int num6 = default(int);
				Joystick joystick = default(Joystick);
				IList<JoystickMap> maps = default(IList<JoystickMap>);
				string text3 = default(string);
				IList<CustomControllerMap> maps2 = default(IList<CustomControllerMap>);
				CustomController customController = default(CustomController);
				object[] array = default(object[]);
				int num20 = default(int);
				iRevELGEXfjBGdpbokXhxqSdIdb iRevELGEXfjBGdpbokXhxqSdIdb2 = default(iRevELGEXfjBGdpbokXhxqSdIdb);
				int num18 = default(int);
				string text4 = default(string);
				object[] array2 = default(object[]);
				string key = default(string);
				while (true)
				{
					YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Player Id", P_0.id.ToString());
					int num = 1448649241;
					while (true)
					{
						switch (num ^ 0x5658A21B)
						{
						case 0:
							goto IL_0056;
						case 1:
							break;
						default:
						{
							YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Name", P_0.name);
							YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Descriptive Name", P_0.descriptiveName);
							YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Is Playing", P_0.isPlaying.ToString());
							PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi2 = new PdvratWBuExgULHQUZUruzxWsgi("Controllers", text + "_controllers", P_2);
							try
							{
								if (pdvratWBuExgULHQUZUruzxWsgi2.SpZKjJhMWylOpfghINSctstbjVX)
								{
									Player.ControllerHelper controllers = P_0.controllers;
									LEpeMIKuMSGVBJdOGVKChBNCFqTd(controllers.Joysticks, P_2, text);
									FBkHjTqMvbWLHcrnWoRLOZMsCDs(controllers.CustomControllers, P_2, text);
									while (true)
									{
										IL_0110:
										int num2 = 1448649242;
										while (true)
										{
											switch (num2 ^ 0x5658A21B)
											{
											case 0:
												break;
											default:
												goto end_IL_0115;
											case 1:
												goto IL_012e;
											case 2:
												goto end_IL_0115;
											}
											goto IL_0110;
											IL_012e:
											YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Has Mouse", controllers.hasMouse.ToString());
											YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Has Keyboard", controllers.hasKeyboard.ToString());
											YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Exclude From Controller Auto Assignment", controllers.excludeFromControllerAutoAssignment.ToString());
											num2 = 1448649241;
											continue;
											end_IL_0115:
											break;
										}
										break;
									}
								}
							}
							finally
							{
								if (pdvratWBuExgULHQUZUruzxWsgi2 != null)
								{
									while (true)
									{
										IL_0185:
										int num3 = 1448649242;
										while (true)
										{
											switch (num3 ^ 0x5658A21B)
											{
											case 2:
												break;
											default:
												goto end_IL_018a;
											case 1:
												goto IL_01a3;
											case 0:
												goto end_IL_018a;
											}
											goto IL_0185;
											IL_01a3:
											((IDisposable)pdvratWBuExgULHQUZUruzxWsgi2).Dispose();
											num3 = 1448649243;
											continue;
											end_IL_018a:
											break;
										}
										break;
									}
								}
							}
							string text2 = text + "_controllerMaps";
							using (PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi3 = new PdvratWBuExgULHQUZUruzxWsgi("Controller Maps", text2, P_2))
							{
								if (pdvratWBuExgULHQUZUruzxWsgi3.SpZKjJhMWylOpfghINSctstbjVX)
								{
									while (true)
									{
										IL_01d9:
										int num4 = 1448649242;
										while (true)
										{
											switch (num4 ^ 0x5658A21B)
											{
											case 0:
												break;
											case 1:
												goto IL_01f7;
											default:
											{
												using (PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi4 = new PdvratWBuExgULHQUZUruzxWsgi("Joysticks (" + P_0.controllers.joystickCount + ")", text3, P_2))
												{
													if (pdvratWBuExgULHQUZUruzxWsgi4.SpZKjJhMWylOpfghINSctstbjVX)
													{
														while (true)
														{
															IL_0293:
															int num5 = 1448649241;
															while (true)
															{
																switch (num5 ^ 0x5658A21B)
																{
																case 0:
																	break;
																default:
																	goto end_IL_0298;
																case 6:
																{
																	int num7;
																	if (num6 < P_0.controllers.joystickCount)
																	{
																		num5 = 1448649244;
																		num7 = num5;
																	}
																	else
																	{
																		num5 = 1448649242;
																		num7 = num5;
																	}
																	continue;
																}
																case 5:
																	text3 = text3 + "_joystickId" + joystick.id;
																	num5 = 1448649240;
																	continue;
																case 2:
																	num6 = 0;
																	num5 = 1448649247;
																	continue;
																case 4:
																	num5 = 1448649245;
																	continue;
																case 3:
																	xjfnCwdkzNSmGNvOtuSZenujxpF(ControllerType.Joystick, maps, (joystick.name != "Unknown Controller") ? joystick.name : joystick.hardwareName, P_2, text3);
																	num6++;
																	num5 = 1448649245;
																	continue;
																case 7:
																	joystick = P_0.controllers.Joysticks[num6];
																	maps = P_0.controllers.maps.GetMaps<JoystickMap>(joystick.id);
																	num5 = 1448649246;
																	continue;
																case 1:
																	goto end_IL_0298;
																}
																goto IL_0293;
																continue;
																end_IL_0298:
																break;
															}
															break;
														}
													}
												}
												text3 = text2 + "_customControllerMaps";
												using (PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi5 = new PdvratWBuExgULHQUZUruzxWsgi("Custom Controllers (" + P_0.controllers.customControllerCount + ")", text3, P_2))
												{
													if (!pdvratWBuExgULHQUZUruzxWsgi5.SpZKjJhMWylOpfghINSctstbjVX)
													{
														goto end_IL_01de;
													}
													int num8 = 0;
													while (true)
													{
														IL_0490:
														int num9;
														int num10;
														if (num8 < P_0.controllers.customControllerCount)
														{
															num9 = 1448649247;
															num10 = num9;
														}
														else
														{
															num9 = 1448649242;
															num10 = num9;
														}
														while (true)
														{
															switch (num9 ^ 0x5658A21B)
															{
															case 3:
																num9 = 1448649247;
																continue;
															default:
																goto end_IL_03f0;
															case 0:
																num8++;
																num9 = 1448649246;
																continue;
															case 2:
																xjfnCwdkzNSmGNvOtuSZenujxpF(ControllerType.Custom, maps2, customController.name, P_2, text3);
																num9 = 1448649243;
																continue;
															case 4:
																customController = P_0.controllers.CustomControllers[num8];
																maps2 = P_0.controllers.maps.GetMaps<CustomControllerMap>(customController.id);
																text3 = text3 + "_customControllerId" + customController.id;
																num9 = 1448649241;
																continue;
															case 5:
																break;
															case 1:
																goto end_IL_03f0;
															}
															goto IL_0490;
															continue;
															end_IL_03f0:
															break;
														}
														break;
													}
												}
												goto end_IL_01de;
											}
											}
											goto IL_01d9;
											IL_01f7:
											xjfnCwdkzNSmGNvOtuSZenujxpF(ControllerType.Keyboard, P_0.controllers.maps.GetMaps<KeyboardMap>(0), "Keyboard Maps", P_2, text2 + "_keyboard");
											xjfnCwdkzNSmGNvOtuSZenujxpF(ControllerType.Mouse, P_0.controllers.maps.GetMaps<MouseMap>(0), "Mouse Maps", P_2, text2 + "_mouse");
											text3 = text2 + "_joystickMaps";
											num4 = 1448649241;
											continue;
											end_IL_01de:
											break;
										}
										break;
									}
								}
							}
							text2 = text + "_controllerMapLayoutManager";
							using (PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi6 = new PdvratWBuExgULHQUZUruzxWsgi("Layout Manager", text2, P_2))
							{
								if (pdvratWBuExgULHQUZUruzxWsgi6.SpZKjJhMWylOpfghINSctstbjVX)
								{
									CBOPaVKYjXNOeuKddPDrJPJmavu(P_0.controllers.maps.layoutManager, P_2, text2);
								}
							}
							text2 = text + "_controllerMapEnabler";
							PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi7 = new PdvratWBuExgULHQUZUruzxWsgi("Map Enabler", text2, P_2);
							try
							{
								if (pdvratWBuExgULHQUZUruzxWsgi7.SpZKjJhMWylOpfghINSctstbjVX)
								{
									RtZfkekPRDPceZvSgACkrHhXFXfE(P_0.controllers.maps.mapEnabler, P_2, text2);
								}
							}
							finally
							{
								if (pdvratWBuExgULHQUZUruzxWsgi7 != null)
								{
									while (true)
									{
										IL_055d:
										int num11 = 1448649242;
										while (true)
										{
											switch (num11 ^ 0x5658A21B)
											{
											case 0:
												break;
											default:
												goto end_IL_0562;
											case 1:
												goto IL_057b;
											case 2:
												goto end_IL_0562;
											}
											goto IL_055d;
											IL_057b:
											((IDisposable)pdvratWBuExgULHQUZUruzxWsgi7).Dispose();
											num11 = 1448649241;
											continue;
											end_IL_0562:
											break;
										}
										break;
									}
								}
							}
							text2 = text + "_inputBehaviors";
							qmgtrNvshnJbwoIskPBGMOMMazg(P_0.controllers.maps.InputBehaviors, P_2, text2);
							text2 = text + "_actions";
							List<InputAction> list = new List<InputAction>(ReInput.mapping.Actions);
							list.Sort((InputAction inputAction2, InputAction inputAction3) => inputAction2.name.CompareTo(inputAction3.name));
							IList<InputCategory> actionCategories = ReInput.mapping.ActionCategories;
							PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi8 = new PdvratWBuExgULHQUZUruzxWsgi("Actions (" + list.Count + ")", text2, P_2);
							try
							{
								if (!pdvratWBuExgULHQUZUruzxWsgi8.SpZKjJhMWylOpfghINSctstbjVX)
								{
									return;
								}
								while (true)
								{
									int num12 = 1448649246;
									while (true)
									{
										int num19;
										switch (num12 ^ 0x5658A21B)
										{
										case 3:
											break;
										case 6:
											array = new object[7] { "id ", null, null, null, null, null, null };
											num12 = 1448649242;
											continue;
										case 7:
											array[6] = ")";
											num12 = 1448649235;
											continue;
										case 4:
											num20 = ListTools.Count(list, iRevELGEXfjBGdpbokXhxqSdIdb2.veNGHTCsiRRFnQiOTtpnqouLOMg);
											num12 = 1448649245;
											continue;
										case 5:
											num18 = 0;
											num12 = 1448649241;
											continue;
										case 0:
											iRevELGEXfjBGdpbokXhxqSdIdb2 = new iRevELGEXfjBGdpbokXhxqSdIdb();
											iRevELGEXfjBGdpbokXhxqSdIdb2.HAKEPohyMmXooUcPgNOSxLBIAxZ = actionCategories[num18];
											text4 = text2 + "_actionCat" + iRevELGEXfjBGdpbokXhxqSdIdb2.HAKEPohyMmXooUcPgNOSxLBIAxZ.id;
											num12 = 1448649247;
											continue;
										case 1:
											array[1] = iRevELGEXfjBGdpbokXhxqSdIdb2.HAKEPohyMmXooUcPgNOSxLBIAxZ.id;
											array[2] = ": ";
											array[3] = iRevELGEXfjBGdpbokXhxqSdIdb2.HAKEPohyMmXooUcPgNOSxLBIAxZ.name;
											array[4] = " (";
											array[5] = num20;
											num12 = 1448649244;
											continue;
										default:
										{
											using (PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi9 = new PdvratWBuExgULHQUZUruzxWsgi(string.Concat(array), text4, P_2))
											{
												if (pdvratWBuExgULHQUZUruzxWsgi9.SpZKjJhMWylOpfghINSctstbjVX)
												{
													int num13 = 0;
													while (true)
													{
														if (num13 < list.Count)
														{
															while (true)
															{
																InputAction inputAction = list[num13];
																int num14 = 1448649242;
																while (true)
																{
																	switch (num14 ^ 0x5658A21B)
																	{
																	case 3:
																		num14 = 1448649241;
																		continue;
																	case 0:
																		array2[0] = "id ";
																		array2[1] = inputAction.id;
																		array2[2] = ": ";
																		num14 = 1448649246;
																		continue;
																	case 5:
																		array2[3] = inputAction.name;
																		array2[4] = ": ";
																		array2[5] = P_0.GetAxis(inputAction.id).ToString("f3");
																		num14 = 1448649247;
																		continue;
																	case 2:
																		break;
																	case 1:
																		goto IL_0821;
																	default:
																		goto IL_0865;
																	}
																	break;
																	IL_0865:
																	PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi10 = new PdvratWBuExgULHQUZUruzxWsgi(string.Concat(array2), key, P_2);
																	try
																	{
																		if (pdvratWBuExgULHQUZUruzxWsgi10.SpZKjJhMWylOpfghINSctstbjVX)
																		{
																			YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Axis Value", P_0.GetAxis(inputAction.id).ToString());
																			YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Axis Raw Value", P_0.GetAxisRaw(inputAction.id).ToString());
																			while (true)
																			{
																				IL_08c2:
																				int num15 = 1448649241;
																				while (true)
																				{
																					switch (num15 ^ 0x5658A21B)
																					{
																					case 0:
																						break;
																					default:
																						goto end_IL_08c7;
																					case 5:
																						YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Negative Button Repeating Value", P_0.GetNegativeButtonRepeating(inputAction.id).ToString());
																						num15 = 1448649242;
																						continue;
																					case 3:
																						YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Button Repeating Value", P_0.GetButtonRepeating(inputAction.id).ToString());
																						YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Negative Button Value", P_0.GetNegativeButton(inputAction.id).ToString());
																						num15 = 1448649247;
																						continue;
																					case 4:
																						YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Negative Button Double Press Value", P_0.GetNegativeButtonDoublePressHold(inputAction.id).ToString());
																						YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Negative Button Short Press Value", P_0.GetNegativeButtonShortPress(inputAction.id).ToString());
																						YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Negative Button Long Press Value", P_0.GetNegativeButtonLongPress(inputAction.id).ToString());
																						num15 = 1448649246;
																						continue;
																					case 2:
																						YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Button Value", P_0.GetButton(inputAction.id).ToString());
																						YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Button Double Press Value", P_0.GetButtonDoublePressHold(inputAction.id).ToString());
																						YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Button Short Press Value", P_0.GetButtonShortPress(inputAction.id).ToString());
																						YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Button Long Press Value", P_0.GetButtonLongPress(inputAction.id).ToString());
																						num15 = 1448649240;
																						continue;
																					case 1:
																						goto end_IL_08c7;
																					}
																					goto IL_08c2;
																					continue;
																					end_IL_08c7:
																					break;
																				}
																				break;
																			}
																		}
																	}
																	finally
																	{
																		if (pdvratWBuExgULHQUZUruzxWsgi10 != null)
																		{
																			while (true)
																			{
																				IL_0a5a:
																				int num16 = 1448649241;
																				while (true)
																				{
																					switch (num16 ^ 0x5658A21B)
																					{
																					case 0:
																						break;
																					default:
																						goto end_IL_0a5f;
																					case 2:
																						goto IL_0a78;
																					case 1:
																						goto end_IL_0a5f;
																					}
																					goto IL_0a5a;
																					IL_0a78:
																					((IDisposable)pdvratWBuExgULHQUZUruzxWsgi10).Dispose();
																					num16 = 1448649242;
																					continue;
																					end_IL_0a5f:
																					break;
																				}
																				break;
																			}
																		}
																	}
																	goto IL_0a87;
																	IL_0821:
																	if (inputAction.categoryId == iRevELGEXfjBGdpbokXhxqSdIdb2.HAKEPohyMmXooUcPgNOSxLBIAxZ.id)
																	{
																		key = text4 + "_actionId" + inputAction.id;
																		array2 = new object[6];
																		num14 = 1448649243;
																		continue;
																	}
																	goto IL_0a87;
																	IL_0a87:
																	num13++;
																	goto end_IL_080c;
																}
																continue;
																end_IL_080c:
																break;
															}
															goto IL_0a8d;
														}
														int num17 = 1448649243;
														goto IL_0a92;
														IL_0a8d:
														num17 = 1448649242;
														goto IL_0a92;
														IL_0a92:
														switch (num17 ^ 0x5658A21B)
														{
														case 2:
															break;
														default:
															goto end_IL_0aab;
														case 1:
															continue;
														case 0:
															goto end_IL_0aab;
														}
														goto IL_0a8d;
														continue;
														end_IL_0aab:
														break;
													}
												}
											}
											num18++;
											goto IL_0ad4;
										}
										case 2:
											goto IL_0af2;
											IL_0ad4:
											num19 = 1448649241;
											goto IL_0ad9;
											IL_0ad9:
											switch (num19 ^ 0x5658A21B)
											{
											case 0:
												break;
											default:
												return;
											case 2:
												goto IL_0af2;
											case 1:
												return;
											}
											goto IL_0ad4;
											IL_0af2:
											if (num18 < actionCategories.Count)
											{
												goto case 0;
											}
											num19 = 1448649242;
											goto IL_0ad9;
										}
										break;
									}
								}
							}
							finally
							{
								if (pdvratWBuExgULHQUZUruzxWsgi8 != null)
								{
									while (true)
									{
										IL_0b0d:
										int num21 = 1448649242;
										while (true)
										{
											switch (num21 ^ 0x5658A21B)
											{
											case 2:
												break;
											default:
												goto end_IL_0b12;
											case 1:
												goto IL_0b2b;
											case 0:
												goto end_IL_0b12;
											}
											goto IL_0b0d;
											IL_0b2b:
											((IDisposable)pdvratWBuExgULHQUZUruzxWsgi8).Dispose();
											num21 = 1448649243;
											continue;
											end_IL_0b12:
											break;
										}
										break;
									}
								}
							}
						}
						}
						break;
						IL_0056:
						num = 1448649242;
					}
				}
			}
		}

		private static void qmgtrNvshnJbwoIskPBGMOMMazg(IList<InputBehavior> P_0, IDictionary<string, bool> P_1, string P_2)
		{
			int num = ((P_0 != null) ? P_0.Count : 0);
			using (PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi = new PdvratWBuExgULHQUZUruzxWsgi("Input Behaviors (" + num + ")", P_2 + "_inputBehaviors", P_1))
			{
				if (!pdvratWBuExgULHQUZUruzxWsgi.SpZKjJhMWylOpfghINSctstbjVX)
				{
					return;
				}
				while (true)
				{
					int num2 = 0;
					int num3 = 787945137;
					while (true)
					{
						switch (num3 ^ 0x2EF716B3)
						{
						case 0:
							num3 = 787945136;
							continue;
						case 3:
							break;
						case 1:
						{
							InputBehavior inputBehavior = P_0[num2];
							avfZPTbRPCbCzOfwdEpFAkZbTBr(inputBehavior, num2, P_1, P_2);
							num2++;
							num3 = 787945137;
							continue;
						}
						default:
							if (num2 >= num)
							{
								return;
							}
							goto case 1;
						}
						break;
					}
				}
			}
		}

		private static void avfZPTbRPCbCzOfwdEpFAkZbTBr(InputBehavior P_0, int P_1, IDictionary<string, bool> P_2, string P_3)
		{
			string key = P_3 + "_inputBehavior" + P_0.id;
			using (PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi = new PdvratWBuExgULHQUZUruzxWsgi(P_1 + ": " + P_0.name, key, P_2))
			{
				if (!pdvratWBuExgULHQUZUruzxWsgi.SpZKjJhMWylOpfghINSctstbjVX)
				{
					return;
				}
				while (true)
				{
					YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Id", P_0.id.ToString());
					YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Name", P_0.name);
					YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Digital Axis Gravity", P_0.digitalAxisGravity.ToString());
					YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Digital Axis Instant Reverse", P_0.digitalAxisInstantReverse.ToString());
					YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Digital Axis Sensitivity", P_0.digitalAxisSensitivity.ToString());
					YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Digital Axis Snap", P_0.digitalAxisSnap.ToString());
					int num = 120935217;
					while (true)
					{
						switch (num ^ 0x7355333)
						{
						case 3:
							num = 120935222;
							continue;
						case 5:
							break;
						case 0:
							YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Button Short Press Time", P_0.buttonShortPressTime.ToString());
							YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Button Short Press Expires In", P_0.buttonShortPressExpiresIn.ToString());
							num = 120935218;
							continue;
						case 4:
							YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Button Dead Zone", P_0.buttonDeadZone.ToString());
							YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Button Double Press Speed", P_0.buttonDoublePressSpeed.ToString());
							num = 120935219;
							continue;
						case 2:
							YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Joystick Axis Sensitivity", P_0.joystickAxisSensitivity.ToString());
							YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Custom Controller Axis Sensitivity", P_0.customControllerAxisSensitivity.ToString());
							YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Mouse XY Axis Mode", P_0.mouseXYAxisMode.ToString());
							YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Mouse XY Axis Sensitivity", P_0.mouseXYAxisSensitivity.ToString());
							YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Mouse XY Axis Delta Calc", P_0.mouseXYAxisDeltaCalc.ToString());
							YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Mouse Other Axis Mode", P_0.mouseOtherAxisMode.ToString());
							YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Mouse Other Axis Sensitivity", P_0.mouseOtherAxisSensitivity.ToString());
							num = 120935223;
							continue;
						default:
							YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Button Long Press Time", P_0.buttonLongPressTime.ToString());
							YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Button Long Press Expires In", P_0.buttonLongPressExpiresIn.ToString());
							YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Button Down Buffer", P_0.buttonDownBuffer.ToString());
							return;
						}
						break;
					}
				}
			}
		}

		private static void ftNPEXXPbkHYMHIJpPBBkZJJFwG(Controller P_0, IDictionary<string, bool> P_1, string P_2)
		{
			using (PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi = new PdvratWBuExgULHQUZUruzxWsgi("Element Identifiers", P_2 + "_elementIdentifiers", P_1))
			{
				if (!pdvratWBuExgULHQUZUruzxWsgi.SpZKjJhMWylOpfghINSctstbjVX)
				{
					return;
				}
				int num2 = default(int);
				if (P_0 is ControllerWithAxes)
				{
					ControllerWithAxes controllerWithAxes = default(ControllerWithAxes);
					while (true)
					{
						int num = 654689687;
						while (true)
						{
							switch (num ^ 0x2705C596)
							{
							case 2:
								break;
							case 1:
								controllerWithAxes = P_0 as ControllerWithAxes;
								num2 = ((controllerWithAxes.AxisElementIdentifiers != null) ? controllerWithAxes.AxisElementIdentifiers.Count : 0);
								num = 654689686;
								continue;
							default:
								goto end_IL_002d;
							}
							break;
						}
						continue;
						end_IL_002d:
						break;
					}
					using (PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi2 = new PdvratWBuExgULHQUZUruzxWsgi("Axis Element Identifiers (" + num2 + ")", P_2 + "_axisEIs", P_1))
					{
						if (pdvratWBuExgULHQUZUruzxWsgi2.SpZKjJhMWylOpfghINSctstbjVX)
						{
							int num3 = 0;
							ControllerElementIdentifier controllerElementIdentifier = default(ControllerElementIdentifier);
							object[] array = default(object[]);
							while (true)
							{
								IL_00a5:
								int num4 = 654689687;
								while (true)
								{
									int num5;
									switch (num4 ^ 0x2705C596)
									{
									case 2:
										break;
									case 5:
										controllerElementIdentifier = controllerWithAxes.AxisElementIdentifiers[num3];
										num4 = 654689682;
										continue;
									case 0:
										array[1] = ": ";
										array[2] = controllerElementIdentifier.name;
										array[3] = " (id: ";
										array[4] = controllerElementIdentifier.id;
										num4 = 654689685;
										continue;
									case 4:
										array = new object[6] { num3, null, null, null, null, null };
										num4 = 654689686;
										continue;
									default:
									{
										array[5] = ")";
										using (PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi3 = new PdvratWBuExgULHQUZUruzxWsgi(string.Concat(array), P_2 + "_AxisEI" + num3 + "_" + controllerElementIdentifier.name, P_1))
										{
											if (pdvratWBuExgULHQUZUruzxWsgi3.SpZKjJhMWylOpfghINSctstbjVX)
											{
												YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Id", controllerElementIdentifier.id.ToString());
												YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Name", controllerElementIdentifier.name);
											}
										}
										num3++;
										goto IL_01e0;
									}
									case 1:
										goto IL_01fe;
										IL_01e0:
										num5 = 654689687;
										goto IL_01e5;
										IL_01e5:
										switch (num5 ^ 0x2705C596)
										{
										case 2:
											break;
										default:
											goto end_IL_00aa;
										case 1:
											goto IL_01fe;
										case 0:
											goto end_IL_00aa;
										}
										goto IL_01e0;
										IL_01fe:
										if (num3 < num2)
										{
											goto case 5;
										}
										num5 = 654689686;
										goto IL_01e5;
									}
									goto IL_00a5;
									continue;
									end_IL_00aa:
									break;
								}
								break;
							}
						}
					}
				}
				if (P_0 == null)
				{
					return;
				}
				num2 = ((P_0.ButtonElementIdentifiers != null) ? P_0.ButtonElementIdentifiers.Count : 0);
				PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi4 = new PdvratWBuExgULHQUZUruzxWsgi("Button Element Identifiers (" + num2 + ")", P_2 + "_buttonEIs", P_1);
				try
				{
					if (!pdvratWBuExgULHQUZUruzxWsgi4.SpZKjJhMWylOpfghINSctstbjVX)
					{
						return;
					}
					int num6 = 0;
					while (true)
					{
						if (num6 < num2)
						{
							ControllerElementIdentifier controllerElementIdentifier2;
							object[] array2;
							while (true)
							{
								controllerElementIdentifier2 = P_0.ButtonElementIdentifiers[num6];
								array2 = new object[6];
								int num7 = 654689687;
								while (true)
								{
									switch (num7 ^ 0x2705C596)
									{
									case 4:
										num7 = 654689685;
										continue;
									case 3:
										break;
									case 1:
										array2[0] = num6;
										array2[1] = ": ";
										array2[2] = controllerElementIdentifier2.name;
										num7 = 654689684;
										continue;
									case 2:
										array2[3] = " (id: ";
										array2[4] = controllerElementIdentifier2.id;
										num7 = 654689686;
										continue;
									default:
										goto end_IL_029d;
									}
									break;
								}
								continue;
								end_IL_029d:
								break;
							}
							array2[5] = ")";
							using (PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi5 = new PdvratWBuExgULHQUZUruzxWsgi(string.Concat(array2), P_2 + "_ButtonEI" + num6 + "_" + controllerElementIdentifier2.name, P_1))
							{
								if (pdvratWBuExgULHQUZUruzxWsgi5.SpZKjJhMWylOpfghINSctstbjVX)
								{
									while (true)
									{
										IL_0382:
										YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Id", controllerElementIdentifier2.id.ToString());
										YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Name", controllerElementIdentifier2.name);
										int num8 = 654689684;
										while (true)
										{
											switch (num8 ^ 0x2705C596)
											{
											case 0:
												goto IL_0364;
											default:
												goto end_IL_0369;
											case 1:
												break;
											case 2:
												goto end_IL_0369;
											}
											goto IL_0382;
											IL_0364:
											num8 = 654689687;
											continue;
											end_IL_0369:
											break;
										}
										break;
									}
								}
							}
							num6++;
							goto IL_03c8;
						}
						int num9 = 654689687;
						goto IL_03cd;
						IL_03c8:
						num9 = 654689684;
						goto IL_03cd;
						IL_03cd:
						switch (num9 ^ 0x2705C596)
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
						goto IL_03c8;
					}
				}
				finally
				{
					if (pdvratWBuExgULHQUZUruzxWsgi4 != null)
					{
						while (true)
						{
							IL_03fb:
							int num10 = 654689687;
							while (true)
							{
								switch (num10 ^ 0x2705C596)
								{
								case 0:
									break;
								default:
									goto end_IL_0400;
								case 1:
									goto IL_0419;
								case 2:
									goto end_IL_0400;
								}
								goto IL_03fb;
								IL_0419:
								((IDisposable)pdvratWBuExgULHQUZUruzxWsgi4).Dispose();
								num10 = 654689684;
								continue;
								end_IL_0400:
								break;
							}
							break;
						}
					}
				}
			}
		}

		private static void ZHFfildjfFpPAxiLTdkLEywAgtu(IList<Controller.Button> P_0, ControllerType P_1, IDictionary<string, bool> P_2, string P_3)
		{
			string text = ((P_1 == ControllerType.Keyboard) ? "Key" : "Button");
			int num = ((P_0 != null) ? P_0.Count : 0);
			PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi = new PdvratWBuExgULHQUZUruzxWsgi(text + "s (" + num + ")", P_3 + "_Buttons", P_2);
			try
			{
				if (!pdvratWBuExgULHQUZUruzxWsgi.SpZKjJhMWylOpfghINSctstbjVX)
				{
					return;
				}
				object[] array = default(object[]);
				Controller.Button button = default(Controller.Button);
				while (true)
				{
					int num2 = 0;
					int num3 = -2118030293;
					while (true)
					{
						switch (num3 ^ -2118030295)
						{
						case 5:
							num3 = -2118030289;
							continue;
						case 6:
							break;
						case 3:
							array[1] = ": ";
							array[2] = ((P_1 == ControllerType.Keyboard) ? Keyboard.GetKeyboardKeyCodeByButtonIndex(num2).ToString() : button.elementIdentifier.name);
							array[3] = ": ";
							array[4] = (button.value ? "Pressed" : "");
							num3 = -2118030291;
							continue;
						case 0:
							button = P_0[num2];
							num3 = -2118030296;
							continue;
						case 1:
							array = new object[8] { num2, null, null, null, null, null, null, null };
							num3 = -2118030294;
							continue;
						default:
						{
							array[5] = " (";
							array[6] = button.pressure.ToString("f3");
							array[7] = ")";
							using (PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi2 = new PdvratWBuExgULHQUZUruzxWsgi(string.Concat(array), P_3 + "_" + button.name, P_2))
							{
								if (pdvratWBuExgULHQUZUruzxWsgi2.SpZKjJhMWylOpfghINSctstbjVX)
								{
									while (true)
									{
										IL_02b7:
										YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Is Member Element", button.isMemberElement.ToString());
										int num4 = -2118030292;
										while (true)
										{
											switch (num4 ^ -2118030295)
											{
											case 0:
												num4 = -2118030289;
												continue;
											default:
												goto end_IL_019d;
											case 3:
												YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Time Unpressed", button.timeUnpressed.ToString());
												YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Last Time Pressed", button.lastTimePressed.ToString());
												YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Last Time Unpressed", button.lastTimeUnpressed.ToString());
												num4 = -2118030293;
												continue;
											case 5:
												YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Is Pressure Sensitive", button.isPressureSensitive.ToString());
												YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Value", button.value.ToString());
												YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Value Prev", button.valuePrev.ToString());
												YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Pressure", button.pressure.ToString());
												num4 = -2118030296;
												continue;
											case 1:
												YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Pressure Prev", button.pressurePrev.ToString());
												num4 = -2118030291;
												continue;
											case 6:
												break;
											case 4:
												YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Just Pressed", button.justPressed.ToString());
												YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Just Released", button.justReleased.ToString());
												YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Just Double Pressed", button.justDoublePressed.ToString());
												YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Double Pressed And Held", button.doublePressedAndHeld.ToString());
												YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Time Pressed", button.timePressed.ToString());
												num4 = -2118030294;
												continue;
											case 2:
												goto end_IL_019d;
											}
											goto IL_02b7;
											continue;
											end_IL_019d:
											break;
										}
										break;
									}
								}
							}
							num2++;
							goto case 2;
						}
						case 2:
							if (num2 >= num)
							{
								return;
							}
							goto case 0;
						}
						break;
					}
				}
			}
			finally
			{
				if (pdvratWBuExgULHQUZUruzxWsgi != null)
				{
					while (true)
					{
						IL_0385:
						int num5 = -2118030293;
						while (true)
						{
							switch (num5 ^ -2118030295)
							{
							case 0:
								break;
							default:
								goto end_IL_038a;
							case 2:
								goto IL_03a3;
							case 1:
								goto end_IL_038a;
							}
							goto IL_0385;
							IL_03a3:
							((IDisposable)pdvratWBuExgULHQUZUruzxWsgi).Dispose();
							num5 = -2118030296;
							continue;
							end_IL_038a:
							break;
						}
						break;
					}
				}
			}
		}

		private static void FflrVUtBcBEQxAgDrhEUgdakmXie(IList<Controller.Axis> P_0, IDictionary<string, bool> P_1, string P_2)
		{
			int num = ((P_0 != null) ? P_0.Count : 0);
			using (PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi = new PdvratWBuExgULHQUZUruzxWsgi("Axes (" + num + ")", P_2 + "_Axes", P_1))
			{
				if (!pdvratWBuExgULHQUZUruzxWsgi.SpZKjJhMWylOpfghINSctstbjVX)
				{
					return;
				}
				for (int i = 0; i < num; i++)
				{
					Controller.Axis axis = P_0[i];
					using (PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi2 = new PdvratWBuExgULHQUZUruzxWsgi(i + ": " + axis.elementIdentifier.name + ": " + axis.value.ToString("f3") + " (" + axis.valueRaw.ToString("f3") + ")", P_2 + "_" + axis.name, P_1))
					{
						if (!pdvratWBuExgULHQUZUruzxWsgi2.SpZKjJhMWylOpfghINSctstbjVX)
						{
							continue;
						}
						while (true)
						{
							IL_0141:
							YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Is Member Element", axis.isMemberElement.ToString());
							YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Value", axis.value.ToString());
							YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Value Raw", axis.valueRaw.ToString());
							YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Value Prev", axis.valuePrev.ToString());
							YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Value Raw Prev", axis.valueRawPrev.ToString());
							int num2 = 1687814870;
							while (true)
							{
								switch (num2 ^ 0x649A02D6)
								{
								case 3:
									num2 = 1687814871;
									continue;
								case 1:
									break;
								case 2:
									YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Time Active Raw", axis.timeActiveRaw.ToString());
									YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Time Inactive", axis.timeInactive.ToString());
									YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Time Inactive Raw", axis.timeInactiveRaw.ToString());
									num2 = 1687814866;
									continue;
								case 0:
									YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Value Delta", axis.valueDelta.ToString());
									YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Value Delta Raw", axis.valueDeltaRaw.ToString());
									YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Time Active", axis.timeActive.ToString());
									num2 = 1687814868;
									continue;
								default:
									YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Last Time Active", axis.lastTimeActive.ToString());
									YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Last Time Active Raw", axis.lastTimeActiveRaw.ToString());
									YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Last Time Inactive", axis.lastTimeInactive.ToString());
									YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Last Time Inactive Raw", axis.lastTimeInactiveRaw.ToString());
									goto end_IL_011d;
								}
								goto IL_0141;
								continue;
								end_IL_011d:
								break;
							}
							break;
						}
					}
				}
			}
		}

		private static void xjfnCwdkzNSmGNvOtuSZenujxpF<T>(ControllerType P_0, IList<T> P_1, string P_2, IDictionary<string, bool> P_3, string P_4) where T : ControllerMap
		{
			string text = P_4 + "_controllerMaps";
			int num = ((P_1 != null) ? P_1.Count : 0);
			object[] array = default(object[]);
			InputLayout layout = default(InputLayout);
			string text4 = default(string);
			string text3 = default(string);
			while (true)
			{
				int num2 = -523912736;
				while (true)
				{
					switch (num2 ^ -523912733)
					{
					case 0:
						break;
					case 3:
						array = new object[4] { P_2, null, null, null };
						num2 = -523912735;
						continue;
					case 2:
						array[1] = " (";
						array[2] = num;
						array[3] = ")";
						num2 = -523912734;
						continue;
					default:
					{
						PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi = new PdvratWBuExgULHQUZUruzxWsgi(string.Concat(array), text, P_3);
						try
						{
							if (!pdvratWBuExgULHQUZUruzxWsgi.SpZKjJhMWylOpfghINSctstbjVX)
							{
								return;
							}
							while (true)
							{
								int num3 = 0;
								while (true)
								{
									if (num3 >= num)
									{
										return;
									}
									string text2;
									while (true)
									{
										IL_012d:
										T val = P_1[num3];
										text2 = (val.enabled ? "Enabled" : "Disabled");
										int num4 = -523912733;
										while (true)
										{
											switch (num4 ^ -523912733)
											{
											case 3:
												num4 = -523912735;
												continue;
											case 2:
												break;
											case 0:
											{
												ReInput.MappingHelper mapping = ReInput.mapping;
												T val2 = P_1[num3];
												InputMapCategory mapCategory = mapping.GetMapCategory(val2.categoryId);
												ReInput.MappingHelper mapping2 = ReInput.mapping;
												T val3 = P_1[num3];
												layout = mapping2.GetLayout(P_0, val3.layoutId);
												text4 = ((mapCategory != null) ? mapCategory.name : "n/a");
												num4 = -523912729;
												continue;
											}
											case 1:
												goto IL_012d;
											case 4:
												text3 = ((layout != null) ? layout.name : "n/a");
												num4 = -523912730;
												continue;
											default:
												goto IL_017b;
											}
											break;
										}
										break;
									}
									break;
									IL_017b:
									using (PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi2 = new PdvratWBuExgULHQUZUruzxWsgi(num3 + ": " + text4 + ", " + text3 + ": " + text2, P_4 + "_index" + num3, P_3))
									{
										if (pdvratWBuExgULHQUZUruzxWsgi2.SpZKjJhMWylOpfghINSctstbjVX)
										{
											while (true)
											{
												IL_020f:
												int num5;
												if (P_1[num3] is ControllerMapWithAxes)
												{
													uCXPPelmUOSRBIQEarUsiycaiYs(P_1[num3] as ControllerMapWithAxes, P_3, text + num3);
													num5 = -523912734;
													goto IL_01ee;
												}
												goto IL_0253;
												IL_01ee:
												while (true)
												{
													switch (num5 ^ -523912733)
													{
													case 3:
														num5 = -523912729;
														continue;
													case 4:
														goto IL_020f;
													case 1:
														num5 = -523912735;
														continue;
													case 0:
														goto IL_0253;
													case 2:
														break;
													}
													break;
												}
												break;
												IL_0253:
												uCXPPelmUOSRBIQEarUsiycaiYs(P_1[num3], P_3, text);
												num5 = -523912735;
												goto IL_01ee;
											}
										}
									}
									num3++;
								}
							}
						}
						finally
						{
							if (pdvratWBuExgULHQUZUruzxWsgi != null)
							{
								while (true)
								{
									IL_028b:
									int num6 = -523912735;
									while (true)
									{
										switch (num6 ^ -523912733)
										{
										case 0:
											break;
										default:
											goto end_IL_0290;
										case 2:
											goto IL_02a9;
										case 1:
											goto end_IL_0290;
										}
										goto IL_028b;
										IL_02a9:
										((IDisposable)pdvratWBuExgULHQUZUruzxWsgi).Dispose();
										num6 = -523912734;
										continue;
										end_IL_0290:
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

		private static void uCXPPelmUOSRBIQEarUsiycaiYs(ControllerMap P_0, IDictionary<string, bool> P_1, string P_2)
		{
			YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Id (unique id)", P_0.id.ToString());
			YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Source Map Id", P_0.sourceMapId.ToString());
			YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Enabled", P_0.enabled.ToString());
			string text = default(string);
			int layoutId = default(int);
			int num6 = default(int);
			while (true)
			{
				int num = 1561723827;
				while (true)
				{
					switch (num ^ 0x5D1603B2)
					{
					case 0:
						break;
					case 2:
						YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Controller Id", P_0.controllerId.ToString());
						num = 1561723825;
						continue;
					case 5:
					{
						int num8;
						if (P_0.controllerType == ControllerType.Custom)
						{
							num = 1561723824;
							num8 = num;
						}
						else
						{
							num = 1561723825;
							num8 = num;
						}
						continue;
					}
					case 1:
					{
						YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Controller Type", P_0.controllerType.ToString());
						int num9;
						if (P_0.controllerType != ControllerType.Joystick)
						{
							num = 1561723831;
							num9 = num;
						}
						else
						{
							num = 1561723824;
							num9 = num;
						}
						continue;
					}
					case 3:
						text = P_0.categoryId.ToString();
						num = 1561723830;
						continue;
					default:
						if (P_0.categoryId >= 0)
						{
							try
							{
								InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(P_0.categoryId);
								if (mapCategory != null)
								{
									text = text + " (" + mapCategory.name + ")";
								}
							}
							catch
							{
							}
						}
						YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Category Id", text);
						while (true)
						{
							int num2 = 1561723827;
							while (true)
							{
								switch (num2 ^ 0x5D1603B2)
								{
								case 2:
									break;
								case 1:
									goto IL_0166;
								default:
								{
									string text2 = layoutId.ToString();
									if (P_0.layoutId >= 0)
									{
										try
										{
											InputLayout layout = ReInput.mapping.GetLayout(P_0.controllerType, P_0.layoutId);
											while (true)
											{
												IL_019d:
												int num3 = 1561723824;
												while (true)
												{
													switch (num3 ^ 0x5D1603B2)
													{
													case 0:
														break;
													default:
														goto end_IL_01a2;
													case 2:
													{
														int num4;
														if (layout == null)
														{
															num3 = 1561723825;
															num4 = num3;
														}
														else
														{
															num3 = 1561723827;
															num4 = num3;
														}
														continue;
													}
													case 1:
														text2 = text2 + " (" + layout.name + ")";
														num3 = 1561723825;
														continue;
													case 3:
														goto end_IL_01a2;
													}
													goto IL_019d;
													continue;
													end_IL_01a2:
													break;
												}
												break;
											}
										}
										catch
										{
										}
									}
									YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Layout Id", text2);
									int buttonMapCount = P_0.buttonMapCount;
									string text3 = P_2 + "_buttonMaps";
									using (PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi = new PdvratWBuExgULHQUZUruzxWsgi("Button Maps (" + buttonMapCount + ")", text3, P_1))
									{
										if (!pdvratWBuExgULHQUZUruzxWsgi.SpZKjJhMWylOpfghINSctstbjVX)
										{
											return;
										}
										while (true)
										{
											int num5 = 1561723830;
											while (true)
											{
												switch (num5 ^ 0x5D1603B2)
												{
												case 0:
													break;
												default:
													return;
												case 4:
													num6 = 0;
													num5 = 1561723825;
													continue;
												case 2:
													nEbKjEtDxBzOcEjLbproCxNlVPY(P_0.controllerType, P_0.ButtonMaps[num6], num6, P_1, text3 + num6);
													num6++;
													num5 = 1561723825;
													continue;
												case 3:
												{
													int num7;
													if (num6 < buttonMapCount)
													{
														num5 = 1561723824;
														num7 = num5;
													}
													else
													{
														num5 = 1561723827;
														num7 = num5;
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
								}
								}
								break;
								IL_0166:
								layoutId = P_0.layoutId;
								num2 = 1561723826;
							}
						}
					}
					break;
				}
			}
		}

		private static void uCXPPelmUOSRBIQEarUsiycaiYs(ControllerMapWithAxes P_0, IDictionary<string, bool> P_1, string P_2)
		{
			uCXPPelmUOSRBIQEarUsiycaiYs((ControllerMap)P_0, P_1, P_2);
			string text = P_2 + "_axisMaps";
			int axisMapCount = P_0.axisMapCount;
			using (PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi = new PdvratWBuExgULHQUZUruzxWsgi("Axis Maps (" + axisMapCount + ")", text, P_1))
			{
				if (!pdvratWBuExgULHQUZUruzxWsgi.SpZKjJhMWylOpfghINSctstbjVX)
				{
					return;
				}
				while (true)
				{
					int num = 0;
					int num2 = 499245532;
					while (true)
					{
						switch (num2 ^ 0x1DC1E1D8)
						{
						case 0:
							num2 = 499245529;
							continue;
						default:
							return;
						case 4:
						{
							int num3;
							if (num >= axisMapCount)
							{
								num2 = 499245530;
								num3 = num2;
							}
							else
							{
								num2 = 499245531;
								num3 = num2;
							}
							continue;
						}
						case 3:
							nEbKjEtDxBzOcEjLbproCxNlVPY(P_0.controllerType, P_0.AxisMaps[num], num, P_1, text + num);
							num++;
							num2 = 499245532;
							continue;
						case 1:
							break;
						case 2:
							return;
						}
						break;
					}
				}
			}
		}

		private static void nEbKjEtDxBzOcEjLbproCxNlVPY(ControllerType P_0, ActionElementMap P_1, int P_2, IDictionary<string, bool> P_3, string P_4)
		{
			string text = "Action Element Map";
			InputAction action = default(InputAction);
			string text3 = default(string);
			while (true)
			{
				int num = -261464616;
				while (true)
				{
					switch (num ^ -261464613)
					{
					case 2:
						break;
					case 3:
						action = ReInput.mapping.GetAction(P_1.actionId);
						text3 = ((action != null) ? action.name : string.Empty);
						num = -261464613;
						continue;
					case 0:
					{
						string text2 = jVZvOpeiERGUnDOyivGdgmDlRrTQ(P_1);
						if (!string.IsNullOrEmpty(text2))
						{
							text = P_1.elementIdentifierName + " (" + text2 + ")";
							num = -261464614;
							continue;
						}
						goto default;
					}
					default:
					{
						PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi = new PdvratWBuExgULHQUZUruzxWsgi(P_2 + ": " + text, P_4 + "_" + P_2, P_3);
						try
						{
							if (!pdvratWBuExgULHQUZUruzxWsgi.SpZKjJhMWylOpfghINSctstbjVX)
							{
								return;
							}
							while (true)
							{
								YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Id (unique id)", P_1.id.ToString());
								YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Enabled", P_1.enabled.ToString());
								YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Element Type", P_1.elementType.ToString());
								int num2 = -261464611;
								while (true)
								{
									switch (num2 ^ -261464613)
									{
									case 5:
										num2 = -261464615;
										continue;
									case 2:
										break;
									case 8:
									{
										int num4;
										if (P_0 == ControllerType.Keyboard)
										{
											num2 = -261464614;
											num4 = num2;
										}
										else
										{
											num2 = -261464616;
											num4 = num2;
										}
										continue;
									}
									case 4:
										YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Has Modifiers", P_1.hasModifiers.ToString());
										YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Modifier Key 1", P_1.modifierKey1.ToString());
										YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Modifier Key 2", P_1.modifierKey2.ToString());
										YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Modifier Key 3", P_1.modifierKey3.ToString());
										num2 = -261464616;
										continue;
									case 7:
										YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Element Index", P_1.elementIndex.ToString());
										num2 = -261464621;
										continue;
									case 1:
										YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Key Code", P_1.keyCode.ToString());
										num2 = -261464613;
										continue;
									case 6:
										YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Action Id", P_1.actionId + " " + ((action != null) ? ("(" + text3 + ")") : ""));
										YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Element Identifier Id", P_1.elementIdentifierId.ToString());
										YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Element Identifier Name", P_1.elementIdentifierName);
										if (P_1.elementType == ControllerElementType.Axis)
										{
											YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Element Index", P_1.elementIndex.ToString());
											YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Axis Range", P_1.axisRange.ToString());
											YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Axis Type", P_1.axisType.ToString());
											YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Invert", P_1.invert.ToString());
											num2 = -261464616;
											continue;
										}
										goto case 9;
									case 9:
									{
										int num3;
										if (P_1.elementType != ControllerElementType.Button)
										{
											num2 = -261464616;
											num3 = num2;
										}
										else
										{
											num2 = -261464612;
											num3 = num2;
										}
										continue;
									}
									case 0:
										YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Keyboard Key Code", P_1.keyboardKeyCode.ToString());
										num2 = -261464609;
										continue;
									default:
										YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Axis Contribution", P_1.axisContribution.ToString());
										return;
									}
									break;
								}
							}
						}
						finally
						{
							if (pdvratWBuExgULHQUZUruzxWsgi != null)
							{
								while (true)
								{
									IL_035d:
									int num5 = -261464614;
									while (true)
									{
										switch (num5 ^ -261464613)
										{
										case 0:
											break;
										default:
											goto end_IL_0362;
										case 1:
											goto IL_037b;
										case 2:
											goto end_IL_0362;
										}
										goto IL_035d;
										IL_037b:
										((IDisposable)pdvratWBuExgULHQUZUruzxWsgi).Dispose();
										num5 = -261464615;
										continue;
										end_IL_0362:
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

		private static string jVZvOpeiERGUnDOyivGdgmDlRrTQ(ActionElementMap P_0)
		{
			InputAction action = ReInput.mapping.GetAction(P_0.actionId);
			if (action == null)
			{
				return string.Empty;
			}
			string text = string.Empty;
			if (P_0.elementType == ControllerElementType.Button)
			{
				goto IL_007d;
			}
			if (P_0.elementType == ControllerElementType.Axis && P_0.axisType == AxisType.Split)
			{
				goto IL_0040;
			}
			goto IL_00e2;
			IL_0190:
			return text;
			IL_00e2:
			int num;
			if (P_0.elementType == ControllerElementType.Axis && P_0.axisType == AxisType.Normal)
			{
				text = ((!string.IsNullOrEmpty(action.descriptiveName)) ? action.descriptiveName : action.name);
				num = -898263209;
				goto IL_0045;
			}
			goto IL_0190;
			IL_007d:
			if (P_0.axisContribution == Pole.Positive)
			{
				text = action.positiveDescriptiveName;
				num = -898263211;
				goto IL_0045;
			}
			goto IL_0163;
			IL_0040:
			num = -898263213;
			goto IL_0045;
			IL_0045:
			while (true)
			{
				string text2;
				switch (num ^ -898263215)
				{
				case 0:
					break;
				case 2:
					goto IL_007d;
				case 1:
					num = -898263209;
					continue;
				case 4:
					if (string.IsNullOrEmpty(text))
					{
						text = ((!string.IsNullOrEmpty(action.descriptiveName)) ? (action.descriptiveName + " +") : (action.name + " +"));
						num = -898263216;
						continue;
					}
					goto IL_0190;
				case 3:
					goto IL_00e2;
				case 9:
					text2 = action.name + " -";
					goto IL_0141;
				case 8:
					if (!string.IsNullOrEmpty(action.descriptiveName))
					{
						text2 = action.descriptiveName + " -";
						goto IL_0141;
					}
					num = -898263208;
					continue;
				case 5:
					goto IL_0163;
				case 7:
					goto IL_0174;
				default:
					goto IL_0190;
					IL_0141:
					text = text2;
					num = -898263209;
					continue;
				}
				break;
				IL_0174:
				int num2;
				if (!string.IsNullOrEmpty(text))
				{
					num = -898263209;
					num2 = num;
				}
				else
				{
					num = -898263207;
					num2 = num;
				}
			}
			goto IL_0040;
			IL_0163:
			text = action.negativeDescriptiveName;
			num = -898263210;
			goto IL_0045;
		}

		private static void CBOPaVKYjXNOeuKddPDrJPJmavu(ControllerMapLayoutManager P_0, IDictionary<string, bool> P_1, string P_2)
		{
			if (btyRilkCemQDQYvUxrdobnXUCSU("Enabled", P_0.enabled))
			{
				goto IL_0012;
			}
			goto IL_004a;
			IL_0012:
			int num = -1680449441;
			goto IL_0017;
			IL_0017:
			int num3 = default(int);
			while (true)
			{
				switch (num ^ -1680449443)
				{
				case 3:
					break;
				case 2:
					P_0.enabled = !P_0.enabled;
					num = -1680449444;
					continue;
				case 1:
					goto IL_004a;
				default:
				{
					string text = P_2 + "_ruleSets";
					int count = P_0.ruleSets.Count;
					using (PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi = new PdvratWBuExgULHQUZUruzxWsgi("Rule Sets (" + count + ")", text, P_1))
					{
						if (!pdvratWBuExgULHQUZUruzxWsgi.SpZKjJhMWylOpfghINSctstbjVX)
						{
							return;
						}
						while (true)
						{
							int num2 = -1680449444;
							while (true)
							{
								switch (num2 ^ -1680449443)
								{
								case 5:
									break;
								default:
									return;
								case 1:
									num3 = 0;
									num2 = -1680449442;
									continue;
								case 0:
									WFEenqRGnWcSjSHkkenAcqOpyrs(P_0.ruleSets[num3], num3, P_1, text + num3);
									num3++;
									num2 = -1680449447;
									continue;
								case 4:
								{
									int num4;
									if (num3 < count)
									{
										num2 = -1680449443;
										num4 = num2;
									}
									else
									{
										num2 = -1680449441;
										num4 = num2;
									}
									continue;
								}
								case 3:
									num2 = -1680449447;
									continue;
								case 2:
									return;
								}
								break;
							}
						}
					}
				}
				}
				break;
			}
			goto IL_0012;
			IL_004a:
			YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Load from User Data Store", P_0.loadFromUserDataStore.ToString());
			num = -1680449443;
			goto IL_0017;
		}

		private static void WFEenqRGnWcSjSHkkenAcqOpyrs(ControllerMapLayoutManager.RuleSet P_0, int P_1, IDictionary<string, bool> P_2, string P_3)
		{
			int num = ((P_0 != null) ? P_0.Count : 0);
			using (PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi = new PdvratWBuExgULHQUZUruzxWsgi(P_1 + ": " + ((!string.IsNullOrEmpty(P_0.tag)) ? (P_0.tag + ", ") : "") + (P_0.enabled ? "Enabled" : "Disabled"), P_3, P_2))
			{
				if (!pdvratWBuExgULHQUZUruzxWsgi.SpZKjJhMWylOpfghINSctstbjVX)
				{
					return;
				}
				string text = default(string);
				int[] categoryIds = default(int[]);
				int num9 = default(int);
				string text3 = default(string);
				InputMapCategory mapCategory = default(InputMapCategory);
				object[] array = default(object[]);
				while (true)
				{
					int num2;
					int num3;
					if (!btyRilkCemQDQYvUxrdobnXUCSU("Enabled", P_0.enabled))
					{
						num2 = 1476593292;
						num3 = num2;
					}
					else
					{
						num2 = 1476593294;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ 0x5803068D)
						{
						case 0:
							num2 = 1476593288;
							continue;
						case 2:
							text = P_3 + "_rules";
							num2 = 1476593289;
							continue;
						case 3:
							P_0.enabled = !P_0.enabled;
							num2 = 1476593292;
							continue;
						case 1:
							YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Tag", P_0.tag);
							num2 = 1476593295;
							continue;
						case 5:
							break;
						default:
						{
							PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi2 = new PdvratWBuExgULHQUZUruzxWsgi("Rules (" + P_0.Count + ")", text, P_2);
							try
							{
								if (!pdvratWBuExgULHQUZUruzxWsgi2.SpZKjJhMWylOpfghINSctstbjVX)
								{
									return;
								}
								int num4 = 0;
								while (true)
								{
									if (num4 < num)
									{
										ControllerMapLayoutManager.Rule rule = P_0[num4];
										string text2 = text + num4;
										PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi3 = new PdvratWBuExgULHQUZUruzxWsgi(num4 + ": " + ((!string.IsNullOrEmpty(rule.tag)) ? rule.tag : ""), text2, P_2);
										try
										{
											if (pdvratWBuExgULHQUZUruzxWsgi3.SpZKjJhMWylOpfghINSctstbjVX)
											{
												while (true)
												{
													IL_01a5:
													int num5 = 1476593292;
													while (true)
													{
														int num6;
														int num7;
														InputLayout layout;
														switch (num5 ^ 0x5803068D)
														{
														case 3:
															break;
														case 1:
															YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Tag", rule.tag);
															num5 = 1476593295;
															continue;
														case 2:
															QCdcePrhQJwrQFgltNiwczAjzFI(rule.controllerSetSelector, P_2, text2);
															categoryIds = rule.categoryIds;
															num5 = 1476593289;
															continue;
														case 4:
															if (categoryIds == null)
															{
																num5 = 1476593293;
																continue;
															}
															num6 = categoryIds.Length;
															goto IL_0214;
														default:
															{
																num6 = 0;
																goto IL_0214;
															}
															IL_0214:
															num7 = num6;
															using (PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi4 = new PdvratWBuExgULHQUZUruzxWsgi("Map Categories (" + num7 + ")", text2 + "_categoryIds", P_2))
															{
																if (pdvratWBuExgULHQUZUruzxWsgi4.SpZKjJhMWylOpfghINSctstbjVX)
																{
																	while (true)
																	{
																		IL_024c:
																		int num8 = 1476593289;
																		while (true)
																		{
																			object obj;
																			switch (num8 ^ 0x5803068D)
																			{
																			case 8:
																				break;
																			default:
																				goto end_IL_0251;
																			case 7:
																			{
																				int num10;
																				if (num9 < categoryIds.Length)
																				{
																					num8 = 1476593292;
																					num10 = num8;
																				}
																				else
																				{
																					num8 = 1476593291;
																					num10 = num8;
																				}
																				continue;
																			}
																			case 0:
																				num9 = 0;
																				num8 = 1476593294;
																				continue;
																			case 9:
																				YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Category " + num9, text3);
																				num9++;
																				num8 = 1476593290;
																				continue;
																			case 1:
																				mapCategory = ReInput.mapping.GetMapCategory(categoryIds[num9]);
																				if (mapCategory == null)
																				{
																					obj = "[INVALID]";
																					goto IL_035a;
																				}
																				array = new object[4] { mapCategory.name, null, null, null };
																				num8 = 1476593295;
																				continue;
																			case 4:
																				if (num7 == 0)
																				{
																					YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Category", "All Map Categories");
																					num8 = 1476593291;
																					continue;
																				}
																				goto case 0;
																			case 2:
																				array[1] = " (";
																				array[2] = mapCategory.id;
																				num8 = 1476593288;
																				continue;
																			case 5:
																				array[3] = ")";
																				obj = string.Concat(array);
																				goto IL_035a;
																			case 3:
																				num8 = 1476593290;
																				continue;
																			case 6:
																				goto end_IL_0251;
																				IL_035a:
																				text3 = (string)obj;
																				num8 = 1476593284;
																				continue;
																			}
																			goto IL_024c;
																			continue;
																			end_IL_0251:
																			break;
																		}
																		break;
																	}
																}
															}
															layout = ReInput.mapping.GetLayout(rule.controllerSetSelector.controllerType, rule.layoutId);
															YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI(rule.controllerSetSelector.controllerType.ToString() + " Layout", (layout != null) ? (layout.name + " (" + layout.id + ")") : "[INVALID]");
															goto end_IL_01aa;
														}
														goto IL_01a5;
														continue;
														end_IL_01aa:
														break;
													}
													break;
												}
											}
										}
										finally
										{
											if (pdvratWBuExgULHQUZUruzxWsgi3 != null)
											{
												while (true)
												{
													IL_040f:
													int num11 = 1476593292;
													while (true)
													{
														switch (num11 ^ 0x5803068D)
														{
														case 0:
															break;
														default:
															goto end_IL_0414;
														case 1:
															goto IL_042d;
														case 2:
															goto end_IL_0414;
														}
														goto IL_040f;
														IL_042d:
														((IDisposable)pdvratWBuExgULHQUZUruzxWsgi3).Dispose();
														num11 = 1476593295;
														continue;
														end_IL_0414:
														break;
													}
													break;
												}
											}
										}
										num4++;
										goto IL_0442;
									}
									int num12 = 1476593293;
									goto IL_0447;
									IL_0447:
									switch (num12 ^ 0x5803068D)
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
									goto IL_0442;
									IL_0442:
									num12 = 1476593292;
									goto IL_0447;
								}
							}
							finally
							{
								if (pdvratWBuExgULHQUZUruzxWsgi2 != null)
								{
									while (true)
									{
										IL_0474:
										int num13 = 1476593295;
										while (true)
										{
											switch (num13 ^ 0x5803068D)
											{
											case 0:
												break;
											default:
												goto end_IL_0479;
											case 2:
												goto IL_0492;
											case 1:
												goto end_IL_0479;
											}
											goto IL_0474;
											IL_0492:
											((IDisposable)pdvratWBuExgULHQUZUruzxWsgi2).Dispose();
											num13 = 1476593292;
											continue;
											end_IL_0479:
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
		}

		private static void RtZfkekPRDPceZvSgACkrHhXFXfE(ControllerMapEnabler P_0, IDictionary<string, bool> P_1, string P_2)
		{
			if (btyRilkCemQDQYvUxrdobnXUCSU("Enabled", P_0.enabled))
			{
				P_0.enabled = !P_0.enabled;
				goto IL_0021;
			}
			goto IL_003f;
			IL_003f:
			string text = P_2 + "_ruleSets";
			int count = P_0.ruleSets.Count;
			int num = 2058869944;
			goto IL_0026;
			IL_0021:
			num = 2058869947;
			goto IL_0026;
			IL_0026:
			switch (num ^ 0x7AB7DCBA)
			{
			case 0:
				break;
			case 1:
				goto IL_003f;
			default:
			{
				using (PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi = new PdvratWBuExgULHQUZUruzxWsgi("Rule Sets (" + count + ")", text, P_1))
				{
					if (!pdvratWBuExgULHQUZUruzxWsgi.SpZKjJhMWylOpfghINSctstbjVX)
					{
						return;
					}
					int num3 = default(int);
					while (true)
					{
						int num2 = 2058869947;
						while (true)
						{
							switch (num2 ^ 0x7AB7DCBA)
							{
							case 0:
								break;
							default:
								return;
							case 1:
								num3 = 0;
								num2 = 2058869950;
								continue;
							case 4:
							{
								int num4;
								if (num3 >= count)
								{
									num2 = 2058869944;
									num4 = num2;
								}
								else
								{
									num2 = 2058869945;
									num4 = num2;
								}
								continue;
							}
							case 3:
								zyjDIXohrwoCxPPIJfRIrIhWNmv(P_0.ruleSets[num3], num3, P_1, text + num3);
								num3++;
								num2 = 2058869950;
								continue;
							case 2:
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

		private static void zyjDIXohrwoCxPPIJfRIrIhWNmv(ControllerMapEnabler.RuleSet P_0, int P_1, IDictionary<string, bool> P_2, string P_3)
		{
			int num = ((P_0 != null) ? P_0.Count : 0);
			object[] array = default(object[]);
			string text2 = default(string);
			int[] categoryIds = default(int[]);
			object[] array2 = default(object[]);
			InputMapCategory mapCategory = default(InputMapCategory);
			InputLayout layout = default(InputLayout);
			int num15 = default(int);
			object[] array3 = default(object[]);
			string text4 = default(string);
			while (true)
			{
				int num2 = 907927194;
				while (true)
				{
					switch (num2 ^ 0x361DDE9B)
					{
					case 2:
						break;
					case 1:
						array = new object[4]
						{
							P_1,
							": ",
							(!string.IsNullOrEmpty(P_0.tag)) ? (P_0.tag + ", ") : "",
							null
						};
						num2 = 907927195;
						continue;
					case 0:
						array[3] = (P_0.enabled ? "Enabled" : "Disabled");
						num2 = 907927192;
						continue;
					default:
					{
						using (PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi = new PdvratWBuExgULHQUZUruzxWsgi(string.Concat(array), P_3, P_2))
						{
							if (!pdvratWBuExgULHQUZUruzxWsgi.SpZKjJhMWylOpfghINSctstbjVX)
							{
								return;
							}
							while (true)
							{
								int num3;
								int num4;
								if (btyRilkCemQDQYvUxrdobnXUCSU("Enabled", P_0.enabled))
								{
									num3 = 907927192;
									num4 = num3;
								}
								else
								{
									num3 = 907927193;
									num4 = num3;
								}
								while (true)
								{
									switch (num3 ^ 0x361DDE9B)
									{
									case 0:
										num3 = 907927194;
										continue;
									case 1:
										break;
									case 3:
										P_0.enabled = !P_0.enabled;
										num3 = 907927193;
										continue;
									default:
									{
										YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Tag", P_0.tag);
										string text = P_3 + "_rules";
										PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi2 = new PdvratWBuExgULHQUZUruzxWsgi("Rules (" + P_0.Count + ")", text, P_2);
										try
										{
											if (!pdvratWBuExgULHQUZUruzxWsgi2.SpZKjJhMWylOpfghINSctstbjVX)
											{
												return;
											}
											int num5 = 0;
											while (true)
											{
												if (num5 < num)
												{
													ControllerMapEnabler.Rule rule;
													while (true)
													{
														rule = P_0[num5];
														int num6 = 907927192;
														while (true)
														{
															switch (num6 ^ 0x361DDE9B)
															{
															case 0:
																num6 = 907927193;
																continue;
															case 2:
																break;
															case 3:
																text2 = text + num5;
																num6 = 907927194;
																continue;
															default:
																goto end_IL_0185;
															}
															break;
														}
														continue;
														end_IL_0185:
														break;
													}
													using (PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi3 = new PdvratWBuExgULHQUZUruzxWsgi(num5 + ": " + ((!string.IsNullOrEmpty(rule.tag)) ? rule.tag : ""), text2, P_2))
													{
														if (pdvratWBuExgULHQUZUruzxWsgi3.SpZKjJhMWylOpfghINSctstbjVX)
														{
															if (btyRilkCemQDQYvUxrdobnXUCSU("Enable", rule.enable))
															{
																rule.enable = !rule.enable;
																goto IL_0213;
															}
															goto IL_0235;
														}
														goto end_IL_01e3;
														IL_0218:
														int num7;
														while (true)
														{
															int num8;
															int num9;
															int[] layoutIds;
															int num13;
															switch (num7 ^ 0x361DDE9B)
															{
															case 0:
																break;
															case 3:
																goto IL_0235;
															case 2:
																categoryIds = rule.categoryIds;
																if (categoryIds == null)
																{
																	num7 = 907927194;
																	continue;
																}
																num8 = categoryIds.Length;
																goto IL_0277;
															default:
																{
																	num8 = 0;
																	goto IL_0277;
																}
																IL_0277:
																num9 = num8;
																using (PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi4 = new PdvratWBuExgULHQUZUruzxWsgi("Map Categories (" + num9 + ")", text2 + "_categoryIds", P_2))
																{
																	if (pdvratWBuExgULHQUZUruzxWsgi4.SpZKjJhMWylOpfghINSctstbjVX)
																	{
																		if (num9 == 0)
																		{
																			YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Category", "All Map Categories");
																		}
																		else
																		{
																			while (true)
																			{
																				IL_0363:
																				int num10 = 0;
																				int num11 = 907927193;
																				while (true)
																				{
																					object obj;
																					string text3;
																					switch (num11 ^ 0x361DDE9B)
																					{
																					case 4:
																						num11 = 907927194;
																						continue;
																					default:
																						goto end_IL_02cf;
																					case 6:
																					{
																						int num12;
																						if (num10 >= categoryIds.Length)
																						{
																							num11 = 907927196;
																							num12 = num11;
																						}
																						else
																						{
																							num11 = 907927187;
																							num12 = num11;
																						}
																						continue;
																					}
																					case 2:
																						num11 = 907927197;
																						continue;
																					case 0:
																						array2[0] = mapCategory.name;
																						num11 = 907927192;
																						continue;
																					case 8:
																						mapCategory = ReInput.mapping.GetMapCategory(categoryIds[num10]);
																						if (mapCategory == null)
																						{
																							obj = "[INVALID]";
																							goto IL_0380;
																						}
																						array2 = new object[4];
																						num11 = 907927195;
																						continue;
																					case 1:
																						break;
																					case 5:
																						array2[3] = ")";
																						obj = string.Concat(array2);
																						goto IL_0380;
																					case 3:
																						array2[1] = " (";
																						array2[2] = mapCategory.id;
																						num11 = 907927198;
																						continue;
																					case 7:
																						goto end_IL_02cf;
																						IL_0380:
																						text3 = (string)obj;
																						YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Category " + num10, text3);
																						num10++;
																						num11 = 907927197;
																						continue;
																					}
																					goto IL_0363;
																					continue;
																					end_IL_02cf:
																					break;
																				}
																				break;
																			}
																		}
																	}
																}
																layoutIds = rule.layoutIds;
																num13 = ((layoutIds != null) ? layoutIds.Length : 0);
																using (PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi5 = new PdvratWBuExgULHQUZUruzxWsgi("Layouts (" + num13 + ")", text2 + "_layoutIds", P_2))
																{
																	if (pdvratWBuExgULHQUZUruzxWsgi5.SpZKjJhMWylOpfghINSctstbjVX)
																	{
																		while (true)
																		{
																			IL_0427:
																			int num14 = 907927199;
																			while (true)
																			{
																				object obj2;
																				switch (num14 ^ 0x361DDE9B)
																				{
																				case 10:
																					break;
																				default:
																					goto end_IL_042c;
																				case 2:
																					layout = ReInput.mapping.GetLayout(rule.controllerSetSelector.controllerType, layoutIds[num15]);
																					if (layout == null)
																					{
																						obj2 = "[INVALID]";
																						goto IL_0562;
																					}
																					array3 = new object[4];
																					num14 = 907927187;
																					continue;
																				case 7:
																				{
																					int num16;
																					if (num15 >= layoutIds.Length)
																					{
																						num14 = 907927195;
																						num16 = num14;
																					}
																					else
																					{
																						num14 = 907927193;
																						num16 = num14;
																					}
																					continue;
																				}
																				case 3:
																					num15 = 0;
																					num14 = 907927196;
																					continue;
																				case 4:
																					if (num13 == 0)
																					{
																						YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Layout", (rule.controllerSetSelector.type == ControllerSetSelector.Type.All) ? "All Layouts" : string.Concat("All ", rule.controllerSetSelector.controllerType, " Layouts"));
																						num14 = 907927197;
																						continue;
																					}
																					goto case 3;
																				case 1:
																					YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI(string.Concat(rule.controllerSetSelector.controllerType, " Layout ", num15.ToString()), text4);
																					num15++;
																					num14 = 907927196;
																					continue;
																				case 6:
																					num14 = 907927195;
																					continue;
																				case 9:
																					obj2 = string.Concat(array3);
																					goto IL_0562;
																				case 5:
																					array3[2] = layout.id;
																					array3[3] = ")";
																					num14 = 907927186;
																					continue;
																				case 8:
																					array3[0] = layout.name;
																					array3[1] = " (";
																					num14 = 907927198;
																					continue;
																				case 0:
																					goto end_IL_042c;
																					IL_0562:
																					text4 = (string)obj2;
																					num14 = 907927194;
																					continue;
																				}
																				goto IL_0427;
																				continue;
																				end_IL_042c:
																				break;
																			}
																			break;
																		}
																	}
																}
																goto end_IL_01e3;
															}
															break;
														}
														goto IL_0213;
														IL_0235:
														YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Tag", rule.tag);
														QCdcePrhQJwrQFgltNiwczAjzFI(rule.controllerSetSelector, P_2, text2);
														num7 = 907927193;
														goto IL_0218;
														IL_0213:
														num7 = 907927192;
														goto IL_0218;
														end_IL_01e3:;
													}
													num5++;
													goto IL_05d1;
												}
												int num17 = 907927194;
												goto IL_05d6;
												IL_05d1:
												num17 = 907927193;
												goto IL_05d6;
												IL_05d6:
												switch (num17 ^ 0x361DDE9B)
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
												goto IL_05d1;
											}
										}
										finally
										{
											if (pdvratWBuExgULHQUZUruzxWsgi2 != null)
											{
												while (true)
												{
													IL_0603:
													int num18 = 907927194;
													while (true)
													{
														switch (num18 ^ 0x361DDE9B)
														{
														case 2:
															break;
														default:
															goto end_IL_0608;
														case 1:
															goto IL_0621;
														case 0:
															goto end_IL_0608;
														}
														goto IL_0603;
														IL_0621:
														((IDisposable)pdvratWBuExgULHQUZUruzxWsgi2).Dispose();
														num18 = 907927195;
														continue;
														end_IL_0608:
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
					}
					}
					break;
				}
			}
		}

		private static void QCdcePrhQJwrQFgltNiwczAjzFI(ControllerSetSelector P_0, IDictionary<string, bool> P_1, string P_2)
		{
			string key = P_2 + "_controllerSetSelector";
			PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi = new PdvratWBuExgULHQUZUruzxWsgi("Controller Set Selector", key, P_1);
			try
			{
				if (pdvratWBuExgULHQUZUruzxWsgi.SpZKjJhMWylOpfghINSctstbjVX)
				{
					YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Type", StringTools.AddSpacesToSentence(P_0.type.ToString(), false));
					if (P_0.type != ControllerSetSelector.Type.All)
					{
						YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Controller Type", P_0.controllerType.ToString());
						goto IL_0066;
					}
					goto IL_0097;
				}
				return;
				IL_012d:
				int num;
				if (P_0.type == ControllerSetSelector.Type.ControllerTemplateType)
				{
					YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Controller Template Type Guid", P_0.controllerTemplateTypeGuid.ToString());
					num = 2103373629;
					goto IL_006b;
				}
				goto IL_00d8;
				IL_00d8:
				if (P_0.type == ControllerSetSelector.Type.PersistentControllerInstance)
				{
					YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Device Instance Guid", P_0.deviceInstanceGuid.ToString());
					num = 2103373625;
					goto IL_006b;
				}
				goto IL_015e;
				IL_0066:
				num = 2103373628;
				goto IL_006b;
				IL_006b:
				while (true)
				{
					switch (num ^ 0x7D5EEF3D)
					{
					case 3:
						break;
					default:
						return;
					case 1:
						goto IL_0097;
					case 0:
						goto IL_00d8;
					case 6:
						YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Controller Id", P_0.controllerId.ToString());
						num = 2103373631;
						continue;
					case 5:
						goto IL_012d;
					case 4:
						goto IL_015e;
					case 2:
						return;
					}
					break;
				}
				goto IL_0066;
				IL_0097:
				if (P_0.type == ControllerSetSelector.Type.HardwareType)
				{
					YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Hardware Type Guid", P_0.hardwareTypeGuid.ToString());
					YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Hardware Identifier", P_0.hardwareIdentifier);
					num = 2103373624;
					goto IL_006b;
				}
				goto IL_012d;
				IL_015e:
				int num2;
				if (P_0.type == ControllerSetSelector.Type.SessionControllerInstance)
				{
					num = 2103373627;
					num2 = num;
				}
				else
				{
					num = 2103373631;
					num2 = num;
				}
				goto IL_006b;
			}
			finally
			{
				if (pdvratWBuExgULHQUZUruzxWsgi != null)
				{
					while (true)
					{
						IL_0180:
						int num3 = 2103373628;
						while (true)
						{
							switch (num3 ^ 0x7D5EEF3D)
							{
							case 2:
								break;
							default:
								goto end_IL_0185;
							case 1:
								goto IL_019e;
							case 0:
								goto end_IL_0185;
							}
							goto IL_0180;
							IL_019e:
							((IDisposable)pdvratWBuExgULHQUZUruzxWsgi).Dispose();
							num3 = 2103373629;
							continue;
							end_IL_0185:
							break;
						}
						break;
					}
				}
			}
		}

		private static void GngwrrgmLCFumJUTkbBytgMcRGT(Controller P_0, IDictionary<string, bool> P_1, string P_2)
		{
			P_2 += "_templates";
			using (PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi = new PdvratWBuExgULHQUZUruzxWsgi("Templates (" + P_0.templateCount + ")", P_2, P_1))
			{
				if (!pdvratWBuExgULHQUZUruzxWsgi.SpZKjJhMWylOpfghINSctstbjVX)
				{
					return;
				}
				int num = 0;
				while (true)
				{
					int num2 = -467322884;
					while (true)
					{
						switch (num2 ^ -467322881)
						{
						case 4:
							break;
						default:
							return;
						case 1:
						{
							int num3;
							if (num >= P_0.templateCount)
							{
								num2 = -467322883;
								num3 = num2;
							}
							else
							{
								num2 = -467322881;
								num3 = num2;
							}
							continue;
						}
						case 0:
							SyiqEKRaLmQOMbqqNUXsQUbxGPW(P_0.Templates[num], num, P_2, P_1);
							num++;
							num2 = -467322882;
							continue;
						case 3:
							num2 = -467322882;
							continue;
						case 2:
							return;
						}
						break;
					}
				}
			}
		}

		private static void SyiqEKRaLmQOMbqqNUXsQUbxGPW(IControllerTemplate P_0, int P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 += ((P_1 >= 0) ? ("_" + P_1) : "");
			while (true)
			{
				int num = -681455202;
				while (true)
				{
					object obj;
					PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi;
					switch (num ^ -681455201)
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
						pdvratWBuExgULHQUZUruzxWsgi = new PdvratWBuExgULHQUZUruzxWsgi((string)obj + P_0.name, P_2, P_3);
						try
						{
							if (!pdvratWBuExgULHQUZUruzxWsgi.SpZKjJhMWylOpfghINSctstbjVX)
							{
								return;
							}
							YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Type GUID", P_0.typeGuid.ToString());
							YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Class Type", P_0.GetType().ToString());
							P_2 += "_elements";
							PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi2 = new PdvratWBuExgULHQUZUruzxWsgi("Elements (" + P_0.elementCount + ")", P_2, P_3);
							try
							{
								if (!pdvratWBuExgULHQUZUruzxWsgi2.SpZKjJhMWylOpfghINSctstbjVX)
								{
									return;
								}
								int num2 = 0;
								while (true)
								{
									int num3;
									int num4;
									if (num2 >= P_0.elementCount)
									{
										num3 = -681455204;
										num4 = num3;
									}
									else
									{
										num3 = -681455202;
										num4 = num3;
									}
									while (true)
									{
										switch (num3 ^ -681455201)
										{
										case 0:
											num3 = -681455202;
											continue;
										default:
											return;
										case 1:
											ZoocpACLuoZyzoLlzcgKDJsOMxby(P_0.elements[num2], num2, P_2, P_3);
											num2++;
											num3 = -681455203;
											continue;
										case 2:
											break;
										case 3:
											return;
										}
										break;
									}
								}
							}
							finally
							{
								if (pdvratWBuExgULHQUZUruzxWsgi2 != null)
								{
									while (true)
									{
										IL_0150:
										int num5 = -681455203;
										while (true)
										{
											switch (num5 ^ -681455201)
											{
											case 0:
												break;
											default:
												goto end_IL_0155;
											case 2:
												goto IL_016e;
											case 1:
												goto end_IL_0155;
											}
											goto IL_0150;
											IL_016e:
											((IDisposable)pdvratWBuExgULHQUZUruzxWsgi2).Dispose();
											num5 = -681455202;
											continue;
											end_IL_0155:
											break;
										}
										break;
									}
								}
							}
						}
						finally
						{
							if (pdvratWBuExgULHQUZUruzxWsgi != null)
							{
								while (true)
								{
									IL_0181:
									int num6 = -681455202;
									while (true)
									{
										switch (num6 ^ -681455201)
										{
										case 0:
											break;
										default:
											goto end_IL_0186;
										case 1:
											goto IL_019f;
										case 2:
											goto end_IL_0186;
										}
										goto IL_0181;
										IL_019f:
										((IDisposable)pdvratWBuExgULHQUZUruzxWsgi).Dispose();
										num6 = -681455203;
										continue;
										end_IL_0186:
										break;
									}
									break;
								}
							}
						}
					}
					break;
					IL_0046:
					num = -681455203;
				}
			}
		}

		private static void ZoocpACLuoZyzoLlzcgKDJsOMxby(IControllerTemplateElement P_0, int P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 += ((P_1 >= 0) ? ("_" + P_1) : "");
			object[] array = new object[5]
			{
				(P_1 >= 0) ? ": " : "",
				P_0.descriptiveName,
				" (id: ",
				P_0.id,
				null
			};
			IControllerTemplateStick controllerTemplateStick = default(IControllerTemplateStick);
			IControllerTemplateThrottle controllerTemplateThrottle = default(IControllerTemplateThrottle);
			IControllerTemplateButton controllerTemplateButton = default(IControllerTemplateButton);
			IControllerTemplateThumbStick controllerTemplateThumbStick = default(IControllerTemplateThumbStick);
			IControllerTemplateYoke controllerTemplateYoke = default(IControllerTemplateYoke);
			IControllerTemplateStick6D controllerTemplateStick6D = default(IControllerTemplateStick6D);
			IControllerTemplateHat controllerTemplateHat = default(IControllerTemplateHat);
			IControllerTemplateDPad controllerTemplateDPad = default(IControllerTemplateDPad);
			while (true)
			{
				int num = -1348839524;
				while (true)
				{
					switch (num ^ -1348839523)
					{
					case 2:
						break;
					case 1:
						goto IL_0080;
					default:
					{
						using (PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi = new PdvratWBuExgULHQUZUruzxWsgi(string.Concat(array), P_2, P_3))
						{
							if (!pdvratWBuExgULHQUZUruzxWsgi.SpZKjJhMWylOpfghINSctstbjVX)
							{
								return;
							}
							YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Id", P_0.id.ToString());
							YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Name", P_0.descriptiveName.ToString());
							while (true)
							{
								int num2 = -1348839551;
								while (true)
								{
									switch (num2 ^ -1348839523)
									{
									case 23:
										break;
									default:
										return;
									case 27:
										if (P_0.type == ControllerTemplateElementType.Stick)
										{
											controllerTemplateStick = P_0 as IControllerTemplateStick;
											YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Value", controllerTemplateStick.value.ToString());
											num2 = -1348839528;
											continue;
										}
										goto case 8;
									case 8:
										if (P_0.type == ControllerTemplateElementType.Throttle)
										{
											controllerTemplateThrottle = P_0 as IControllerTemplateThrottle;
											YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Value", controllerTemplateThrottle.value.ToString());
											num2 = -1348839526;
											continue;
										}
										goto case 6;
									case 24:
										controllerTemplateButton = P_0 as IControllerTemplateButton;
										num2 = -1348839534;
										continue;
									case 14:
									{
										IControllerTemplateAxis controllerTemplateAxis = P_0 as IControllerTemplateAxis;
										BWiEHnLzrqtNcsfyWCekQBuUEqM(controllerTemplateAxis, P_2, P_3);
										num2 = -1348839521;
										continue;
									}
									case 21:
										yzzEygPgSKHduwUlcPOHzolzErx(controllerTemplateThumbStick.press, "press", P_2, P_3);
										num2 = -1348839521;
										continue;
									case 4:
										num2 = -1348839521;
										continue;
									case 20:
									{
										int num5;
										if (P_0.type != ControllerTemplateElementType.DPad)
										{
											num2 = -1348839530;
											num5 = num2;
										}
										else
										{
											num2 = -1348839552;
											num5 = num2;
										}
										continue;
									}
									case 31:
										MGXAzEPwXuffWmKraBdKJWZNtgNr(controllerTemplateStick.horizontal, "horizontal", P_2, P_3);
										MGXAzEPwXuffWmKraBdKJWZNtgNr(controllerTemplateStick.vertical, "vertical", P_2, P_3);
										MGXAzEPwXuffWmKraBdKJWZNtgNr(controllerTemplateStick.rotation, "rotation", P_2, P_3);
										num2 = -1348839521;
										continue;
									case 10:
										if (P_0.type == ControllerTemplateElementType.Yoke)
										{
											controllerTemplateYoke = P_0 as IControllerTemplateYoke;
											num2 = -1348839536;
											continue;
										}
										goto case 17;
									case 28:
									{
										YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Type", P_0.type.ToString());
										YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Exists", P_0.exists.ToString());
										int num4;
										if (P_0.type == ControllerTemplateElementType.Button)
										{
											num2 = -1348839547;
											num4 = num2;
										}
										else
										{
											num2 = -1348839539;
											num4 = num2;
										}
										continue;
									}
									case 26:
										YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Rotation", controllerTemplateStick6D.rotation.ToString());
										num2 = -1348839538;
										continue;
									case 15:
										UNDQVqsarSFyvubNEOLvFaRgfBR(controllerTemplateButton, P_2, P_3);
										num2 = -1348839523;
										continue;
									case 25:
										YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Unknown element type", P_0.type.ToString());
										num2 = -1348839521;
										continue;
									case 16:
									{
										int num3;
										if (P_0.type == ControllerTemplateElementType.Axis)
										{
											num2 = -1348839533;
											num3 = num2;
										}
										else
										{
											num2 = -1348839543;
											num3 = num2;
										}
										continue;
									}
									case 6:
										if (P_0.type == ControllerTemplateElementType.ThumbStick)
										{
											controllerTemplateThumbStick = P_0 as IControllerTemplateThumbStick;
											YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Value", controllerTemplateThumbStick.value.ToString());
											YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Value Prev", controllerTemplateThumbStick.valuePrev.ToString());
											MGXAzEPwXuffWmKraBdKJWZNtgNr(controllerTemplateThumbStick.horizontal, "horizontal", P_2, P_3);
											MGXAzEPwXuffWmKraBdKJWZNtgNr(controllerTemplateThumbStick.vertical, "vertical", P_2, P_3);
											num2 = -1348839544;
											continue;
										}
										goto case 10;
									case 9:
										YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Position", controllerTemplateStick6D.position.ToString());
										num2 = -1348839537;
										continue;
									case 11:
										if (P_0.type == ControllerTemplateElementType.Hat)
										{
											controllerTemplateHat = P_0 as IControllerTemplateHat;
											YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Value", controllerTemplateHat.value.ToString());
											YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Value Prev", controllerTemplateHat.valuePrev.ToString());
											yzzEygPgSKHduwUlcPOHzolzErx(controllerTemplateHat.up, "up", P_2, P_3);
											yzzEygPgSKHduwUlcPOHzolzErx(controllerTemplateHat.upRight, "upRight", P_2, P_3);
											yzzEygPgSKHduwUlcPOHzolzErx(controllerTemplateHat.right, "right", P_2, P_3);
											num2 = -1348839541;
											continue;
										}
										goto case 27;
									case 19:
										YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Rotation Prev", controllerTemplateStick6D.rotationPrev.ToString());
										MGXAzEPwXuffWmKraBdKJWZNtgNr(controllerTemplateStick6D.positionX, "PositionX", P_2, P_3);
										MGXAzEPwXuffWmKraBdKJWZNtgNr(controllerTemplateStick6D.positionY, "PositionY", P_2, P_3);
										MGXAzEPwXuffWmKraBdKJWZNtgNr(controllerTemplateStick6D.positionZ, "PositionZ", P_2, P_3);
										MGXAzEPwXuffWmKraBdKJWZNtgNr(controllerTemplateStick6D.rotationX, "RotationX", P_2, P_3);
										MGXAzEPwXuffWmKraBdKJWZNtgNr(controllerTemplateStick6D.rotationY, "RotationY", P_2, P_3);
										num2 = -1348839524;
										continue;
									case 29:
										controllerTemplateDPad = P_0 as IControllerTemplateDPad;
										YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Value", controllerTemplateDPad.value.ToString());
										YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Value Prev", controllerTemplateDPad.valuePrev.ToString());
										num2 = -1348839535;
										continue;
									case 30:
										MGXAzEPwXuffWmKraBdKJWZNtgNr(controllerTemplateYoke.pushPull, "pushPull", P_2, P_3);
										num2 = -1348839521;
										continue;
									case 18:
										YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Position Prev", controllerTemplateStick6D.positionPrev.ToString());
										num2 = -1348839545;
										continue;
									case 22:
										yzzEygPgSKHduwUlcPOHzolzErx(controllerTemplateHat.downRight, "downRight", P_2, P_3);
										yzzEygPgSKHduwUlcPOHzolzErx(controllerTemplateHat.down, "down", P_2, P_3);
										yzzEygPgSKHduwUlcPOHzolzErx(controllerTemplateHat.downLeft, "downLeft", P_2, P_3);
										yzzEygPgSKHduwUlcPOHzolzErx(controllerTemplateHat.left, "left", P_2, P_3);
										yzzEygPgSKHduwUlcPOHzolzErx(controllerTemplateHat.upLeft, "upLeft", P_2, P_3);
										num2 = -1348839521;
										continue;
									case 1:
										MGXAzEPwXuffWmKraBdKJWZNtgNr(controllerTemplateStick6D.rotationZ, "RotationZ", P_2, P_3);
										num2 = -1348839521;
										continue;
									case 7:
										YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Value Prev", controllerTemplateThrottle.valuePrev.ToString());
										MGXAzEPwXuffWmKraBdKJWZNtgNr(controllerTemplateThrottle.throttle, "throttle", P_2, P_3);
										yzzEygPgSKHduwUlcPOHzolzErx(controllerTemplateThrottle.minDetent, "zeroDetent", P_2, P_3);
										num2 = -1348839527;
										continue;
									case 12:
										yzzEygPgSKHduwUlcPOHzolzErx(controllerTemplateDPad.up, "Up", P_2, P_3);
										yzzEygPgSKHduwUlcPOHzolzErx(controllerTemplateDPad.right, "Right", P_2, P_3);
										yzzEygPgSKHduwUlcPOHzolzErx(controllerTemplateDPad.down, "Down", P_2, P_3);
										yzzEygPgSKHduwUlcPOHzolzErx(controllerTemplateDPad.left, "Left", P_2, P_3);
										num2 = -1348839522;
										continue;
									case 13:
										YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Value", controllerTemplateYoke.value.ToString());
										YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Value Prev", controllerTemplateYoke.valuePrev.ToString());
										MGXAzEPwXuffWmKraBdKJWZNtgNr(controllerTemplateYoke.rotation, "rotation", P_2, P_3);
										num2 = -1348839549;
										continue;
									case 17:
										if (P_0.type == ControllerTemplateElementType.Stick6D)
										{
											controllerTemplateStick6D = P_0 as IControllerTemplateStick6D;
											num2 = -1348839532;
											continue;
										}
										goto case 25;
									case 0:
										num2 = -1348839521;
										continue;
									case 3:
										num2 = -1348839521;
										continue;
									case 5:
										YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Value Prev", controllerTemplateStick.valuePrev.ToString());
										num2 = -1348839550;
										continue;
									case 2:
										return;
									}
									break;
								}
							}
						}
					}
					}
					break;
					IL_0080:
					array[4] = ")";
					num = -1348839523;
				}
			}
		}

		private static void MGXAzEPwXuffWmKraBdKJWZNtgNr(IControllerTemplateAxis P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			using (PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi = new PdvratWBuExgULHQUZUruzxWsgi(StringTools.VariableNameToDisplayName(P_1), P_2, P_3))
			{
				if (pdvratWBuExgULHQUZUruzxWsgi.SpZKjJhMWylOpfghINSctstbjVX)
				{
					BWiEHnLzrqtNcsfyWCekQBuUEqM(P_0, P_2, P_3);
				}
			}
		}

		private static void yzzEygPgSKHduwUlcPOHzolzErx(IControllerTemplateButton P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			using (PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi = new PdvratWBuExgULHQUZUruzxWsgi(StringTools.VariableNameToDisplayName(P_1), P_2, P_3))
			{
				if (pdvratWBuExgULHQUZUruzxWsgi.SpZKjJhMWylOpfghINSctstbjVX)
				{
					UNDQVqsarSFyvubNEOLvFaRgfBR(P_0, P_2, P_3);
				}
			}
		}

		private static void BWiEHnLzrqtNcsfyWCekQBuUEqM(IControllerTemplateAxis P_0, string P_1, IDictionary<string, bool> P_2)
		{
			YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Value", P_0.value.ToString());
			YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Value Prev", P_0.valuePrev.ToString());
			FOUSDwCaqbCqSDuSuxCqoYDipIr(P_0.source, "target", P_1, P_2);
		}

		private static void UNDQVqsarSFyvubNEOLvFaRgfBR(IControllerTemplateButton P_0, string P_1, IDictionary<string, bool> P_2)
		{
			YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Value", P_0.value.ToString());
			YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Value Prev", P_0.valuePrev.ToString());
			YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Pressure", P_0.pressure.ToString());
			YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Pressure Prev", P_0.pressurePrev.ToString());
			YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Just Pressed", P_0.justPressed.ToString());
			YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Just Released", P_0.justReleased.ToString());
			while (true)
			{
				int num = 1319379594;
				while (true)
				{
					switch (num ^ 0x4EA4228B)
					{
					case 2:
						break;
					default:
						return;
					case 1:
						goto IL_00b0;
					case 0:
						return;
					}
					break;
					IL_00b0:
					vpgApPaVSaCaxBudBtPXdjfJkgxP(P_0.source, "target", P_1, P_2);
					num = 1319379595;
				}
			}
		}

		private static void FOUSDwCaqbCqSDuSuxCqoYDipIr(IControllerTemplateAxisSource P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi = new PdvratWBuExgULHQUZUruzxWsgi("Axis Target", P_2, P_3);
			try
			{
				if (pdvratWBuExgULHQUZUruzxWsgi.SpZKjJhMWylOpfghINSctstbjVX)
				{
					YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Split Axis", P_0.splitAxis.ToString());
					ppMBtqgjSiwpcWjqvtLvZllzeJX(P_0.fullTarget, "target", P_2, P_3);
					ppMBtqgjSiwpcWjqvtLvZllzeJX(P_0.positiveTarget, "positiveTarget", P_2, P_3);
					ppMBtqgjSiwpcWjqvtLvZllzeJX(P_0.negativeTarget, "negativeTarget", P_2, P_3);
				}
			}
			finally
			{
				if (pdvratWBuExgULHQUZUruzxWsgi != null)
				{
					while (true)
					{
						IL_0076:
						int num = 1927041702;
						while (true)
						{
							switch (num ^ 0x72DC52A7)
							{
							case 0:
								break;
							default:
								goto end_IL_007b;
							case 1:
								goto IL_0094;
							case 2:
								goto end_IL_007b;
							}
							goto IL_0076;
							IL_0094:
							((IDisposable)pdvratWBuExgULHQUZUruzxWsgi).Dispose();
							num = 1927041701;
							continue;
							end_IL_007b:
							break;
						}
						break;
					}
				}
			}
		}

		private static void vpgApPaVSaCaxBudBtPXdjfJkgxP(IControllerTemplateButtonSource P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			ppMBtqgjSiwpcWjqvtLvZllzeJX(P_0.target, "target", P_2, P_3);
		}

		private static void ppMBtqgjSiwpcWjqvtLvZllzeJX(IControllerElementTarget P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			using (PdvratWBuExgULHQUZUruzxWsgi pdvratWBuExgULHQUZUruzxWsgi = new PdvratWBuExgULHQUZUruzxWsgi(StringTools.VariableNameToDisplayName(P_1), P_2, P_3))
			{
				if (!pdvratWBuExgULHQUZUruzxWsgi.SpZKjJhMWylOpfghINSctstbjVX)
				{
					return;
				}
				while (true)
				{
					int num = 38139439;
					while (true)
					{
						switch (num ^ 0x245F62E)
						{
						case 3:
							break;
						default:
							return;
						case 4:
							YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Has Target", P_0.hasTarget.ToString());
							if (P_0.hasTarget)
							{
								YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Target Element", P_0.descriptiveName);
								num = 38139436;
								continue;
							}
							return;
						case 0:
							YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Axis Range", P_0.axisRange.ToString());
							num = 38139434;
							continue;
						case 1:
							YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI("Element Identifier Id", P_0.elementIdentifierId.ToString());
							num = 38139438;
							continue;
						case 2:
							return;
						}
						break;
					}
				}
			}
		}

		private static bool btyRilkCemQDQYvUxrdobnXUCSU(string P_0, bool P_1)
		{
			YtsAUmVGnyfimunrOBlQEainCWMR.agzptvdlSoBcREWCrkmdPyihERI(P_0, P_1.ToString());
			return false;
		}

		private static GUIStyle nNGVjwnTDSOTFOPTgnSBoZKcxCL()
		{
			GUIStyle gUIStyle = new GUIStyle(GUI.skin.label);
			gUIStyle.margin.top = 1;
			gUIStyle.margin.bottom = 1;
			return sEweJrFDzolbbFvtvgiQOTIsSpR(gUIStyle);
		}

		public static GUIStyle GetToggleStyle()
		{
			GUIStyle gUIStyle = new GUIStyle(GUI.skin.toggle);
			gUIStyle.margin.top = 0;
			gUIStyle.margin.bottom = 0;
			while (true)
			{
				int num = -1414972266;
				while (true)
				{
					switch (num ^ -1414972268)
					{
					case 0:
						break;
					case 2:
						goto IL_0046;
					default:
						return gUIStyle;
					}
					break;
					IL_0046:
					gUIStyle = sEweJrFDzolbbFvtvgiQOTIsSpR(gUIStyle);
					num = -1414972267;
				}
			}
		}

		private static GUIStyle sEweJrFDzolbbFvtvgiQOTIsSpR(GUIStyle P_0)
		{
			P_0 = new GUIStyle(P_0);
			P_0.margin.left = VyyCMhxCVCrOcvHHRMFRKbLLfHq.indentLevel * 20;
			return P_0;
		}

		[CompilerGenerated]
		private static int LmAeWwUhOfCgvkeTtfqrAfYOMuRl(InputAction P_0, InputAction P_1)
		{
			return P_0.name.CompareTo(P_1.name);
		}
	}
}
