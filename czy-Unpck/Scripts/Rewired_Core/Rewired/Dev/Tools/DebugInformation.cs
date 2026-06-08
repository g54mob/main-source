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
		private class uexdDwgADKzvNcFbZrcqoUZBltX : IDisposable
		{
			public readonly bool rqXWHSFytsZjoYhGBfurrGRgYww;

			public uexdDwgADKzvNcFbZrcqoUZBltX(string label, string key, IDictionary<string, bool> foldouts)
			{
				rqXWHSFytsZjoYhGBfurrGRgYww = qdnGjRHdJSyJSuVQubPnaYXgoNGN(label, key, foldouts);
				ofaHbsbJsIXmhcEcORnYUSfCXWZ.indentLevel++;
			}

			private bool qdnGjRHdJSyJSuVQubPnaYXgoNGN(string P_0, string P_1, IDictionary<string, bool> P_2)
			{
				return waszzfKNVJcIDdpGGetzkVYKPzBD(P_1, GUILayout.Toggle(UfMdfbTNUaWLFNmEowpRyHayiKH(P_1, P_2), new GUIContent(P_0, P_0), GetToggleStyle()), P_2);
			}

			private bool UfMdfbTNUaWLFNmEowpRyHayiKH(string P_0, IDictionary<string, bool> P_1)
			{
				if (!P_1.ContainsKey(P_0))
				{
					P_1.Add(P_0, value: false);
				}
				return P_1[P_0];
			}

			private bool waszzfKNVJcIDdpGGetzkVYKPzBD(string P_0, bool P_1, IDictionary<string, bool> P_2)
			{
				if (!P_2.ContainsKey(P_0))
				{
					goto IL_0009;
				}
				goto IL_003a;
				IL_0009:
				int num = -1706034212;
				goto IL_000e;
				IL_000e:
				while (true)
				{
					switch (num ^ -1706034211)
					{
					case 2:
						break;
					case 1:
						P_2.Add(P_0, P_1);
						num = -1706034210;
						continue;
					case 0:
						goto IL_003a;
					default:
						return P_1;
					}
					break;
				}
				goto IL_0009;
				IL_003a:
				P_2[P_0] = P_1;
				num = -1706034210;
				goto IL_000e;
			}

			public void Dispose()
			{
				ofaHbsbJsIXmhcEcORnYUSfCXWZ.indentLevel--;
			}
		}

		private static class ofaHbsbJsIXmhcEcORnYUSfCXWZ
		{
			private static int XDUhSyinKjpvPTZvqpvKAlCJxArO;

			public static int indentLevel
			{
				get
				{
					return XDUhSyinKjpvPTZvqpvKAlCJxArO;
				}
				set
				{
					XDUhSyinKjpvPTZvqpvKAlCJxArO = Mathf.Max(0, value);
				}
			}
		}

		private static class jSgNthdoSksvjHKWNlIBatSmzFr
		{
			public static void vkfJXCEKhbcmhKJljYExNRecwvu()
			{
				GUILayout.BeginHorizontal();
			}

			public static void ayIkXBnRKtxcGEYpTMhebyBPrul()
			{
				GUILayout.EndHorizontal();
			}

			public static void anbnwRSYgxojBwyRBLbKpqjwLNz()
			{
				GUILayout.BeginVertical();
			}

			public static void QgktdcVpbzcASHXKcduIzewNMoif()
			{
				GUILayout.EndVertical();
			}

			public static void ZRmFhhmdSnDJnLJwdKgKEmgQNjI(string P_0, pcWCMIemAZHZnmCYLelKnqMlLBJL P_1)
			{
				GUILayout.Label(P_0, KUWYwnBWkUdLKblcrHIKcohjHcuz());
			}

			public static void ZBzYVsVZdstlQlxloHIwZNQsQmt(string P_0, string P_1)
			{
				GUILayout.Label(P_0 + ": " + P_1, KUWYwnBWkUdLKblcrHIKcohjHcuz());
			}

			public static void bzRBKgBGLqgPFywEBYQAGdnToMN(string P_0, AnimationCurve P_1)
			{
				GUILayout.Label(P_0 + ": Curves are not visualized by this tool.");
			}

			public static bool GpucLgSDXqoAXrllaFKfijpJuRjJ(string P_0, bool P_1)
			{
				return GUILayout.Toggle(P_1, P_0, KUWYwnBWkUdLKblcrHIKcohjHcuz());
			}
		}

		private static class JaSrmkxsbVSBfmVHpGUsTUhYzBa
		{
			[CompilerGenerated]
			private static float MwQiBGvXaUKzxFedBHngeKeffdqI;

			[CompilerGenerated]
			private static float YksbkNvFkwXsEMNSyWpuBvjEyqO;

			public static float labelWidth
			{
				[CompilerGenerated]
				get
				{
					return MwQiBGvXaUKzxFedBHngeKeffdqI;
				}
				[CompilerGenerated]
				set
				{
					MwQiBGvXaUKzxFedBHngeKeffdqI = value;
				}
			}

			public static float fieldWidth
			{
				[CompilerGenerated]
				get
				{
					return YksbkNvFkwXsEMNSyWpuBvjEyqO;
				}
				[CompilerGenerated]
				set
				{
					YksbkNvFkwXsEMNSyWpuBvjEyqO = value;
				}
			}
		}

		internal enum pcWCMIemAZHZnmCYLelKnqMlLBJL
		{
			XHUTYEIfTgeCBgXrVRVbPfGzuhN = 0,
			PrqBmKgWoiempGKRYisobyaeHqLT = 1,
			urljbmVuQSsLICFvgNDaTCaNuOp = 2,
			ZtUwsrwXzuJnuLzcmZfjeVDsJIY = 3
		}

		private sealed class TTqeIGAsozKoDYMMlUVwAveslNCa
		{
			public InputCategory aTMeBxQhbsnTprbyblHHhBhHecc;

			public bool KaZqhCmOVDCskrwxIQpiuvWGJaD(InputAction P_0)
			{
				return P_0.categoryId == aTMeBxQhbsnTprbyblHHhBhHecc.id;
			}
		}

		private const string UsNBXNCTFkceBDicOCNuIXliSPA = "Rewired_DebugInformation";

		private const string iLGtbCbeSydvohmUXOEaJEuVqSG = "Rewired Debug Information";

		private const int GCyvswzcJZDBAzFprlDTUAtyIvO = 20;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int _fontSize = 13;

		private static DebugInformation ilVQEiENSgAnwgRreWwIUWTqyneQ;

		private IDictionary<string, bool> JwOGoeglQPrAzUOiGYcFamDzzXLR = new Dictionary<string, bool>();

		private static Vector2 zCxsLTwNZhBVbApVNdJQvMEGjbiG;

		[CompilerGenerated]
		private static Comparison<InputAction> KHkSqdlHHCBAXjHBKogdttKMiJQx;

		[CustomObfuscation(rename = false)]
		private void OnEnable()
		{
			ilVQEiENSgAnwgRreWwIUWTqyneQ = this;
			if (JwOGoeglQPrAzUOiGYcFamDzzXLR.Count == 0)
			{
				JwOGoeglQPrAzUOiGYcFamDzzXLR.Add("Rewired_DebugInformation", value: true);
			}
		}

		[CustomObfuscation(rename = false)]
		private void OnDisable()
		{
			if (ilVQEiENSgAnwgRreWwIUWTqyneQ == this)
			{
				ilVQEiENSgAnwgRreWwIUWTqyneQ = null;
			}
		}

		[CustomObfuscation(rename = false)]
		private void OnGUI()
		{
			ofaHbsbJsIXmhcEcORnYUSfCXWZ.indentLevel = 0;
			GUILayout.BeginArea(new Rect(0f, 0f, Screen.width, Screen.height));
			zCxsLTwNZhBVbApVNdJQvMEGjbiG = GUILayout.BeginScrollView(zCxsLTwNZhBVbApVNdJQvMEGjbiG, GUILayout.ExpandWidth(expand: true), GUILayout.ExpandHeight(expand: true));
			DrawDebugInformation(enabled: true, JwOGoeglQPrAzUOiGYcFamDzzXLR);
			GUILayout.EndScrollView();
			GUILayout.EndArea();
		}

		public static void DrawDebugInformation(bool enabled, IDictionary<string, bool> foldouts)
		{
			bool flag = GUI.enabled;
			if (!ReInput.isReady)
			{
				goto IL_006a;
			}
			if (!enabled)
			{
				goto IL_0010;
			}
			goto IL_0077;
			IL_006a:
			GUI.enabled = false;
			int num = 1445735847;
			goto IL_0015;
			IL_0010:
			num = 1445735841;
			goto IL_0015;
			IL_0015:
			Rect lastRect = default(Rect);
			float num2 = default(float);
			while (true)
			{
				switch (num ^ 0x562C2DA2)
				{
				case 0:
					break;
				case 4:
					lastRect = GUILayoutUtility.GetLastRect();
					num = 1445735843;
					continue;
				case 1:
					num2 = lastRect.width / 3f;
					JaSrmkxsbVSBfmVHpGUsTUhYzBa.labelWidth = lastRect.width - num2;
					num = 1445735840;
					continue;
				case 3:
					goto IL_006a;
				case 5:
					goto IL_0077;
				default:
					JaSrmkxsbVSBfmVHpGUsTUhYzBa.fieldWidth = num2;
					sNnnHgFMGeCWKGFGDKLoTZXXZex(enabled, foldouts);
					GUI.enabled = flag;
					JaSrmkxsbVSBfmVHpGUsTUhYzBa.labelWidth = 0f;
					JaSrmkxsbVSBfmVHpGUsTUhYzBa.fieldWidth = 0f;
					return;
				}
				break;
			}
			goto IL_0010;
			IL_0077:
			jSgNthdoSksvjHKWNlIBatSmzFr.vkfJXCEKhbcmhKJljYExNRecwvu();
			GUILayout.FlexibleSpace();
			jSgNthdoSksvjHKWNlIBatSmzFr.ayIkXBnRKtxcGEYpTMhebyBPrul();
			num = 1445735846;
			goto IL_0015;
		}

		private static void sNnnHgFMGeCWKGFGDKLoTZXXZex(bool P_0, IDictionary<string, bool> P_1)
		{
			using (uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX2 = new uexdDwgADKzvNcFbZrcqoUZBltX("Rewired Debug Information", "Rewired_DebugInformation", P_1))
			{
				if (!ReInput.isReady)
				{
					goto IL_00c5;
				}
				if (!P_0)
				{
					goto IL_0021;
				}
				goto IL_00f3;
				IL_00c5:
				GUILayout.Label("There is no active Rewired Input Manager in the scene.");
				return;
				IL_0021:
				int num = 1530477376;
				goto IL_0026;
				IL_0026:
				bool flag = default(bool);
				while (true)
				{
					switch (num ^ 0x5B393B45)
					{
					case 6:
						break;
					case 1:
						jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Rewired Version", ReInput.programVersion);
						flag = ReInput.configuration.disableNativeInput;
						if (!flag)
						{
							if (ReInput.currentPlatform != Platform.Windows)
							{
								goto IL_007b;
							}
							goto case 4;
						}
						goto case 3;
					case 4:
						if (ReInput.primaryInputManager.inputSourceType == InputSource.Fallback)
						{
							flag = true;
							num = 1530477382;
							continue;
						}
						goto case 3;
					case 3:
						if (flag)
						{
							jSgNthdoSksvjHKWNlIBatSmzFr.ZRmFhhmdSnDJnLJwdKgKEmgQNjI("Native input is disabled. Many special features are unavailable without native input.", pcWCMIemAZHZnmCYLelKnqMlLBJL.urljbmVuQSsLICFvgNDaTCaNuOp);
							num = 1530477378;
							continue;
						}
						goto default;
					case 5:
						goto IL_00c5;
					case 0:
						return;
					case 2:
						goto IL_00f3;
					default:
					{
						KHhSTPEJLBnECtMzEQqbmtAGHKv(P_1, "Rewired_DebugInformation");
						string text = "Rewired_DebugInformation_controllers";
						uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX3 = new uexdDwgADKzvNcFbZrcqoUZBltX("Controllers", text, P_1);
						try
						{
							if (!uexdDwgADKzvNcFbZrcqoUZBltX3.rqXWHSFytsZjoYhGBfurrGRgYww)
							{
								return;
							}
							while (true)
							{
								int num2 = 1530477382;
								while (true)
								{
									switch (num2 ^ 0x5B393B45)
									{
									case 4:
										break;
									default:
										return;
									case 3:
										mFbfwZiFhIExCeodNxbPzhtPcpe(ReInput.controllers.Joysticks, P_1, text);
										num2 = 1530477383;
										continue;
									case 2:
										wDazeIKCbtNLGZrEXBFKAYnhTBZ(ReInput.controllers.CustomControllers, P_1, text);
										pFjRBOWIkoeQOrkBuGsclKNfvfg(P_1, "Rewired_DebugInformation");
										num2 = 1530477380;
										continue;
									case 1:
										VfvRKoProBBRlXwLQEBqLNNNpFu(P_1, "Rewired_DebugInformation");
										num2 = 1530477381;
										continue;
									case 0:
										return;
									}
									break;
								}
							}
						}
						finally
						{
							if (uexdDwgADKzvNcFbZrcqoUZBltX3 != null)
							{
								while (true)
								{
									IL_01ad:
									int num3 = 1530477380;
									while (true)
									{
										switch (num3 ^ 0x5B393B45)
										{
										case 0:
											break;
										default:
											goto end_IL_01b2;
										case 1:
											goto IL_01cb;
										case 2:
											goto end_IL_01b2;
										}
										goto IL_01ad;
										IL_01cb:
										((IDisposable)uexdDwgADKzvNcFbZrcqoUZBltX3).Dispose();
										num3 = 1530477383;
										continue;
										end_IL_01b2:
										break;
									}
									break;
								}
							}
						}
					}
					}
					break;
					IL_007b:
					int num4;
					if (ReInput.currentPlatform != Platform.OSX)
					{
						num = 1530477382;
						num4 = num;
					}
					else
					{
						num = 1530477377;
						num4 = num;
					}
				}
				goto IL_0021;
				IL_00f3:
				int num5;
				if (uexdDwgADKzvNcFbZrcqoUZBltX2.rqXWHSFytsZjoYhGBfurrGRgYww)
				{
					num = 1530477380;
					num5 = num;
				}
				else
				{
					num = 1530477381;
					num5 = num;
				}
				goto IL_0026;
			}
		}

		private static void KHhSTPEJLBnECtMzEQqbmtAGHKv(IDictionary<string, bool> P_0, string P_1)
		{
			string text = P_1 + "_players";
			using (uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX2 = new uexdDwgADKzvNcFbZrcqoUZBltX("Players (" + ReInput.players.allPlayerCount + ")", text, P_0))
			{
				if (!uexdDwgADKzvNcFbZrcqoUZBltX2.rqXWHSFytsZjoYhGBfurrGRgYww)
				{
					return;
				}
				int playerCount = ReInput.players.playerCount;
				int num = 0;
				while (true)
				{
					int num2 = -97366971;
					while (true)
					{
						switch (num2 ^ -97366969)
						{
						case 0:
							break;
						default:
							return;
						case 4:
							num++;
							num2 = -97366970;
							continue;
						case 3:
						{
							Player player = ReInput.players.GetPlayer(num);
							WcuTbqpCtiXwbgEltPpsLVMsQAe(player, num, P_0, text);
							num2 = -97366973;
							continue;
						}
						case 1:
						{
							int num3;
							if (num >= playerCount)
							{
								num2 = -97366975;
								num3 = num2;
							}
							else
							{
								num2 = -97366972;
								num3 = num2;
							}
							continue;
						}
						case 2:
							num2 = -97366970;
							continue;
						case 6:
							WcuTbqpCtiXwbgEltPpsLVMsQAe(ReInput.players.SystemPlayer, -1, P_0, text);
							num2 = -97366974;
							continue;
						case 5:
							return;
						}
						break;
					}
				}
			}
		}

		private static void mFbfwZiFhIExCeodNxbPzhtPcpe(IList<Joystick> P_0, IDictionary<string, bool> P_1, string P_2)
		{
			int num = P_0?.Count ?? 0;
			using (uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX2 = new uexdDwgADKzvNcFbZrcqoUZBltX("Joysticks (" + num + ")", P_2 + "_joysticks", P_1))
			{
				if (!uexdDwgADKzvNcFbZrcqoUZBltX2.rqXWHSFytsZjoYhGBfurrGRgYww)
				{
					return;
				}
				Joystick joystick = default(Joystick);
				string text = default(string);
				int num10 = default(int);
				Player player = default(Player);
				string text2 = default(string);
				CalibrationMap calibrationMap = default(CalibrationMap);
				object[] array = default(object[]);
				int num6 = default(int);
				AxisCalibration axisCalibration = default(AxisCalibration);
				int axisCount = default(int);
				bool flag = default(bool);
				while (true)
				{
					int num2 = 0;
					int num3 = -693156009;
					while (true)
					{
						switch (num3 ^ -693156009)
						{
						case 2:
							num3 = -693156012;
							continue;
						case 3:
							break;
						case 1:
							joystick = P_0[num2];
							text = P_2 + "_joystick" + joystick.id;
							num3 = -693156013;
							continue;
						default:
						{
							using (uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX3 = new uexdDwgADKzvNcFbZrcqoUZBltX(num2 + ": " + ((joystick.name == "Unknown Controller") ? joystick.hardwareName : joystick.name), text, P_1))
							{
								if (uexdDwgADKzvNcFbZrcqoUZBltX3.rqXWHSFytsZjoYhGBfurrGRgYww)
								{
									while (true)
									{
										IL_02d0:
										jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Id (unique id)", joystick.id.ToString());
										int num4 = -693156002;
										while (true)
										{
											switch (num4 ^ -693156009)
											{
											case 0:
												num4 = -693156010;
												continue;
											case 5:
												jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Hardware Type Guid", joystick.hardwareTypeGuid.ToString());
												jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Hardware Identifier", joystick.hardwareIdentifier);
												num4 = -693156012;
												continue;
											case 3:
												jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Device Instance Guid", joystick.deviceInstanceGuid.ToString());
												num4 = -693156006;
												continue;
											case 13:
												jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Tag", joystick.tag);
												genNKTDKVXBNqdPiyuxDtYItUIF(joystick.Axes, P_1, text);
												num4 = -693156001;
												continue;
											case 12:
												num10++;
												num4 = -693156003;
												continue;
											case 11:
												player = ReInput.players.AllPlayers[num10];
												num4 = -693156013;
												continue;
											case 7:
												jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Hardware Name", joystick.hardwareName);
												num4 = -693156007;
												continue;
											case 16:
												if (text2 != string.Empty)
												{
													text2 += ", ";
													num4 = -693156008;
													continue;
												}
												goto case 15;
											case 14:
												jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Is Recognized", (joystick.hardwareTypeGuid != Guid.Empty).ToString());
												num4 = -693156015;
												continue;
											case 6:
												jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Enabled", joystick.enabled.ToString());
												text2 = string.Empty;
												num10 = 0;
												num4 = -693156003;
												continue;
											case 15:
												text2 += ((player.id == 9999999) ? "System" : player.id.ToString());
												num4 = -693156005;
												continue;
											case 1:
												break;
											case 10:
												if (num10 >= ReInput.players.allPlayerCount)
												{
													jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
													jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("System Id", joystick.systemId.ToString());
													jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Unity Id", ReInput.usingUnityInput ? joystick.unityId.ToString() : "--");
													num4 = -693156014;
													continue;
												}
												goto case 11;
											case 4:
											{
												int num11;
												if (ReInput.controllers.IsJoystickAssignedToPlayer(joystick.id, player.id))
												{
													num4 = -693156025;
													num11 = num4;
												}
												else
												{
													num4 = -693156005;
													num11 = num4;
												}
												continue;
											}
											case 9:
												jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Name", joystick.name);
												num4 = -693156016;
												continue;
											case 8:
												sJZDYsCLILewZEAkbINWkQMRVaHX(joystick.Buttons, ControllerType.Joystick, P_1, text);
												jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Axis2D Count", joystick.axis2DCount.ToString());
												jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Hat Count", joystick.hatCount.ToString());
												OuJadMdTIshNZupyoUqSgWpYajv(joystick, P_1, text);
												calibrationMap = joystick.calibrationMap;
												num4 = -693156011;
												continue;
											default:
											{
												using (uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX4 = new uexdDwgADKzvNcFbZrcqoUZBltX("Calibration Map", text + "_calibrationMap", P_1))
												{
													if (uexdDwgADKzvNcFbZrcqoUZBltX4.rqXWHSFytsZjoYhGBfurrGRgYww)
													{
														while (true)
														{
															IL_0438:
															int num5 = -693156010;
															while (true)
															{
																int num9;
																switch (num5 ^ -693156009)
																{
																case 3:
																	break;
																case 4:
																	array = new object[4] { num6, null, null, null };
																	num5 = -693156011;
																	continue;
																case 5:
																	axisCalibration = calibrationMap.Axes[num6];
																	num5 = -693156013;
																	continue;
																case 1:
																	axisCount = calibrationMap.axisCount;
																	num6 = 0;
																	goto IL_06fa;
																case 2:
																	array[1] = ": Axis Calibration (";
																	num5 = -693156009;
																	continue;
																default:
																	{
																		array[2] = (axisCalibration.enabled ? "Enabled" : "Disabled");
																		array[3] = ")";
																		uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX5 = new uexdDwgADKzvNcFbZrcqoUZBltX(string.Concat(array), text + "_AxisCalibration" + num6, P_1);
																		try
																		{
																			if (uexdDwgADKzvNcFbZrcqoUZBltX5.rqXWHSFytsZjoYhGBfurrGRgYww)
																			{
																				while (true)
																				{
																					IL_0542:
																					jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Enabled", axisCalibration.enabled.ToString());
																					int num7 = -693156013;
																					while (true)
																					{
																						switch (num7 ^ -693156009)
																						{
																						case 0:
																							num7 = -693156014;
																							continue;
																						default:
																							goto end_IL_0512;
																						case 5:
																							break;
																						case 3:
																							jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Sensitivity Curve", "--");
																							num7 = -693156016;
																							continue;
																						case 4:
																							jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Apply Range Calibration", axisCalibration.applyRangeCalibration.ToString());
																							jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Calibrated Max", axisCalibration.calibratedMax.ToString());
																							num7 = -693156015;
																							continue;
																						case 2:
																							GUI.enabled = false;
																							jSgNthdoSksvjHKWNlIBatSmzFr.bzRBKgBGLqgPFywEBYQAGdnToMN("Sensitivity Curve", axisCalibration.sensitivityCurve);
																							GUI.enabled = flag;
																							num7 = -693156016;
																							continue;
																						case 6:
																							jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Calibrated Min", axisCalibration.calibratedMin.ToString());
																							jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Calibrated Zero", axisCalibration.calibratedZero.ToString());
																							jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Dead Zone", axisCalibration.deadZone.ToString());
																							jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Invert", axisCalibration.invert.ToString());
																							jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Sensitivity Type", axisCalibration.sensitivityType.ToString());
																							jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Sensitivity", axisCalibration.sensitivity.ToString());
																							num7 = -693156010;
																							continue;
																						case 1:
																							if (axisCalibration.sensitivityCurve != null)
																							{
																								flag = GUI.enabled;
																								num7 = -693156011;
																								continue;
																							}
																							goto case 3;
																						case 7:
																							goto end_IL_0512;
																						}
																						goto IL_0542;
																						continue;
																						end_IL_0512:
																						break;
																					}
																					break;
																				}
																			}
																		}
																		finally
																		{
																			if (uexdDwgADKzvNcFbZrcqoUZBltX5 != null)
																			{
																				while (true)
																				{
																					IL_06a9:
																					int num8 = -693156010;
																					while (true)
																					{
																						switch (num8 ^ -693156009)
																						{
																						case 0:
																							break;
																						default:
																							goto end_IL_06ae;
																						case 1:
																							goto IL_06c7;
																						case 2:
																							goto end_IL_06ae;
																						}
																						goto IL_06a9;
																						IL_06c7:
																						((IDisposable)uexdDwgADKzvNcFbZrcqoUZBltX5).Dispose();
																						num8 = -693156011;
																						continue;
																						end_IL_06ae:
																						break;
																					}
																					break;
																				}
																			}
																		}
																		num6++;
																		goto IL_06dc;
																	}
																	IL_06e1:
																	switch (num9 ^ -693156009)
																	{
																	case 2:
																		break;
																	default:
																		goto end_IL_043d;
																	case 1:
																		goto IL_06fa;
																	case 0:
																		goto end_IL_043d;
																	}
																	goto IL_06dc;
																	IL_06dc:
																	num9 = -693156010;
																	goto IL_06e1;
																	IL_06fa:
																	if (num6 < axisCount)
																	{
																		goto case 5;
																	}
																	num9 = -693156009;
																	goto IL_06e1;
																}
																goto IL_0438;
																continue;
																end_IL_043d:
																break;
															}
															break;
														}
													}
												}
												jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Supports Vibration", joystick.supportsVibration.ToString());
												jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Vibration Motor Count", joystick.vibrationMotorCount.ToString());
												jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Has Extension", (joystick.extension != null).ToString());
												jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Extension Type", (joystick.extension != null) ? joystick.extension.GetType().Name : "--");
												jlcYuEGeDKtjbowwpeIzdibdZTu(joystick, P_1, text);
												goto end_IL_00f3;
											}
											}
											goto IL_02d0;
											continue;
											end_IL_00f3:
											break;
										}
										break;
									}
								}
							}
							num2++;
							goto case 0;
						}
						case 0:
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

		private static void pFjRBOWIkoeQOrkBuGsclKNfvfg(IDictionary<string, bool> P_0, string P_1)
		{
			string text = P_1 + "_mouse";
			using (uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX2 = new uexdDwgADKzvNcFbZrcqoUZBltX("Mouse", text, P_0))
			{
				if (!uexdDwgADKzvNcFbZrcqoUZBltX2.rqXWHSFytsZjoYhGBfurrGRgYww)
				{
					goto IL_0021;
				}
				goto IL_009c;
				IL_0021:
				int num = -1100401134;
				goto IL_0026;
				IL_0026:
				int num2 = default(int);
				string text2 = default(string);
				Mouse mouse = default(Mouse);
				Player player = default(Player);
				while (true)
				{
					switch (num ^ -1100401136)
					{
					case 3:
						break;
					case 4:
						if (num2 >= ReInput.players.allPlayerCount)
						{
							jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
							num = -1100401127;
							continue;
						}
						goto case 6;
					case 8:
						goto IL_009c;
					case 12:
						genNKTDKVXBNqdPiyuxDtYItUIF(mouse.Axes, P_0, text);
						sJZDYsCLILewZEAkbINWkQMRVaHX(mouse.Buttons, ControllerType.Mouse, P_0, text);
						OuJadMdTIshNZupyoUqSgWpYajv(mouse, P_0, text);
						num = -1100401136;
						continue;
					case 5:
						num2++;
						num = -1100401132;
						continue;
					case 11:
						text2 = string.Empty;
						num = -1100401126;
						continue;
					case 1:
						text2 += ", ";
						num = -1100401129;
						continue;
					case 10:
						num2 = 0;
						num = -1100401132;
						continue;
					case 7:
						text2 += ((player.id == 9999999) ? "System" : player.id.ToString());
						num = -1100401131;
						continue;
					case 2:
						return;
					case 6:
						player = ReInput.players.AllPlayers[num2];
						if (!player.controllers.hasMouse)
						{
							goto case 5;
						}
						goto IL_01a3;
					case 9:
						jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Screen Position", mouse.screenPosition.ToString());
						jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Screen Position Prev", mouse.screenPositionPrev.ToString());
						jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Screen Position Delta", mouse.screenPositionDelta.ToString());
						num = -1100401124;
						continue;
					default:
						jlcYuEGeDKtjbowwpeIzdibdZTu(mouse, P_0, text);
						return;
					}
					break;
					IL_01a3:
					int num3;
					if (text2 != string.Empty)
					{
						num = -1100401135;
						num3 = num;
					}
					else
					{
						num = -1100401129;
						num3 = num;
					}
				}
				goto IL_0021;
				IL_009c:
				mouse = ReInput.controllers.Mouse;
				jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Enabled", mouse.enabled.ToString());
				num = -1100401125;
				goto IL_0026;
			}
		}

		private static void VfvRKoProBBRlXwLQEBqLNNNpFu(IDictionary<string, bool> P_0, string P_1)
		{
			string text = P_1 + "_keyboard";
			using (uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX2 = new uexdDwgADKzvNcFbZrcqoUZBltX("Keyboard", text, P_0))
			{
				if (!uexdDwgADKzvNcFbZrcqoUZBltX2.rqXWHSFytsZjoYhGBfurrGRgYww)
				{
					return;
				}
				int num2 = default(int);
				string text2 = default(string);
				Player player = default(Player);
				while (true)
				{
					Keyboard keyboard = ReInput.controllers.Keyboard;
					int num = -1404314525;
					while (true)
					{
						switch (num ^ -1404314524)
						{
						case 6:
							num = -1404314513;
							continue;
						default:
							return;
						case 0:
							num2 = 0;
							num = -1404314516;
							continue;
						case 1:
							text2 += ", ";
							num = -1404314522;
							continue;
						case 12:
							player = ReInput.players.AllPlayers[num2];
							if (player.controllers.hasKeyboard)
							{
								int num4;
								if (text2 != string.Empty)
								{
									num = -1404314523;
									num4 = num;
								}
								else
								{
									num = -1404314522;
									num4 = num;
								}
								continue;
							}
							goto case 3;
						case 11:
							break;
						case 8:
						{
							int num3;
							if (num2 < ReInput.players.allPlayerCount)
							{
								num = -1404314520;
								num3 = num;
							}
							else
							{
								num = -1404314528;
								num3 = num;
							}
							continue;
						}
						case 9:
							sJZDYsCLILewZEAkbINWkQMRVaHX(keyboard.Buttons, ControllerType.Keyboard, P_0, text);
							OuJadMdTIshNZupyoUqSgWpYajv(keyboard, P_0, text);
							num = -1404314527;
							continue;
						case 2:
							text2 += ((player.id == 9999999) ? "System" : player.id.ToString());
							num = -1404314521;
							continue;
						case 7:
							jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Enabled", keyboard.enabled.ToString());
							text2 = string.Empty;
							num = -1404314524;
							continue;
						case 5:
							jlcYuEGeDKtjbowwpeIzdibdZTu(keyboard, P_0, text);
							num = -1404314514;
							continue;
						case 4:
							jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
							num = -1404314515;
							continue;
						case 3:
							num2++;
							num = -1404314516;
							continue;
						case 10:
							return;
						}
						break;
					}
				}
			}
		}

		private static void wDazeIKCbtNLGZrEXBFKAYnhTBZ(IList<CustomController> P_0, IDictionary<string, bool> P_1, string P_2)
		{
			int num = P_0?.Count ?? 0;
			using (uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX2 = new uexdDwgADKzvNcFbZrcqoUZBltX("Custom Controllers (" + num + ")", P_2 + "_customControllers", P_1))
			{
				if (!uexdDwgADKzvNcFbZrcqoUZBltX2.rqXWHSFytsZjoYhGBfurrGRgYww)
				{
					goto IL_003c;
				}
				goto IL_006e;
				IL_003c:
				int num2 = 1475874348;
				goto IL_0041;
				IL_0041:
				int num3 = default(int);
				switch (num2 ^ 0x57F80E28)
				{
				case 0:
					break;
				case 1:
					goto IL_006e;
				case 4:
					return;
				default:
				{
					CustomController customController = P_0[num3];
					string text = P_2 + "_customController" + customController.id;
					using (uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX3 = new uexdDwgADKzvNcFbZrcqoUZBltX(num3 + ": " + customController.name, text, P_1))
					{
						if (uexdDwgADKzvNcFbZrcqoUZBltX3.rqXWHSFytsZjoYhGBfurrGRgYww)
						{
							Player player = default(Player);
							int num6 = default(int);
							object[] array2 = default(object[]);
							object[] array3 = default(object[]);
							int num17 = default(int);
							AxisCalibration axisCalibration = default(AxisCalibration);
							bool flag = default(bool);
							while (true)
							{
								IL_010e:
								jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Id", customController.id.ToString());
								jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Name", customController.name);
								jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Hardware Name", customController.hardwareName);
								jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Tag", customController.tag);
								jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Hardware Identifier", customController.hardwareIdentifier);
								jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Enabled", customController.enabled.ToString());
								string text2 = string.Empty;
								int num4 = 0;
								int num5 = 1475874348;
								while (true)
								{
									switch (num5 ^ 0x57F80E28)
									{
									case 3:
										num5 = 1475874351;
										continue;
									case 7:
										break;
									case 6:
										text2 += ((player.id == 9999999) ? "System" : player.id.ToString());
										num5 = 1475874345;
										continue;
									case 4:
									{
										int num20;
										if (num4 >= ReInput.players.allPlayerCount)
										{
											num5 = 1475874337;
											num20 = num5;
										}
										else
										{
											num5 = 1475874344;
											num20 = num5;
										}
										continue;
									}
									case 8:
										if (ReInput.controllers.IsCustomControllerAssignedToPlayer(customController.id, player.id))
										{
											if (text2 != string.Empty)
											{
												text2 += ", ";
												num5 = 1475874350;
												continue;
											}
											goto case 6;
										}
										goto case 1;
									case 0:
										player = ReInput.players.AllPlayers[num4];
										num5 = 1475874336;
										continue;
									case 9:
										jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
										genNKTDKVXBNqdPiyuxDtYItUIF(customController.Axes, P_1, text);
										num5 = 1475874346;
										continue;
									case 2:
										sJZDYsCLILewZEAkbINWkQMRVaHX(customController.Buttons, ControllerType.Custom, P_1, text);
										jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Axis2D Count", customController.axis2DCount.ToString());
										num5 = 1475874349;
										continue;
									case 1:
										num4++;
										num5 = 1475874348;
										continue;
									default:
									{
										uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX4 = new uexdDwgADKzvNcFbZrcqoUZBltX("Element Identifiers", text + "_elementIdentifiers", P_1);
										try
										{
											if (uexdDwgADKzvNcFbZrcqoUZBltX4.rqXWHSFytsZjoYhGBfurrGRgYww)
											{
												num6 = ((customController.AxisElementIdentifiers != null) ? customController.AxisElementIdentifiers.Count : 0);
												using (uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX5 = new uexdDwgADKzvNcFbZrcqoUZBltX("Axis Element Identifiers (" + num6 + ")", text + "_axisEIs", P_1))
												{
													if (uexdDwgADKzvNcFbZrcqoUZBltX5.rqXWHSFytsZjoYhGBfurrGRgYww)
													{
														int num7 = 0;
														while (true)
														{
															if (num7 < num6)
															{
																ControllerElementIdentifier controllerElementIdentifier;
																object[] array;
																while (true)
																{
																	controllerElementIdentifier = customController.AxisElementIdentifiers[num7];
																	array = new object[6];
																	int num8 = 1475874344;
																	while (true)
																	{
																		switch (num8 ^ 0x57F80E28)
																		{
																		case 2:
																			num8 = 1475874348;
																			continue;
																		case 4:
																			break;
																		case 0:
																			array[0] = num7;
																			array[1] = ": ";
																			num8 = 1475874347;
																			continue;
																		case 3:
																			array[2] = controllerElementIdentifier.name;
																			num8 = 1475874345;
																			continue;
																		default:
																			goto end_IL_0368;
																		}
																		break;
																	}
																	continue;
																	end_IL_0368:
																	break;
																}
																array[3] = " (id: ";
																array[4] = controllerElementIdentifier.id;
																array[5] = ")";
																using (uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX6 = new uexdDwgADKzvNcFbZrcqoUZBltX(string.Concat(array), text + "_AxisEI" + num7 + "_" + controllerElementIdentifier.name, P_1))
																{
																	if (!uexdDwgADKzvNcFbZrcqoUZBltX6.rqXWHSFytsZjoYhGBfurrGRgYww)
																	{
																		goto IL_042a;
																	}
																	goto IL_0455;
																	IL_042a:
																	int num9 = 1475874345;
																	goto IL_042f;
																	IL_042f:
																	switch (num9 ^ 0x57F80E28)
																	{
																	case 2:
																		break;
																	default:
																		goto end_IL_0421;
																	case 1:
																		goto end_IL_0421;
																	case 0:
																		goto IL_0455;
																	case 3:
																		goto end_IL_0421;
																	}
																	goto IL_042a;
																	IL_0455:
																	jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Id", controllerElementIdentifier.id.ToString());
																	jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Name", controllerElementIdentifier.name);
																	num9 = 1475874347;
																	goto IL_042f;
																	end_IL_0421:;
																}
																num7++;
																goto IL_049b;
															}
															int num10 = 1475874345;
															goto IL_04a0;
															IL_049b:
															num10 = 1475874346;
															goto IL_04a0;
															IL_04a0:
															switch (num10 ^ 0x57F80E28)
															{
															case 0:
																break;
															default:
																goto end_IL_04b9;
															case 2:
																continue;
															case 1:
																goto end_IL_04b9;
															}
															goto IL_049b;
															continue;
															end_IL_04b9:
															break;
														}
													}
												}
												num6 = ((customController.ButtonElementIdentifiers != null) ? customController.ButtonElementIdentifiers.Count : 0);
												using (uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX7 = new uexdDwgADKzvNcFbZrcqoUZBltX("Button Element Identifiers (" + num6 + ")", text + "_buttonEIs", P_1))
												{
													if (uexdDwgADKzvNcFbZrcqoUZBltX7.rqXWHSFytsZjoYhGBfurrGRgYww)
													{
														int num11 = 0;
														while (true)
														{
															if (num11 < num6)
															{
																ControllerElementIdentifier controllerElementIdentifier2;
																while (true)
																{
																	controllerElementIdentifier2 = customController.ButtonElementIdentifiers[num11];
																	int num12 = 1475874345;
																	while (true)
																	{
																		switch (num12 ^ 0x57F80E28)
																		{
																		case 0:
																			num12 = 1475874348;
																			continue;
																		case 2:
																			array2[1] = ": ";
																			array2[2] = controllerElementIdentifier2.name;
																			array2[3] = " (id: ";
																			array2[4] = controllerElementIdentifier2.id;
																			array2[5] = ")";
																			num12 = 1475874347;
																			continue;
																		case 1:
																			array2 = new object[6] { num11, null, null, null, null, null };
																			num12 = 1475874346;
																			continue;
																		case 4:
																			break;
																		default:
																			goto end_IL_05aa;
																		}
																		break;
																	}
																	continue;
																	end_IL_05aa:
																	break;
																}
																using (uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX8 = new uexdDwgADKzvNcFbZrcqoUZBltX(string.Concat(array2), text + "_ButtonEI" + num11 + "_" + controllerElementIdentifier2.name, P_1))
																{
																	if (uexdDwgADKzvNcFbZrcqoUZBltX8.rqXWHSFytsZjoYhGBfurrGRgYww)
																	{
																		while (true)
																		{
																			IL_0638:
																			jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Id", controllerElementIdentifier2.id.ToString());
																			jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Name", controllerElementIdentifier2.name);
																			int num13 = 1475874346;
																			while (true)
																			{
																				switch (num13 ^ 0x57F80E28)
																				{
																				case 0:
																					goto IL_061a;
																				default:
																					goto end_IL_061f;
																				case 1:
																					break;
																				case 2:
																					goto end_IL_061f;
																				}
																				goto IL_0638;
																				IL_061a:
																				num13 = 1475874345;
																				continue;
																				end_IL_061f:
																				break;
																			}
																			break;
																		}
																	}
																}
																num11++;
																goto IL_067e;
															}
															int num14 = 1475874346;
															goto IL_0683;
															IL_067e:
															num14 = 1475874345;
															goto IL_0683;
															IL_0683:
															switch (num14 ^ 0x57F80E28)
															{
															case 0:
																break;
															default:
																goto end_IL_069c;
															case 1:
																continue;
															case 2:
																goto end_IL_069c;
															}
															goto IL_067e;
															continue;
															end_IL_069c:
															break;
														}
													}
												}
											}
										}
										finally
										{
											if (uexdDwgADKzvNcFbZrcqoUZBltX4 != null)
											{
												while (true)
												{
													IL_06c0:
													int num15 = 1475874346;
													while (true)
													{
														switch (num15 ^ 0x57F80E28)
														{
														case 0:
															break;
														default:
															goto end_IL_06c5;
														case 2:
															goto IL_06de;
														case 1:
															goto end_IL_06c5;
														}
														goto IL_06c0;
														IL_06de:
														((IDisposable)uexdDwgADKzvNcFbZrcqoUZBltX4).Dispose();
														num15 = 1475874345;
														continue;
														end_IL_06c5:
														break;
													}
													break;
												}
											}
										}
										CalibrationMap calibrationMap = customController.calibrationMap;
										using (uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX9 = new uexdDwgADKzvNcFbZrcqoUZBltX("Calibration Map", text + "_calibrationMap", P_1))
										{
											if (uexdDwgADKzvNcFbZrcqoUZBltX9.rqXWHSFytsZjoYhGBfurrGRgYww)
											{
												while (true)
												{
													IL_071a:
													int num16 = 1475874345;
													while (true)
													{
														int num19;
														switch (num16 ^ 0x57F80E28)
														{
														case 3:
															break;
														case 0:
															array3[0] = num17;
															array3[1] = ": Axis Calibration (";
															array3[2] = (axisCalibration.enabled ? "Enabled" : "Disabled");
															array3[3] = ")";
															num16 = 1475874346;
															continue;
														case 4:
															axisCalibration = calibrationMap.Axes[num17];
															array3 = new object[4];
															num16 = 1475874344;
															continue;
														case 1:
															num6 = calibrationMap.axisCount;
															num17 = 0;
															goto IL_09a4;
														default:
															{
																using (uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX10 = new uexdDwgADKzvNcFbZrcqoUZBltX(string.Concat(array3), text + "_AxisCalibration" + num17, P_1))
																{
																	if (uexdDwgADKzvNcFbZrcqoUZBltX10.rqXWHSFytsZjoYhGBfurrGRgYww)
																	{
																		while (true)
																		{
																			IL_094e:
																			jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Enabled", axisCalibration.enabled.ToString());
																			int num18 = 1475874345;
																			while (true)
																			{
																				switch (num18 ^ 0x57F80E28)
																				{
																				case 5:
																					num18 = 1475874347;
																					continue;
																				default:
																					goto end_IL_07ef;
																				case 0:
																					jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Sensitivity Curve", "--");
																					num18 = 1475874348;
																					continue;
																				case 1:
																					jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Apply Range Calibration", axisCalibration.applyRangeCalibration.ToString());
																					num18 = 1475874350;
																					continue;
																				case 6:
																					jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Calibrated Max", axisCalibration.calibratedMax.ToString());
																					jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Calibrated Min", axisCalibration.calibratedMin.ToString());
																					jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Calibrated Zero", axisCalibration.calibratedZero.ToString());
																					jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Dead Zone", axisCalibration.deadZone.ToString());
																					jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Invert", axisCalibration.invert.ToString());
																					jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Sensitivity Type", axisCalibration.sensitivityType.ToString());
																					jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Sensitivity", axisCalibration.sensitivity.ToString());
																					if (axisCalibration.sensitivityCurve != null)
																					{
																						flag = GUI.enabled;
																						GUI.enabled = false;
																						num18 = 1475874346;
																						continue;
																					}
																					goto case 0;
																				case 2:
																					jSgNthdoSksvjHKWNlIBatSmzFr.bzRBKgBGLqgPFywEBYQAGdnToMN("Sensitivity Curve", axisCalibration.sensitivityCurve);
																					GUI.enabled = flag;
																					num18 = 1475874348;
																					continue;
																				case 3:
																					break;
																				case 4:
																					goto end_IL_07ef;
																				}
																				goto IL_094e;
																				continue;
																				end_IL_07ef:
																				break;
																			}
																			break;
																		}
																	}
																}
																num17++;
																goto IL_0986;
															}
															IL_09a4:
															if (num17 < num6)
															{
																goto case 4;
															}
															num19 = 1475874344;
															goto IL_098b;
															IL_098b:
															switch (num19 ^ 0x57F80E28)
															{
															case 2:
																break;
															default:
																goto end_IL_071f;
															case 1:
																goto IL_09a4;
															case 0:
																goto end_IL_071f;
															}
															goto IL_0986;
															IL_0986:
															num19 = 1475874345;
															goto IL_098b;
														}
														goto IL_071a;
														continue;
														end_IL_071f:
														break;
													}
													break;
												}
											}
										}
										jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Has Extension", (customController.extension != null).ToString());
										jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Extension Type", (customController.extension != null) ? customController.extension.GetType().Name : "--");
										jlcYuEGeDKtjbowwpeIzdibdZTu(customController, P_1, text);
										goto end_IL_00d6;
									}
									}
									goto IL_010e;
									continue;
									end_IL_00d6:
									break;
								}
								break;
							}
						}
					}
					num3++;
					goto case 3;
				}
				case 3:
					if (num3 >= num)
					{
						return;
					}
					goto default;
				}
				goto IL_003c;
				IL_006e:
				num3 = 0;
				num2 = 1475874347;
				goto IL_0041;
			}
		}

		private static void WcuTbqpCtiXwbgEltPpsLVMsQAe(Player P_0, int P_1, IDictionary<string, bool> P_2, string P_3)
		{
			string text = P_3 + "_player" + P_0.id;
			using (uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX2 = new uexdDwgADKzvNcFbZrcqoUZBltX((P_0.id == 9999999) ? "System Player" : (P_1 + ": " + P_0.name), text, P_2))
			{
				if (!uexdDwgADKzvNcFbZrcqoUZBltX2.rqXWHSFytsZjoYhGBfurrGRgYww)
				{
					return;
				}
				jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Player Id", P_0.id.ToString());
				jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Name", P_0.name);
				jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Descriptive Name", P_0.descriptiveName);
				jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Is Playing", P_0.isPlaying.ToString());
				using (uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX3 = new uexdDwgADKzvNcFbZrcqoUZBltX("Controllers", text + "_controllers", P_2))
				{
					if (uexdDwgADKzvNcFbZrcqoUZBltX3.rqXWHSFytsZjoYhGBfurrGRgYww)
					{
						Player.ControllerHelper controllers = default(Player.ControllerHelper);
						while (true)
						{
							IL_00ca:
							int num = 575142871;
							while (true)
							{
								switch (num ^ 0x2247FBD6)
								{
								case 2:
									break;
								default:
									goto end_IL_00cf;
								case 1:
									controllers = P_0.controllers;
									mFbfwZiFhIExCeodNxbPzhtPcpe(controllers.Joysticks, P_2, text);
									wDazeIKCbtNLGZrEXBFKAYnhTBZ(controllers.CustomControllers, P_2, text);
									jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Has Mouse", controllers.hasMouse.ToString());
									num = 575142869;
									continue;
								case 3:
									jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Has Keyboard", controllers.hasKeyboard.ToString());
									jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Exclude From Controller Auto Assignment", controllers.excludeFromControllerAutoAssignment.ToString());
									num = 575142870;
									continue;
								case 0:
									goto end_IL_00cf;
								}
								goto IL_00ca;
								continue;
								end_IL_00cf:
								break;
							}
							break;
						}
					}
				}
				string text2 = text + "_controllerMaps";
				uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX4 = new uexdDwgADKzvNcFbZrcqoUZBltX("Controller Maps", text2, P_2);
				try
				{
					if (uexdDwgADKzvNcFbZrcqoUZBltX4.rqXWHSFytsZjoYhGBfurrGRgYww)
					{
						UijFUzVUMJQTHkVdaxDAgYMwEio(ControllerType.Keyboard, P_0.controllers.maps.GetMaps<KeyboardMap>(0), "Keyboard Maps", P_2, text2 + "_keyboard");
						UijFUzVUMJQTHkVdaxDAgYMwEio(ControllerType.Mouse, P_0.controllers.maps.GetMaps<MouseMap>(0), "Mouse Maps", P_2, text2 + "_mouse");
						string text3 = text2 + "_joystickMaps";
						using (uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX5 = new uexdDwgADKzvNcFbZrcqoUZBltX("Joysticks (" + P_0.controllers.joystickCount + ")", text3, P_2))
						{
							if (uexdDwgADKzvNcFbZrcqoUZBltX5.rqXWHSFytsZjoYhGBfurrGRgYww)
							{
								int num2 = 0;
								while (true)
								{
									IL_02e4:
									int num3;
									int num4;
									if (num2 >= P_0.controllers.joystickCount)
									{
										num3 = 575142869;
										num4 = num3;
									}
									else
									{
										num3 = 575142868;
										num4 = num3;
									}
									while (true)
									{
										switch (num3 ^ 0x2247FBD6)
										{
										case 0:
											num3 = 575142868;
											continue;
										default:
											goto end_IL_023f;
										case 2:
										{
											Joystick joystick = P_0.controllers.Joysticks[num2];
											IList<JoystickMap> maps = P_0.controllers.maps.GetMaps<JoystickMap>(joystick.id);
											text3 = text3 + "_joystickId" + joystick.id;
											UijFUzVUMJQTHkVdaxDAgYMwEio(ControllerType.Joystick, maps, (joystick.name != "Unknown Controller") ? joystick.name : joystick.hardwareName, P_2, text3);
											num2++;
											num3 = 575142871;
											continue;
										}
										case 1:
											break;
										case 3:
											goto end_IL_023f;
										}
										goto IL_02e4;
										continue;
										end_IL_023f:
										break;
									}
									break;
								}
							}
						}
						text3 = text2 + "_customControllerMaps";
						using (uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX6 = new uexdDwgADKzvNcFbZrcqoUZBltX("Custom Controllers (" + P_0.controllers.customControllerCount + ")", text3, P_2))
						{
							if (uexdDwgADKzvNcFbZrcqoUZBltX6.rqXWHSFytsZjoYhGBfurrGRgYww)
							{
								int num5 = 0;
								IList<CustomControllerMap> maps2 = default(IList<CustomControllerMap>);
								CustomController customController = default(CustomController);
								while (true)
								{
									IL_038a:
									int num6;
									int num7;
									if (num5 >= P_0.controllers.customControllerCount)
									{
										num6 = 575142870;
										num7 = num6;
									}
									else
									{
										num6 = 575142869;
										num7 = num6;
									}
									while (true)
									{
										switch (num6 ^ 0x2247FBD6)
										{
										case 5:
											num6 = 575142869;
											continue;
										default:
											goto end_IL_0362;
										case 1:
											break;
										case 2:
											maps2 = P_0.controllers.maps.GetMaps<CustomControllerMap>(customController.id);
											text3 = text3 + "_customControllerId" + customController.id;
											num6 = 575142866;
											continue;
										case 3:
											customController = P_0.controllers.CustomControllers[num5];
											num6 = 575142868;
											continue;
										case 4:
											UijFUzVUMJQTHkVdaxDAgYMwEio(ControllerType.Custom, maps2, customController.name, P_2, text3);
											num5++;
											num6 = 575142871;
											continue;
										case 0:
											goto end_IL_0362;
										}
										goto IL_038a;
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
				finally
				{
					if (uexdDwgADKzvNcFbZrcqoUZBltX4 != null)
					{
						while (true)
						{
							IL_043c:
							int num8 = 575142871;
							while (true)
							{
								switch (num8 ^ 0x2247FBD6)
								{
								case 2:
									break;
								default:
									goto end_IL_0441;
								case 1:
									goto IL_045a;
								case 0:
									goto end_IL_0441;
								}
								goto IL_043c;
								IL_045a:
								((IDisposable)uexdDwgADKzvNcFbZrcqoUZBltX4).Dispose();
								num8 = 575142870;
								continue;
								end_IL_0441:
								break;
							}
							break;
						}
					}
				}
				text2 = text + "_controllerMapLayoutManager";
				uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX7 = new uexdDwgADKzvNcFbZrcqoUZBltX("Layout Manager", text2, P_2);
				try
				{
					if (uexdDwgADKzvNcFbZrcqoUZBltX7.rqXWHSFytsZjoYhGBfurrGRgYww)
					{
						rXQPnMkXERPVxLfKccKkPkpxiZP(P_0.controllers.maps.layoutManager, P_2, text2);
					}
				}
				finally
				{
					if (uexdDwgADKzvNcFbZrcqoUZBltX7 != null)
					{
						while (true)
						{
							IL_04ac:
							int num9 = 575142868;
							while (true)
							{
								switch (num9 ^ 0x2247FBD6)
								{
								case 0:
									break;
								default:
									goto end_IL_04b1;
								case 2:
									goto IL_04ca;
								case 1:
									goto end_IL_04b1;
								}
								goto IL_04ac;
								IL_04ca:
								((IDisposable)uexdDwgADKzvNcFbZrcqoUZBltX7).Dispose();
								num9 = 575142871;
								continue;
								end_IL_04b1:
								break;
							}
							break;
						}
					}
				}
				text2 = text + "_controllerMapEnabler";
				using (uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX8 = new uexdDwgADKzvNcFbZrcqoUZBltX("Map Enabler", text2, P_2))
				{
					if (uexdDwgADKzvNcFbZrcqoUZBltX8.rqXWHSFytsZjoYhGBfurrGRgYww)
					{
						cuPDcrQrcTlQpwLdhxJfdpNMIpC(P_0.controllers.maps.mapEnabler, P_2, text2);
					}
				}
				text2 = text + "_inputBehaviors";
				BebOQHOOnkmjPQZleRNKjkPfoN(P_0.controllers.maps.InputBehaviors, P_2, text2);
				text2 = text + "_actions";
				List<InputAction> list = new List<InputAction>(ReInput.mapping.Actions);
				list.Sort((InputAction inputAction2, InputAction inputAction3) => inputAction2.name.CompareTo(inputAction3.name));
				IList<InputCategory> actionCategories = ReInput.mapping.ActionCategories;
				using (uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX9 = new uexdDwgADKzvNcFbZrcqoUZBltX("Actions (" + list.Count + ")", text2, P_2))
				{
					if (!uexdDwgADKzvNcFbZrcqoUZBltX9.rqXWHSFytsZjoYhGBfurrGRgYww)
					{
						return;
					}
					int num10 = 0;
					object[] array = default(object[]);
					int num12 = default(int);
					int num16 = default(int);
					InputAction inputAction = default(InputAction);
					string key = default(string);
					object[] array2 = default(object[]);
					while (true)
					{
						if (num10 < actionCategories.Count)
						{
							TTqeIGAsozKoDYMMlUVwAveslNCa tTqeIGAsozKoDYMMlUVwAveslNCa;
							string text4;
							while (true)
							{
								tTqeIGAsozKoDYMMlUVwAveslNCa = new TTqeIGAsozKoDYMMlUVwAveslNCa();
								tTqeIGAsozKoDYMMlUVwAveslNCa.aTMeBxQhbsnTprbyblHHhBhHecc = actionCategories[num10];
								text4 = text2 + "_actionCat" + tTqeIGAsozKoDYMMlUVwAveslNCa.aTMeBxQhbsnTprbyblHHhBhHecc.id;
								int num11 = 575142868;
								while (true)
								{
									switch (num11 ^ 0x2247FBD6)
									{
									case 4:
										num11 = 575142867;
										continue;
									case 1:
										array[0] = "id ";
										array[1] = tTqeIGAsozKoDYMMlUVwAveslNCa.aTMeBxQhbsnTprbyblHHhBhHecc.id;
										array[2] = ": ";
										num11 = 575142870;
										continue;
									case 0:
										array[3] = tTqeIGAsozKoDYMMlUVwAveslNCa.aTMeBxQhbsnTprbyblHHhBhHecc.name;
										array[4] = " (";
										num11 = 575142869;
										continue;
									case 5:
										break;
									case 2:
										num12 = ListTools.Count(list, tTqeIGAsozKoDYMMlUVwAveslNCa.KaZqhCmOVDCskrwxIQpiuvWGJaD);
										array = new object[7];
										num11 = 575142871;
										continue;
									default:
										goto end_IL_064b;
									}
									break;
								}
								continue;
								end_IL_064b:
								break;
							}
							array[5] = num12;
							array[6] = ")";
							using (uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX10 = new uexdDwgADKzvNcFbZrcqoUZBltX(string.Concat(array), text4, P_2))
							{
								if (uexdDwgADKzvNcFbZrcqoUZBltX10.rqXWHSFytsZjoYhGBfurrGRgYww)
								{
									while (true)
									{
										IL_06e4:
										int num13 = 575142869;
										while (true)
										{
											int num15;
											switch (num13 ^ 0x2247FBD6)
											{
											case 0:
												break;
											case 3:
												num16 = 0;
												goto IL_0af9;
											case 4:
												if (inputAction.categoryId == tTqeIGAsozKoDYMMlUVwAveslNCa.aTMeBxQhbsnTprbyblHHhBhHecc.id)
												{
													key = text4 + "_actionId" + inputAction.id;
													array2 = new object[6]
													{
														"id ",
														inputAction.id,
														": ",
														inputAction.name,
														": ",
														P_0.GetAxis(inputAction.id).ToString("f3")
													};
													num13 = 575142871;
													continue;
												}
												goto IL_0ad5;
											case 2:
												inputAction = list[num16];
												num13 = 575142866;
												continue;
											default:
												{
													using (uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX11 = new uexdDwgADKzvNcFbZrcqoUZBltX(string.Concat(array2), key, P_2))
													{
														if (uexdDwgADKzvNcFbZrcqoUZBltX11.rqXWHSFytsZjoYhGBfurrGRgYww)
														{
															jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Axis Value", P_0.GetAxis(inputAction.id).ToString());
															jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Axis Raw Value", P_0.GetAxisRaw(inputAction.id).ToString());
															jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Button Value", P_0.GetButton(inputAction.id).ToString());
															jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Button Double Press Value", P_0.GetButtonDoublePressHold(inputAction.id).ToString());
															while (true)
															{
																IL_0867:
																int num14 = 575142867;
																while (true)
																{
																	switch (num14 ^ 0x2247FBD6)
																	{
																	case 6:
																		break;
																	default:
																		goto end_IL_086c;
																	case 1:
																		jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Button Time Unpressed", P_0.GetButtonTimeUnpressed(inputAction.id).ToString());
																		jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Negative Button Time Pressed", P_0.GetNegativeButtonTimePressed(inputAction.id).ToString());
																		num14 = 575142869;
																		continue;
																	case 4:
																		jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Negative Button Long Press Value", P_0.GetNegativeButtonLongPress(inputAction.id).ToString());
																		jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Negative Button Repeating Value", P_0.GetNegativeButtonRepeating(inputAction.id).ToString());
																		jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Axis Time Active", P_0.GetAxisTimeActive(inputAction.id).ToString());
																		jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Axis Time Inactive", P_0.GetAxisTimeInactive(inputAction.id).ToString());
																		num14 = 575142868;
																		continue;
																	case 5:
																		jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Button Short Press Value", P_0.GetButtonShortPress(inputAction.id).ToString());
																		jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Button Long Press Value", P_0.GetButtonLongPress(inputAction.id).ToString());
																		jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Button Repeating Value", P_0.GetButtonRepeating(inputAction.id).ToString());
																		jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Negative Button Value", P_0.GetNegativeButton(inputAction.id).ToString());
																		jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Negative Button Double Press Value", P_0.GetNegativeButtonDoublePressHold(inputAction.id).ToString());
																		jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Negative Button Short Press Value", P_0.GetNegativeButtonShortPress(inputAction.id).ToString());
																		num14 = 575142866;
																		continue;
																	case 2:
																		jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Axis Raw Time Active", P_0.GetAxisRawTimeActive(inputAction.id).ToString());
																		jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Axis Raw Time Inactive", P_0.GetAxisRawTimeInactive(inputAction.id).ToString());
																		jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Button Time Pressed", P_0.GetButtonTimePressed(inputAction.id).ToString());
																		num14 = 575142871;
																		continue;
																	case 3:
																		jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Negative Button Time Unpressed", P_0.GetNegativeButtonTimeUnpressed(inputAction.id).ToString());
																		num14 = 575142870;
																		continue;
																	case 0:
																		goto end_IL_086c;
																	}
																	goto IL_0867;
																	continue;
																	end_IL_086c:
																	break;
																}
																break;
															}
														}
													}
													goto IL_0ad5;
												}
												IL_0adb:
												num15 = 575142871;
												goto IL_0ae0;
												IL_0ad5:
												num16++;
												goto IL_0adb;
												IL_0af9:
												if (num16 < list.Count)
												{
													goto case 2;
												}
												num15 = 575142870;
												goto IL_0ae0;
												IL_0ae0:
												switch (num15 ^ 0x2247FBD6)
												{
												case 2:
													break;
												default:
													goto end_IL_06e9;
												case 1:
													goto IL_0af9;
												case 0:
													goto end_IL_06e9;
												}
												goto IL_0adb;
											}
											goto IL_06e4;
											continue;
											end_IL_06e9:
											break;
										}
										break;
									}
								}
							}
							num10++;
							goto IL_0b22;
						}
						int num17 = 575142868;
						goto IL_0b27;
						IL_0b22:
						num17 = 575142871;
						goto IL_0b27;
						IL_0b27:
						switch (num17 ^ 0x2247FBD6)
						{
						case 0:
							break;
						default:
							return;
						case 1:
							continue;
						case 2:
							return;
						}
						goto IL_0b22;
					}
				}
			}
		}

		private static void BebOQHOOnkmjPQZleRNKjkPfoN(IList<InputBehavior> P_0, IDictionary<string, bool> P_1, string P_2)
		{
			int num = P_0?.Count ?? 0;
			using (uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX2 = new uexdDwgADKzvNcFbZrcqoUZBltX("Input Behaviors (" + num + ")", P_2 + "_inputBehaviors", P_1))
			{
				if (!uexdDwgADKzvNcFbZrcqoUZBltX2.rqXWHSFytsZjoYhGBfurrGRgYww)
				{
					return;
				}
				while (true)
				{
					int num2 = 0;
					int num3 = -758421604;
					while (true)
					{
						switch (num3 ^ -758421608)
						{
						case 0:
							num3 = -758421606;
							continue;
						case 2:
							break;
						case 1:
							num2++;
							num3 = -758421604;
							continue;
						case 3:
						{
							InputBehavior inputBehavior = P_0[num2];
							VBdCaQVXsSdgiIrEqTvOSQMyiIUq(inputBehavior, num2, P_1, P_2);
							num3 = -758421607;
							continue;
						}
						default:
							if (num2 >= num)
							{
								return;
							}
							goto case 3;
						}
						break;
					}
				}
			}
		}

		private static void VBdCaQVXsSdgiIrEqTvOSQMyiIUq(InputBehavior P_0, int P_1, IDictionary<string, bool> P_2, string P_3)
		{
			string key = P_3 + "_inputBehavior" + P_0.id;
			using (uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX2 = new uexdDwgADKzvNcFbZrcqoUZBltX(P_1 + ": " + P_0.name, key, P_2))
			{
				if (!uexdDwgADKzvNcFbZrcqoUZBltX2.rqXWHSFytsZjoYhGBfurrGRgYww)
				{
					goto IL_003d;
				}
				goto IL_006e;
				IL_003d:
				int num = 544481031;
				goto IL_0042;
				IL_0042:
				switch (num ^ 0x20741F06)
				{
				case 2:
					break;
				case 1:
					return;
				case 0:
					goto IL_006e;
				default:
					jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Button Long Press Time", P_0.buttonLongPressTime.ToString());
					jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Button Long Press Expires In", P_0.buttonLongPressExpiresIn.ToString());
					jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Button Down Buffer", P_0.buttonDownBuffer.ToString());
					return;
				}
				goto IL_003d;
				IL_006e:
				jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Id", P_0.id.ToString());
				jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Name", P_0.name);
				jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Digital Axis Gravity", P_0.digitalAxisGravity.ToString());
				jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Digital Axis Instant Reverse", P_0.digitalAxisInstantReverse.ToString());
				jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Digital Axis Sensitivity", P_0.digitalAxisSensitivity.ToString());
				jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Digital Axis Snap", P_0.digitalAxisSnap.ToString());
				jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Joystick Axis Sensitivity", P_0.joystickAxisSensitivity.ToString());
				jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Custom Controller Axis Sensitivity", P_0.customControllerAxisSensitivity.ToString());
				jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Mouse XY Axis Mode", P_0.mouseXYAxisMode.ToString());
				jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Mouse XY Axis Sensitivity", P_0.mouseXYAxisSensitivity.ToString());
				jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Mouse XY Axis Delta Calc", P_0.mouseXYAxisDeltaCalc.ToString());
				jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Mouse Other Axis Mode", P_0.mouseOtherAxisMode.ToString());
				jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Mouse Other Axis Sensitivity", P_0.mouseOtherAxisSensitivity.ToString());
				jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Button Dead Zone", P_0.buttonDeadZone.ToString());
				jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Button Double Press Speed", P_0.buttonDoublePressSpeed.ToString());
				jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Button Short Press Time", P_0.buttonShortPressTime.ToString());
				jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Button Short Press Expires In", P_0.buttonShortPressExpiresIn.ToString());
				num = 544481029;
				goto IL_0042;
			}
		}

		private static void OuJadMdTIshNZupyoUqSgWpYajv(Controller P_0, IDictionary<string, bool> P_1, string P_2)
		{
			uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX2 = new uexdDwgADKzvNcFbZrcqoUZBltX("Element Identifiers", P_2 + "_elementIdentifiers", P_1);
			try
			{
				if (!uexdDwgADKzvNcFbZrcqoUZBltX2.rqXWHSFytsZjoYhGBfurrGRgYww)
				{
					return;
				}
				int num = default(int);
				if (P_0 is ControllerWithAxes)
				{
					ControllerWithAxes controllerWithAxes = P_0 as ControllerWithAxes;
					num = ((controllerWithAxes.AxisElementIdentifiers != null) ? controllerWithAxes.AxisElementIdentifiers.Count : 0);
					using (uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX3 = new uexdDwgADKzvNcFbZrcqoUZBltX("Axis Element Identifiers (" + num + ")", P_2 + "_axisEIs", P_1))
					{
						if (uexdDwgADKzvNcFbZrcqoUZBltX3.rqXWHSFytsZjoYhGBfurrGRgYww)
						{
							object[] array = default(object[]);
							int num3 = default(int);
							ControllerElementIdentifier controllerElementIdentifier = default(ControllerElementIdentifier);
							while (true)
							{
								IL_007d:
								int num2 = -84358453;
								while (true)
								{
									int num5;
									switch (num2 ^ -84358450)
									{
									case 2:
										break;
									case 0:
										array = new object[6];
										num2 = -84358454;
										continue;
									case 4:
										array[0] = num3;
										array[1] = ": ";
										array[2] = controllerElementIdentifier.name;
										array[3] = " (id: ";
										array[4] = controllerElementIdentifier.id;
										num2 = -84358449;
										continue;
									case 5:
										num3 = 0;
										goto IL_020c;
									case 3:
										controllerElementIdentifier = controllerWithAxes.AxisElementIdentifiers[num3];
										num2 = -84358450;
										continue;
									default:
										{
											array[5] = ")";
											using (uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX4 = new uexdDwgADKzvNcFbZrcqoUZBltX(string.Concat(array), P_2 + "_AxisEI" + num3 + "_" + controllerElementIdentifier.name, P_1))
											{
												if (uexdDwgADKzvNcFbZrcqoUZBltX4.rqXWHSFytsZjoYhGBfurrGRgYww)
												{
													while (true)
													{
														IL_01a1:
														jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Id", controllerElementIdentifier.id.ToString());
														int num4 = -84358452;
														while (true)
														{
															switch (num4 ^ -84358450)
															{
															case 3:
																num4 = -84358449;
																continue;
															default:
																goto end_IL_0184;
															case 1:
																break;
															case 2:
																jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Name", controllerElementIdentifier.name);
																num4 = -84358450;
																continue;
															case 0:
																goto end_IL_0184;
															}
															goto IL_01a1;
															continue;
															end_IL_0184:
															break;
														}
														break;
													}
												}
											}
											num3++;
											goto IL_01ee;
										}
										IL_020c:
										if (num3 < num)
										{
											goto case 3;
										}
										num5 = -84358452;
										goto IL_01f3;
										IL_01f3:
										switch (num5 ^ -84358450)
										{
										case 0:
											break;
										default:
											goto end_IL_0082;
										case 1:
											goto IL_020c;
										case 2:
											goto end_IL_0082;
										}
										goto IL_01ee;
										IL_01ee:
										num5 = -84358449;
										goto IL_01f3;
									}
									goto IL_007d;
									continue;
									end_IL_0082:
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
				int num8 = default(int);
				object[] array2 = default(object[]);
				ControllerElementIdentifier controllerElementIdentifier2 = default(ControllerElementIdentifier);
				while (true)
				{
					int num6 = -84358449;
					while (true)
					{
						int num11;
						switch (num6 ^ -84358450)
						{
						case 2:
							break;
						case 1:
							num11 = ((P_0.ButtonElementIdentifiers != null) ? P_0.ButtonElementIdentifiers.Count : 0);
							goto IL_0266;
						default:
						{
							using (uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX5 = new uexdDwgADKzvNcFbZrcqoUZBltX("Button Element Identifiers (" + num + ")", P_2 + "_buttonEIs", P_1))
							{
								if (!uexdDwgADKzvNcFbZrcqoUZBltX5.rqXWHSFytsZjoYhGBfurrGRgYww)
								{
									return;
								}
								while (true)
								{
									int num7 = -84358454;
									while (true)
									{
										int num10;
										switch (num7 ^ -84358450)
										{
										case 2:
											break;
										case 4:
											num8 = 0;
											goto IL_0416;
										case 0:
											array2[0] = num8;
											num7 = -84358449;
											continue;
										case 3:
											controllerElementIdentifier2 = P_0.ButtonElementIdentifiers[num8];
											array2 = new object[6];
											num7 = -84358450;
											continue;
										default:
											{
												array2[1] = ": ";
												array2[2] = controllerElementIdentifier2.name;
												array2[3] = " (id: ";
												array2[4] = controllerElementIdentifier2.id;
												array2[5] = ")";
												using (uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX6 = new uexdDwgADKzvNcFbZrcqoUZBltX(string.Concat(array2), P_2 + "_ButtonEI" + num8 + "_" + controllerElementIdentifier2.name, P_1))
												{
													if (uexdDwgADKzvNcFbZrcqoUZBltX6.rqXWHSFytsZjoYhGBfurrGRgYww)
													{
														while (true)
														{
															IL_03b2:
															jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Id", controllerElementIdentifier2.id.ToString());
															int num9 = -84358452;
															while (true)
															{
																switch (num9 ^ -84358450)
																{
																case 0:
																	goto IL_0394;
																case 1:
																	break;
																default:
																	jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Name", controllerElementIdentifier2.name);
																	goto end_IL_0399;
																}
																goto IL_03b2;
																IL_0394:
																num9 = -84358449;
																continue;
																end_IL_0399:
																break;
															}
															break;
														}
													}
												}
												num8++;
												goto IL_03f8;
											}
											IL_03f8:
											num10 = -84358449;
											goto IL_03fd;
											IL_0416:
											if (num8 < num)
											{
												goto case 3;
											}
											num10 = -84358450;
											goto IL_03fd;
											IL_03fd:
											switch (num10 ^ -84358450)
											{
											case 2:
												break;
											default:
												return;
											case 1:
												goto IL_0416;
											case 0:
												return;
											}
											goto IL_03f8;
										}
										break;
									}
								}
							}
						}
						}
						break;
						IL_0266:
						num = num11;
						num6 = -84358450;
					}
				}
			}
			finally
			{
				if (uexdDwgADKzvNcFbZrcqoUZBltX2 != null)
				{
					while (true)
					{
						IL_0438:
						int num12 = -84358449;
						while (true)
						{
							switch (num12 ^ -84358450)
							{
							case 0:
								break;
							default:
								goto end_IL_043d;
							case 1:
								goto IL_0456;
							case 2:
								goto end_IL_043d;
							}
							goto IL_0438;
							IL_0456:
							((IDisposable)uexdDwgADKzvNcFbZrcqoUZBltX2).Dispose();
							num12 = -84358452;
							continue;
							end_IL_043d:
							break;
						}
						break;
					}
				}
			}
		}

		private static void sJZDYsCLILewZEAkbINWkQMRVaHX(IList<Controller.Button> P_0, ControllerType P_1, IDictionary<string, bool> P_2, string P_3)
		{
			string text = ((P_1 == ControllerType.Keyboard) ? "Key" : "Button");
			int num = P_0?.Count ?? 0;
			object[] array = default(object[]);
			object[] array2 = default(object[]);
			while (true)
			{
				int num2 = 1549850989;
				while (true)
				{
					switch (num2 ^ 0x5C60D969)
					{
					case 3:
						break;
					case 4:
						array = new object[4];
						num2 = 1549850987;
						continue;
					case 0:
						array[3] = ")";
						num2 = 1549850984;
						continue;
					case 2:
						array[0] = text;
						array[1] = "s (";
						array[2] = num;
						num2 = 1549850985;
						continue;
					default:
					{
						using (uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX2 = new uexdDwgADKzvNcFbZrcqoUZBltX(string.Concat(array), P_3 + "_Buttons", P_2))
						{
							if (!uexdDwgADKzvNcFbZrcqoUZBltX2.rqXWHSFytsZjoYhGBfurrGRgYww)
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
									Controller.Button button;
									while (true)
									{
										IL_0161:
										button = P_0[num3];
										int num4 = 1549850988;
										while (true)
										{
											switch (num4 ^ 0x5C60D969)
											{
											case 6:
												num4 = 1549850984;
												continue;
											case 3:
												array2[0] = num3;
												num4 = 1549850989;
												continue;
											case 4:
												array2[1] = ": ";
												array2[2] = ((P_1 == ControllerType.Keyboard) ? (Keyboard.GetKeyboardKeyCodeByButtonIndex(num3).ToString() + " (" + Keyboard.GetKeyName((KeyCode)Keyboard.GetKeyboardKeyCodeByButtonIndex(num3)) + ")") : button.elementIdentifier.name);
												num4 = 1549850987;
												continue;
											case 5:
												array2 = new object[8];
												num4 = 1549850986;
												continue;
											case 1:
												break;
											case 0:
												goto IL_0161;
											default:
												goto IL_0174;
											}
											break;
										}
										break;
									}
									break;
									IL_0174:
									array2[3] = ": ";
									array2[4] = (button.value ? "Pressed" : "");
									array2[5] = " (";
									array2[6] = button.pressure.ToString("f3");
									array2[7] = ")";
									using (uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX3 = new uexdDwgADKzvNcFbZrcqoUZBltX(string.Concat(array2), P_3 + "_" + button.name, P_2))
									{
										if (uexdDwgADKzvNcFbZrcqoUZBltX3.rqXWHSFytsZjoYhGBfurrGRgYww)
										{
											while (true)
											{
												IL_0221:
												jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Is Member Element", button.isMemberElement.ToString());
												int num5 = 1549850987;
												while (true)
												{
													switch (num5 ^ 0x5C60D969)
													{
													case 0:
														num5 = 1549850988;
														continue;
													case 5:
														break;
													case 2:
														jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Is Pressure Sensitive", button.isPressureSensitive.ToString());
														jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Value", button.value.ToString());
														jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Value Prev", button.valuePrev.ToString());
														num5 = 1549850986;
														continue;
													case 6:
														jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Double Pressed And Held", button.doublePressedAndHeld.ToString());
														jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Time Pressed", button.timePressed.ToString());
														jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Time Unpressed", button.timeUnpressed.ToString());
														num5 = 1549850989;
														continue;
													case 3:
														jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Pressure", button.pressure.ToString());
														jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Pressure Prev", button.pressurePrev.ToString());
														jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Just Pressed", button.justPressed.ToString());
														jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Just Released", button.justReleased.ToString());
														num5 = 1549850984;
														continue;
													case 1:
														jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Just Double Pressed", button.justDoublePressed.ToString());
														num5 = 1549850991;
														continue;
													default:
														jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Last Time Pressed", button.lastTimePressed.ToString());
														jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Last Time Unpressed", button.lastTimeUnpressed.ToString());
														goto end_IL_01f5;
													}
													goto IL_0221;
													continue;
													end_IL_01f5:
													break;
												}
												break;
											}
										}
									}
									num3++;
								}
							}
						}
					}
					}
					break;
				}
			}
		}

		private static void genNKTDKVXBNqdPiyuxDtYItUIF(IList<Controller.Axis> P_0, IDictionary<string, bool> P_1, string P_2)
		{
			int num = P_0?.Count ?? 0;
			using (uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX2 = new uexdDwgADKzvNcFbZrcqoUZBltX("Axes (" + num + ")", P_2 + "_Axes", P_1))
			{
				if (!uexdDwgADKzvNcFbZrcqoUZBltX2.rqXWHSFytsZjoYhGBfurrGRgYww)
				{
					goto IL_003c;
				}
				goto IL_00aa;
				IL_003c:
				int num2 = 1196685576;
				goto IL_0041;
				IL_0041:
				object[] array = default(object[]);
				int num3 = default(int);
				Controller.Axis axis = default(Controller.Axis);
				while (true)
				{
					switch (num2 ^ 0x4753F909)
					{
					case 4:
						break;
					case 1:
						return;
					case 6:
						array = new object[8]
						{
							num3,
							": ",
							axis.elementIdentifier.name,
							null,
							null,
							null,
							null,
							null
						};
						num2 = 1196685579;
						continue;
					case 0:
						goto IL_00aa;
					case 2:
						array[3] = ": ";
						array[4] = axis.value.ToString("f3");
						array[5] = " (";
						array[6] = axis.valueRaw.ToString("f3");
						num2 = 1196685580;
						continue;
					case 3:
						goto IL_0104;
					default:
						goto IL_0116;
					}
					break;
				}
				goto IL_003c;
				IL_00aa:
				num3 = 0;
				goto IL_0357;
				IL_033e:
				int num4;
				switch (num4 ^ 0x4753F909)
				{
				case 0:
					break;
				default:
					return;
				case 2:
					goto IL_0357;
				case 1:
					return;
				}
				goto IL_0339;
				IL_0104:
				axis = P_0[num3];
				num2 = 1196685583;
				goto IL_0041;
				IL_0116:
				array[7] = ")";
				using (uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX3 = new uexdDwgADKzvNcFbZrcqoUZBltX(string.Concat(array), P_2 + "_" + axis.name, P_1))
				{
					if (uexdDwgADKzvNcFbZrcqoUZBltX3.rqXWHSFytsZjoYhGBfurrGRgYww)
					{
						while (true)
						{
							IL_0264:
							jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Is Member Element", axis.isMemberElement.ToString());
							jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Value", axis.value.ToString());
							jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Value Raw", axis.valueRaw.ToString());
							int num5 = 1196685576;
							while (true)
							{
								switch (num5 ^ 0x4753F909)
								{
								case 6:
									num5 = 1196685579;
									continue;
								case 3:
									jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Value Raw Prev", axis.valueRawPrev.ToString());
									jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Value Delta", axis.valueDelta.ToString());
									num5 = 1196685581;
									continue;
								case 1:
									jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Value Prev", axis.valuePrev.ToString());
									num5 = 1196685578;
									continue;
								case 4:
									jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Value Delta Raw", axis.valueDeltaRaw.ToString());
									jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Time Active", axis.timeActive.ToString());
									jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Time Active Raw", axis.timeActiveRaw.ToString());
									jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Time Inactive", axis.timeInactive.ToString());
									jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Time Inactive Raw", axis.timeInactiveRaw.ToString());
									num5 = 1196685577;
									continue;
								case 2:
									break;
								case 0:
									jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Last Time Active", axis.lastTimeActive.ToString());
									num5 = 1196685580;
									continue;
								default:
									jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Last Time Active Raw", axis.lastTimeActiveRaw.ToString());
									jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Last Time Inactive", axis.lastTimeInactive.ToString());
									jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Last Time Inactive Raw", axis.lastTimeInactiveRaw.ToString());
									goto end_IL_0155;
								}
								goto IL_0264;
								continue;
								end_IL_0155:
								break;
							}
							break;
						}
					}
				}
				num3++;
				goto IL_0339;
				IL_0357:
				if (num3 < num)
				{
					goto IL_0104;
				}
				num4 = 1196685576;
				goto IL_033e;
				IL_0339:
				num4 = 1196685579;
				goto IL_033e;
			}
		}

		private static void UijFUzVUMJQTHkVdaxDAgYMwEio<T>(ControllerType P_0, IList<T> P_1, string P_2, IDictionary<string, bool> P_3, string P_4) where T : ControllerMap
		{
			string text = P_4 + "_controllerMaps";
			int num2 = default(int);
			object[] array = default(object[]);
			object[] array2 = default(object[]);
			string text2 = default(string);
			string text3 = default(string);
			string text4 = default(string);
			int num4 = default(int);
			while (true)
			{
				int num = 2005216935;
				while (true)
				{
					switch (num ^ 0x77852EA6)
					{
					case 2:
						break;
					case 1:
						num2 = P_1?.Count ?? 0;
						num = 2005216934;
						continue;
					case 0:
						array = new object[4];
						num = 2005216933;
						continue;
					default:
					{
						array[0] = P_2;
						array[1] = " (";
						array[2] = num2;
						array[3] = ")";
						uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX2 = new uexdDwgADKzvNcFbZrcqoUZBltX(string.Concat(array), text, P_3);
						try
						{
							if (!uexdDwgADKzvNcFbZrcqoUZBltX2.rqXWHSFytsZjoYhGBfurrGRgYww)
							{
								goto IL_008a;
							}
							goto IL_00c3;
							IL_008a:
							int num3 = 2005216930;
							goto IL_008f;
							IL_008f:
							while (true)
							{
								switch (num3 ^ 0x77852EA6)
								{
								case 2:
									break;
								case 4:
									return;
								case 0:
									goto IL_00c3;
								case 5:
									goto IL_00d1;
								case 3:
									array2[2] = text2;
									array2[3] = ", ";
									array2[4] = text3;
									array2[5] = ": ";
									array2[6] = text4;
									num3 = 2005216935;
									continue;
								default:
									goto IL_01b7;
								}
								break;
							}
							goto IL_008a;
							IL_00c3:
							num4 = 0;
							goto IL_02a5;
							IL_02a5:
							if (num4 >= num2)
							{
								return;
							}
							goto IL_00d1;
							IL_01b7:
							using (uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX3 = new uexdDwgADKzvNcFbZrcqoUZBltX(string.Concat(array2), P_4 + "_index" + num4, P_3))
							{
								if (uexdDwgADKzvNcFbZrcqoUZBltX3.rqXWHSFytsZjoYhGBfurrGRgYww)
								{
									while (true)
									{
										IL_0213:
										int num5;
										int num6;
										if (P_1[num4] is ControllerMapWithAxes)
										{
											num5 = 2005216934;
											num6 = num5;
										}
										else
										{
											num5 = 2005216930;
											num6 = num5;
										}
										while (true)
										{
											switch (num5 ^ 0x77852EA6)
											{
											case 2:
												num5 = 2005216931;
												continue;
											default:
												goto end_IL_01eb;
											case 5:
												break;
											case 0:
												DDZBqtHgnWsUShljzyzfiaCfAPT(P_1[num4] as ControllerMapWithAxes, P_3, text + num4);
												num5 = 2005216933;
												continue;
											case 4:
												DDZBqtHgnWsUShljzyzfiaCfAPT(P_1[num4], P_3, text + num4);
												num5 = 2005216935;
												continue;
											case 3:
												num5 = 2005216935;
												continue;
											case 1:
												goto end_IL_01eb;
											}
											goto IL_0213;
											continue;
											end_IL_01eb:
											break;
										}
										break;
									}
								}
							}
							num4++;
							goto IL_02a5;
							IL_00d1:
							T val = P_1[num4];
							text4 = (val.enabled ? "Enabled" : "Disabled");
							ReInput.MappingHelper mapping = ReInput.mapping;
							T val2 = P_1[num4];
							InputMapCategory mapCategory = mapping.GetMapCategory(val2.categoryId);
							ReInput.MappingHelper mapping2 = ReInput.mapping;
							T val3 = P_1[num4];
							InputLayout layout = mapping2.GetLayout(P_0, val3.layoutId);
							text2 = ((mapCategory != null) ? mapCategory.name : "n/a");
							text3 = ((layout != null) ? layout.name : "n/a");
							array2 = new object[7] { num4, ": ", null, null, null, null, null };
							num3 = 2005216933;
							goto IL_008f;
						}
						finally
						{
							if (uexdDwgADKzvNcFbZrcqoUZBltX2 != null)
							{
								while (true)
								{
									IL_02b1:
									int num7 = 2005216935;
									while (true)
									{
										switch (num7 ^ 0x77852EA6)
										{
										case 2:
											break;
										default:
											goto end_IL_02b6;
										case 1:
											goto IL_02cf;
										case 0:
											goto end_IL_02b6;
										}
										goto IL_02b1;
										IL_02cf:
										((IDisposable)uexdDwgADKzvNcFbZrcqoUZBltX2).Dispose();
										num7 = 2005216934;
										continue;
										end_IL_02b6:
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

		private static void DDZBqtHgnWsUShljzyzfiaCfAPT(ControllerMap P_0, IDictionary<string, bool> P_1, string P_2)
		{
			jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Id (unique id)", P_0.id.ToString());
			jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Source Map Id", P_0.sourceMapId.ToString());
			string text2 = default(string);
			while (true)
			{
				int num = 3690602;
				while (true)
				{
					switch (num ^ 0x38506B)
					{
					case 4:
						break;
					case 5:
					{
						int num8;
						if (P_0.controllerType != ControllerType.Custom)
						{
							num = 3690601;
							num8 = num;
						}
						else
						{
							num = 3690603;
							num8 = num;
						}
						continue;
					}
					case 3:
					{
						int num7;
						if (P_0.controllerType == ControllerType.Joystick)
						{
							num = 3690603;
							num7 = num;
						}
						else
						{
							num = 3690606;
							num7 = num;
						}
						continue;
					}
					case 1:
						jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Enabled", P_0.enabled.ToString());
						jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Controller Type", P_0.controllerType.ToString());
						num = 3690600;
						continue;
					case 0:
						jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Controller Id", P_0.controllerId.ToString());
						num = 3690601;
						continue;
					default:
					{
						string text = P_0.categoryId.ToString();
						if (P_0.categoryId >= 0)
						{
							try
							{
								InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(P_0.categoryId);
								while (true)
								{
									IL_011e:
									int num2 = 3690602;
									while (true)
									{
										switch (num2 ^ 0x38506B)
										{
										case 2:
											break;
										default:
											goto end_IL_0123;
										case 1:
											if (mapCategory != null)
											{
												goto IL_013f;
											}
											goto end_IL_0123;
										case 0:
											goto end_IL_0123;
										}
										goto IL_011e;
										IL_013f:
										text = text + " (" + mapCategory.name + ")";
										num2 = 3690603;
										continue;
										end_IL_0123:
										break;
									}
									break;
								}
							}
							catch
							{
							}
						}
						jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Category Id", text);
						int layoutId = P_0.layoutId;
						while (true)
						{
							int num3 = 3690602;
							while (true)
							{
								switch (num3 ^ 0x38506B)
								{
								case 0:
									break;
								case 1:
									goto IL_0193;
								default:
								{
									if (P_0.layoutId >= 0)
									{
										try
										{
											InputLayout layout = ReInput.mapping.GetLayout(P_0.controllerType, P_0.layoutId);
											if (layout != null)
											{
												text2 = text2 + " (" + layout.name + ")";
											}
										}
										catch
										{
										}
									}
									jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Layout Id", text2);
									int buttonMapCount = P_0.buttonMapCount;
									string text3 = P_2 + "_buttonMaps";
									using (uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX2 = new uexdDwgADKzvNcFbZrcqoUZBltX("Button Maps (" + buttonMapCount + ")", text3, P_1))
									{
										if (!uexdDwgADKzvNcFbZrcqoUZBltX2.rqXWHSFytsZjoYhGBfurrGRgYww)
										{
											return;
										}
										int num4 = 0;
										while (true)
										{
											int num5 = 3690602;
											while (true)
											{
												switch (num5 ^ 0x38506B)
												{
												case 0:
													break;
												default:
													return;
												case 1:
													num5 = 3690600;
													continue;
												case 3:
												{
													int num6;
													if (num4 < buttonMapCount)
													{
														num5 = 3690601;
														num6 = num5;
													}
													else
													{
														num5 = 3690607;
														num6 = num5;
													}
													continue;
												}
												case 2:
													OAxIYPLQUFTQhzkceCNxGxOcUdl(P_0.controllerType, P_0.ButtonMaps[num4], num4, P_1, text3 + num4);
													num4++;
													num5 = 3690600;
													continue;
												case 4:
													return;
												}
												break;
											}
										}
									}
								}
								}
								break;
								IL_0193:
								text2 = layoutId.ToString();
								num3 = 3690601;
							}
						}
					}
					}
					break;
				}
			}
		}

		private static void DDZBqtHgnWsUShljzyzfiaCfAPT(ControllerMapWithAxes P_0, IDictionary<string, bool> P_1, string P_2)
		{
			DDZBqtHgnWsUShljzyzfiaCfAPT((ControllerMap)P_0, P_1, P_2);
			string text = P_2 + "_axisMaps";
			int axisMapCount = P_0.axisMapCount;
			uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX2 = new uexdDwgADKzvNcFbZrcqoUZBltX("Axis Maps (" + axisMapCount + ")", text, P_1);
			try
			{
				if (!uexdDwgADKzvNcFbZrcqoUZBltX2.rqXWHSFytsZjoYhGBfurrGRgYww)
				{
					return;
				}
				while (true)
				{
					int num = 0;
					int num2 = -1271681242;
					while (true)
					{
						switch (num2 ^ -1271681243)
						{
						case 2:
							num2 = -1271681244;
							continue;
						default:
							return;
						case 1:
							break;
						case 3:
						{
							int num3;
							if (num < axisMapCount)
							{
								num2 = -1271681243;
								num3 = num2;
							}
							else
							{
								num2 = -1271681247;
								num3 = num2;
							}
							continue;
						}
						case 0:
							OAxIYPLQUFTQhzkceCNxGxOcUdl(P_0.controllerType, P_0.AxisMaps[num], num, P_1, text + num);
							num++;
							num2 = -1271681242;
							continue;
						case 4:
							return;
						}
						break;
					}
				}
			}
			finally
			{
				if (uexdDwgADKzvNcFbZrcqoUZBltX2 != null)
				{
					while (true)
					{
						IL_00be:
						int num4 = -1271681244;
						while (true)
						{
							switch (num4 ^ -1271681243)
							{
							case 2:
								break;
							default:
								goto end_IL_00c3;
							case 1:
								goto IL_00dc;
							case 0:
								goto end_IL_00c3;
							}
							goto IL_00be;
							IL_00dc:
							((IDisposable)uexdDwgADKzvNcFbZrcqoUZBltX2).Dispose();
							num4 = -1271681243;
							continue;
							end_IL_00c3:
							break;
						}
						break;
					}
				}
			}
		}

		private static void OAxIYPLQUFTQhzkceCNxGxOcUdl(ControllerType P_0, ActionElementMap P_1, int P_2, IDictionary<string, bool> P_3, string P_4)
		{
			string text = default(string);
			string text3 = default(string);
			InputAction action = default(InputAction);
			string text2 = default(string);
			while (true)
			{
				int num = -556729792;
				while (true)
				{
					string empty;
					switch (num ^ -556729787)
					{
					case 3:
						break;
					case 1:
						text = P_1.elementIdentifierName + " (" + text3 + ")";
						num = -556729787;
						continue;
					case 4:
					{
						int num5;
						if (string.IsNullOrEmpty(text3))
						{
							num = -556729787;
							num5 = num;
						}
						else
						{
							num = -556729788;
							num5 = num;
						}
						continue;
					}
					case 2:
						empty = string.Empty;
						goto IL_007a;
					case 6:
						if (action != null)
						{
							empty = action.name;
							goto IL_007a;
						}
						num = -556729785;
						continue;
					case 5:
						text = "Action Element Map";
						action = ReInput.mapping.GetAction(P_1.actionId);
						num = -556729789;
						continue;
					default:
						{
							using (uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX2 = new uexdDwgADKzvNcFbZrcqoUZBltX(P_2 + ": " + text, P_4 + "_" + P_2, P_3))
							{
								if (!uexdDwgADKzvNcFbZrcqoUZBltX2.rqXWHSFytsZjoYhGBfurrGRgYww)
								{
									goto IL_00f1;
								}
								goto IL_02e8;
								IL_00f1:
								int num2 = -556729785;
								goto IL_00f6;
								IL_00f6:
								while (true)
								{
									switch (num2 ^ -556729787)
									{
									case 10:
										break;
									case 2:
										return;
									case 7:
										jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Key Code", P_1.keyCode.ToString());
										jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Keyboard Key Code", P_1.keyboardKeyCode.ToString());
										jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Has Modifiers", P_1.hasModifiers.ToString());
										jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Modifier Key 1", P_1.modifierKey1.ToString());
										jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Modifier Key 2", P_1.modifierKey2.ToString());
										jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Modifier Key 3", P_1.modifierKey3.ToString());
										num2 = -556729789;
										continue;
									case 5:
										if (P_1.elementType == ControllerElementType.Button)
										{
											jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Element Index", P_1.elementIndex.ToString());
											num2 = -556729780;
											continue;
										}
										goto default;
									case 9:
										goto IL_0212;
									case 0:
										jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Invert", P_1.invert.ToString());
										num2 = -556729789;
										continue;
									case 8:
										goto IL_024c;
									case 1:
										goto IL_02e8;
									case 4:
										jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Element Index", P_1.elementIndex.ToString());
										jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Axis Range", P_1.axisRange.ToString());
										jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Axis Type", P_1.axisType.ToString());
										num2 = -556729787;
										continue;
									case 3:
										jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Enabled", P_1.enabled.ToString());
										num2 = -556729779;
										continue;
									default:
										jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Axis Contribution", P_1.axisContribution.ToString());
										return;
									}
									break;
									IL_024c:
									jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Element Type", P_1.elementType.ToString());
									jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Action Id", P_1.actionId + " " + ((action != null) ? ("(" + text2 + ")") : ""));
									jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Element Identifier Id", P_1.elementIdentifierId.ToString());
									jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Element Identifier Name", P_1.elementIdentifierName);
									int num3;
									if (P_1.elementType != ControllerElementType.Axis)
									{
										num2 = -556729792;
										num3 = num2;
									}
									else
									{
										num2 = -556729791;
										num3 = num2;
									}
									continue;
									IL_0212:
									int num4;
									if (P_0 == ControllerType.Keyboard)
									{
										num2 = -556729790;
										num4 = num2;
									}
									else
									{
										num2 = -556729789;
										num4 = num2;
									}
								}
								goto IL_00f1;
								IL_02e8:
								jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Id (unique id)", P_1.id.ToString());
								num2 = -556729786;
								goto IL_00f6;
							}
						}
						IL_007a:
						text2 = empty;
						text3 = QoNjeTWnPNFejhJjfpsechNuosG(P_1);
						num = -556729791;
						continue;
					}
					break;
				}
			}
		}

		private static string QoNjeTWnPNFejhJjfpsechNuosG(ActionElementMap P_0)
		{
			InputAction action = ReInput.mapping.GetAction(P_0.actionId);
			string text = default(string);
			while (true)
			{
				int num = -980027998;
				while (true)
				{
					string descriptiveName;
					switch (num ^ -980027993)
					{
					case 8:
						break;
					case 10:
						if (string.IsNullOrEmpty(action.descriptiveName))
						{
							num = -980027997;
							continue;
						}
						descriptiveName = action.descriptiveName;
						goto IL_00e2;
					case 2:
					{
						int num5;
						if (P_0.axisType != AxisType.Normal)
						{
							num = -980027996;
							num5 = num;
						}
						else
						{
							num = -980027987;
							num5 = num;
						}
						continue;
					}
					case 9:
						if (P_0.axisContribution != Pole.Positive)
						{
							goto case 7;
						}
						text = action.positiveDescriptiveName;
						if (string.IsNullOrEmpty(text))
						{
							text = ((!string.IsNullOrEmpty(action.descriptiveName)) ? (action.descriptiveName + " +") : (action.name + " +"));
							num = -980027996;
							continue;
						}
						goto default;
					case 4:
						descriptiveName = action.name;
						goto IL_00e2;
					case 6:
						num = -980027996;
						continue;
					case 7:
						text = action.negativeDescriptiveName;
						if (string.IsNullOrEmpty(text))
						{
							text = ((!string.IsNullOrEmpty(action.descriptiveName)) ? (action.descriptiveName + " -") : (action.name + " -"));
							num = -980027999;
							continue;
						}
						goto default;
					case 0:
					{
						int num4;
						if (P_0.axisType != AxisType.Split)
						{
							num = -980027994;
							num4 = num;
						}
						else
						{
							num = -980027986;
							num4 = num;
						}
						continue;
					}
					case 1:
					{
						int num3;
						if (P_0.elementType == ControllerElementType.Axis)
						{
							num = -980027995;
							num3 = num;
						}
						else
						{
							num = -980027996;
							num3 = num;
						}
						continue;
					}
					case 5:
						if (action == null)
						{
							return string.Empty;
						}
						text = string.Empty;
						if (P_0.elementType != ControllerElementType.Button)
						{
							int num2;
							if (P_0.elementType == ControllerElementType.Axis)
							{
								num = -980027993;
								num2 = num;
							}
							else
							{
								num = -980027994;
								num2 = num;
							}
							continue;
						}
						goto case 9;
					default:
						{
							return text;
						}
						IL_00e2:
						text = descriptiveName;
						num = -980027996;
						continue;
					}
					break;
				}
			}
		}

		private static void rXQPnMkXERPVxLfKccKkPkpxiZP(ControllerMapLayoutManager P_0, IDictionary<string, bool> P_1, string P_2)
		{
			if (GpucLgSDXqoAXrllaFKfijpJuRjJ("Enabled", P_0.enabled))
			{
				P_0.enabled = !P_0.enabled;
				goto IL_0021;
			}
			goto IL_003f;
			IL_003f:
			jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Load from User Data Store", P_0.loadFromUserDataStore.ToString());
			string text = P_2 + "_ruleSets";
			int num = -884388879;
			goto IL_0026;
			IL_0021:
			num = -884388880;
			goto IL_0026;
			IL_0026:
			switch (num ^ -884388879)
			{
			case 2:
				break;
			case 1:
				goto IL_003f;
			default:
			{
				int count = P_0.ruleSets.Count;
				using (uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX2 = new uexdDwgADKzvNcFbZrcqoUZBltX("Rule Sets (" + count + ")", text, P_1))
				{
					if (!uexdDwgADKzvNcFbZrcqoUZBltX2.rqXWHSFytsZjoYhGBfurrGRgYww)
					{
						return;
					}
					int num2 = 0;
					while (true)
					{
						int num3 = -884388875;
						while (true)
						{
							switch (num3 ^ -884388879)
							{
							case 3:
								break;
							default:
								return;
							case 4:
								num3 = -884388877;
								continue;
							case 2:
							{
								int num4;
								if (num2 >= count)
								{
									num3 = -884388880;
									num4 = num3;
								}
								else
								{
									num3 = -884388879;
									num4 = num3;
								}
								continue;
							}
							case 0:
								rMQaHdKvbOLxsCpcpNFXcgMbqxRl(P_0.ruleSets[num2], num2, P_1, text + num2);
								num2++;
								num3 = -884388877;
								continue;
							case 1:
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

		private static void rMQaHdKvbOLxsCpcpNFXcgMbqxRl(ControllerMapLayoutManager.RuleSet P_0, int P_1, IDictionary<string, bool> P_2, string P_3)
		{
			if (P_0 == null)
			{
				goto IL_0003;
			}
			int num = P_0.Count;
			goto IL_002a;
			IL_002a:
			int num2 = num;
			object[] array = new object[4] { P_1, null, null, null };
			int num3 = 1983380605;
			goto IL_0008;
			IL_0003:
			num3 = 1983380606;
			goto IL_0008;
			IL_0008:
			switch (num3 ^ 0x7637FC7F)
			{
			case 0:
				break;
			case 1:
				goto IL_0021;
			default:
			{
				array[1] = ": ";
				array[2] = ((!string.IsNullOrEmpty(P_0.tag)) ? (P_0.tag + ", ") : "");
				array[3] = (P_0.enabled ? "Enabled" : "Disabled");
				using (uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX2 = new uexdDwgADKzvNcFbZrcqoUZBltX(string.Concat(array), P_3, P_2))
				{
					if (!uexdDwgADKzvNcFbZrcqoUZBltX2.rqXWHSFytsZjoYhGBfurrGRgYww)
					{
						return;
					}
					string text = default(string);
					int[] categoryIds = default(int[]);
					object[] array2 = default(object[]);
					InputMapCategory mapCategory = default(InputMapCategory);
					while (true)
					{
						int num4;
						if (GpucLgSDXqoAXrllaFKfijpJuRjJ("Enabled", P_0.enabled))
						{
							P_0.enabled = !P_0.enabled;
							num4 = 1983380606;
							goto IL_00ae;
						}
						goto IL_010a;
						IL_00ae:
						while (true)
						{
							switch (num4 ^ 0x7637FC7F)
							{
							case 4:
								num4 = 1983380605;
								continue;
							case 2:
								break;
							case 0:
								text = P_3 + "_rules";
								num4 = 1983380604;
								continue;
							case 1:
								goto IL_010a;
							default:
							{
								using (uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX3 = new uexdDwgADKzvNcFbZrcqoUZBltX("Rules (" + P_0.Count + ")", text, P_2))
								{
									if (!uexdDwgADKzvNcFbZrcqoUZBltX3.rqXWHSFytsZjoYhGBfurrGRgYww)
									{
										return;
									}
									int num5 = 0;
									while (true)
									{
										if (num5 < num2)
										{
											ControllerMapLayoutManager.Rule rule;
											string text2;
											while (true)
											{
												rule = P_0[num5];
												text2 = text + num5;
												int num6 = 1983380607;
												while (true)
												{
													switch (num6 ^ 0x7637FC7F)
													{
													case 2:
														num6 = 1983380606;
														continue;
													case 1:
														break;
													default:
														goto end_IL_0174;
													}
													break;
												}
												continue;
												end_IL_0174:
												break;
											}
											using (uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX4 = new uexdDwgADKzvNcFbZrcqoUZBltX(num5 + ": " + ((!string.IsNullOrEmpty(rule.tag)) ? rule.tag : ""), text2, P_2))
											{
												if (uexdDwgADKzvNcFbZrcqoUZBltX4.rqXWHSFytsZjoYhGBfurrGRgYww)
												{
													while (true)
													{
														IL_01d7:
														int num7 = 1983380606;
														while (true)
														{
															int num8;
															int num9;
															InputLayout layout;
															switch (num7 ^ 0x7637FC7F)
															{
															case 2:
																break;
															case 1:
																jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Tag", rule.tag);
																jfdCPWhZtJZhPivIkHsvyHwyZgz(rule.controllerSetSelector, P_2, text2);
																categoryIds = rule.categoryIds;
																if (categoryIds == null)
																{
																	goto IL_0222;
																}
																num8 = categoryIds.Length;
																goto IL_0230;
															default:
																{
																	num8 = 0;
																	goto IL_0230;
																}
																IL_0230:
																num9 = num8;
																using (uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX5 = new uexdDwgADKzvNcFbZrcqoUZBltX("Map Categories (" + num9 + ")", text2 + "_categoryIds", P_2))
																{
																	if (uexdDwgADKzvNcFbZrcqoUZBltX5.rqXWHSFytsZjoYhGBfurrGRgYww)
																	{
																		if (num9 == 0)
																		{
																			jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Category", "All Map Categories");
																		}
																		else
																		{
																			while (true)
																			{
																				IL_02b5:
																				int num10 = 0;
																				int num11 = 1983380602;
																				while (true)
																				{
																					object obj;
																					string text3;
																					switch (num11 ^ 0x7637FC7F)
																					{
																					case 7:
																						num11 = 1983380604;
																						continue;
																					default:
																						goto end_IL_0285;
																					case 3:
																						break;
																					case 4:
																					{
																						int num12;
																						if (num10 >= categoryIds.Length)
																						{
																							num11 = 1983380605;
																							num12 = num11;
																						}
																						else
																						{
																							num11 = 1983380601;
																							num12 = num11;
																						}
																						continue;
																					}
																					case 5:
																						num11 = 1983380603;
																						continue;
																					case 0:
																						array2[3] = ")";
																						obj = string.Concat(array2);
																						goto IL_02ef;
																					case 6:
																						mapCategory = ReInput.mapping.GetMapCategory(categoryIds[num10]);
																						if (mapCategory == null)
																						{
																							obj = "[INVALID]";
																							goto IL_02ef;
																						}
																						array2 = new object[4];
																						num11 = 1983380606;
																						continue;
																					case 1:
																						array2[0] = mapCategory.name;
																						array2[1] = " (";
																						array2[2] = mapCategory.id;
																						num11 = 1983380607;
																						continue;
																					case 2:
																						goto end_IL_0285;
																						IL_02ef:
																						text3 = (string)obj;
																						jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Category " + num10, text3);
																						num10++;
																						num11 = 1983380603;
																						continue;
																					}
																					goto IL_02b5;
																					continue;
																					end_IL_0285:
																					break;
																				}
																				break;
																			}
																		}
																	}
																}
																layout = ReInput.mapping.GetLayout(rule.controllerSetSelector.controllerType, rule.layoutId);
																jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt(rule.controllerSetSelector.controllerType.ToString() + " Layout", (layout != null) ? (layout.name + " (" + layout.id + ")") : "[INVALID]");
																goto end_IL_01dc;
															}
															goto IL_01d7;
															IL_0222:
															num7 = 1983380607;
															continue;
															end_IL_01dc:
															break;
														}
														break;
													}
												}
											}
											num5++;
											goto IL_0422;
										}
										int num13 = 1983380606;
										goto IL_0427;
										IL_0422:
										num13 = 1983380605;
										goto IL_0427;
										IL_0427:
										switch (num13 ^ 0x7637FC7F)
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
										goto IL_0422;
									}
								}
							}
							}
							break;
						}
						continue;
						IL_010a:
						jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Tag", P_0.tag);
						num4 = 1983380607;
						goto IL_00ae;
					}
				}
			}
			}
			goto IL_0003;
			IL_0021:
			num = 0;
			goto IL_002a;
		}

		private static void cuPDcrQrcTlQpwLdhxJfdpNMIpC(ControllerMapEnabler P_0, IDictionary<string, bool> P_1, string P_2)
		{
			if (GpucLgSDXqoAXrllaFKfijpJuRjJ("Enabled", P_0.enabled))
			{
				while (true)
				{
					int num = 1527712661;
					while (true)
					{
						switch (num ^ 0x5B0F0B97)
						{
						case 0:
							break;
						case 2:
							P_0.enabled = !P_0.enabled;
							num = 1527712662;
							continue;
						default:
							goto end_IL_0012;
						}
						break;
					}
					continue;
					end_IL_0012:
					break;
				}
			}
			string text = P_2 + "_ruleSets";
			int count = P_0.ruleSets.Count;
			using (uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX2 = new uexdDwgADKzvNcFbZrcqoUZBltX("Rule Sets (" + count + ")", text, P_1))
			{
				if (!uexdDwgADKzvNcFbZrcqoUZBltX2.rqXWHSFytsZjoYhGBfurrGRgYww)
				{
					return;
				}
				int num3 = default(int);
				while (true)
				{
					int num2 = 1527712662;
					while (true)
					{
						switch (num2 ^ 0x5B0F0B97)
						{
						case 2:
							break;
						default:
							return;
						case 1:
							num3 = 0;
							num2 = 1527712660;
							continue;
						case 3:
						{
							int num4;
							if (num3 >= count)
							{
								num2 = 1527712659;
								num4 = num2;
							}
							else
							{
								num2 = 1527712663;
								num4 = num2;
							}
							continue;
						}
						case 0:
							EAbBcEKwUeVremyiGmAPngwFXSO(P_0.ruleSets[num3], num3, P_1, text + num3);
							num3++;
							num2 = 1527712660;
							continue;
						case 4:
							return;
						}
						break;
					}
				}
			}
		}

		private static void EAbBcEKwUeVremyiGmAPngwFXSO(ControllerMapEnabler.RuleSet P_0, int P_1, IDictionary<string, bool> P_2, string P_3)
		{
			if (P_0 == null)
			{
				goto IL_0003;
			}
			int num = P_0.Count;
			goto IL_002a;
			IL_002a:
			int num2 = num;
			object[] array = new object[4] { P_1, ": ", null, null };
			int num3 = 126487198;
			goto IL_0008;
			IL_0003:
			num3 = 126487197;
			goto IL_0008;
			IL_0008:
			switch (num3 ^ 0x78A0A9F)
			{
			case 0:
				break;
			case 2:
				goto IL_0021;
			default:
			{
				array[2] = ((!string.IsNullOrEmpty(P_0.tag)) ? (P_0.tag + ", ") : "");
				array[3] = (P_0.enabled ? "Enabled" : "Disabled");
				using (uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX2 = new uexdDwgADKzvNcFbZrcqoUZBltX(string.Concat(array), P_3, P_2))
				{
					if (!uexdDwgADKzvNcFbZrcqoUZBltX2.rqXWHSFytsZjoYhGBfurrGRgYww)
					{
						return;
					}
					string text = default(string);
					ControllerMapEnabler.Rule rule = default(ControllerMapEnabler.Rule);
					string text2 = default(string);
					int num10 = default(int);
					object[] array2 = default(object[]);
					string text3 = default(string);
					InputMapCategory mapCategory = default(InputMapCategory);
					InputLayout layout = default(InputLayout);
					while (true)
					{
						int num4;
						int num5;
						if (GpucLgSDXqoAXrllaFKfijpJuRjJ("Enabled", P_0.enabled))
						{
							num4 = 126487197;
							num5 = num4;
						}
						else
						{
							num4 = 126487194;
							num5 = num4;
						}
						while (true)
						{
							switch (num4 ^ 0x78A0A9F)
							{
							case 0:
								num4 = 126487196;
								continue;
							case 3:
								break;
							case 4:
								text = P_3 + "_rules";
								num4 = 126487198;
								continue;
							case 5:
								jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Tag", P_0.tag);
								num4 = 126487195;
								continue;
							case 2:
								P_0.enabled = !P_0.enabled;
								num4 = 126487194;
								continue;
							default:
							{
								using (uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX3 = new uexdDwgADKzvNcFbZrcqoUZBltX("Rules (" + P_0.Count + ")", text, P_2))
								{
									if (!uexdDwgADKzvNcFbZrcqoUZBltX3.rqXWHSFytsZjoYhGBfurrGRgYww)
									{
										return;
									}
									int num6 = 0;
									while (true)
									{
										int num7 = 126487198;
										while (true)
										{
											int num17;
											switch (num7 ^ 0x78A0A9F)
											{
											case 0:
												break;
											case 3:
												goto IL_0197;
											default:
											{
												using (uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX4 = new uexdDwgADKzvNcFbZrcqoUZBltX(num6 + ": " + ((!string.IsNullOrEmpty(rule.tag)) ? rule.tag : ""), text2, P_2))
												{
													if (uexdDwgADKzvNcFbZrcqoUZBltX4.rqXWHSFytsZjoYhGBfurrGRgYww)
													{
														if (GpucLgSDXqoAXrllaFKfijpJuRjJ("Enable", rule.enable))
														{
															rule.enable = !rule.enable;
															goto IL_021e;
														}
														goto IL_0240;
													}
													goto end_IL_01ee;
													IL_0223:
													int num8;
													while (true)
													{
														switch (num8 ^ 0x78A0A9F)
														{
														case 0:
															break;
														case 3:
															goto IL_0240;
														case 1:
															jfdCPWhZtJZhPivIkHsvyHwyZgz(rule.controllerSetSelector, P_2, text2);
															num8 = 126487197;
															continue;
														default:
														{
															int[] categoryIds = rule.categoryIds;
															int num9 = ((categoryIds != null) ? categoryIds.Length : 0);
															using (uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX5 = new uexdDwgADKzvNcFbZrcqoUZBltX("Map Categories (" + num9 + ")", text2 + "_categoryIds", P_2))
															{
																if (uexdDwgADKzvNcFbZrcqoUZBltX5.rqXWHSFytsZjoYhGBfurrGRgYww)
																{
																	if (num9 == 0)
																	{
																		goto IL_02c1;
																	}
																	goto IL_0388;
																}
																goto end_IL_02ae;
																IL_0388:
																num10 = 0;
																int num11 = 126487194;
																goto IL_02c6;
																IL_02c1:
																num11 = 126487192;
																goto IL_02c6;
																IL_02c6:
																while (true)
																{
																	object obj;
																	switch (num11 ^ 0x78A0A9F)
																	{
																	case 4:
																		break;
																	default:
																		goto end_IL_02ae;
																	case 5:
																		goto IL_0302;
																	case 8:
																		goto IL_031b;
																	case 1:
																		obj = string.Concat(array2);
																		goto IL_0341;
																	case 7:
																		jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Category", "All Map Categories");
																		num11 = 126487199;
																		continue;
																	case 2:
																		jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Category " + num10, text3);
																		num11 = 126487190;
																		continue;
																	case 3:
																		goto IL_0388;
																	case 6:
																		array2[1] = " (";
																		array2[2] = mapCategory.id;
																		array2[3] = ")";
																		num11 = 126487198;
																		continue;
																	case 10:
																		obj = "[INVALID]";
																		goto IL_0341;
																	case 9:
																		num10++;
																		num11 = 126487194;
																		continue;
																	case 0:
																		goto end_IL_02ae;
																		IL_0341:
																		text3 = (string)obj;
																		num11 = 126487197;
																		continue;
																	}
																	break;
																	IL_031b:
																	mapCategory = ReInput.mapping.GetMapCategory(categoryIds[num10]);
																	if (mapCategory == null)
																	{
																		num11 = 126487189;
																		continue;
																	}
																	array2 = new object[4] { mapCategory.name, null, null, null };
																	num11 = 126487193;
																	continue;
																	IL_0302:
																	int num12;
																	if (num10 < categoryIds.Length)
																	{
																		num11 = 126487191;
																		num12 = num11;
																	}
																	else
																	{
																		num11 = 126487199;
																		num12 = num11;
																	}
																}
																goto IL_02c1;
																end_IL_02ae:;
															}
															int[] layoutIds = rule.layoutIds;
															int num13 = ((layoutIds != null) ? layoutIds.Length : 0);
															using (uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX6 = new uexdDwgADKzvNcFbZrcqoUZBltX("Layouts (" + num13 + ")", text2 + "_layoutIds", P_2))
															{
																if (uexdDwgADKzvNcFbZrcqoUZBltX6.rqXWHSFytsZjoYhGBfurrGRgYww)
																{
																	if (num13 == 0)
																	{
																		jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Layout", (rule.controllerSetSelector.type == ControllerSetSelector.Type.All) ? "All Layouts" : string.Concat("All ", rule.controllerSetSelector.controllerType, " Layouts"));
																	}
																	else
																	{
																		while (true)
																		{
																			IL_0513:
																			int num14 = 0;
																			int num15 = 126487197;
																			while (true)
																			{
																				object obj2;
																				string text4;
																				switch (num15 ^ 0x78A0A9F)
																				{
																				case 0:
																					num15 = 126487196;
																					continue;
																				default:
																					goto end_IL_04a2;
																				case 1:
																					layout = ReInput.mapping.GetLayout(rule.controllerSetSelector.controllerType, layoutIds[num14]);
																					num15 = 126487191;
																					continue;
																				case 5:
																				{
																					int num16;
																					if (num14 >= layoutIds.Length)
																					{
																						num15 = 126487195;
																						num16 = num15;
																					}
																					else
																					{
																						num15 = 126487198;
																						num16 = num15;
																					}
																					continue;
																				}
																				case 3:
																					break;
																				case 8:
																					if (layout == null)
																					{
																						num15 = 126487192;
																						continue;
																					}
																					obj2 = layout.name + " (" + layout.id + ")";
																					goto IL_056e;
																				case 7:
																					obj2 = "[INVALID]";
																					goto IL_056e;
																				case 6:
																					num14++;
																					num15 = 126487194;
																					continue;
																				case 2:
																					num15 = 126487194;
																					continue;
																				case 4:
																					goto end_IL_04a2;
																					IL_056e:
																					text4 = (string)obj2;
																					jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt(string.Concat(rule.controllerSetSelector.controllerType, " Layout ", num14.ToString()), text4);
																					num15 = 126487193;
																					continue;
																				}
																				goto IL_0513;
																				continue;
																				end_IL_04a2:
																				break;
																			}
																			break;
																		}
																	}
																}
															}
															goto end_IL_01ee;
														}
														}
														break;
													}
													goto IL_021e;
													IL_0240:
													jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Tag", rule.tag);
													num8 = 126487198;
													goto IL_0223;
													IL_021e:
													num8 = 126487196;
													goto IL_0223;
													end_IL_01ee:;
												}
												num6++;
												goto IL_05df;
											}
											case 1:
												goto IL_05fd;
												IL_05df:
												num17 = 126487198;
												goto IL_05e4;
												IL_05e4:
												switch (num17 ^ 0x78A0A9F)
												{
												case 2:
													break;
												default:
													return;
												case 1:
													goto IL_05fd;
												case 0:
													return;
												}
												goto IL_05df;
												IL_05fd:
												if (num6 < num2)
												{
													goto IL_0197;
												}
												num17 = 126487199;
												goto IL_05e4;
											}
											break;
											IL_0197:
											rule = P_0[num6];
											text2 = text + num6;
											num7 = 126487197;
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
			goto IL_0003;
			IL_0021:
			num = 0;
			goto IL_002a;
		}

		private static void jfdCPWhZtJZhPivIkHsvyHwyZgz(ControllerSetSelector P_0, IDictionary<string, bool> P_1, string P_2)
		{
			string key = P_2 + "_controllerSetSelector";
			using (uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX2 = new uexdDwgADKzvNcFbZrcqoUZBltX("Controller Set Selector", key, P_1))
			{
				if (uexdDwgADKzvNcFbZrcqoUZBltX2.rqXWHSFytsZjoYhGBfurrGRgYww)
				{
					jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Type", StringTools.AddSpacesToSentence(P_0.type.ToString(), preserveAcronyms: false));
					if (P_0.type != ControllerSetSelector.Type.All)
					{
						goto IL_004c;
					}
					goto IL_00a5;
				}
				return;
				IL_00a5:
				int num;
				int num2;
				if (P_0.type == ControllerSetSelector.Type.HardwareType)
				{
					num = -243372717;
					num2 = num;
				}
				else
				{
					num = -243372711;
					num2 = num;
				}
				goto IL_0051;
				IL_004c:
				num = -243372716;
				goto IL_0051;
				IL_0051:
				while (true)
				{
					switch (num ^ -243372719)
					{
					case 7:
						break;
					default:
						return;
					case 4:
						jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Controller Id", P_0.controllerId.ToString());
						num = -243372719;
						continue;
					case 3:
						goto IL_00a5;
					case 5:
						jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Controller Type", P_0.controllerType.ToString());
						num = -243372718;
						continue;
					case 1:
						goto IL_00e3;
					case 6:
						if (P_0.type == ControllerSetSelector.Type.PersistentControllerInstance)
						{
							jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Device Instance Guid", P_0.deviceInstanceGuid.ToString());
							num = -243372720;
							continue;
						}
						goto IL_00e3;
					case 8:
						if (P_0.type == ControllerSetSelector.Type.ControllerTemplateType)
						{
							jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Controller Template Type Guid", P_0.controllerTemplateTypeGuid.ToString());
							num = -243372713;
							continue;
						}
						goto case 6;
					case 2:
						jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Hardware Type Guid", P_0.hardwareTypeGuid.ToString());
						jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Hardware Identifier", P_0.hardwareIdentifier);
						num = -243372711;
						continue;
					case 0:
						return;
					}
					break;
					IL_00e3:
					int num3;
					if (P_0.type != ControllerSetSelector.Type.SessionControllerInstance)
					{
						num = -243372719;
						num3 = num;
					}
					else
					{
						num = -243372715;
						num3 = num;
					}
				}
				goto IL_004c;
			}
		}

		private static void jlcYuEGeDKtjbowwpeIzdibdZTu(Controller P_0, IDictionary<string, bool> P_1, string P_2)
		{
			P_2 += "_templates";
			using (uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX2 = new uexdDwgADKzvNcFbZrcqoUZBltX("Templates (" + P_0.templateCount + ")", P_2, P_1))
			{
				if (!uexdDwgADKzvNcFbZrcqoUZBltX2.rqXWHSFytsZjoYhGBfurrGRgYww)
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
						num2 = -2078217817;
						num3 = num2;
					}
					else
					{
						num2 = -2078217818;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ -2078217818)
						{
						case 2:
							num2 = -2078217817;
							continue;
						default:
							return;
						case 1:
							nukchPlWuyeTTCFPKcyrCkTyVKz(P_0.Templates[num], num, P_2, P_1);
							num++;
							num2 = -2078217819;
							continue;
						case 3:
							break;
						case 0:
							return;
						}
						break;
					}
				}
			}
		}

		private static void nukchPlWuyeTTCFPKcyrCkTyVKz(IControllerTemplate P_0, int P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 += ((P_1 >= 0) ? ("_" + P_1) : "");
			uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX2 = new uexdDwgADKzvNcFbZrcqoUZBltX(((P_1 >= 0) ? (P_1 + ": ") : "") + P_0.name, P_2, P_3);
			try
			{
				if (!uexdDwgADKzvNcFbZrcqoUZBltX2.rqXWHSFytsZjoYhGBfurrGRgYww)
				{
					return;
				}
				int num3 = default(int);
				while (true)
				{
					int num = 686382778;
					while (true)
					{
						switch (num ^ 0x28E95EB8)
						{
						case 0:
							break;
						case 2:
							goto IL_007b;
						default:
						{
							jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Class Type", P_0.GetType().ToString());
							P_2 += "_elements";
							uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX3 = new uexdDwgADKzvNcFbZrcqoUZBltX("Elements (" + P_0.elementCount + ")", P_2, P_3);
							try
							{
								if (!uexdDwgADKzvNcFbZrcqoUZBltX3.rqXWHSFytsZjoYhGBfurrGRgYww)
								{
									return;
								}
								while (true)
								{
									int num2 = 686382777;
									while (true)
									{
										switch (num2 ^ 0x28E95EB8)
										{
										case 2:
											break;
										default:
											return;
										case 1:
											num3 = 0;
											num2 = 686382779;
											continue;
										case 3:
										{
											int num4;
											if (num3 < P_0.elementCount)
											{
												num2 = 686382776;
												num4 = num2;
											}
											else
											{
												num2 = 686382780;
												num4 = num2;
											}
											continue;
										}
										case 0:
											eMkEAPvHXsvBcHRYoHcPDaGJoXQ(P_0.elements[num3], num3, P_2, P_3);
											num3++;
											num2 = 686382779;
											continue;
										case 4:
											return;
										}
										break;
									}
								}
							}
							finally
							{
								if (uexdDwgADKzvNcFbZrcqoUZBltX3 != null)
								{
									while (true)
									{
										IL_0159:
										int num5 = 686382778;
										while (true)
										{
											switch (num5 ^ 0x28E95EB8)
											{
											case 0:
												break;
											default:
												goto end_IL_015e;
											case 2:
												goto IL_0177;
											case 1:
												goto end_IL_015e;
											}
											goto IL_0159;
											IL_0177:
											((IDisposable)uexdDwgADKzvNcFbZrcqoUZBltX3).Dispose();
											num5 = 686382777;
											continue;
											end_IL_015e:
											break;
										}
										break;
									}
								}
							}
						}
						}
						break;
						IL_007b:
						jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Type GUID", P_0.typeGuid.ToString());
						num = 686382777;
					}
				}
			}
			finally
			{
				if (uexdDwgADKzvNcFbZrcqoUZBltX2 != null)
				{
					while (true)
					{
						IL_018a:
						int num6 = 686382777;
						while (true)
						{
							switch (num6 ^ 0x28E95EB8)
							{
							case 0:
								break;
							default:
								goto end_IL_018f;
							case 1:
								goto IL_01a8;
							case 2:
								goto end_IL_018f;
							}
							goto IL_018a;
							IL_01a8:
							((IDisposable)uexdDwgADKzvNcFbZrcqoUZBltX2).Dispose();
							num6 = 686382778;
							continue;
							end_IL_018f:
							break;
						}
						break;
					}
				}
			}
		}

		private static void eMkEAPvHXsvBcHRYoHcPDaGJoXQ(IControllerTemplateElement P_0, int P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 += ((P_1 >= 0) ? ("_" + P_1) : "");
			object[] array = default(object[]);
			IControllerTemplateDPad controllerTemplateDPad = default(IControllerTemplateDPad);
			IControllerTemplateStick controllerTemplateStick = default(IControllerTemplateStick);
			IControllerTemplateStick6D controllerTemplateStick6D = default(IControllerTemplateStick6D);
			IControllerTemplateHat controllerTemplateHat = default(IControllerTemplateHat);
			IControllerTemplateThrottle controllerTemplateThrottle = default(IControllerTemplateThrottle);
			IControllerTemplateButton controllerTemplateButton = default(IControllerTemplateButton);
			while (true)
			{
				int num = 1235468509;
				while (true)
				{
					switch (num ^ 0x49A3C0D9)
					{
					case 0:
						break;
					case 3:
						array[1] = P_0.descriptiveName;
						num = 1235468504;
						continue;
					case 2:
						array[0] = ((P_1 >= 0) ? ": " : "");
						num = 1235468506;
						continue;
					case 1:
						array[2] = " (id: ";
						array[3] = P_0.id;
						array[4] = ")";
						num = 1235468508;
						continue;
					case 4:
						array = new object[5];
						num = 1235468507;
						continue;
					default:
					{
						uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX2 = new uexdDwgADKzvNcFbZrcqoUZBltX(string.Concat(array), P_2, P_3);
						try
						{
							if (!uexdDwgADKzvNcFbZrcqoUZBltX2.rqXWHSFytsZjoYhGBfurrGRgYww)
							{
								return;
							}
							while (true)
							{
								int num2 = 1235468489;
								while (true)
								{
									switch (num2 ^ 0x49A3C0D9)
									{
									case 0:
										break;
									default:
										return;
									case 22:
										jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Value Prev", controllerTemplateDPad.valuePrev.ToString());
										num2 = 1235468503;
										continue;
									case 7:
										zkZOATlmmosgRVUWfLOBWehGgnud(controllerTemplateStick.horizontal, "horizontal", P_2, P_3);
										zkZOATlmmosgRVUWfLOBWehGgnud(controllerTemplateStick.vertical, "vertical", P_2, P_3);
										zkZOATlmmosgRVUWfLOBWehGgnud(controllerTemplateStick.rotation, "rotation", P_2, P_3);
										num2 = 1235468499;
										continue;
									case 6:
										jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Position Prev", controllerTemplateStick6D.positionPrev.ToString());
										jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Rotation", controllerTemplateStick6D.rotation.ToString());
										num2 = 1235468481;
										continue;
									case 15:
										if (P_0.type == ControllerTemplateElementType.Stick)
										{
											controllerTemplateStick = P_0 as IControllerTemplateStick;
											jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Value", controllerTemplateStick.value.ToString());
											num2 = 1235468487;
											continue;
										}
										goto case 18;
									case 14:
										PvhPdjhvdAmNlVdAtnrMxINwsVW(controllerTemplateDPad.up, "Up", P_2, P_3);
										num2 = 1235468480;
										continue;
									case 29:
										PvhPdjhvdAmNlVdAtnrMxINwsVW(controllerTemplateHat.downRight, "downRight", P_2, P_3);
										num2 = 1235468488;
										continue;
									case 18:
										if (P_0.type == ControllerTemplateElementType.Throttle)
										{
											controllerTemplateThrottle = P_0 as IControllerTemplateThrottle;
											jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Value", controllerTemplateThrottle.value.ToString());
											jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Value Prev", controllerTemplateThrottle.valuePrev.ToString());
											num2 = 1235468492;
											continue;
										}
										goto case 8;
									case 32:
										jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Value", controllerTemplateHat.value.ToString());
										num2 = 1235468508;
										continue;
									case 17:
										PvhPdjhvdAmNlVdAtnrMxINwsVW(controllerTemplateHat.down, "down", P_2, P_3);
										PvhPdjhvdAmNlVdAtnrMxINwsVW(controllerTemplateHat.downLeft, "downLeft", P_2, P_3);
										PvhPdjhvdAmNlVdAtnrMxINwsVW(controllerTemplateHat.left, "left", P_2, P_3);
										PvhPdjhvdAmNlVdAtnrMxINwsVW(controllerTemplateHat.upLeft, "upLeft", P_2, P_3);
										num2 = 1235468499;
										continue;
									case 23:
										if (P_0.type == ControllerTemplateElementType.Axis)
										{
											IControllerTemplateAxis controllerTemplateAxis = P_0 as IControllerTemplateAxis;
											uaqonyzYWwoUdNERZBdbQVMNPNp(controllerTemplateAxis, P_2, P_3);
											num2 = 1235468507;
											continue;
										}
										goto case 11;
									case 2:
										num2 = 1235468499;
										continue;
									case 11:
										if (P_0.type == ControllerTemplateElementType.DPad)
										{
											controllerTemplateDPad = P_0 as IControllerTemplateDPad;
											jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Value", controllerTemplateDPad.value.ToString());
											num2 = 1235468495;
											continue;
										}
										goto case 9;
									case 30:
										jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Value Prev", controllerTemplateStick.valuePrev.ToString());
										num2 = 1235468510;
										continue;
									case 19:
										PvhPdjhvdAmNlVdAtnrMxINwsVW(controllerTemplateHat.right, "right", P_2, P_3);
										num2 = 1235468484;
										continue;
									case 25:
										PvhPdjhvdAmNlVdAtnrMxINwsVW(controllerTemplateDPad.right, "Right", P_2, P_3);
										PvhPdjhvdAmNlVdAtnrMxINwsVW(controllerTemplateDPad.down, "Down", P_2, P_3);
										PvhPdjhvdAmNlVdAtnrMxINwsVW(controllerTemplateDPad.left, "Left", P_2, P_3);
										num2 = 1235468500;
										continue;
									case 16:
										jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Id", P_0.id.ToString());
										num2 = 1235468483;
										continue;
									case 1:
										if (P_0.type == ControllerTemplateElementType.Yoke)
										{
											IControllerTemplateYoke controllerTemplateYoke = P_0 as IControllerTemplateYoke;
											jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Value", controllerTemplateYoke.value.ToString());
											jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Value Prev", controllerTemplateYoke.valuePrev.ToString());
											zkZOATlmmosgRVUWfLOBWehGgnud(controllerTemplateYoke.rotation, "rotation", P_2, P_3);
											zkZOATlmmosgRVUWfLOBWehGgnud(controllerTemplateYoke.pushPull, "pushPull", P_2, P_3);
											num2 = 1235468499;
											continue;
										}
										goto case 20;
									case 20:
										if (P_0.type == ControllerTemplateElementType.Stick6D)
										{
											controllerTemplateStick6D = P_0 as IControllerTemplateStick6D;
											jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Position", controllerTemplateStick6D.position.ToString());
											num2 = 1235468511;
											continue;
										}
										goto case 27;
									case 28:
										PvhPdjhvdAmNlVdAtnrMxINwsVW(controllerTemplateHat.up, "up", P_2, P_3);
										PvhPdjhvdAmNlVdAtnrMxINwsVW(controllerTemplateHat.upRight, "upRight", P_2, P_3);
										num2 = 1235468490;
										continue;
									case 9:
										if (P_0.type == ControllerTemplateElementType.Hat)
										{
											controllerTemplateHat = P_0 as IControllerTemplateHat;
											num2 = 1235468537;
											continue;
										}
										goto case 15;
									case 31:
										jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Exists", P_0.exists.ToString());
										if (P_0.type == ControllerTemplateElementType.Button)
										{
											controllerTemplateButton = P_0 as IControllerTemplateButton;
											num2 = 1235468506;
											continue;
										}
										goto case 23;
									case 12:
										zkZOATlmmosgRVUWfLOBWehGgnud(controllerTemplateStick6D.positionY, "PositionY", P_2, P_3);
										zkZOATlmmosgRVUWfLOBWehGgnud(controllerTemplateStick6D.positionZ, "PositionZ", P_2, P_3);
										zkZOATlmmosgRVUWfLOBWehGgnud(controllerTemplateStick6D.rotationX, "RotationX", P_2, P_3);
										num2 = 1235468509;
										continue;
									case 3:
										tUXgrjJCYSVUefTwHoviNLjdIGqI(controllerTemplateButton, P_2, P_3);
										num2 = 1235468499;
										continue;
									case 21:
										zkZOATlmmosgRVUWfLOBWehGgnud(controllerTemplateThrottle.throttle, "throttle", P_2, P_3);
										PvhPdjhvdAmNlVdAtnrMxINwsVW(controllerTemplateThrottle.minDetent, "zeroDetent", P_2, P_3);
										num2 = 1235468499;
										continue;
									case 24:
										jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Rotation Prev", controllerTemplateStick6D.rotationPrev.ToString());
										zkZOATlmmosgRVUWfLOBWehGgnud(controllerTemplateStick6D.positionX, "PositionX", P_2, P_3);
										num2 = 1235468501;
										continue;
									case 26:
										jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Name", P_0.descriptiveName.ToString());
										jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Type", P_0.type.ToString());
										num2 = 1235468486;
										continue;
									case 13:
										num2 = 1235468499;
										continue;
									case 8:
										if (P_0.type == ControllerTemplateElementType.ThumbStick)
										{
											IControllerTemplateThumbStick controllerTemplateThumbStick = P_0 as IControllerTemplateThumbStick;
											jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Value", controllerTemplateThumbStick.value.ToString());
											jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Value Prev", controllerTemplateThumbStick.valuePrev.ToString());
											zkZOATlmmosgRVUWfLOBWehGgnud(controllerTemplateThumbStick.horizontal, "horizontal", P_2, P_3);
											zkZOATlmmosgRVUWfLOBWehGgnud(controllerTemplateThumbStick.vertical, "vertical", P_2, P_3);
											PvhPdjhvdAmNlVdAtnrMxINwsVW(controllerTemplateThumbStick.press, "press", P_2, P_3);
											num2 = 1235468499;
											continue;
										}
										goto case 1;
									case 4:
										zkZOATlmmosgRVUWfLOBWehGgnud(controllerTemplateStick6D.rotationY, "RotationY", P_2, P_3);
										zkZOATlmmosgRVUWfLOBWehGgnud(controllerTemplateStick6D.rotationZ, "RotationZ", P_2, P_3);
										num2 = 1235468499;
										continue;
									case 27:
										jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Unknown element type", P_0.type.ToString());
										num2 = 1235468499;
										continue;
									case 5:
										jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Value Prev", controllerTemplateHat.valuePrev.ToString());
										num2 = 1235468485;
										continue;
									case 10:
										return;
									}
									break;
								}
							}
						}
						finally
						{
							if (uexdDwgADKzvNcFbZrcqoUZBltX2 != null)
							{
								while (true)
								{
									IL_07d7:
									int num3 = 1235468504;
									while (true)
									{
										switch (num3 ^ 0x49A3C0D9)
										{
										case 0:
											break;
										default:
											goto end_IL_07dc;
										case 1:
											goto IL_07f5;
										case 2:
											goto end_IL_07dc;
										}
										goto IL_07d7;
										IL_07f5:
										((IDisposable)uexdDwgADKzvNcFbZrcqoUZBltX2).Dispose();
										num3 = 1235468507;
										continue;
										end_IL_07dc:
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

		private static void zkZOATlmmosgRVUWfLOBWehGgnud(IControllerTemplateAxis P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			using (uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX2 = new uexdDwgADKzvNcFbZrcqoUZBltX(StringTools.VariableNameToDisplayName(P_1), P_2, P_3))
			{
				if (uexdDwgADKzvNcFbZrcqoUZBltX2.rqXWHSFytsZjoYhGBfurrGRgYww)
				{
					uaqonyzYWwoUdNERZBdbQVMNPNp(P_0, P_2, P_3);
				}
			}
		}

		private static void PvhPdjhvdAmNlVdAtnrMxINwsVW(IControllerTemplateButton P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			using (uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX2 = new uexdDwgADKzvNcFbZrcqoUZBltX(StringTools.VariableNameToDisplayName(P_1), P_2, P_3))
			{
				if (!uexdDwgADKzvNcFbZrcqoUZBltX2.rqXWHSFytsZjoYhGBfurrGRgYww)
				{
					return;
				}
				while (true)
				{
					int num = 1639491313;
					while (true)
					{
						switch (num ^ 0x61B8A6F3)
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
						tUXgrjJCYSVUefTwHoviNLjdIGqI(P_0, P_2, P_3);
						num = 1639491314;
					}
				}
			}
		}

		private static void uaqonyzYWwoUdNERZBdbQVMNPNp(IControllerTemplateAxis P_0, string P_1, IDictionary<string, bool> P_2)
		{
			jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Value", P_0.value.ToString());
			jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Value Prev", P_0.valuePrev.ToString());
			yEiylFwBhZnLOajzlnjEwrnPZCe(P_0.source, "target", P_1, P_2);
		}

		private static void tUXgrjJCYSVUefTwHoviNLjdIGqI(IControllerTemplateButton P_0, string P_1, IDictionary<string, bool> P_2)
		{
			jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Value", P_0.value.ToString());
			jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Value Prev", P_0.valuePrev.ToString());
			jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Pressure", P_0.pressure.ToString());
			jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Pressure Prev", P_0.pressurePrev.ToString());
			jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Just Pressed", P_0.justPressed.ToString());
			jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Just Released", P_0.justReleased.ToString());
			KnuMlGWtniteUTUeMiSujTFUrGY(P_0.source, "target", P_1, P_2);
		}

		private static void yEiylFwBhZnLOajzlnjEwrnPZCe(IControllerTemplateAxisSource P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX2 = new uexdDwgADKzvNcFbZrcqoUZBltX("Axis Target", P_2, P_3);
			try
			{
				if (!uexdDwgADKzvNcFbZrcqoUZBltX2.rqXWHSFytsZjoYhGBfurrGRgYww)
				{
					return;
				}
				while (true)
				{
					int num = 981656604;
					while (true)
					{
						switch (num ^ 0x3A82E41F)
						{
						case 0:
							break;
						default:
							return;
						case 3:
							jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Split Axis", P_0.splitAxis.ToString());
							GRGgchkWniwfjlbJupAmHRRImveX(P_0.fullTarget, "target", P_2, P_3);
							GRGgchkWniwfjlbJupAmHRRImveX(P_0.positiveTarget, "positiveTarget", P_2, P_3);
							num = 981656606;
							continue;
						case 1:
							GRGgchkWniwfjlbJupAmHRRImveX(P_0.negativeTarget, "negativeTarget", P_2, P_3);
							num = 981656605;
							continue;
						case 2:
							return;
						}
						break;
					}
				}
			}
			finally
			{
				if (uexdDwgADKzvNcFbZrcqoUZBltX2 != null)
				{
					while (true)
					{
						IL_00a6:
						int num2 = 981656606;
						while (true)
						{
							switch (num2 ^ 0x3A82E41F)
							{
							case 0:
								break;
							default:
								goto end_IL_00ab;
							case 1:
								goto IL_00c4;
							case 2:
								goto end_IL_00ab;
							}
							goto IL_00a6;
							IL_00c4:
							((IDisposable)uexdDwgADKzvNcFbZrcqoUZBltX2).Dispose();
							num2 = 981656605;
							continue;
							end_IL_00ab:
							break;
						}
						break;
					}
				}
			}
		}

		private static void KnuMlGWtniteUTUeMiSujTFUrGY(IControllerTemplateButtonSource P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			GRGgchkWniwfjlbJupAmHRRImveX(P_0.target, "target", P_2, P_3);
		}

		private static void GRGgchkWniwfjlbJupAmHRRImveX(IControllerElementTarget P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			using (uexdDwgADKzvNcFbZrcqoUZBltX uexdDwgADKzvNcFbZrcqoUZBltX2 = new uexdDwgADKzvNcFbZrcqoUZBltX(StringTools.VariableNameToDisplayName(P_1), P_2, P_3))
			{
				if (uexdDwgADKzvNcFbZrcqoUZBltX2.rqXWHSFytsZjoYhGBfurrGRgYww)
				{
					jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Element Identifier Id", P_0.elementIdentifierId.ToString());
					jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Axis Range", P_0.axisRange.ToString());
					jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Has Target", P_0.hasTarget.ToString());
					if (P_0.hasTarget)
					{
						jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt("Target Element", P_0.descriptiveName);
					}
				}
			}
		}

		private static bool GpucLgSDXqoAXrllaFKfijpJuRjJ(string P_0, bool P_1)
		{
			jSgNthdoSksvjHKWNlIBatSmzFr.ZBzYVsVZdstlQlxloHIwZNQsQmt(P_0, P_1.ToString());
			return false;
		}

		private static GUIStyle KUWYwnBWkUdLKblcrHIKcohjHcuz()
		{
			GUIStyle gUIStyle = new GUIStyle(GUI.skin.label);
			gUIStyle.margin.top = 1;
			while (true)
			{
				int num = 74451681;
				while (true)
				{
					switch (num ^ 0x4700AE2)
					{
					case 2:
						break;
					case 3:
						gUIStyle.margin.bottom = 1;
						num = 74451682;
						continue;
					case 0:
						gUIStyle.fontSize = ilVQEiENSgAnwgRreWwIUWTqyneQ._fontSize;
						num = 74451683;
						continue;
					default:
						return DmqEXcbPAkDqqbsKoRVHRQszEXcM(gUIStyle);
					}
					break;
				}
			}
		}

		public static GUIStyle GetToggleStyle()
		{
			GUIStyle gUIStyle = new GUIStyle(GUI.skin.toggle);
			gUIStyle.margin.top = 0;
			gUIStyle.margin.bottom = 0;
			gUIStyle = DmqEXcbPAkDqqbsKoRVHRQszEXcM(gUIStyle);
			gUIStyle.fontSize = ilVQEiENSgAnwgRreWwIUWTqyneQ._fontSize;
			return gUIStyle;
		}

		private static GUIStyle DmqEXcbPAkDqqbsKoRVHRQszEXcM(GUIStyle P_0)
		{
			P_0 = new GUIStyle(P_0);
			P_0.margin.left = ofaHbsbJsIXmhcEcORnYUSfCXWZ.indentLevel * 20;
			return P_0;
		}

		[CompilerGenerated]
		private static int eiMrYpkCjrvCkFLqyPNqfRqNdVg(InputAction P_0, InputAction P_1)
		{
			return P_0.name.CompareTo(P_1.name);
		}
	}
}
